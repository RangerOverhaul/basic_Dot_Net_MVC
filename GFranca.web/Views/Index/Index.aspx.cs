using System;

using System.Data;

namespace GFranca.web.Views.Index
{
    public partial class Index1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                try
                {
                    Controllers.IndexController objTecnicosController = new Controllers.IndexController();

                    DataSet rsConsulta = objTecnicosController.getTecnicosController();

                    if (rsConsulta.Tables[0].Rows.Count > 0)
                        dataTable.DataSource = rsConsulta;
                    else dataTable.DataSource = null;

                    dataTable.DataBind();
                }
                catch (Exception ex){ 
                    ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "<script> swal('Error!', '" + ex.Message + "!', 'error')</script>");
                }

            }
        }

        protected void dataTable_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            try
            {
                int inIndice = Convert.ToInt32(e.CommandArgument);

                if(e.CommandName.Equals("Editar"))
                {

                    Logic.Models.clsTecnico webTecObject = new Logic.Models.clsTecnico
                    {
                        codigo = dataTable.Rows[inIndice].Cells[0].Text,
                        nombre = dataTable.Rows[inIndice].Cells[1].Text,
                        salario_b = Convert.ToInt32(dataTable.Rows[inIndice].Cells[2].Text),
                        sucursal = dataTable.Rows[inIndice].Cells[3].Text
                    };

                    Session["Data"] = webTecObject;

                    Response.Redirect("~/Views/Register/Register.aspx");

                }else if (e.CommandName.Equals("Eliminar"))
                {
                    string codigo = dataTable.Rows[inIndice].Cells[0].Text;

                    Logic.BL.clsTecnico objTecnicoController = new Logic.BL.clsTecnico();
                    Logic.Models.clsTecnico objTecnico = new Logic.Models.clsTecnico();
                    objTecnico.codigo = codigo;

                    Logic.BL.clsElemen_Tec objEleTecController = new Logic.BL.clsElemen_Tec();
                    Logic.Models.clsElemen_Tec objEleTec = new Logic.Models.clsElemen_Tec();
                    objEleTec.tecnico_id = codigo;

                    objEleTecController.eliminarElemenTec(objEleTec);
                    objTecnicoController.eliminarTecnico(objTecnico);
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "<script> swal('Error!', '" + ex.Message + "!', 'error')</script>");
            }
        }
    }
}