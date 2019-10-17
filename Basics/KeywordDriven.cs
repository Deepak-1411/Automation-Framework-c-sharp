using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Threading;
using AventStack.ExtentReports;

using AventStack.ExtentReports.Reporter;
using NUnit.Framework;

namespace Basics
{
    class KeywordDriven
    {/*keyword are input,page action,navigation,verify*/
     //inside input:switchToFrame,url,textbox,dropdown,dropdownbyvalue,dragandDropInStrip,button,datepicker
     //inside pageaction:pageDown,changeTab
     //inside the navigation:browserRefresh,NavigateToUrl,navigateBack
     //inside the verify:getText,getTitle,isDisplayed,Isenabled

     /*     static By locator;
          static String testdata;*/

        private static int count = 0;
        static IWebDriver driver;
        static ExtentHtmlReporter extentHtmlReport;
        static ExtentTest test = null;
        static ExtentReports report = null;
       static  string path = System.IO.Directory.GetCurrentDirectory();
        String cwd = Directory.GetCurrentDirectory();
        static DirectoryInfo path1 = Directory.GetParent(path);
        static DirectoryInfo path2 = Directory.GetParent(path1.ToString());
        static String currentpath = path2.ToString();
        static String picspath = currentpath + "\\screenshots";
        static String reportpath = currentpath + "\\reports";
        


        public static void Script(String jsonpath,String testname)
        {

            Directory.CreateDirectory(picspath);
            JObject data = JObject.Parse(File.ReadAllText(@jsonpath));
            var data1 = (JArray)data["scriptstep"];
            var count = (data1.Count);
            Console.WriteLine(count);
            var minus = count-1;
            Console.WriteLine(" after "+minus);
             driver = new ChromeDriver();
            IWebElement element = null;
            KeywordDriven d = new KeywordDriven();
            ExtentReportGeneration(testname);


        //apply loop here
       for (int i = 0; i <= minus; i++)
            {
               
                var data2 = data1[i];
                var keyword = data2["keyword"].ToString();
                var fieldType = data2["fieldType"].ToString();
                var testdata = data2["testdata"].ToString();
                var locator = By.XPath(data2["selector"].ToString());
                var stepnumber = data2["stepno"].ToString();
                var stepdescription = data2["stepdescription"].ToString().Replace(" ","_");
                Boolean button = false;
                


                Console.WriteLine("Step Number is :"+" "+stepnumber+" "+"keyword :" + " " + keyword + " " + "FieldType is :" + " " + fieldType+" "+ "testdata is::"+testdata);

                switch (keyword) 
                {
                    case "input":
                        switch (fieldType)
                        {
                            case "url"://urlshould be passed as testdata
                                try
                                {
                                    Console.WriteLine("inside the url fieldType");
                                    Console.WriteLine("Browser is launched");
                                    driver.Url = testdata.ToString();
                                    driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(40);
                                    driver.Manage().Window.Maximize();
                                    Console.WriteLine("Browser and Url opened properly");
                                    test.Log(Status.Pass, "Browser and URL opened Properly");
                                    TakesScreenshot(stepdescription, testname);
                                    count++;
                                }
                                catch (Exception)
                                {
                                    test.Log(Status.Fail, "Unable to launch the browser and URL");
                                    TakesScreenshot(stepdescription + "Fail", testname);
                                    button = true;

                                }
                                break;

                            case "textbox":
                                try
                                {
                                    element = waitExplictly(locator);
                                    element.SendKeys(testdata);
                                    Console.WriteLine("Clicked at the locator");
                                    test.Log(Status.Pass, "Type the " + testdata + "in the" + locator);
                                    TakesScreenshot(stepdescription, testname);
                                    count++;
                                }
                                catch (Exception)
                                {
                                    test.Log(Status.Fail, "Unable to enter the " + testdata + "in the" + locator);
                                    TakesScreenshot(stepdescription+"fail", testname);
                                    button = true;
                                }
                                break;

                            case "dropdown":

                                try
                                {
                                    element = waitExplictly(locator);
                                    SelectElement oSelect = new SelectElement(element);
                                    oSelect.SelectByValue(testdata);
                                    test.Log(Status.Pass, "select " + testdata + " :Form the drop down" + locator);
                                    TakesScreenshot(stepdescription, testname);
                                    Console.WriteLine("Drop down action is performed and data " + testdata + " " + "is selected from Dropdown");
                                    count++;
                                }
                                catch (Exception)
                                {
                                    test.Log(Status.Fail, "unable select " + testdata + " :Form the drop down" + locator);
                                    TakesScreenshot(stepdescription+"fail", testname);
                                    button = true;
                                }
                                break;

                            case "dropdownbyvalue":

                                try
                                {
                                    element = waitExplictly(locator);
                                    SelectElement dd = new SelectElement(element);
                                    dd.SelectByValue(testdata);
                                    test.Log(Status.Pass, "select " + testdata + " :Form the drop down" + locator);
                                    TakesScreenshot(stepdescription, testname);
                                    Console.WriteLine("Drop down action is performed and data " + testdata + " " + "is selected from Dropdown");
                                    count++;
                                }
                                catch (Exception)
                                {
                                    TakesScreenshot(stepdescription, testname);
                                    test.Log(Status.Fail, "unable to select " + testdata + " :Form the drop down" + locator);
                                    button = true;
                                }
                                break;

                            case "dragandDropInStrip":

                                try
                                {
                                    int result = int.Parse(testdata);
                                    element = waitExplictly(locator);
                                    Actions act = new Actions(driver);
                                    act.DragAndDropToOffset(element, 0, result).Build().Perform();
                                    test.Log(Status.Pass, "Drag and Drop Operation perform in stip from 0 to :" + testdata);
                                    TakesScreenshot(stepdescription, testname);
                                    Console.WriteLine("Trying to Drag in the strip");
                                    count++;
                                }
                                catch (Exception)
                                {
                                    TakesScreenshot(stepdescription+"Fail", testname);
                                    test.Log(Status.Fail, "unable to Drag and Drop Operation perform in stip from 0 to :" + testdata);
                                    button = true;
                                }
                                break;

                            case "button":

                                try
                                {
                                    element = waitExplictly(locator);
                                    element.Click();
                                    TakesScreenshot(stepdescription, testname);
                                    test.Log(Status.Info, "Click operation peformed at " + locator);
                                    test.Log(Status.Pass, "Clicked at the locator");
                                    count++;
                                   
                                }

                                catch (Exception)
                                {
                                    test.Log(Status.Fail, "Unable to Click operation peformed at " + locator);
                                    TakesScreenshot(stepdescription+"fail", testname);
                                    addFailure("Failure");
                                    button = true;
                                   
                                }
                                break;

                            case "datepicker": //In testdata it should be in the formate of dd/mm/yyyy


                                try
                                {
                                    String[] date = testdata.Split('/');
                                    String day = date[0];
                                    String month = date[1];
                                    String year = date[2];

                                    By yearlocator = By.XPath("//select[@aria-label='Select year']");
                                    waitExplictly(yearlocator);
                                    element = driver.FindElement(yearlocator);
                                    SelectElement select = new SelectElement(element);
                                    select.SelectByText(year);
                                    By monthselection = By.XPath("//select[@data-handler='selectMonth']");
                                    waitExplictly(monthselection);
                                    element = driver.FindElement(monthselection);
                                    select.SelectByText(month);
                                    By datelocator = By.XPath("//a[contains(text()," + day + ")]");
                                    waitExplictly(datelocator);
                                    element = driver.FindElement(datelocator);
                                    select.SelectByText(day);
                                    test.Log(Status.Pass, "Date picker operation is performed in ");
                                    TakesScreenshot(stepdescription, testname);
                                    count++;
                                }
                                catch (Exception)
                                {
                                    TakesScreenshot(stepdescription + "fail", testname);
                                    test.Log(Status.Fail, "Date picker operation is not performed ");
                                    button = true;
                                }
                                break;

                            case "switchToFrame"://testdata pass the name of the frame

                                try
                                {
                                    driver.SwitchTo().Frame(testdata);
                                    test.Log(Status.Pass, "Switched to the Frame " + testdata);
                                    TakesScreenshot(stepdescription, testname);
                                    Console.WriteLine("Switched to the frame");
                                    count++;
                                }
                                catch (Exception)
                                {
                                    test.Log(Status.Fail, "Unable to Switched to the Frame " + testdata);
                                    button = true;
                                }
                                break;
                        }
                 
                        break;

                    case "pageAction":
                        switch (fieldType)
                        {
                            case "pageDown":
                                try
                                {
                                    d.fixedwait(2);
                                    Actions act = new Actions(driver);
                                    act.SendKeys(Keys.PageDown).Build().Perform();
                                    test.Log(Status.Pass, "Page down action is performed");
                                    TakesScreenshot(stepdescription, testname);
                                    count++;
                                }
                                catch (Exception)
                                {
                                    test.Log(Status.Fail, "Unable to perform page down action");
                                    button = true;
                                }
                                break;

                            case "changeTab":
                                d.fixedwait(2);
                                try
                                {
                                    string newTabHandle = driver.WindowHandles.Last();
                                    var newTab = driver.SwitchTo().Window(newTabHandle);
                                    d.fixedwait(20);
                                    driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(20);
                                    test.Log(Status.Pass, "Tab changed to the next tab");
                                    TakesScreenshot(stepdescription, testname);
                                    Console.WriteLine("switched to the new tab");
                                    count++;
                                }
                                catch (Exception)
                                {
                                    TakesScreenshot(stepdescription+"Fail", testname);
                                    test.Log(Status.Fail,"unable to changed to the next tab");
                                    button = true;
                                }
                                break;
                        }
                        break;

                    case "navigate":
                        switch (fieldType)
                        {
                            case "browserRefresh":
                                try
                                {
                                    d.fixedwait(2);
                                    driver.Navigate().Refresh();
                                    Console.WriteLine("Browser is refreshed");
                                    test.Log(Status.Pass, "Browser refreshed");
                                    TakesScreenshot(stepdescription, testname);
                                    count++;
                                }
                                catch (Exception)
                                {
                                    TakesScreenshot(stepdescription+"fail", testname);
                                    test.Log(Status.Fail, "error while Refreshing Browser");
                                    button = true;
                                }
                                break;

                            case "NavigateToUrl": // testdata should contain the url
                                d.fixedwait(2);
                                try
                                {
                                    driver.Navigate().GoToUrl(testdata);
                                    test.Log(Status.Pass, "Navigated to the url" + testdata);
                                    TakesScreenshot(stepdescription, testname);
                                    Console.WriteLine("Naviagated to the URL:" + testdata);
                                    count++;
                                }
                                catch (Exception)
                                {
                                    TakesScreenshot(stepdescription+"Fail", testname);
                                    test.Log(Status.Fail, "Navigated to the url" + testdata);
                                    button = true;
                                }
                                break;

                            case "navigateBack":
                                d.fixedwait(2);
                                try
                                {
                                    driver.Navigate().Back();
                                    test.Log(Status.Pass, "Navigated back ");
                                    TakesScreenshot(stepdescription, testname);
                                    Console.WriteLine("Navigated back");
                                    count++;
                                }
                                catch (Exception)
                                {
                                    TakesScreenshot(stepdescription+"Fail", testname);
                                    test.Log(Status.Fail, "Unable to Navigated back ");
                                    button = true;
                                }
                                break;
                        }
                        break;

                    case "verify":
                        switch (fieldType)
                        {
                            case "getText"://code to get the text from locator
                                d.fixedwait(2);
                                element = waitExplictly(locator);
                                String text = element.Text;

                                TakesScreenshot(stepdescription, testname);
                                Console.WriteLine(text);
                                break;
                            case "getTitle":
                                d.fixedwait(2);
                                String title = driver.Title;
                                Console.WriteLine("Title of the Current Window is " + title);
                                break;
                            case "isDisplayed":
                                d.fixedwait(2);
                                Console.WriteLine("varifying Element is displayed or not");
                                element = waitExplictly(locator);
                                Console.WriteLine("For Keyword" + " " + keyword + "and fiel type" + " " + fieldType + "element is" + element.Displayed);
                                break;
                            case "Isenabled":
                                d.fixedwait(2);
                                Console.WriteLine("check whether element is enabled or not");
                                element = waitExplictly(locator);
                                Console.WriteLine("For Keyword" + " " + keyword + "and fiel type" + " " + fieldType + "element is" + element.Enabled);
                                break;
                        }
                        break;

                }
                if (button)
                    break;
            }
           
            report.Flush();
           driver.Quit();
        }
        public void fixedwait(int secs) {
            Thread.Sleep(secs * 1000);
        }

       public static IWebElement waitExplictly(By loc)
        {
            IWebElement elem=null;
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
                elem = wait.Until(ExpectedConditions.ElementIsVisible(loc));
                Console.WriteLine("Element Found: " + loc);
            }
            catch (Exception)
            {
                Console.WriteLine("Element not Found: " + loc);
            }
            return elem;
        }

        public static void  TakesScreenshot(String stepdescription,String Testname) {


            String picturepath = picspath + "\\" + Testname ;
            if (!Directory.Exists(picturepath)){
                Directory.CreateDirectory(picturepath);
            }
        // Console.WriteLine("Current working directory : " + currentpath);
          ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(picturepath+ "\\" + "_" + stepdescription + ".jpeg", ScreenshotImageFormat.Jpeg);
          test.AddScreenCaptureFromPath(picspath +"\\"+ "_" + stepdescription + ".jpeg");
            

        }
        public static void Main(String[] args) {
         Script("D:\\csharp\\JsonData\\test1.json","Scenario1");
         Script("D:\\csharp\\JsonData\\test2.json", "Scenario2");
         Script("D:\\csharp\\JsonData\\test3.json", "Scenario3");
         Script("C:\\Users\\MR\\Downloads\\testJSONBoA.json","BankOfAmerica");

        }

        public static  void ExtentReportGeneration(String Testname) {
            String date = DateTime.Now.ToString("HH:mm:ss");
            String date1 = date.Replace(":", "_");
          
            extentHtmlReport = new ExtentHtmlReporter(reportpath + "\\AutomationReport"+ Testname+"_"+ date1 + ".html");
            report = new AventStack.ExtentReports.ExtentReports();
            report.AttachReporter(extentHtmlReport);
            test = report.CreateTest(Testname);
        }

        public static void addFailure(String message)
        {
            try
            {
                Assert.Fail(message);
            }
            catch (AssertionException e)
            {
                test.Log(Status.Fail, e.GetBaseException());
                report.Flush();  
            }
           
        }
    }


}

