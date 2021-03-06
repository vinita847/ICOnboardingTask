﻿using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mars
{
    class Education
    {
       public void Main()
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
            Thread.Sleep(2000);

            ////////////////Adding education//////////////

            //find 'Education' tab and click
            driver.FindElement(By.LinkText("Education")).Click();

            //click on Add New button
            driver.FindElement(By.XPath("//tr/th[6]/div[1]")).Click();
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
            //select Add button to add the entry
            driver.FindElement(By.XPath("*//input[@value='Add']")).Click();

           
            //verify you getting the notification that education is added
            string EduAddedMsg = driver.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']/div")).Text;
            Thread.Sleep(2000);

            string ExpectedAddMessage = "Eductaion has been added";
            Assert.AreEqual(ExpectedAddMessage, EduAddedMsg);

            //print the pop up text
            Console.WriteLine(ExpectedAddMessage);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            //Thread.Sleep(4000);
            //driver.Quit();

            //////////////updating Education////////////////
            //select update icon and click
            driver.FindElement(By.XPath("//td[contains(text(), 'Australia')]//following-sibling::td[5]//descendant::i[1]")).Click();

            
            //clear and edit/update university
            driver.FindElement(By.XPath("//input[@name='instituteName']")).Clear();
            driver.FindElement(By.XPath("//input[@name='instituteName']")).SendKeys("AUT");

            //click on update button
            driver.FindElement(By.XPath("//input[@class='ui teal button']")).Click();

            //verify the updated entry
            string ActualUpdateMsg = driver.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']/div")).Text;

            string ExpectedUpdateMsg = "Education as been updated";
            Assert.AreEqual(ExpectedUpdateMsg, ActualUpdateMsg);
            //print the pop up text
            Console.WriteLine(ExpectedUpdateMsg);


            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            //driver.Quit();

            //////////////Deleting Education/////////////

            //select delete icon
            driver.FindElement(By.XPath("//td[contains(text(), 'India')]//preceding::i[2]")).Click();

            //verify item is delete using assertion
            string DeleteMsg = driver.FindElement(By.XPath("Education entry successfully removed")).Text;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            string ExpectedDeleteMsg = "Education entry successfully removed";
            Assert.AreEqual(ExpectedDeleteMsg, DeleteMsg);
            Console.WriteLine(ExpectedDeleteMsg);




        }
    }
}
