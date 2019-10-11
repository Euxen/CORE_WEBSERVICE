
using System;
using System.Linq;

namespace ConsumirDummy
{
    [Serializable]
    public class ResponseToTransferToAccountsOfSameClient : Response
    {
        private string identifier;
        private string account_name1;
        private string account_name2;
        private decimal balance;
        private static string description;

        public string Identifier { get => identifier; set => identifier = value; }

        public string Account_Name1 { get => account_name1; set => account_name1 = value; }

        public string Account_Name2 { get => account_name2; set => account_name2 = value; }

        public decimal Balance { get => balance; set => balance = value; }

        public ResponseToTransferToAccountsOfSameClient()
        {

        }

        public ResponseToTransferToAccountsOfSameClient(bool success, string identifier, string account1,
            string account2, decimal balance)
        {
            Identifier = identifier;
            Account_Name1 = account1;
            Account_Name2 = account2;
            Success = success;
            Balance = balance;
            Message = null;

            switch (Success)
            {
                case true:
                    {
                        Message = $"La transferencia de {Identifier} a a las cuentas {Account_Name1} y {Account_Name2} " +
                            $"fue realizada satisfactoriamente con un valor de ${Balance}.";
                    }
                    break;

                case false:
                    {
                        Message = $"La transferencia solicitada por el usuario con cédula {Identifier} fracasó";
                    }
                    break;
            }
        }

        public ResponseToTransferToAccountsOfSameClient(char underflow)
        {
            switch (underflow)
            {
                case 'Y':
                case 'y':
                    {
                        Success = false;
                        Message = "No se puede realizar transacciones porque la cuenta presenta sobregiro.";
                    }
                    break;

                case 'N':
                case 'n':
                    {
                        Success = false;
                        Message = "No se puede realizar transacciones porque el balance solicitado es mayor al balance presente en la cuenta.";
                    }
                    break;
            }
        }

        public ResponseToTransferToAccountsOfSameClient(bool transfer_complete, decimal balance)
        {
            Success = transfer_complete;
            Message = null;
            Balance = balance;

            switch (Success)
            {
                case false:
                    {
                        Message = $"No se pudo procesar la solicitud de transferencia porque el cliente o la cuenta no existe " +
                            $"o porque la cuenta no tiene balance: ${Balance}.";
                    }
                    break;
            }
        }

        public static ResponseToTransferToAccountsOfSameClient TransferToSameClientResponse(RequestTransferToAccountsOfSameClient requestSameTransfer)
        {
            if (requestSameTransfer.Pin.ToUpper().Length > 8) requestSameTransfer.Pin = requestSameTransfer.Pin.ToUpper().Substring(0, 7);

            ResponseToTransferToAccountsOfSameClient responseSameTransfer = null;
            decimal balanceVerifier = 0;
            CoreProyectoDBEntities entities = new CoreProyectoDBEntities();
            var account_table = entities.accountTables.ToList();
            bool correctPin = Response.IsThePinCorrect(new Request(requestSameTransfer.Identifier.ToUpper(), requestSameTransfer.Pin.ToUpper()));

            try
            {
                foreach (var element in account_table)
                {
                    if (requestSameTransfer.Main_Account.ToUpper() == element.ACCOUNT_NAME &&
                        requestSameTransfer.Identifier.ToUpper() == element.IDENTIFIER)
                    {
                        balanceVerifier = element.BALANCE;
                    }
                }

                if (balanceVerifier < 0) return responseSameTransfer = new ResponseToTransferToAccountsOfSameClient('Y');
                if (balanceVerifier == 0) return responseSameTransfer = new ResponseToTransferToAccountsOfSameClient(false, balanceVerifier);
                if (balanceVerifier < requestSameTransfer.Balance_To_Transfer) return responseSameTransfer = new ResponseToTransferToAccountsOfSameClient('N');

                foreach (var element in account_table)
                {
                    if (requestSameTransfer.Secondary_Account.ToUpper() == element.ACCOUNT_NAME &&
                        requestSameTransfer.Identifier.ToUpper() == element.IDENTIFIER)
                    {
                        description = TransactionTypes.Transfer(requestSameTransfer.Identifier.ToUpper(), requestSameTransfer.Identifier.ToUpper(), 
                            requestSameTransfer.Main_Account.ToUpper(),
                            requestSameTransfer.Secondary_Account.ToUpper(), requestSameTransfer.Balance_To_Transfer, false);

                        entities.bankTransfer(requestSameTransfer.Balance_To_Transfer, requestSameTransfer.Identifier.ToUpper(), requestSameTransfer.Main_Account.ToUpper(),
                            requestSameTransfer.Identifier.ToUpper(), requestSameTransfer.Secondary_Account.ToUpper(), description);

                        responseSameTransfer = new ResponseToTransferToAccountsOfSameClient(true, requestSameTransfer.Identifier.ToUpper(), 
                            requestSameTransfer.Main_Account.ToUpper(), requestSameTransfer.Secondary_Account.ToUpper(),
                            requestSameTransfer.Balance_To_Transfer);
                        break;
                    }
                }
            }
            

            catch (Exception ex)
            {
                
                responseSameTransfer = new ResponseToTransferToAccountsOfSameClient(false, decimal.MinusOne);
            }

            finally
            {
                GC.Collect(); entities.SaveChanges();
            }

            
            return responseSameTransfer;
        }
    }
}