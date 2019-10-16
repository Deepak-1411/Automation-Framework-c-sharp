using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics
{
    class ChooseCard : DemoRun
    {


        public void SelectCard()
        {
            Takescreenshot();
            By cardsheader = By.XPath("//*[@id='header']/header/div[2]/div/div/div[3]/div/ul/li[5]/a");
            Click(cardsheader);
            By btnhelpmechooseacard = By.XPath("//*[@id='CrdHP_rec-me-a-card']");
            Click(btnhelpmechooseacard);
            Takescreenshot();
            By citymumbai = By.XPath("//*[@id='city1']");
            Click(citymumbai);
            Takescreenshot();

            By nextbutton = By.XPath("//*[@id='CrdHP_currentcity_next']");
            Click(nextbutton);
            By dobselection = By.XPath("//*[@id='userDetails']/div/div/div/div[2]/div[2]/div[3]/div/div/button/img");
            Click(dobselection);
            Datepicker("1992/Dec/08");
            StrictWait(10);
            By datenextbutton = By.XPath("//*[@id='CrdHP_dob_next']");
            Click(datenextbutton);
            By howofterflynextbutton = By.XPath("//*[@id='CrdHP_ff_next']");
            Click(howofterflynextbutton);
            By golfaccessckbox = By.XPath("//*[@id='lsbp4']");
            Click(golfaccessckbox);
            By wellnessofferbox = By.XPath("//*[@id='lsbp8']");
            Click(wellnessofferbox);
            By lifestylnxtbtn = By.XPath("//*[@id='CrdHP_lifestyle_next']");
            Click(lifestylnxtbtn);
            By spentnxtbtn = By.XPath("//*[@id='CrdHP_pm-spend_next']");
            Click(spentnxtbtn);
            By salrybutton = By.XPath("//input[@value='300000-500000']");
            Click(salrybutton);
            By grossanualsubmit = By.XPath("//*[@id='CrdHP_btn_submit-recommend']");
            Click(grossanualsubmit);
            Takescreenshot();
            StrictWait(10);

        }

        public void ChooseAmount() {
           By src = By.XPath("//div[@class='range-example-5 asRange']/div[3]/ul[@class='asRange-scale-lines']/li[1]");
             By dest = By.XPath("//div[@class='range-example-5 asRange']/div[3]/ul[@class='asRange-scale-lines']/li[3]");
            By slider = By.XPath("//div[@class='range-example-5 asRange']");

             DragandDrop(slider);
       /*   By inrAmount = By.XPath("//*[@id='unranged - value1']");
            Type(inrAmount, "200000");
            By doneAmount = By.XPath("//*[@id='CrdRC_btn_cal - ur - ff - asper - spend']/div[2]/div[3]/div/div[2]");
            Click(doneAmount);*/
        }

        public void compaircards()
        {
            By firstcard = By.XPath("//div[@class='select_compare']/input[@value='10']");
            Click(firstcard);
            Pagedown();
            By secoudcard = By.XPath("//div[@class='select_compare']/input[@value='11']");
            ActionsClick(secoudcard);
            By compairbutton = By.XPath("//button[contains(text(),'Compare Cards')]");
            Click(compairbutton);
        }
        public void ChooseCardScenario() { 
            
           CreatBrowserInstance();
           Openurl("https://www.jetprivilege.com/");
            SelectCard();
           ChooseAmount();
           compaircards();

            // run.Teardown();


        }
    }
}
