
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumirDummy
{
    public class ResponseAccountRegister : Response
    {
        #region Atributes and Constructors
        public ResponseAccountRegister()
        {

        }

        public ResponseAccountRegister(bool success, string identifier)
        {
            Success = success;
            Message = null;

            switch (Success)
            {
                case true:
                    {
                        Message = $"La cuenta del cliente asociado al identificador {identifier} se ha registrado exitosamente.";
                    }
                    break;

                case false:
                    {
                        Message = "No se pudo registrar la cuenta del cliente asociada.";
                    }
                    break;

                default:
                    {
                        throw new Exception("Success is a boolean, and can only be either true or false.");
                    }
                    break;
            }
        }
        #endregion

        public static ResponseAccountRegister ResponseToAccountRegister(RequestAccountRegister accountToRegister)
        {
            ResponseAccountRegister responseAccount;
            CoreProyectoDBEntities entities = new CoreProyectoDBEntities();

            try
            {
                switch (accountToRegister.Account_Type)
                {
                    case "EMPRESARIAL": accountToRegister.Account_Type = AccountTypes.EMPRESARIAL.ToString(); break;
                    case "AHORRO": accountToRegister.Account_Type = AccountTypes.AHORRO.ToString(); break;
                    case "CORRIENTE": accountToRegister.Account_Type = AccountTypes.CORRIENTE.ToString(); break;
                    default: accountToRegister.Account_Type = AccountTypes.OTRO.ToString(); break;
                }

                entities.accountRegister(accountToRegister.Identifier, 
                    accountToRegister.Account_Name, accountToRegister.Account_Type);

                responseAccount = new ResponseAccountRegister(true, accountToRegister.Identifier);
            }


            catch (Exception ex)
            {
                responseAccount = new ResponseAccountRegister(false, accountToRegister.Identifier);
            }

            finally
            {
                GC.Collect(); entities.SaveChanges();
            }

            return responseAccount;
        }
    }
}