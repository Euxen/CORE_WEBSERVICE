using System;

namespace ConsumirDummy
{
    [Serializable]
    public class RequestTransferToAccountsOfSameClient : Request
    {
        #region Atributes and Construtors
        private string main_Account;
        private string secondary_Account;
        private decimal balance_To_Transfer;

        public string Main_Account { get => main_Account; set => main_Account = value; }

        public string Secondary_Account { get => secondary_Account; set => secondary_Account = value; }

        public decimal Balance_To_Transfer { get => balance_To_Transfer; set => balance_To_Transfer = value; }

        public RequestTransferToAccountsOfSameClient()
        {

        }

        public RequestTransferToAccountsOfSameClient(string identifier, string main_account, string secondary_account,
            decimal balance, string pin)
        {
            Identifier = identifier;
            Main_Account = main_account;
            Secondary_Account = secondary_account;
            Balance_To_Transfer = balance;
            Pin = pin;
        }
        #endregion
    }
}
