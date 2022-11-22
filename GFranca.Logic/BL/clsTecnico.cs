using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace GFranca.Logic.BL
{
    public class clsTecnico
    {
        SqlConnection DBConnection = null;
        SqlCommand DBCommand = null;
        SqlDataAdapter DBDataAdapter = null;
       
        string connectionString = string.Empty;

        public clsTecnico()
        {
            clsConexion Connection = new clsConexion();

            connectionString = Connection.getConexion();
        }

        static async Task<int> AsyncTransaction(SqlConnection conn, SqlCommand cmd)
        {
            await conn.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
            return 1;
        }

        public DataSet getTecnicos() // Select all
        {
            try
            {
                DataSet rsConsulta = new DataSet();

                DBConnection = new SqlConnection(connectionString);
                DBConnection.Open();

                DBCommand = new SqlCommand("sp_select_all_tec", DBConnection);
                DBCommand.CommandType = CommandType.StoredProcedure;

                DBCommand.ExecuteNonQuery();

                DBDataAdapter = new SqlDataAdapter(DBCommand);
                DBDataAdapter.Fill(rsConsulta);

                return rsConsulta;                           
            }
            catch (Exception ex) { throw ex; }
            finally { DBConnection.Close(); }
        }

        public void insertarTecnico(Models.clsTecnico objTecnico)  // Insert
        {
            try
            {
                DBConnection = new SqlConnection(connectionString);

                DBCommand = new SqlCommand("sp_insert_tec", DBConnection);
                DBCommand.CommandType = CommandType.StoredProcedure;

                DBCommand.Parameters.Add(new SqlParameter("@nombretec", objTecnico.nombre));
                DBCommand.Parameters.Add(new SqlParameter("@codigotec", objTecnico.codigo));
                DBCommand.Parameters.Add(new SqlParameter("@sbasetec", objTecnico.salario_b));
                DBCommand.Parameters.Add(new SqlParameter("@sucursaltec", objTecnico.sucursal));

                int result = AsyncTransaction(DBConnection, DBCommand).Result;

            }
            catch (Exception ex) { throw ex; }
            finally { DBConnection.Close(); }
        }

        public void actualizarTecnico(Models.clsTecnico objTecnico)  // Update
        {
            try
            {
                DBConnection = new SqlConnection(connectionString);

                DBCommand = new SqlCommand("sp_update_tec", DBConnection);
                DBCommand.CommandType = CommandType.StoredProcedure;
                
                DBCommand.Parameters.Add(new SqlParameter("@codigotec", objTecnico.codigo));

                int result = AsyncTransaction(DBConnection, DBCommand).Result;
            }
            catch (Exception ex) { throw ex; }
            finally { DBConnection.Close(); }
        }

        public void eliminarTecnico(Models.clsTecnico objTecnico)  // Delete
        {
            try
            {
                DBConnection = new SqlConnection(connectionString);

                DBCommand = new SqlCommand("sp_delete_tec", DBConnection);
                DBCommand.CommandType = CommandType.StoredProcedure;

                DBCommand.Parameters.Add(new SqlParameter("@codigotec", objTecnico.codigo));

                int result = AsyncTransaction(DBConnection, DBCommand).Result;
            }
            catch (Exception ex) { throw ex; }
            finally { DBConnection.Close(); }
        }
        public DataSet buscarTecnico(Models.clsTecnico objTecnico) // Select One
        {
            try
            {
                DataSet rsConsulta = new DataSet();

                DBConnection = new SqlConnection(connectionString);
                DBConnection.Open();

                DBCommand = new SqlCommand("sp_select_one_tec", DBConnection);
                DBCommand.CommandType = CommandType.StoredProcedure;

                DBCommand.Parameters.Add(new SqlParameter("@codigotec", objTecnico.codigo));

                DBCommand.ExecuteNonQuery();

                DBDataAdapter = new SqlDataAdapter(DBCommand);
                DBDataAdapter.Fill(rsConsulta);

                return rsConsulta;
            }
            catch (Exception ex) { throw ex; }
            finally { DBConnection.Close(); }
        }
    }
}
