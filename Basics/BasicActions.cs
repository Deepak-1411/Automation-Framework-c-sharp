using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;

namespace Basics
{

    class DemoRun
    {
        public IWebDriver driver;
        private Actions actions= null;
        private int count = 0;
        private WebDriverWait wait;

        public void CreatBrowserInstance() {
            driver= new ChromeDriver("D:\\csharp");
            Console.WriteLine("Browser Instance is Created");
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(100));
        }
        public void Openurl(String path)
        {
            try {
                CreatBrowserInstance();
                Console.WriteLine("Browser is launched");
                driver.Url = path;
                Pageloadtimeout(10);
                driver.Manage().Window.Maximize();
                Console.WriteLine("Browser and Url opened properly");
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(40);
            }
            catch (Exception e) {
               Console.WriteLine(e.Message);
            }
    
        }
        public void MaximizeWindow() {
            driver.Manage().Window.Maximize();
        }
        public void ArrowDown()
        {
            actions = new Actions(driver);
            actions.SendKeys(Keys.ArrowDown).Perform();
            Console.WriteLine("Clicked the Arrow down button");
        }
        public void Pageloadtimeout(int secs) {
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(secs);
        }

        public void Takescreenshot()
        {
            String classname = this.GetType().Name;
            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(@"D:\csharp\pics\"+classname+"_"+count+ ".jpeg", ScreenshotImageFormat.Jpeg);
            Console.WriteLine("ScreenShot is Taken");
            count++;
        }

        public void Wait(int secs)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(secs);
            Console.WriteLine("Waited for the " + secs);
        }
        public void StrictWait(int secs)
        {
            System.Threading.Thread.Sleep(secs*1000);
        }
        public void Click(By loc)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(loc));
            IWebElement element = driver.FindElement(loc);
            element.Click();
            Console.WriteLine("Clicked at the locator");
        }
        public void DragandDrop(By src) {
            wait.Until(ExpectedConditions.ElementIsVisible(src));
           
            IWebElement src1 = driver.FindElement(src);
    
            Actions act = new Actions(driver);
            act.DragAndDropToOffset(src1,0,30).Build().Perform();
            Console.WriteLine("Trying to Drag in");
          


        }


        public void ActionsClick(By loc)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(loc));
            IWebElement element = driver.FindElement(loc);
          
            actions.SendKeys(Keys.PageDown).Perform();

            actions.MoveToElement(element).Perform();
        }

        public void Type(By loc, String value)
        {
        //    wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(loc));
            IWebElement element = driver.FindElement(loc);
            element.Click();
            element.SendKeys(value);
            Console.WriteLine("Typed the " + value + " " + "in the ");
        }
        public void Cleartext(By loc)
        {
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(loc));
            IWebElement element = driver.FindElement(loc);
            Wait(2);
            element.Clear();
        }
        public void Teardown()
        {
            Console.WriteLine("Closed the Browser");
            driver.Quit();
        }
        public void Closewindow()
        {
            Console.WriteLine("Close the current window");
            driver.Close();
        }
        public void DropDownByValue(By loc, String data) {
       //     wait.Until(ExpectedConditions.ElementToBeSelected(loc));
            IWebElement element = driver.FindElement(loc);
            SelectElement oSelect = new SelectElement(element);
            oSelect.SelectByValue(data);
            Console.WriteLine("Drop down action is performed and data " + data + " " + "is selected from Dropdown");

        }
        public void Dropdown(By loc, String data)
        {
         
            IWebElement element = driver.FindElement(loc);
            SelectElement oSelect = new SelectElement(element);
            oSelect.SelectByText(data);
            Console.WriteLine("Drop down action is performed and data " + data + " " + "is selected from Dropdown");
        }
        public void Datepicker(String yyyymmmdd)
        {
            String[] splitteddate = yyyymmmdd.Split('/');
            String year = splitteddate[0];
            String month = splitteddate[1];
            String date = splitteddate[2];
            By yearlocator = By.XPath("//select[@aria-label='Select year']");
            Dropdown(yearlocator, year);
       
            By monthselection = By.XPath("//select[@data-handler='selectMonth']");
            Dropdown(monthselection, month);
     
            By datelocator = By.XPath("//a[contains(text()," + date + ")]");
            Click(datelocator);
            Console.WriteLine("Date picker is performed and choose a " + date + "/" + month + "/" + year);

        }
        public void Totalwindows()
        {
           
            List<String> windows = driver.WindowHandles.ToList();
            Console.WriteLine("Totle Number of the windows present in browser");
            Console.WriteLine(windows);
        }

        public string GetTitle()
        {
            String mytitle = driver.Title;
            Console.WriteLine("Title of the current Webpage is :"+mytitle);
            return mytitle;
        }
        public void Scrollintoview(By loc)
        {
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(loc));
            IWebElement webelement = driver.FindElement(loc);
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
           jse.ExecuteScript("arguments[0].scrollIntoView()", webelement);
            Console.WriteLine("Scrolled to the element :" + loc);
        }
        public void Switchtoframe(String name)
        {
            wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(name));
            driver.SwitchTo().Frame(name);
            Console.WriteLine("Switched to the frame");
        }
        public void Pagedown()
        {
            Actions act = new Actions(driver);
            act.SendKeys(Keys.PageDown).Build().Perform();
        }
        public void changeTab()
        {
            string newTabHandle = driver.WindowHandles.Last();
            var newTab = driver.SwitchTo().Window(newTabHandle);
            Console.WriteLine("switched to the new tab");
        }
        public void NavigateToURL(String url)
        {
            driver.Navigate().GoToUrl(url);
            Console.WriteLine("Naviagated to the URL:" + url);
        }
        public void Navigateback()
        {
            driver.Navigate().Back();
            Console.WriteLine("naviagated to the backword");
        }
        public void BrowserRefresh()
        {
            driver.Navigate().Refresh();
            Console.WriteLine("Browser is refreshed");
        }
    } //Class closing
} //nname space closing