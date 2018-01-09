using System;
using System.Diagnostics;
using System.Threading;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;

/*
 * Author   :   Thimira Andradi
 * Date     :   9th Aug 2017
 * Company  :   CHML IT - Development
 * Legal    :   All Rights Reserved | CHML IT | Development Team
 */

namespace CCFS
{
	/*
	 * Class    :   EndPage
	 * Remark   :   This is the Final Content page class
	 */
	public partial class EndPage : ContentPage
    {
        public EndPage()
        {
            BackgroundColor = Color.Black;
            InitComp(); // Execute the method 'InitComp' for initialize User Interface elements
            Constants con = Constants.Instance; // Creates the Singleton Object of 'Constants'

            NavigationPage.SetHasNavigationBar(this, false);
		}

		/*
         * Method       :   InitComp
         * Task         :   Creates Page UI Dynamically
         */
		private void InitComp(){
			var layout = new StackLayout();
            layout.BackgroundColor = Color.Black;
            layout.VerticalOptions = LayoutOptions.CenterAndExpand;

			var titleImage = new Image { Aspect = Aspect.AspectFit };
			titleImage.Source = ImageSource.FromFile("images/lifestyle.png");
            titleImage.HeightRequest = 300;

			var thankLabel = new Label
			{
				Text = "Thank You!",
				FontSize = 40,
				HorizontalTextAlignment = TextAlignment.Center,
				TextColor = Color.White,
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				HeightRequest = 100

			};

			var welcomeLabel = new Label
			{
				Text = "Have A Wonderful Day!",
				FontSize = 24,
				HorizontalTextAlignment = TextAlignment.Center,
                TextColor = Color.White,
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				HeightRequest = 200

			};

            var titleLabel = new Label
            {
                Text = "We value your feedback and thank you very much for selecting Cinnamon.",
                FontSize = 24,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
				TextColor = Color.White,
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				HeightRequest = 300

			};

			var copyrightLabel = new Label
			{
				Text = "Designed and developed By Cinnamon IT | Copyrights © 2017",
				FontSize = 12,
				HorizontalTextAlignment = TextAlignment.Center,
                TextColor = Color.DarkGray,
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				HeightRequest = 200

			};

            var endButton = new Button
            {
                Text="Finish",
                FontSize=24,
                HorizontalOptions=LayoutOptions.CenterAndExpand,
                HeightRequest=60,
                WidthRequest=150
            };

			/*
             * Event        :   end Button 'Clicked' Event
             * Task         :   End Application thread               
             */
             
			endButton.Clicked+=  async delegate {
                endButton.IsEnabled = false;

				//DateTime localDate = DateTime.Now;
                //SaveRatings.SaveRatingInstance._endTime = localDate.ToString();

                //SaveRatings.SaveRatingInstance.SaveRating(); // Save Data
                ActivityLogger.AddLogger("*************** Finish button pressed *******************");

                await Navigation.PopToRootAsync();
                                    
			};

            layout.Children.Add(thankLabel);
            layout.Children.Add(welcomeLabel);
			layout.Children.Add(titleImage);
			layout.Children.Add(titleLabel);
            layout.Children.Add(endButton);
			layout.Children.Add(copyrightLabel);

			layout.Padding = 10;
			layout.Spacing = 10;

			Content = layout;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ActivityLogger.AddLogger("Finish page On Appearing... Feedback data saved.");

            DateTime localDate = DateTime.Now;
            SaveRatings.SaveRatingInstance._endTime = localDate.ToString();

            //SaveRatings.SaveRatingInstance.SaveRating(); // Save Data
        }

    }

}
