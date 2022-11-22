using System;
using System.Data;

namespace GFranca.web.Controllers
{
    public class IndexController
    {
        public DataSet getTecnicosController()
        { 
            try
            {
                Logic.BL.clsTecnico objTecnico = new Logic.BL.clsTecnico();

                return objTecnico.getTecnicos();
            }
            catch (Exception ex){throw ex;}
        }
        
        public DataSet getOneTecnicosController(Logic.Models.clsTecnico objTecnicoModel)
        {
            try
            {
                Logic.BL.clsTecnico objTecnico = new Logic.BL.clsTecnico();

                return objTecnico.buscarTecnico(objTecnicoModel);
            }
            catch (Exception ex) { throw ex; }
        }

        public void insertTecnicosController(Logic.Models.clsTecnico objTecnicoModel)
        {
            try
            {
                Logic.BL.clsTecnico objTecnico = new Logic.BL.clsTecnico();

                objTecnico.insertarTecnico(objTecnicoModel);

            }
            catch (Exception ex) { throw ex; }
        }
        public void updateTecnicosController(Logic.Models.clsTecnico objTecnicoModel)
        {
            try
            {
                Logic.BL.clsTecnico objTecnico = new Logic.BL.clsTecnico();

                objTecnico.actualizarTecnico(objTecnicoModel);

            }
            catch (Exception ex) { throw ex; }
        }

        public void deleteTecnicosController(Logic.Models.clsTecnico objTecnicoModel)
        {
            try
            {
                Logic.BL.clsTecnico objTecnico = new Logic.BL.clsTecnico();

                objTecnico.eliminarTecnico(objTecnicoModel);

            }
            catch (Exception ex) { throw ex; }
        }
    }
}