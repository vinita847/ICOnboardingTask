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

namespace Mars.Steps
{
    [Binding]//attribute for binding steps  of feature file in stepdfinition file    

    public class LoginSteps
    {
        public IWebDriver driver = new ChromeDriver();//defining driver as object
        [Given(@"I have entered the web address in browser")]
        public void GivenIHaveEnteredTheWebAddressInBrowser()
        {
            //define driver
            //IWebDriver driver = new ChromeDriver();
            //initialize driver and go to given url
            driver.Navigate().GoToUrl("http://192.168.99.100:5000/Home");

            // maximize the browser
            driver.Manage().Window.Maximize();
        }

        [Given(@"I have clicked on Signin button")]
        public void GivenIHaveClickedOnSigninButton()
        {
            //inspect the SignIn element and click

            driver.FindElement(By.XPath("//*[@id='home']/div/div/div[1]/div/a")).Click();
        }

        [When(@"I provide valid email and password and click login")]
        public void WhenIProvideValidEmailAndPasswordAndClickLogin()
        {
            driver.FindElement(By.Name("email")).SendKeys("samantvinita25@gmail.com");

            //Find the element for password and enter password
            driver.FindElement(By.Name("password")).SendKeys("Vinita@999");
            //Find element for login and click
            driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[4]/button")).Click();
            //driver.Manage().Timeouts().PageLoad=TimeSpan.FromSeconds(300);
        }
        
        [Then(@"I should be able to login in the associated account")]
        public void ThenIShouldBeAbleToLoginInTheAssociatedAccount()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(40); //implicit wait 
            //if (driver.FindElement(By.XPath(*//div[@class='ui compact menu']/span[1]/text()[2]")).Text == "Hi vinita")
            //{
            //    Console.WriteLine("Test Passed");
            //}
            //else
            //{
            //    Console.WriteLine("Test Failed");
            //}

            IWebElement ValidUser = driver.FindElement(By.XPath("*//div[@class='ui compact menu']/span[1]/text()[2]"));

            Assert.That(ValidUser.Text, Does.Match("vinita"));
            //Assert.AreEqual(ValidUser.Text, "Hi vinita");
            //*[@id="account-profile-section"]/div/div[1]/div[2]/div/span/text()[2]
        }

    }
}
