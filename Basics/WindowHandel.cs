using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics
{
    class WindowHandel : DemoRun
    {
        public void ChildWindow() {
            CreatBrowserInstance();
            Openurl("https://www.toolsqa.com/automation-practice-switch-windows/");
            GetTitle();
            StrictWait(10);
            By newBrowsewindowbutton = By.XPath("//button[contains(text(),'New Browser Window')]");
            By scroll = By.XPath("//*[@id='content']/div[1]/div[2]/div/div/div/div/p[1]/span/a/em/strong");
            Scrollintoview(scroll);
            Click(newBrowsewindowbutton);
            Console.WriteLine(driver.WindowHandles.Count);
            string NewWindowHandle = driver.WindowHandles.Last();
            var NewWindow = driver.SwitchTo().Window(NewWindowHandle);
            GetTitle();
            NUnit.Framework.Assert.AreEqual(GetTitle(), "Free QA Automation Tools Tutorial for Beginners with Examples");
            Pagedown();
            driver.SwitchTo().Window(driver.WindowHandles[0]);
            GetTitle();
            Teardown();

        }
        public void HandlenewBrowserTab() {
            CreatBrowserInstance();
            Openurl("https://www.toolsqa.com/automation-practice-switch-windows/");
            GetTitle();
            StrictWait(10);
            By scrolllocator = By.XPath("//*[@id='button1']");
            Scrollintoview(scrolllocator);
            IWebElement alertButton = driver.FindElement(By.XPath("//*[@id='content']/div[1]/div[2]/div/div/div/div/p[5]/button"));
            alertButton.Click();


            GetTitle();
            //code to switch to the new window
            string newTabHandle = driver.WindowHandles.Last();
            var newTab = driver.SwitchTo().Window(newTabHandle);
            GetTitle();

            //code to switch to the first window
           var originalTab = driver.SwitchTo().Window(driver.WindowHandles.First());
            GetTitle();
            Teardown();
        }


        
    }
}
