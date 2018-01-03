using System;
using Xamarin.Forms;

/*
 * Author   :   Thimira Andradi
 * Date     :   10th July 2017
 * Company  :   CHML IT - Development
 * Legal    :   All Rights Reserved | CHML IT | Development Team
 */

namespace CCFS
{
	/*
     * Class    :   App   
     * Remark   :   This is the Application Class of the App
     */

	public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            InitPCLStore();

            /*
             * Task         :   Sets content pages to Navigation Stack                
             * Arguments    :   Content page object (Main) --> new Main               
             */
            NavigationPage np = new NavigationPage(new Main())
            {
                BarBackgroundColor = Color.Black,
                BarTextColor = Color.LightGray,
            };

            MainPage = np;  //Sets Navigation object to Application MainPage


            /*
             * Event        :   Navigation Stack Object 'Popped' Event
             * Task         :   Get instance of Static Singleton object of 'Constants' to var 'con'.
             *                  Get current count (to var y) of Question Pages (not all pages) which are in Navigation Stack.
             * 
             * Condition    :   If var 'y' is larger than 0 , Substract the value of 'pageCount' attribute in 'Constants'.
             */

            np.Popped += delegate
            {
                PageGen.pageID = null;
              
            };

			
        }

        private async void InitPCLStore(){
            string res = await ActivityLogger.InitPCLStorage();
            Console.WriteLine(res);
        }

    }
}
