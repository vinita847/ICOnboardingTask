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

            //verify that item is added


            //////////////updating Education////////////////
            //select update icon and click
            //edit/update university field

            //edit/update country

            //click on add button

            //verify the updated entry

            //////////////Deleting Education/////////////

            //select delete icon

            //verify item is deleted


        }
    }
}
