using ConsumirDummy;
using System;
using System.Linq;

namespace ConsumirDummy
{
    public class Response
    {
        #region Master Atributes and Constructors
        private bool success;
        private string message; 


        public bool Success { get => success; set => success = value; }

        public string Message { get => message; set => message = value; }
        #endregion

        //Do not touch.
        public static bool IsThePinCorrect(Request request)
        {
            CoreProyectoDBEntities entities = new CoreProyectoDBEntities();
            var clientTable = entities.clientTables.ToList();
            bool correctPin = false;

            try
            {
                foreach (var element in clientTable)
                {
                    if (request.Identifier == element.IDENTIFIER && 
                        request.Pin == element.PIN)
                    {
                        correctPin = true;
                        break;
                    }

                    else
                    {
                        continue;
                    }
                }
            }

            catch
            {
                throw new Exception("Not handled connection!");
            }

            finally
            {
                GC.Collect(); entities.SaveChanges();
            }

            return correctPin;
        }
    }
}