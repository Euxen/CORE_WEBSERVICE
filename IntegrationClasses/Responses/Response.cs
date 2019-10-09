﻿using Integration.Code;
using Integration.Requests;
using log4net;
using System;
using System.Linq;

namespace Integration.Responses
{
    public class Response
    {
        #region Master Atributes and Constructors
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private bool success;
        private string message; 

        public static ILog Log => log;

        public bool Success { get => success; set => success = value; }

        public string Message { get => message; set => message = value; }
        #endregion

        //Do not touch.
        public static bool IsThePinCorrect(Request request)
        {
            var clientTable = Entities.Integration.clientTables.ToList();
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

            catch (Exception ex)
            {
                Log.Error("Ocurrió un error al ejecutar el metodo 'IsThePinCorrect',", ex);
                throw new Exception("Not handled connection!");
            }

            finally
            {
                GC.Collect(); Entities.Integration.SaveChanges();
            }

            Log.Info("El metodo 'IsThePinCorrect' se ha ejecutado exitosamente.");
            return correctPin;
        }
    }
}