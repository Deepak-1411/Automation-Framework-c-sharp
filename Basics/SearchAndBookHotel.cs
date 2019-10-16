using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics
{
    class SearchAndBookHotel:DemoRun
    {
        public void Searchhotel()
        {

            By hotels = By.XPath("//*[@id='header']/header/div[2]/div/div/div[3]/div/ul/li[2]/a");
            Click(hotels);
            Takescreenshot();
            By destination = By.XPath("//*[@id='HotelsJP_HP_WS_Search_Place']");
            Type(destination, "Mumbai, India");
            Wait(5);
            By bokingdate = By.XPath("//*[@id='HotelsJP_HP_WS_Search_CheckIn_Out']");
            Click(bokingdate);
            By bookingdatefrom = By.XPath("//*[@id='HotelsJP_Homepage_CheckIn']/div[2]/table/tbody/tr[5]/td[7]");
            Click(bookingdatefrom);
            By bookingdateto = By.XPath("//*[@id='HotelsJP_Homepage_CheckOut']/div[2]/table/tbody/tr[2]/td[3]");
            Click(bookingdateto);
            By hotelrooms = By.XPath("//*[@id='hotels_rooms']");
            Click(hotelrooms);
            By singleroom = By.XPath("//*[@id='firstrow']/li[1]/label");
            Click(singleroom);
            Wait(5);
            By submithotel = By.XPath("//*[@id='HotelsJP_HP_WS_Searchbtn']");
            Click(submithotel);
            Takescreenshot();
            Takescreenshot();
            By booknowbutton = By.XPath("//*[@id='HotelsJP_SL_Deals_FabHotel_Atlas_Plaza_Andheri_East']");
            Click(booknowbutton);
            By continueAsAguest = By.XPath("//*[text()='Continue as a Guest ']");
            Click(continueAsAguest);
            StrictWait(20);
            changeTab();
            StrictWait(20);
            GetTitle();
            Pageloadtimeout(30);
        }
        public void book_hotel1()
        {
            By reserveButtonForHotel = By.CssSelector("#app > div > div > div > div.uitk-flex.two-column-body > div.uitk-flex-grow-1.uitk-cell.l-x-padding-six.xl-x-padding-six > main > div.infosite__content.infosite__content--details > section > ul > li:nth-child(1) > div > section > div > div.uitk-cell.all-cell-fill > div > section:nth-child(1) > div > div.uitk-cell.all-y-padding-zero.all-cell-1-4.all-cell-fill.uitk-type-right.rate-plan__content > div.all-t-padding-one > div > div > button > span > span");
            Scrollintoview(reserveButtonForHotel);
            Click(reserveButtonForHotel);
            StrictWait(3);
            try
            {
                By paynow = By.XPath("//*[@id='app']/div/div[2]/div/div/div/section[2]/div/div[1]/div/div[2]/div[4]/div/div/form/button/span/span/span");
                Click(paynow);
            }catch(Exception e)
            {
                By paynow1 = By.XPath("//*[@id='app']/div/div[2]/div/div/div/section[2]/div/div[1]/div/div[2]/div[3]/div/div/form/button/span");
                Click(paynow1);

            }
           
        }
        public void book_hotel() {
            By hotelLink = By.XPath("//*[@id='hotellist_inner']/div[2]/div[2]/div[1]/div[1]/div[1]/h3/a");
            Click(hotelLink);
            changeTab();
            GetTitle();
            By reserve = By.XPath("//*[@id='hcta']/span[1]");
            Click(reserve);
            By roomCount = By.XPath("//*[@id='hprt_nos_select_212104803_203891617_1_1_0']");
            DropDownByValue(roomCount, "2");
            Wait(3);
            By iwillReserverBt = By.XPath("//div[@class='hprt-reservation-cta']/button[@type='submit']");
            Click(iwillReserverBt);
            StrictWait(20);
            By closethealert = By.XPath("//*[@id='b2bookPage']/div[13]/div[1]/div/div/div/div[2]/span");
            Click(closethealert);

        }
        public void enterDetails() {
            By title = By.XPath("//*[@id='booker_title']");
            Dropdown(title, "Mr.");
            By firsttName = By.XPath("//*[@id='firstname']");
            Type(firsttName, "Deepak");
            By lastname = By.XPath("//*[@id='lastname']");
            Type(lastname, "Pal");
            By email = By.XPath("//*[@id='email']");
            Type(email, "abc@xyz.com");
            By emailConfirmation = By.XPath("//*[@id='email_confirm']");
            Type(emailConfirmation, "abc@xyz.com");
            By mainguesBt = By.XPath("//*[@id='notstayer_false']");
            Click(mainguesBt);
            By finalDetails = By.XPath("//button[@name='book']");
            Click(finalDetails);
            By addmobileNumber = By.XPath("//*[@id='phone']");
            Type(addmobileNumber, "9876543211");
            By closethealert = By.XPath("//*[@id='b2bookPage']/div[14]/div[1]/div/div/div/div[2]/span");
            Click(closethealert);
        
        }
        public void CheckYourBoking() {
            By checkUrbookingBt = By.XPath("//*[@id='bookwrapper_cell']/div[4]/div[1]/button[1]/ins");
            Click(checkUrbookingBt);
        }
        public void paymentDetails()
        {
            By fullname = By.XPath("//*[@id='preferences']/fieldset/div[2]/fieldset/div[1]/label/input");
            Type(fullname, "Deepak Pal");
            By mobileNumber = By.XPath("//*[@id='preferences']/fieldset/div[2]/fieldset/div[1]/fieldset/div[2]/label/input");
            Type(mobileNumber, "0123456789");
            By creaditcardinput = By.XPath("//*[@id='creditCardInput']");
            Type(creaditcardinput, "1222232345456767");
            By expirymonth = By.XPath("//*[@id='payment - Type - creditcard']/div/form/fieldset/div/div/div[3]/div/fieldset/fieldset/label[1]/select");
            Dropdown(expirymonth, "06-Jun");
            By expiryYear = By.XPath("//*[@id='payment - Type - creditcard']/div/form/fieldset/div/div/div[3]/div/fieldset/fieldset/label[2]/select");
            Dropdown(expiryYear, "2023");
            By cardSecurityCode = By.XPath("//*[@id='new_cc_security_code']");
            Type(cardSecurityCode, "453");
            By emailAdd = By.XPath("//*[@id='email']/fieldset/div[1]/fieldset/label/input");
            Type(emailAdd, "abc@xyz.com");
            By createpassword = By.XPath("//*[@id='account - creation']/fieldset/label[1]/input");
            Type(createpassword, "qwertyasdfg");
            By confirmpassword = By.XPath("//*[@id='account - creation']/fieldset/label[2]/input");
            Type(confirmpassword, "qwertyasdfg");
            By completbookingbutton = By.XPath("//*[@id='complete - booking']");
            Click(completbookingbutton);
            Takescreenshot();
        }

       public void SearchHotelScenario() { 
           
            CreatBrowserInstance();
            Openurl("https://www.jetprivilege.com/");
            Takescreenshot();
            Searchhotel();
            Takescreenshot();
            book_hotel();
            Takescreenshot();
            enterDetails();
            Takescreenshot();
            CheckYourBoking();
            Takescreenshot();
          
            Takescreenshot();
        //    Teardown();
        }
    }
}
