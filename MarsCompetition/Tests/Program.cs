using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using MarsCompetition.Global;
using MarsCompetition.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace MarsCompetition
{

    class Program : Driver
    {
        static void Main(string[] args)
        {

        }
        public ExtentTest test;
        public static ExtentReports extent;
        public static ExtentHtmlReporter htmlReporter;
        [OneTimeSetUp]
        public void TestSetUP()
        {

            extent = new ExtentReports();
            htmlReporter = new ExtentHtmlReporter(ConstantHelpers.ReportsPath);
            extent.AttachReporter(htmlReporter);
            test = extent.CreateTest("Test").Info("TestStarted");

            Intialise("Chrome");
            LoginPage login = new LoginPage();
            login.LogIn();


        }
        [Test, Description("Verify Adding ShareSkill")]
        public void TestAddShareSkill()
        {
            test = extent.CreateTest("Test Add ShareSkill");
            ProfilePage profilePage = new ProfilePage();
            profilePage.ClickShareSkill();
            ShareSkillPage skillPage = new ShareSkillPage();
            skillPage.ReadExcelAddShareSkill();
            skillPage.AddShareSkill();
            Driver.WaitForElement(60, By.XPath("//tbody/tr[1]/td[3]"));
            String expextedTitle = "Seleinium with Csharp";
            String actualTitle = Driver.driver.FindElement(By.XPath("//tbody/tr[1]/td[3]")).Text;
            Assert.AreEqual(expextedTitle, actualTitle);
            test.Log(Status.Info, "Added a ShareSkill");
        }
        [Test, Description("Verify Edit ManageListing")]
        public void TestEditManageListings()
        {
            test = extent.CreateTest("Test Edit ManageListings");
            ProfilePage profilePage = new ProfilePage();
            profilePage.ClickManageListings();
            ManageListingsPage listings = new ManageListingsPage();
            listings.EditManageListings();
            Driver.WaitForElement(60, By.XPath("//tbody/tr[1]/td[3]"));
            String expextedTitle = "Seleinium with Java";
            String actualTitle = Driver.driver.FindElement(By.XPath("//tbody/tr[1]/td[3]")).Text;
            Assert.AreEqual(expextedTitle, actualTitle);

            test.Log(Status.Info, "Edited ManageListings");
        }


        [Test, Description("Delete MangeListing")]
        public void TestDeleteManageListings()
        {
            test = extent.CreateTest("Test Delete ManagelListing");
            ProfilePage profileObj = new ProfilePage();
            profileObj.ClickManageListings();
            ManageListingsPage listings = new ManageListingsPage();


            Driver.WaitForClickableElement(60, By.XPath("//tbody/tr[1]/td[8]/descendant::button[3]"));
            listings.DeleteManageListing();
            Thread.Sleep(1000);
            String ExpectedDeleteConfirmation = driver.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']/div")).Text;

            Assert.IsTrue(ExpectedDeleteConfirmation.Contains(" has been deleted"));

            test.Log(Status.Info, "Deleted ManageListing");
        }

        [OneTimeTearDown]
        public void TearDown()
        {

            extent.Flush();
            Driver.driver.Close();

        }


    }
}

