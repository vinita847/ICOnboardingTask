using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Mars.Step_Definition
{
    [Binding]
    public class EducationSteps
    {
        public IWebDriver driver = new ChromeDriver();//defining driver as object

        [Given(@"open browser and enter url")]
        public void GivenOpenBrowserAndEnterUrl()
        {
            //initialize driver and go to given url
            driver.Navigate().GoToUrl("http://192.168.99.100:5000/Home");

            // maximize the browser
            driver.Manage().Window.Maximize();
            //inspect the SignIn element and click

            driver.FindElement(By.XPath("//*[@id='home']/div/div/div[1]/div/a")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20); // Implicit wait 

        }

        [When(@"login to your account")]
        public void WhenLoginToYourAccount()
        {
            //find email element and enter email id
            driver.FindElement(By.Name("email")).SendKeys("samantvinita25@gmail.com");
            //Find the element for password and enter password
            driver.FindElement(By.Name("password")).SendKeys("Vinita@999");
            //Find element for login and click
            driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[4]/button")).Click();
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30); // Implicit wait 
        }

        [When(@"click on education tab")]
        public void WhenClickOnEducationTab()
        {
            //find 'Education' tab and click
            driver.FindElement(By.LinkText("Education")).Click();
        }

        [Given(@"I have clicked on Add New button")]
        public void GivenIHaveClickedOnAddNewButton()
        {
            //click on Add New button
            driver.FindElement(By.XPath("//tr/th[6]/div[1]")).Click();
        }

        [When(@"I enter the required details for education")]
        public void WhenIEnterTheRequiredDetailsForEducation()
        {
            //enter uni name
            driver.FindElement(By.XPath("//input[@name='instituteName']")).SendKeys("Unitec");
            //handel dropdown for country
            driver.FindElement(By.XPath("//select[@name='country']"));
            //select country
            driver.FindElement(By.XPath("//option[contains(text(),'New Zealand')]")).Click();
            //select title dropdown button
            driver.FindElement(By.XPath("//select[@name='title']"));
            //select title from dropdown
            driver.FindElement(By.XPath("//option[contains(text(), 'B.Tech')]")).Click();
            //enter degree
            driver.FindElement(By.XPath("*//input[@name='degree']")).SendKeys("Bacholer");
            //select dropdown button for year of graduation
            driver.FindElement(By.XPath("*//select[@name='yearOfGraduation']")).Click();
            //select year of graduation
            driver.FindElement(By.XPath("*//option[contains(text(), 2019)]")).Click();
        }

        [When(@"I click on Add button")]
        public void WhenIClickOnAddButton()
        {
            //select Add button to add the entry
            driver.FindElement(By.XPath("*//input[@value='Add']")).Click();
        }

        [Then(@"I should be able to see a success Add message")]
        public void ThenIShouldBeAbleToSeeASuccessAddMessage()
        {
            //verify you getting the notification that education is added
            string EduAddedMsg = driver.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']/div")).Text;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            Thread.Sleep(3000);
            string ExpectedAddMessage = "Education has been added";
            Assert.AreEqual(ExpectedAddMessage, EduAddedMsg);

            //print the pop up text
            Console.WriteLine(ExpectedAddMessage);         
              
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            
            driver.Quit();       
        }

        [Given(@"I have clicked on Update icon")]
        public void GivenIHaveClickedOnUpdateIcon()
        {
            //select update icon and click
            driver.FindElement(By.XPath("//td[contains(text(), 'Australia')]//following-sibling::td[5]//descendant::i[1]")).Click();
        }

        [When(@"I enter the update the desired fields")]
        public void WhenIEnterTheUpdateTheDesiredFields()
        {
            //clear and edit/update university
            driver.FindElement(By.XPath("//input[@name='instituteName']")).Clear();
            driver.FindElement(By.XPath("//input[@name='instituteName']")).SendKeys("AUT");
            //click on update button
            driver.FindElement(By.XPath("//input[@class='ui teal button']")).Click();
        }

        [Then(@"I should be able to see a Success Update message")]
        public void ThenIShouldBeAbleToSeeASuccessUpdateMessage()
        {
            //verify the updated entry
            string ActualUpdateMsg = driver.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']/div")).Text;

            string ExpectedUpdateMsg = "Education as been updated";
            Assert.AreEqual(ExpectedUpdateMsg, ActualUpdateMsg);
            //print the pop up text
            Console.WriteLine(ExpectedUpdateMsg);


            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.Quit();       
        }

        [When(@"I have clicked on the delete icon")]
        public void WhenIHaveClickedOnTheDeleteIcon()
        {
            //select delete icon
            driver.FindElement(By.XPath("//td[contains(text(), 'India')]//following-sibling::td[5]//span[2]/i")).Click();
            Console.WriteLine("Click on Delete icon");
        }

        [Then(@"I should be able to see a delete success message")]
        public void ThenIShouldBeAbleToSeeADeleteSuccessMessage()
        {
            //verify item is delete using assertion
            string DeleteMsg = driver.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']/div")).Text;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            string ExpectedDeleteMsg = "Education entry successfully removed";
            Assert.AreEqual(ExpectedDeleteMsg, DeleteMsg);
            Console.WriteLine(ExpectedDeleteMsg);
            driver.Quit(); 
        }

    }
}
