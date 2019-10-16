using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics
{
    class EnrollIntoApplication :DemoRun
    {
        
        public void enrol()
        {
            By enrollbutton = By.XPath("//*[@id='jp-adobe-enrol']/button");
            Click(enrollbutton);
            By mobilenumber = By.XPath("//*[@id='txtMobileNumber']");
            Type(mobilenumber, "987 654 3111");
            By emailid = By.XPath("//*[@id='txtemail']");
            Type(emailid, "india@free.com");
            Wait(5);
            By nameprefix = By.XPath("//*[@id='react-select-3--value']");
            Wait(5);
            Click(nameprefix);
            By mr = By.XPath("//*[@id='react-select-3--value']");
            //  Click(mr);
            By firstname = By.XPath("//*[@id='txtFirstName']");
            Type(firstname, "Sherlock");
            By lastname = By.XPath("//*[@id='txtlName']");
            Type(lastname, "Holmes");
            By dob = By.XPath("//*[@id='dob']");
            Type(dob, "14111992");
            By createpassword = By.XPath("//*[@id='txtEnrollPassword']");
            Type(createpassword, "123456@QAq");
            By confirmpassword = By.XPath("//*[@id='confirmpwdName']");
            Type(confirmpassword, "123456@QAq");
            By checkbox1 = By.XPath("//*[@id='chkPolicyLabel']/span[1]");
            Click(checkbox1);
            By termandcondtions = By.XPath("//*[@id='chkTermsLabel']/span[1]");
            Click(termandcondtions);
            Takescreenshot();
            By cancel = By.XPath("//*[@id='enrollContainer']/div/div/div/div[2]/form/div/div[11]/div[2]/div[2]/span/input");
            Click(cancel);
        }
      public void EnrollIntoApplicationScenario() {
           EnrollIntoApplication run = new EnrollIntoApplication();
            run.CreatBrowserInstance();
            run.Openurl("https://www.jetprivilege.com/");
            run.Takescreenshot();
            run.enrol();
            run.Takescreenshot();
            Console.WriteLine("End of the scenario");
         //   run.Teardown();
        }
    }
}
