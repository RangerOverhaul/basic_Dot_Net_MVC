using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace GFranca.Logic.BL
{
    public class clsElemen_Tec
    {
        SqlConnection DBConnection = null;
        SqlCommand DBCommand = null;
        SqlDataAdapter DBDataAdapter = null;

        string connectionString = string.Empty;

        public clsElemen_Tec()
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

        public void insertarElemenTec(Models.clsElemen_Tec objElemenTec)  // Insert
        {
            try
            {
                DBConnection = new SqlConnection(connectionString);
                
                DBCommand = new SqlCommand("sp_insert_ele_tec", DBConnection);
                DBCommand.CommandType = CommandType.StoredProcedure;

                DBCommand.Parameters.Add(new SqlParameter("@codigotec", objElemenTec.tecnico_id));
                DBCommand.Parameters.Add(new SqlParameter("@codigoele", objElemenTec.elemento_id));
                DBCommand.Parameters.Add(new SqlParameter("@cantidad", objElemenTec.cantidad));

                int result = AsyncTransaction(DBConnection, DBCommand).Result;
            }
            catch (Exception ex) { throw ex; }
            finally { DBConnection.Close(); }
        }

        public void actualizarElemenTec(Models.clsElemen_Tec objElemenTec)  // Update
        {
            try
            {
                DBConnection = new SqlConnection(connectionString);

                DBCommand = new SqlCommand("sp_update_ele_tec", DBConnection);
                DBCommand.CommandType = CommandType.StoredProcedure;

                DBCommand.Parameters.Add(new SqlParameter("@codigotec", objElemenTec.tecnico_id));
                DBCommand.Parameters.Add(new SqlParameter("@codigoele", objElemenTec.elemento_id));
                DBCommand.Parameters.Add(new SqlParameter("@cantidad", objElemenTec.cantidad));
               
                int result = AsyncTransaction(DBConnection, DBCommand).Result;
            }
            catch (Exception ex) { throw ex; }
            finally { DBConnection.Close(); }
        }

        public void eliminarElemenTec(Models.clsElemen_Tec objElemenTec)  // Delete
        {
            try
            {
                DBConnection = new SqlConnection(connectionString);

                DBCommand = new SqlCommand("sp_delete_ele_tec", DBConnection);
                DBCommand.CommandType = CommandType.StoredProcedure;

                DBCommand.Parameters.Add(new SqlParameter("@codigotec", objElemenTec.tecnico_id));

                int result = AsyncTransaction(DBConnection, DBCommand).Result;
            }
            catch (Exception ex) { throw ex; }
            finally { DBConnection.Close(); }
        }

        public DataSet buscarTecConElement(Models.clsElemen_Tec objElemenTec)  // Select
        {
            try
            {
                DataSet rsConsulta = new DataSet();

                DBConnection = new SqlConnection(connectionString);
                DBConnection.Open();

                DBCommand = new SqlCommand("sp_select_one_ele_tec", DBConnection);
                DBCommand.CommandType = CommandType.StoredProcedure;

                DBCommand.Parameters.Add(new SqlParameter("@codigoele", objElemenTec.elemento_id));

                DBCommand.ExecuteNonQuery();

                DBDataAdapter = new SqlDataAdapter(DBCommand);
                DBDataAdapter.Fill(rsConsulta);

                return rsConsulta;
            }
            catch (Exception ex) { throw ex; }
            finally { DBConnection.Close(); }
        }

        public DataSet buscarElementosFree()  // Listado de elementos disponibles
        {
            try
            {
                DataSet rsConsulta = new DataSet();

                DBConnection = new SqlConnection(connectionString);
                DBConnection.Open();

                DBCommand = new SqlCommand("sp_free_elements", DBConnection);
                DBCommand.CommandType = CommandType.StoredProcedure;         

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
