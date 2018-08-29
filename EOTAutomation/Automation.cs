using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;

namespace EOTAutomation
{
    public class Automation
    {
        public string _startTime { get; set; }
        public string _endTime { get; set; }
        public string _maxClaimable { get; set; }

        public string _weekChoice { get; set; }

        public void AutomateEot(IWebDriver webdriver)
        {

            try
            {
                webdriver.Navigate().GoToUrl("http://eotproductionweb.svcs.entsvcs.net:9000/login/");

                
                var user = webdriver.FindElement(By.Id("username"));
                user.SendKeys(LoginCredentials._emailAddress);
                var pass = webdriver.FindElement(By.Id("password"));
                pass.SendKeys(LoginCredentials._password);
                webdriver.FindElement(By.Id("submit")).Click();


                do
                {
                    do
                    {

                        Console.WriteLine("Type \"c\" CURRENT WEEK; \"p\" for PREVIOUS WEEK; \"n\" for NEXT WEEK; \"d\" if your Done: ");
                        _weekChoice = Console.ReadLine();

                        if (_weekChoice.ToLower() != "c" && _weekChoice.ToLower() != "p" && _weekChoice.ToLower() != "n" && _weekChoice.ToLower() != "d")
                        {
                            Console.WriteLine("Invalid Input! Please enter 'c', 'p', 'n', or 'd' values only!");
                        }


                    } while (_weekChoice.ToLower() != "c" && _weekChoice.ToLower() != "p" && _weekChoice.ToLower() != "n" && _weekChoice.ToLower() != "d");


                    if (_weekChoice.ToLower() != "d")
                    {


                        switch (_weekChoice.ToLower())
                        {
                            case ("c"):
                                break;
                            case ("p"):
                                {
                                    webdriver.FindElement(By.Id("prev_btn")).Click();
                                    break;
                                }
                            case ("n"):
                                {
                                    webdriver.FindElement(By.Id("next_btn")).Click();
                                    break;
                                }
                            default:
                                break;
                        }

                        try
                        {
                            webdriver.FindElement(By.Name("wbs_element")).Clear();
                            webdriver.FindElement(By.Name("wbs_element")).SendKeys(LoginCredentials._wbs);
                            webdriver.FindElement(By.Id("day1_comment")).Clear();
                        }
                        catch (OpenQA.Selenium.InvalidElementStateException)
                        {

                            Console.WriteLine("Input for current Week is currently restricted.");

                        }




                        if (LoginCredentials._wbs.Equals("US1-PGBCS.10.20") && LoginCredentials._shift.Equals("emea")) //1 US1-PGBCS.10.20 (CRC) 
                        {
                            _startTime = HourElements.StartHour._1400;
                            _endTime = HourElements.EndHour._0200;
                            _maxClaimable = "4.50";
                        }

                        else if (LoginCredentials._wbs.Equals("US1-PGBCS.10.20") && LoginCredentials._shift.Equals("nala")) //1 US1-PGBCS.10.20 (CRC) 
                        {
                            _startTime = HourElements.StartHour._1800;
                            _endTime = HourElements.EndHour._0600;
                            _maxClaimable = "7.00";
                        }

                        if (LoginCredentials._wbs.Equals("US1-GMB01.05.05.03") && LoginCredentials._shift.Equals("emea")) //1 US1-PGBCS.10.20 (CRC) 
                        {
                            _startTime = HourElements.StartHour._1400;
                            _endTime = HourElements.EndHour._0200;
                            _maxClaimable = "4.50";
                        }

                        else if (LoginCredentials._wbs.Equals("US1-GMB01.05.05.03") && LoginCredentials._shift.Equals("nala")) //1 US1-PGBCS.10.20 (CRC) 
                        {
                            _startTime = HourElements.StartHour._1800;
                            _endTime = HourElements.EndHour._0600;
                            _maxClaimable = "7.00";
                        }

                        else
                        {
                            Console.WriteLine("Your WBS Code and Shift are not supported at the moment. Application will close now.");
                            System.Environment.Exit(0);
                        }



                        foreach (var item in WebElements.dayStart)
                        {
                            try
                            {
                                var dayStartTime = webdriver.FindElement(By.Id(item.ToString()));
                                var selectElement = new SelectElement(dayStartTime);
                                selectElement.SelectByValue(_startTime);
                            }
                            catch (OpenQA.Selenium.Support.UI.UnexpectedTagNameException)
                            {

                                Console.WriteLine("Some days are still restricted. Partial input has been done.");
                            }

                        }

                        foreach (var item in WebElements.dayEnd)
                        {
                            try
                            {
                                var dayEndTime = webdriver.FindElement(By.Id(item.ToString()));
                                var selectElement = new SelectElement(dayEndTime);
                                selectElement.SelectByValue(_endTime);
                            }
                            catch (OpenQA.Selenium.Support.UI.UnexpectedTagNameException)
                            {
                                Console.WriteLine("Some days are still restricted. Partial input has been done.");
                            }

                        }

                        foreach (var item in WebElements.hours)
                        {
                            try
                            {
                                webdriver.FindElement(By.Name(item.ToString())).Clear();
                                webdriver.FindElement(By.Name(item.ToString())).SendKeys(_maxClaimable);
                            }
                            catch (OpenQA.Selenium.InvalidElementStateException)
                            {

                                Console.WriteLine("Some days are still restricted. Partial input has been done.");

                            }

                        }

                        Console.WriteLine("\nAutomation Done for this week. PLEASE VERIFY AND MANUALLY SAVE FIRST.");
                        Console.WriteLine("\nDo you want to automate Previous or Next week too?");
                    }

                } while (_weekChoice.ToLower() != "d");
                Console.WriteLine("Thank you for using EOT Automation! You may now close the application.");

               

            }
            catch (OpenQA.Selenium.WebDriverException)
            {
                Console.WriteLine("\nERROR : THE BROWSER HAS FAILED TO LOAD THE EOT WEBSITE. PLEASE CHECK YOUR CONNECTION!\n");
            }


}



    }
}

 