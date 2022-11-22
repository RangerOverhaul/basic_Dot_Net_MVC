using System;
using System.Web.Script.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Web.UI.HtmlControls;
using System.Data;

namespace GFranca.web.Views.Register
{
    public partial class Register : System.Web.UI.Page
    {
        static int cantidad_elementos;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if(Session["Data"] != null)
                {
                    Logic.Models.clsTecnico editTecnico= (Logic.Models.clsTecnico)Session["Data"];
                    nombre.Text = editTecnico.nombre;
                    codigo.Text = editTecnico.codigo;
                    sucursal.Text = editTecnico.sucursal;
                    s_base.Text = Convert.ToString(editTecnico.salario_b);
                }
                try
                {
                    Controllers.RegisterController objElmentTec = new Controllers.RegisterController();

                    DataSet rsConsulta = objElmentTec.getFreeElementsController();

                    if (rsConsulta.Tables[0].Rows.Count > 0)
                        ElementDataTable.DataSource = rsConsulta;
                    else ElementDataTable.DataSource = null;

                    ElementDataTable.DataBind();
                }
                catch (Exception ex)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "<script> swal('Error!', '" + ex.Message + "!', 'error')</script>");
                }
            }
        }

        protected void guardar_Click(object sender, EventArgs e)
        {
            try
            {
                string strMensaje = string.Empty;

                if (string.IsNullOrEmpty(nombre.Text)) strMensaje += " debe ingresar un nombre,";
                if (string.IsNullOrEmpty(codigo.Text)) strMensaje += " debe ingresar un codigo,";
                if (string.IsNullOrEmpty(sucursal.Text)) strMensaje += " debe ingresar una sucursal,";
                if (string.IsNullOrEmpty(s_base.Text)) strMensaje += " debe ingresar un salario,";

                if(!Regex.Match(codigo.Text, "^(?=.*[a-zA-Z])(?=.*[0-9])[A-Za-z0-9]+$").Success)
                    strMensaje += "El codigo de los tecnicos solo puede contener caracteres alfanumericos,";

                if (string.IsNullOrEmpty(cantidaEle.Text))
                    throw new Exception("Debe ingresar la cantidad de elementos que desea añadir!");

                if (!Regex.Match(cantidaEle.Text, "^[0-9]").Success)
                    throw new Exception("La cantidad de elementos debe ser un valor numerico!");

                if (Convert.ToInt32(cantidaEle.Text) < 0)
                    throw new Exception("Debe tener al menos un 1 elemento, no se admiten valores negativos!");

                if (cantidad_elementos <= 0)
                    throw new Exception("Debe tener al menos un 1 elemento, no se admiten valores negativos!");

                string[] id_elementos = new string[cantidad_elementos];
                int[] cd_elementos = new int[cantidad_elementos];

                for (int y=1; y<=cantidad_elementos; y++)
                {
                    string elemento_id = "id_element" + y.ToString();
                    string cantidad_id = "cantidad_element" + y.ToString();

                    string elemento = Request[elemento_id];
                    string cantidad = Request[cantidad_id];

                    int cant;

                    if (!String.IsNullOrEmpty(cantidad) && int.TryParse(cantidad, out cant))
                    {
                        id_elementos[y-1] = string.Copy(elemento);
                        cd_elementos[y - 1] = cant;
                    }
                    else
                    {
                        throw new Exception("No se pudo obtener valores de cantidad de elemento "+ elemento + ", asegurese que este valor sea numerico.");
                    }
                }

                if (id_elementos.Length != id_elementos.Distinct().Count())
                    strMensaje += "No se puede agregar un elemento mas de una vez al mismo tecnico,";

                foreach (var item in id_elementos)
                {
                    if (!Regex.Match(item, "^(?=.*[a-zA-Z])(?=.*[0-9])[A-Za-z0-9]+$").Success)
                        strMensaje += "El codigo de " + item + " solo debe contener caracteres alfanumericos,";
                }

                foreach (var can in cd_elementos)
                {
                    if (can > 10 || can < 1)
                        strMensaje += can.ToString() +" no es un valor valido, la cantidad de elementos debe ser un numero entre 1 y 10,";
                }

                if (!string.IsNullOrEmpty(strMensaje)) throw new Exception(strMensaje.TrimEnd(','));

                Logic.Models.clsTecnico webObjTecnico = new Logic.Models.clsTecnico
                {
                    codigo = codigo.Text,
                    nombre = nombre.Text,
                    salario_b = Convert.ToInt32(s_base.Text),
                    sucursal = sucursal.Text
                };

                Logic.Models.clsElemen_Tec webObjElemenTec = new Logic.Models.clsElemen_Tec();
                webObjElemenTec.tecnico_id = codigo.Text;

                Controllers.IndexController objTecController = new Controllers.IndexController();
                Controllers.RegisterController objEleTecController = new Controllers.RegisterController();

                objTecController.insertTecnicosController(webObjTecnico);
                
                for(int x=0; x < cantidad_elementos; x++)
                {
                    webObjElemenTec.elemento_id = id_elementos[x];
                    webObjElemenTec.cantidad = cd_elementos[x];
                    objEleTecController.insertElemenTecController(webObjElemenTec);
                }
                 

                ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "<script> swal('Info', '"+ webObjTecnico.nombre + " guardado! ', 'success')</script>");
            }
            catch (Exception ex)
            {
                
                ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "<script> swal('Error de validacion!', '" + ex.Message + "', 'error')</script>");
            }                                                                   
        }

        //ver si con el el changed texte agregado como propiedad puedo guardar en listas estaticas los datos
        
        protected void addButton_Click(object sender, EventArgs e)
        {
            int iCnt = 0;
            try
            {
                if (string.IsNullOrEmpty(cantidaEle.Text))
                    throw new Exception("Debe ingresar la cantidad de elemetos que desea añadir!");

                if (!Regex.Match(cantidaEle.Text, "^[0-9]").Success)
                    throw new Exception("Por favor ingrese un numero!");

                if (Convert.ToInt32(cantidaEle.Text) < 0)
                    throw new Exception("Debe tener al menos un 1 elemento, no se admiten valores negativos!");
               
                for (int i = 0; i < Convert.ToInt32(cantidaEle.Text); i++)
                {
                    if (iCnt >= 0)
                    {
                        HtmlGenericControl ul = new HtmlGenericControl("ul");
                        HtmlGenericControl ul2 = new HtmlGenericControl("ul");

                        ul.Attributes.Add("style", "margin:2px 0;padding:0;");
                        ul2.Attributes.Add("style", "margin:2px 0;padding:0;");


                        HtmlGenericControl liCol = new HtmlGenericControl("li");
                        HtmlGenericControl liCol2 = new HtmlGenericControl("li");

                        HtmlGenericControl spanCol = new HtmlGenericControl("span");
                        HtmlGenericControl spanCol2 = new HtmlGenericControl("span");


                        spanCol.InnerHtml = "Element " + (i + 1).ToString();
                        spanCol2.InnerHtml = "Cantidad #" + (i + 1).ToString();


                        liCol.Attributes.Add("style", "width:30%;float:left;");
                        liCol2.Attributes.Add("style", "width:30%;float:left;");

                        liCol.Controls.Add(spanCol);
                        liCol2.Controls.Add(spanCol2);


                        // CREATE AN INSTANCE OF TEXTBOX.
                        // WITH EVERY COLUMN NAME, WE'LL CREATE AND ADD A TEXTBOX.
                        TextBox txt = new TextBox();
                        TextBox txt2 = new TextBox();

                        txt.ID = "id_element" + (i+1).ToString();
                        txt2.ID = "cantidad_element" + (i+1).ToString();

                        // ASSIGN A CLASS. WE'LL USE THE CLASS NAME TO EXTRACT DATA USING JQUERY.
                        txt.CssClass = "form-control form-control-user";
                        txt2.CssClass = "form-control form-control-user";

                        HtmlGenericControl liTxt = new HtmlGenericControl("li");
                        HtmlGenericControl liTxt2 = new HtmlGenericControl("li");

                        liTxt.Attributes.Add("style", "width:auto;");
                        liTxt2.Attributes.Add("style", "width:auto;");

                        liTxt.Controls.Add(txt);    // ADD THE NEWLY CREATED TEXTBOX TO A LIST.
                        liTxt2.Controls.Add(txt2);    // ADD THE NEWLY CREATED TEXTBOX TO A LIST.

                        ul.Controls.Add(liCol);
                        ul2.Controls.Add(liCol2);

                        ul.Controls.Add(liTxt);
                        ul2.Controls.Add(liTxt2);

                        columns.Controls.Add(ul);
                        columns.Controls.Add(ul2);
                    }
                    iCnt = iCnt + 1;
                }
                       
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "<script> swal('Error!', '" + ex.Message + "!', 'error')</script>");
            }
            finally
            {
                cantidad_elementos = iCnt;
            }
        }

       
    }
}