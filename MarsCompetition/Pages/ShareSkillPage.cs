using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MarsCompetition.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;


namespace MarsCompetition.Pages
{
    //<Summary>
    //This class is ShareSkill page containg its page objects.
    //This class is used to data to create a managelisting .
    //</summary>
    
    class ShareSkillPage
    {
        public ShareSkillPage()
        {
            PageFactory.InitElements(Driver.driver, this);
        }
        //pgae object repository

        //Title textbox
        [FindsBy(How = How.XPath, Using = "//input[@name='title']")]
        public IWebElement txtTitle { get; set; }

        //Description
        [FindsBy(How = How.XPath, Using = "//div[@class='field  ']/textarea[@name='description']")]
        public IWebElement txtDescription { get; set; }

        //Category
        [FindsBy(How = How.Name, Using = "categoryId")]
        public IWebElement dropdownCategory { get; set; }

        //SubCategory
        [FindsBy(How = How.Name, Using = "subcategoryId")]
        public IWebElement dropdownSubCategory { get; set; }

        //Tags
        [FindsBy(How = How.XPath, Using = "//div[@class='ReactTags__tagInput']/input")]
        public IWebElement txtTag { get; set; }

        //Service Type
        [FindsBy(How = How.XPath, Using = "//input[@name='serviceType']")]
        public IList<IWebElement> radioServiceType { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name='serviceType']/parent::div/label")]
        public IList<IWebElement> labelServiceType { get; set; }

        //Location
        [FindsBy(How = How.XPath, Using = "//input[@name='locationType']")]
        public IList<IWebElement> radioLocation { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name='locationType']/parent::div/label")]
        public IList<IWebElement> labelLocationType { get; set; }

        //AvailableDays
        //list of weekdays
        [FindsBy(How = How.XPath, Using = "//input[@name='Available']")]
        public IList<IWebElement> WeekDays { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name='Available']/parent::div/label")]
        public IList<IWebElement> WeekDaysName { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name='StartTime']")]
        public IList<IWebElement> StartTime { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name='EndTime']")]
        public IList<IWebElement> EndTime { get; set; }

        //SkillTrade-SkillExchange
        [FindsBy(How = How.XPath, Using = "//div[@class='ui radio checkbox']/input[@name='skillTrades'][@value='true']")]
        public IWebElement radioSkillExchange { get; set; }

        //SkillTrade-SkillExchange-Tag
        [FindsBy(How = How.XPath, Using = "(//input[@class='ReactTags__tagInputField'])[2]")]
        public IWebElement txtSkillExchangeTag { get; set; }

        //SkillTrade-SkillTrade-Credit
        [FindsBy(How = How.XPath, Using = "//div[@class='ui radio checkbox']/input[@name='skillTrades'][@value='false']")]
        public IWebElement radioSkillExchangeCredit { get; set; }

        //Credit Charge

        [FindsBy(How = How.XPath, Using = "//input[@name='charge']")]
        public IWebElement txtCreditCharge { get; set; }

        //Active
        [FindsBy(How = How.XPath, Using = "//input[@name='isActive']")]
        public IList<IWebElement> radioActive { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name='isActive']/parent::div/label")]
        public IList<IWebElement> labelActive { get; set; }

        //Save Button        
        [FindsBy(How = How.XPath, Using = "//div[@class='ui container']/descendant::form/div[11]/div/input[@class='ui teal button']")]
        public IWebElement btnSave { get; set; }

        //Cancel Button
        [FindsBy(How = How.XPath, Using = "//div[@class='ui container']/descendant::form/div[11]/div/input[@class='ui button']")]
        public IWebElement btnCancel { get; set; }


        public void ReadExcelAddShareSkill()
        {
            //populating data from excel sheet 
            ExcelLibrary.PopulateInCollectiion(ConstantHelpers.TestDataPath, "AddShareSkillSheet");
        }

        public void ReadExcelEditShareSkill()
        {
            //populating data from excel sheet 
            ExcelLibrary.PopulateInCollectiion(ConstantHelpers.TestDataPath, "EditShareSkillSheet");
        }



        public void AddShareSkill()
        {
            
            //Entering Title
            Driver.WaitForElement(25, By.XPath("//input[@name='title']"));
            txtTitle.SendKeys(ExcelLibrary.ReadData(2, "Title"));

            //Entering Description
            Driver.WaitForElement(10, By.XPath("//div[@class='field  ']/textarea[@name='description']"));
            txtDescription.SendKeys(ExcelLibrary.ReadData(2, "Description"));

            //Entering Category
            Driver.WaitForElement(10,By.Name("categoryId"));

            SelectElement categoryDropdown = new SelectElement(dropdownCategory);
            categoryDropdown.SelectByText(ExcelLibrary.ReadData(2, "Category"));

            //entering SubCategory
            Driver.WaitForElement(10, By.Name("subcategoryId"));
            SelectElement subCategoryDropdown = new SelectElement(dropdownSubCategory);
            subCategoryDropdown.SelectByText(ExcelLibrary.ReadData(2, "SubCategory"));

            //Entering Tags first tag
            Driver.WaitForElement(10, By.XPath("//div[@class='ReactTags__tagInput']/input"));
            txtTag.SendKeys(ExcelLibrary.ReadData(2, "Tags"));
            txtTag.SendKeys(Keys.Enter);
            

            //Selecting Service Type based on data in excel
            ServiceTypeSelection();

            //Selecting Location based on excel data
           
            LocationSelection();

           

            // Available Days     
           
            SelectAvailaibleDayAndTime();
            
            //Slecting SkillTrade
            if (ExcelLibrary.ReadData(2, "SkillTrade") == "Skill-Exchange")
            {
               // Driver.WaitForClickableElement(10, By.XPath("//div[@class='ui radio checkbox']/input[@name='skillTrades'][@value='true']"));
                radioSkillExchange.Click();
                //entering tags  if Skill excahange radio button is selected
                Driver.WaitForElement(10, By.XPath("(//input[@class='ReactTags__tagInputField'])[2]"));
                txtSkillExchangeTag.SendKeys(ExcelLibrary.ReadData(2, "Skill-Exchange"));
                txtSkillExchangeTag.SendKeys(Keys.Enter);
            }
            else
            {
               // Driver.WaitForClickableElement(10, By.XPath("//div[@class='ui radio checkbox']/input[@name='skillTrades'][@value='false']"));
                radioSkillExchangeCredit.Click();
                //entering charge for credit
                Driver.WaitForElement(10, By.XPath("//input[@name='charge']"));
                txtCreditCharge.SendKeys(ExcelLibrary.ReadData(2, "Credit"));

            }

            //Selecting Active 
            ActiveSelection();

            //click on save to creat a share skill in managelistings table
            Driver.WaitForClickableElement(60,By.XPath("//div[@class='ui container']/descendant::form/div[11]/div/input[@class='ui teal button']"));
            btnSave.Click();
     
        }

        //This method selects ServiceType based on data from excelsheet
        public void ServiceTypeSelection()
        {
            int listSize = radioServiceType.Count();
            for (int i = 0; i < listSize; i++)
            {
                String radioText = labelServiceType.ElementAt(i).Text;
                if (radioText == ExcelLibrary.ReadData(2, "ServiceType"))
                {
                    Thread.Sleep(10000);
                    radioServiceType.ElementAt(i).Click();
                }

            }

        }

        //This method selects ServiceType based on data from excelsheet


        public void LocationSelection()
        {
            int listSize = radioLocation.Count();
            for (int i = 0; i < listSize; i++)
            {
                String radioText = labelLocationType.ElementAt(i).Text;
                if (radioText == ExcelLibrary.ReadData(2, "LocationType"))
                {
                    Thread.Sleep(10000);
                    labelLocationType.ElementAt(i).Click();
                }

            }


        }

        //This method selects ServiceType based on data from excelsheet
        public void ActiveSelection()
        {
            int listSize = radioActive.Count();
            for (int i = 0; i < listSize; i++)
            {
                String radioText = labelActive.ElementAt(i).Text;
                if (radioText == ExcelLibrary.ReadData(2, "Active"))
                {
                    Thread.Sleep(10000);
                    labelActive.ElementAt(i).Click();
                }
            }
        }

        //Slecting Available days
        public void SelectAvailaibleDayAndTime()
        {

            int WeekDaysSize = WeekDays.Count();

            for (int i = 0; i < WeekDaysSize; i++)
            {
                String dayOfWeek = WeekDaysName.ElementAt(i).Text;
                if (dayOfWeek == ExcelLibrary.ReadData(2, "Selectday"))
                {
                    Thread.Sleep(1000);
                    WeekDays.ElementAt(i).Click();
                    Thread.Sleep(1000);

                    string str = ExcelLibrary.ReadData(2, "Starttime");
                    //Console.WriteLine(str);
                    DateTime dt = DateTime.Parse(str);
                    Console.WriteLine(dt.ToLongTimeString().ToString());
                    StartTime.ElementAt(i).SendKeys(dt.ToLongTimeString().ToString());
                    Thread.Sleep(1000);                   
                    string str1 = ExcelLibrary.ReadData(2, "Endtime");
                    DateTime dt1 = DateTime.Parse(str1);
                    EndTime.ElementAt(i).SendKeys(dt1.ToString("hh:mm tt"));

                    //12/31/1899 6:00:00 AM
                   
                    
                }

            }



        }
    }
}

                    
                