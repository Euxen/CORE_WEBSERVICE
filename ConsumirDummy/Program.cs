using ConsumirDummy.COREServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumirDummy
{
    class Program
    {
        static void Main(string[] args)
        {
            
            COREServices.WebMainMenuSoapClient webMainMenu = new COREServices.WebMainMenuSoapClient();

            COREServices.RequestClientRegister requestClientRegister = new COREServices.RequestClientRegister();
            requestClientRegister.AutoGenerate = true;
            requestClientRegister.Direction_Regs = "direction";
            requestClientRegister.Email_Regs = "wsd@email";
            requestClientRegister.Identifier = "12345678";
            requestClientRegister.Lastname_Regs = "Doe";
            requestClientRegister.Name_Regs = "John";
            requestClientRegister.Password_Regs = "1234";
            requestClientRegister.Pin_Regs = "";

            COREServices.ResponseClientRegister responseClientRegister = new COREServices.ResponseClientRegister();

            responseClientRegister = webMainMenu.ClientRegister(requestClientRegister);

            Console.WriteLine(responseClientRegister.Message);
            Console.ReadKey();


            COREServices.RequestAccountRegister requestAccountRegister = new COREServices.RequestAccountRegister();

        }
    }
}
