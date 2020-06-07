using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarsCompetition.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace MarsCompetition.Pages
{
    //<Summary>
    // This class is LoginPage with login object repository
    // This class allows user to successfully login website
    //</summary>
    class LoginPage
    {
        //constructor intialises objects in object repository

        public LoginPage()
        {
            PageFactory.InitElements(Driver.driver, this);
        }

        //Login page object factory

        //Finding SignIn
        [FindsBy(How = How.XPath, Using = "//*[@id='home']/div/div/div[1]/div/a")]
        public IWebElement btnSignIn { get; set; }

        //Finding email textbox
        [FindsBy(How = How.Name, Using = "email")]
        public IWebElement txtEmailAddress { get; set; }

        //Finding password textbox
        [FindsBy(How = How.Name, Using = "password")]
        public IWebElement txtPassword { get; set; }

        //Finding login button
        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div/div/div[1]/div/div[4]/button")]
        public IWebElement btnLogin { get; set; }


        // Login method performs login operation with valid credentials 
        public void LogIn()
        {
            //populating data from excel sheet into datacollectiion 
            ExcelLibrary.PopulateInCollectiion(ConstantHelpers.TestDataPath, "LogInSheet");

            //String result = ExcelLibrary.ReadData(1, "Email");
            Driver.WaitForElement(30, By.XPath("//*[@id='home']/div/div/div[1]/div/a"));

            //user clicks on SignIn button
            btnSignIn.Click();

            //user enters valid username         
            txtEmailAddress.SendKeys(ExcelLibrary.ReadData(2, "Email"));


            //user enters valid password        
            txtPassword.SendKeys(ExcelLibrary.ReadData(2, "Password"));

            //user clicks on login button
            btnLogin.Click();

        }
    }
}
