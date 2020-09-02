using NUnit.Framework;
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
    class Skills
    {
        static void Main()
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
            //Find Skills element and click
            driver.FindElement(By.XPath("//div[@class='ui top attached tabular menu']/a[2]")).Click();

            //Find Add New element and click
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//div[@class='ui teal button']")).Click();
            //find Add Skill element and enter skill
            driver.FindElement(By.XPath("//input[@name='name']")).SendKeys("Linux");
            //Find dropdown element and click
            driver.FindElement(By.XPath("//select[@class='ui fluid dropdown']")).Click();
            //Find element for selected skill level and click
            driver.FindElement(By.XPath("//option[contains(text(),'Beginner')]")).Click();
            //Find element for Add button and click
            driver.FindElement(By.XPath("//input[@value='Add']")).Click();
            Thread.Sleep(2000);
            //handel the confirmation popup for add

            //verify you getting the notification that skill is added
            String SkillAddedMsg = driver.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']/div")).Text;

            String ExpectedAddMessage = "Linux has been added to your skills";

            Assert.AreEqual(SkillAddedMsg, ExpectedAddMessage);
            //print the pop up text
            Console.WriteLine("Test Passed");

            
            
            
            

            Thread.Sleep(4000);
            /////////EDIT/UPDATE SKILLS////

            //select update sign and click
            driver.FindElement(By.XPath("//tbody[4]//tr/td[3]/span/i[@class='outline write icon']")).Click();

            //clear the existing data
            driver.FindElement(By.XPath("//input[@name='name']")).Clear();
            Thread.Sleep(4000);
            //update the Add skill field 
            driver.FindElement(By.XPath("//input[@name='name']")).SendKeys("Linux basic");
            //click on update button
            driver.FindElement(By.XPath("//input[@type='button' and @value='Update']")).Click();
            Thread.Sleep(4000);

            //verify the updated skill(popup identifire will be generated)
            string UpdateMsg = driver.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']/div")).Text;

            String ExpectedUpdateMsg = "Linux basic has been updated to your skills";

            Assert.AreEqual(UpdateMsg, ExpectedUpdateMsg);
            Console.WriteLine("Test Passed");

            //string updatetext = driver.SwitchTo().Alert().Text;
            Thread.Sleep(3000);





            //input[@placeholder = "Add Skill"]



            ////////////DELETE SKILL//////
            //find the element for delete sign and clcik
            driver.FindElement(By.XPath("//tbody[4]//tr[1]//td[3]//span[2]//i[1]")).Click();
            Thread.Sleep(3000);

            //verify that the skill is deleted by getting a confirmation message
            string DeleteMsg = driver.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']/div")).Text;
            Thread.Sleep(3000);

            String ExpectedDeleteMsg = "Linux basic has been deleted";

            Assert.AreEqual(DeleteMsg, ExpectedDeleteMsg);
            Console.WriteLine("Test Passed");
            




        }
    }
}
