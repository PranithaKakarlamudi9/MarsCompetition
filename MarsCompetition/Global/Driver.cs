using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;
using MarsCompetition.Pages;

namespace MarsCompetition.Global
{
    //<Summary>
    // This class is Driver class having static global driver    
    //</summary>
    class Driver
    {
        //Global static driver
        public static IWebDriver driver { get; set; }



        //<Summary>
        // This method is used to initalise driver  with browser as parameter  
        //</summary>
        public void Intialise(String browser)
        {

            switch (browser)
            {
                case "Chrome":
                    driver = new ChromeDriver();
                    driver.Manage().Window.Maximize();
                    driver.Navigate().GoToUrl(ConstantHelpers.BaseUrl);
                    break;
                case "Firefox":
                    driver = new FirefoxDriver();
                    driver.Manage().Window.Maximize();
                    driver.Navigate().GoToUrl(ConstantHelpers.BaseUrl);
                    break;
                case "IE":
                    driver = new FirefoxDriver();
                    driver.Manage().Window.Maximize();
                    driver.Navigate().GoToUrl(ConstantHelpers.BaseUrl);
                    break;
            }

        }

        //<Summary>
        // This method waits until UI web element is found.
        //This method takes wait time and element to be found as parameter
        //</summary>
        public static void WaitForElement(int seconds, By by)
        {
            WebDriverWait driverWait = new WebDriverWait(Driver.driver, TimeSpan.FromSeconds(seconds));
            driverWait.Until(ExpectedConditions.ElementIsVisible(by));
        }

        //<Summary>
        // This method waits until UI web element is .
        //This method takes wait time and element to be found as parameter
        //</summary>
        public static void WaitForClickableElement(int seconds, By by)
        {
            WebDriverWait driverWait = new WebDriverWait(Driver.driver, TimeSpan.FromSeconds(seconds));
            driverWait.Until(ExpectedConditions.ElementToBeClickable(by));
        }
       
    }
}
