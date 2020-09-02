using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Mars
{
    class LogIn
    {
        static void LogInSteps(string[] args)
        {
            //define driver
            IWebDriver driver = new ChromeDriver();
            //initialize driver and go to given url
            driver.Navigate().GoToUrl("http://192.168.99.100:5000/Home");

            // maximize the browser
            driver.Manage().Window.Maximize();
            //inspect the SignIn element and click

            driver.FindElement(By.XPath("//*[@id='home']/div/div/div[1]/div/a")).Click();

            Thread.Sleep(2000);
            
            //find email element and enter email id
            driver.FindElement(By.Name("email")).SendKeys("samantvinita25@gmail.com");
            //Find the element for password and enter password
            driver.FindElement(By.Name("password")).SendKeys("Vinita@999");
            //Find element for login and click
            driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[4]/button")).Click();
            //find element and Verify the account by name
            //Thread.Sleep(2000);

            //driver.FindElement(By.Name("vinita"));
            //Thread.Sleep(1000);
            IWebElement ValidUser = driver.FindElement(By.XPath("*//div[@class='ui compact menu']/span[1]/text()[2]"));

            //if (driver.FindElement(By.XPath("*//div[@class='ui compact menu']/span[1]/text()[2]")).Text == "Hi vinita")
            //{
            //    Console.WriteLine("Test Passed");
            //}
            //else {
            //    Console.WriteLine("Test Failed");
            //}

            Assert.That(ValidUser.Text, Does.Match("vinita"));
            //Assert.AreEqual(ValidUser.Text, "Hi vinita");
            

          //driver.Quit();


        }
    }
}
