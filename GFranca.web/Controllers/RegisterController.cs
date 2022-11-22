using System;
using System.Data;

namespace GFranca.web.Controllers
{
    public class RegisterController
    {
        public void insertElemenTecController(Logic.Models.clsElemen_Tec objElemenTecModel)
        {
            try
            {
                Logic.BL.clsElemen_Tec objElemenTec = new Logic.BL.clsElemen_Tec();

                objElemenTec.insertarElemenTec(objElemenTecModel);
            }
            catch (Exception ex) { throw ex; }
        }
        public void updateElemenTecController(Logic.Models.clsElemen_Tec objElemenTecModel)
        {
            try
            {
                Logic.BL.clsElemen_Tec objElemenTec = new Logic.BL.clsElemen_Tec();

                objElemenTec.actualizarElemenTec(objElemenTecModel);
            }
            catch (Exception ex) { throw ex; }
        }
        public void deleteElemenTecController(Logic.Models.clsElemen_Tec objElemenTecModel)
        {
            try
            {
                Logic.BL.clsElemen_Tec objElemenTec = new Logic.BL.clsElemen_Tec();

               objElemenTec.eliminarElemenTec(objElemenTecModel);
            }
            catch (Exception ex) { throw ex; }
        }
        public DataSet getElemenTecController(Logic.Models.clsElemen_Tec objElemenTecModel)
        {
            try
            {
                Logic.BL.clsElemen_Tec objElemenTec = new Logic.BL.clsElemen_Tec();

                return objElemenTec.buscarTecConElement(objElemenTecModel);
            }
            catch (Exception ex) { throw ex; }
        }

        public DataSet getFreeElementsController()
        {
            try
            {
                Logic.BL.clsElemen_Tec objElemenTc = new Logic.BL.clsElemen_Tec();

                return objElemenTc.buscarElementosFree();
            }
            catch (Exception ex) { throw ex; }
        }

    }
}