using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics
{
    class Runnerclass
    {
        public static void Main11(String[] args) {
            WindowHandel r = new WindowHandel();
        
            Basics.EnrollIntoApplication run = new EnrollIntoApplication();
     
            SearchAndBookHotel run2 = new SearchAndBookHotel();
           
            ChooseCard run3 = new ChooseCard();
       //    r.HandlenewBrowserTab();
      //     r.ChildWindow();
       //    run.EnrollIntoApplicationScenario();
     //      run2.SearchHotelScenario();
           run3.ChooseCardScenario();
           
           Console.WriteLine("All scenario is exicuted");
        }
    }
}
