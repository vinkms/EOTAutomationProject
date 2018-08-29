using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace EOTAutomation
{

    class LoginCredentials
    {
        public static string _emailAddress { get; set; }
        public static string _password { get; set; }

        public static string _password2 { get; set; }
        public string _confirmation { get; set; }

        public string _browser { get; set; }

        public static string _shift { get; set; }

        public static string _wbs { get; set; }

        public static int _wbschoice { get; set; }

        public static string _userinput { get; set; }

        int output;

        bool _correctinput = false;

        DriverManager drive = new DriverManager();
        public IWebDriver BrowserDriver = null;
        //IWebDriver webdriver 


        public void InputCredentials()
        {

            do
            {
                Console.Write("\nEmail Address: ");
                _emailAddress = Console.ReadLine();


                do
                {

                    Console.Write("\nComputer Password: ");
                    _password = PasswordMasker.GetConsolePassword();

                    Console.Write("Confirm Password: ");
                    _password2 = PasswordMasker.GetConsolePassword();

                    if (_password != _password2)
                    {
                        Console.WriteLine("Password isn't matched. Try again");
                    }

                }
                while (_password != _password2);
                Console.Clear();



                //Critical Modifications Needed
                
                do
                {
                    Console.Write(" WBS Code \n Type \"1\" for US1-PGBCS.10.20 (CRC) \n Type \"2\" for US1-PGADS.10.01 : "); 

                    _userinput = Console.ReadLine();

                    _correctinput = int.TryParse(_userinput, out output);
                    
                    
                    if (_correctinput == true)
                    {
                        _wbschoice = Convert.ToInt32(_userinput) - 1;
                        if (WBScodes.wbsCodes.Count < _wbschoice + 1 || _wbschoice < 0)
                        {
                            Console.WriteLine("Invalid input!! Please enter from the choices only! 1");
                        }
                        
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!! Please enter from the choices only! 2");
                    }

                }
                while (WBScodes.wbsCodes.Count < _wbschoice + 1 || _wbschoice < 0 && _correctinput == true);
                _wbs = WBScodes.wbsCodes[_wbschoice].ToString();
               

                do
                {
                    Console.Write("\nAre you sure? y/n:");
                    _confirmation = Console.ReadLine();
                    if (_confirmation.ToLower() != "y" && _confirmation.ToLower() != "n")
                    {
                        Console.WriteLine("Invalid input!! Please enter 'y' or 'n' values only!!");
                    }
                }
                while (_confirmation.ToLower() != "y" && _confirmation.ToLower() != "n");


            } while (_confirmation.ToLower() != "y");
            Console.Clear();
            Confirmed();







        }

        public IWebDriver Confirmed()
        {
            do
            {
                Console.Write("Shift? Type \"emea\" for 2PM-11:30PM / \"nala\" for 6PM-3AM : ");
                _shift = Console.ReadLine();

                if (_shift != "emea" && _shift != "nala")
                {
                    Console.WriteLine("Invalid input!! Only input value from the following choices:");
                    Console.WriteLine(" - emea\n - nala");
                }

            } while (_shift != "emea" && _shift != "nala");
            Console.Clear();

            do
            {

                Console.Write("What browser would you like to use? chrome/ie/edge/firefox: ");
                _browser = Console.ReadLine();
                if (_browser != "chrome" && _browser != "ie" && _browser != "firefox" && _browser != "edge")
                {
                    Console.WriteLine("Invalid input!! Only input value from the following choices:");
                    Console.WriteLine(" - chrome\n - ie\n - edge\n - firefox");
                }
            }
            while (_browser != "chrome" && _browser != "ie" && _browser != "firefox" && _browser != "edge");


            switch (_browser)
            {
                case ("chrome"):
                    BrowserDriver = drive.ChromeDriver();
                    return BrowserDriver;
                case ("ie"):
                    BrowserDriver = drive.IEDriver();
                    return BrowserDriver;
                case ("firefox"):
                    BrowserDriver = drive.FirefoxDriver();
                    return BrowserDriver;
                case ("edge"):
                    BrowserDriver = drive.EdgeDriver();
                    return BrowserDriver;
                default:
                    return BrowserDriver;

            }


        }




    }
}
