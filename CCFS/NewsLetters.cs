using System;
using Xamarin.Forms;

/*
 * Author   :   Thimira Andradi
 * Date     :   9th August 2017
 * Company  :   CHML IT - Development
 * Legal    :   All Rights Reserved | CHML IT | Development Team
 */
namespace CCFS
{
    /*
	 * Class    :   NewsLetters
	 * Remark   :   From this class system will ask guest for enable newsletters
	 */
	public partial class NewsLetters : ContentPage
    {
        Constants con = Constants.Instance; // Creates the Singleton Object of 'Constants'

		public NewsLetters()
        {
            Title = "Promotions and Newsletters"; //Sets the title to the mainpage
            BackgroundColor = Color.Black;
            InitComp(); // Execute the method 'InitComp' for initialize User Interface elements
            NavigationPage.SetHasNavigationBar(this, false);//Remove inbuilt navigator

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
			titleImage.Source = ImageSource.FromFile("images/cinnamon.png");
			titleImage.HeightRequest = 150;

			var titleLabel = new Label
			{
				Text = "Would you like to recieve Cinnamon Promotions and News alerts?",
				FontSize = 24,
				HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
				TextColor = Color.White,
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				HeightRequest = 200

			};

            ElementController ec = new ElementController();
            var ynlayout = ec.GetDualOptionLayout("Yes", "No");

			ec.yesPic.Opacity = 1;
			ec.noPic.Opacity = 1;

			ec.firstLabel.TextColor = Color.White;
			ec.secondLabel.TextColor = Color.White;

			//Navigation

			var baseLayout = new StackLayout();
			baseLayout.Orientation = StackOrientation.Vertical;
			baseLayout.HorizontalOptions = LayoutOptions.Center;
			baseLayout.VerticalOptions = LayoutOptions.Center;

			var buttonPanel = new StackLayout();
			buttonPanel.Orientation = StackOrientation.Horizontal;
			buttonPanel.HorizontalOptions = LayoutOptions.Center;

			var nextBtn = new Image { Aspect = Aspect.AspectFit };
			nextBtn.Source = ImageSource.FromFile("images/next.png");
			nextBtn.WidthRequest = 60;
			nextBtn.HeightRequest = 60;
			nextBtn.HorizontalOptions = LayoutOptions.EndAndExpand;
			nextBtn.Margin = new Thickness(820, 60);

			var backBtn = new Image { Aspect = Aspect.AspectFit };
			backBtn.Source = ImageSource.FromFile("images/back.png");
			backBtn.WidthRequest = 60;
			backBtn.HeightRequest = 60;
			backBtn.HorizontalOptions = LayoutOptions.StartAndExpand;
			backBtn.Margin = new Thickness(10, 60);

			buttonPanel.Children.Add(backBtn);
			buttonPanel.Children.Add(nextBtn);

			baseLayout.Children.Add(buttonPanel);

			//Set Temp Data
			var heatTemp = con.GetTempValue("news");

			if (heatTemp == "1")
			{
				ec.yesPic.Opacity = 1;
				ec.noPic.Opacity = 0.25;

				ec.firstLabel.TextColor = Color.Green;
				ec.secondLabel.TextColor = Color.Gray;

			}
			else if (heatTemp == "0")
			{

				ec.yesPic.Opacity = 0.25;
				ec.noPic.Opacity = 1;

				ec.firstLabel.TextColor = Color.Gray;
				ec.secondLabel.TextColor = Color.Red;

			}
			else
			{
				//Do nothing
			}


			/*
             * Event        :   Yes Button 'Tapped' Event
             * Task         :   Asynchronously pushing content page object 'ContactDetails' into the Navigation stack
             * Arguments    :   Content page object (ContactDetails) --> new ContactDetails                
             */

			var yesTapRecognizer = new TapGestureRecognizer();
            yesTapRecognizer.Tapped += async (s, e) =>
            {

				ec.yesPic.Opacity = 1;
				ec.noPic.Opacity = 0.25;

				//Animating 
				await ec.yesPic.ScaleTo(2, 150, Easing.SinIn);
				await ec.yesPic.ScaleTo(1, 150, Easing.SinOut);

				ec.firstLabel.TextColor = Color.Green;
				ec.secondLabel.TextColor = Color.Gray;

				//Save Temp Selection Data
				con.RemoveFromTempNVC("news");
				con.AddToTempNVC("news", "1");

				//Set 500ms delay for loading next page
				Device.StartTimer(TimeSpan.FromSeconds(0.5), () =>
				{
					Navigation.PushAsync(new ContactDetails());
					return false;
				});


            };


			/*
             * Event        :   No Button 'Taped' Event
             * Task         :   Asynchronously pushing content page object 'EndPage' into the Navigation stack
             * Arguments    :   Content page object (EndPage) --> new EndPage                
             */

			var noTapRecognizer = new TapGestureRecognizer();
			noTapRecognizer.Tapped += async (s, e) =>
			{
				ec.yesPic.Opacity = 0.25;
				ec.noPic.Opacity = 1;

				//Animating 
				await ec.noPic.ScaleTo(2, 150, Easing.SinIn);
				await ec.noPic.ScaleTo(1, 150, Easing.SinOut);

				ec.firstLabel.TextColor = Color.Gray;
				ec.secondLabel.TextColor = Color.Red;

				//Save Temp Selection Data
				con.RemoveFromTempNVC("news");
				con.AddToTempNVC("news", "0");

				//Set 500ms delay for loading next page
				Device.StartTimer(TimeSpan.FromSeconds(0.5), () =>
				{
					Navigation.PushAsync(new EndPage());
					return false;
				});

			};

            ec.yesPic.GestureRecognizers.Add(yesTapRecognizer);
            ec.noPic.GestureRecognizers.Add(noTapRecognizer);

			var backtapRecognizer = new TapGestureRecognizer();
			backtapRecognizer.Tapped += (s, e) =>
			{
				Navigation.PopAsync();
			};

			var NexttapRecognizer = new TapGestureRecognizer();
			NexttapRecognizer.Tapped += (s, e) =>
			{
				try
				{
					if (heatTemp == "0")
					{
						Navigation.PushAsync(new EndPage());
					}
					else if (heatTemp == "1")
					{
						Navigation.PushAsync(new ContactDetails());
					}
					else
					{

					}
				}
				catch (Exception) { }
			};

			backBtn.GestureRecognizers.Add(backtapRecognizer);
			nextBtn.GestureRecognizers.Add(NexttapRecognizer);


			layout.Children.Add(titleImage);
            layout.Children.Add(titleLabel);
            layout.Children.Add(ynlayout);
            layout.Children.Add(baseLayout);

			layout.Padding = 10;
			layout.Spacing = 10;

			Content = layout;
        }
    }
}
