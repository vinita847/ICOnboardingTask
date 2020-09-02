using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace Mars.Step_Definition
{
    [Binding]
    public class SkillsSteps
    {
        public IWebDriver driver = new ChromeDriver();//defining driver as object

        
        [Given(@"I have opened the browser")]
        public void GivenIHaveOpenedTheBrowser()
        {
            //initialize driver and go to given url
            driver.Navigate().GoToUrl("http://192.168.99.100:5000/Home");

            // maximize the browser
            driver.Manage().Window.Maximize();
        }

        [Given(@"I sign in on the skillswap web")]
        public void GivenISignInOnTheSkillswapWeb()
        {
            //inspect the SignIn element and click

            driver.FindElement(By.XPath("//*[@id='home']/div/div/div[1]/div/a")).Click();

            //Thread.Sleep(2000); // explicit wait
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20); // Implicit wait 
            //find email element and enter email id
            driver.FindElement(By.Name("email")).SendKeys("samantvinita25@gmail.com");
            //Find the element for password and enter password
            driver.FindElement(By.Name("password")).SendKeys("Vinita@999");
            //Find element for login and click
            driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[4]/button")).Click();

            //Thread.Sleep(2000);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30); //for page loading

        }

        [Given(@"I opened the skills tab")]
        public void GivenIOpenedTheSkillsTab()
        {
            //Find Skills element and click
            driver.FindElement(By.XPath("//div[@class='ui top attached tabular menu']/a[2]")).Click();
        }

        [When(@"I add new skill")]
        public void WhenIAddNewSkill()
        {
            //Find Add New element and click
            try
            {
                driver.FindElement(By.XPath("*//div[@class='ui teal button']")).Click();
            }
            catch (NoSuchElementException)
            {
                Console.Write("Element not found");
            }
            Console.Write("Add skill");

            //find Add Skill element and enter skill
            driver.FindElement(By.XPath("//input[@name='name']")).SendKeys("Linux");
            //Find dropdown element and click
            driver.FindElement(By.XPath("//select[@class='ui fluid dropdown']")).Click();
            //Find element for selected skill level and click
            driver.FindElement(By.XPath("//option[contains(text(),'Beginner')]")).Click();

            //Find element for Add button and click
            driver.FindElement(By.XPath("//input[@value='Add']")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(40);
            //Thread.Sleep(2000);
        }

        
       
        [Then(@"A success popup message should be displayed")]
        public void ThenASuccessPopupMessageShouldBeDisplayed()
        {
            //verify you getting the notification that skill is added
            string SkillAddedMsg = driver.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']/div")).Text;
            Thread.Sleep(2000);

            string ExpectedAddMessage = "Linux has been added to your skills";

            //Assert.That(SkillAddedMsg, Does.Match("Linux has been added to your skills"));
            Assert.AreEqual(ExpectedAddMessage, SkillAddedMsg);
            
            //print the pop up text
            Console.WriteLine("Test Passed now");
            
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            //Thread.Sleep(4000);

        }


        [Given(@"I have opened the chrome browser")]
        public void GivenIHaveOpenedTheChromeBrowser()
        {
            //define driver
            //initialize driver and go to given url
            driver.Navigate().GoToUrl("http://192.168.99.100:5000/Home");

            // maximize the browser
            driver.Manage().Window.Maximize();
        }

        [Given(@"I have signed in on skill swap web app")]
        public void GivenIHaveSignedInOnSkillSwapWebApp()
        {
            //inspect the SignIn element and click

            driver.FindElement(By.XPath("//*[@id='home']/div/div/div[1]/div/a")).Click();

            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
            //Thread.Sleep(2000);

            //find email element and enter email id
            driver.FindElement(By.Name("email")).SendKeys("samantvinita25@gmail.com");
            //Find the element for password and enter password
            driver.FindElement(By.Name("password")).SendKeys("Vinita@999");
            //Find element for login and click
            driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[4]/button")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            //Thread.Sleep(2000);
        }

        [Given(@"I oopened the skils section")]
        public void GivenIOopenedTheSkilsSection()
        {
            driver.FindElement(By.XPath("//div[@class='ui top attached tabular menu']/a[2]")).Click();
        }


        [When(@"I click on Update button and enter valid data")]
        public void WhenIClickOnUpdateButtonAndEnterValidData()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            //Thread.Sleep(3000);
          try
            {
                //select update sign and click
                driver.FindElement(By.XPath("//tbody[4]//tr/td[3]/span/i[@class='outline write icon']")).Click();
            }
            catch (NoSuchElementException)
            {
                Console.Write("Skill Updated element not found");
            }
            
            //clear the existing data
            driver.FindElement(By.XPath("//input[@name='name']")).Clear();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            //Thread.Sleep(4000);
            //update the Add skill field 
            driver.FindElement(By.XPath("//input[@name='name']")).SendKeys("Linux basic");
            //click on update button
            driver.FindElement(By.XPath("//input[@type='button' and @value='Update']")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            //Thread.Sleep(4000);


        }

        [Then(@"A success Updated message should be displayed")]
        public void ThenASuccessUpdatedMessageShouldBeDisplayed()
        {
            string UpdateMsg = driver.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']/div")).Text;

            string ExpectedUpdateMsg = "Linux basic has been updated to your skills";

            Assert.AreEqual(ExpectedUpdateMsg, UpdateMsg);
            Console.WriteLine("Test Passed: Update successfuly");

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            //Thread.Sleep(3000);
        }


        [Given(@"I have opend the chrome browser")]
        public void GivenIHaveOpendTheChromeBrowser()
        {
            driver.Navigate().GoToUrl("http://192.168.99.100:5000/Home");

            // maximize the browser
            driver.Manage().Window.Maximize();
        }

        [Given(@"I have signed in skill swap web page")]
        public void GivenIHaveSignedInSkillSwapWebPage()
        {
            driver.FindElement(By.XPath("//*[@id='home']/div/div/div[1]/div/a")).Click();
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(40);
            //Thread.Sleep(2000);

            //find email element and enter email id
            driver.FindElement(By.Name("email")).SendKeys("samantvinita25@gmail.com");
            //Find the element for password and enter password
            driver.FindElement(By.Name("password")).SendKeys("Vinita@999");
            //Find element for login and click
            driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[4]/button")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            //Thread.Sleep(2000);
        }

        [Given(@"I opened the Skills section")]
        public void GivenIOpenedTheSkillsSection()
        {
            driver.FindElement(By.XPath("//div[@class='ui top attached tabular menu']/a[2]")).Click();
        }

        
        [When(@"I click on delete icon")]
        public void WhenIClickOnDeleteIcon()
        {
            driver.FindElement(By.XPath("//tbody[4]//tr[1]//td[3]//span[2]//i[1]")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            //Thread.Sleep(3000);
        }

        [Then(@"A delete message should be displayed")]
        public void ThenADeleteMessageShouldBeDisplayed()
        {
            //verify that the skill is deleted by getting a confirmation message
            string DeleteMsg = driver.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']/div")).Text;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            //Thread.Sleep(3000);

            string ExpectedDeleteMsg = "Linux basic has been deleted";

            Assert.AreEqual(ExpectedDeleteMsg, DeleteMsg);
            Console.WriteLine("Test Passed: Delete successfuly");
        }

       

       

    }
}
