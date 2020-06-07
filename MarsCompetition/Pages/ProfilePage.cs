using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarsCompetition.Global;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace MarsCompetition.Pages
{
    //<Summary>
    // this class is Profile page with 
    // user navigates to ShareSkill page and Manage Listings page
    //</summary>
    class ProfilePage
    {
        //<Summary>
        // Profile page constructor intialises this page objects     
        //</summary>
        public ProfilePage()
        {

            PageFactory.InitElements(Driver.driver, this);
        }
        //object repository

        //Finds ShareSkill button
        [FindsBy(How = How.LinkText, Using = "Share Skill")]
        public IWebElement ShareSkill { get; set; }


        //Finds ManageListings Link
        [FindsBy(How = How.LinkText, Using = "Manage Listings")]
        public IWebElement ManageLIstings { get; set; }

        //<Summary>
        // Clicks on ShareSkills Link
        //</summary>
        public void ClickShareSkill()
        {
            Driver.WaitForElement(60, By.XPath("//div[@id='account-profile-section']/descendant::div[1]/section/descendant::a[6]"));
            ShareSkill.Click();
        }

        //<Summary>
        // Clicks on ManageListings Link
        //</summary>
        public void ClickManageListings()
        {
            Driver.WaitForElement(60, By.XPath("//div[@id='account-profile-section']/descendant::div[1]/section/descendant::a[3]"));
            ManageLIstings.Click();
        }

    }
}
