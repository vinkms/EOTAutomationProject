using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOTAutomation
{
    class Program
    {
        static void Main(string[] args)



            
        {
            
            Console.WriteLine("EOT AUTOMATION TOOL 1.0");

            var LoginCreds = new LoginCredentials();
            var automate = new Automation();
          

            LoginCreds.InputCredentials();
            automate.AutomateEot(LoginCreds.BrowserDriver);
           
           
            

            

           
        }
    }
}
