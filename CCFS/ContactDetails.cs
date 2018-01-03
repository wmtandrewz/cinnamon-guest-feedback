using System.Linq;
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
	 * Class    :   ContactDetails
	 * Remark   :   From this class system will request Contact details of guest for sending newsletters
	 */
	public partial class ContactDetails : ContentPage
    {

        private Entry guestPhoneEditor,guestMailEditor;
        private Validation validator;
        private bool validated = false;

        public ContactDetails()
        {
            Title = "Contact Details"; //Sets the title to the mainpage
            BackgroundColor = Color.Black;
            InitComp(); // Execute the method 'InitComp' for initialize User Interface elements
            NavigationPage.SetHasNavigationBar(this, false);//Remove inbuilt navigator

			Constants con = Constants.Instance; // Creates the Singleton Object of 'Constants'
            validator = new Validation();

		}

		/*
         * Method       :   InitComp
         * Task         :   Creates Page UI Dynamically
         */
		private void InitComp(){
			var layout = new StackLayout();
            layout.BackgroundColor = Color.Black;
            layout.VerticalOptions = LayoutOptions.StartAndExpand;

			var titleImage = new Image { Aspect = Aspect.AspectFit };
			titleImage.Source = ImageSource.FromFile("images/cinnamon.png");
			titleImage.HeightRequest = 150;

			var titleLabel = new Label
			{
				Text = "Please provide your contact details",
				FontSize = 24,
				HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
				TextColor = Color.White,
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				HeightRequest = 200

			};

			var formLayout = new StackLayout();
			formLayout.Orientation = StackOrientation.Vertical;
			formLayout.VerticalOptions = LayoutOptions.StartAndExpand;

			var guestPhoneLabel = new Label
			{
				Text = "Mobile Phone Number",
				FontSize = 18,
				TextColor = Color.White,
                HorizontalTextAlignment = TextAlignment.Start,
                VerticalTextAlignment = TextAlignment.Center,
				VerticalOptions = LayoutOptions.Start,
				HeightRequest = 40,
			};

			 guestPhoneEditor = new Entry
			{
				Placeholder = "Your Mobile Number",
                Text=SaveRatings.SaveRatingInstance._guestPhone,
				HeightRequest = 40,
				Keyboard = Keyboard.Telephone
			};

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

			/*
             * Event        :   guestPhoneEditor Completed Event
             * Task         :   Sets entered phone Number to 'SaveRatings' properties
             */
			guestPhoneEditor.TextChanged+=delegate {

                if(guestPhoneEditor.Text.Length>13){
                    guestPhoneEditor.Text= guestPhoneEditor.Text.Remove(guestPhoneEditor.Text.Length - 1);
   				}

     //           if(!guestPhoneEditor.Text.All(char.IsDigit)){
					//guestPhoneEditor.Text = guestPhoneEditor.Text.Remove(guestPhoneEditor.Text.Length - 1);
                //}

                if(validator.MobileNumberValidator(guestPhoneEditor.Text)){
                    guestPhoneEditor.BackgroundColor = Color.LimeGreen;
                    validated = true;
                }else{
                    guestPhoneEditor.BackgroundColor = Color.Red;
                    validated = false;
                }

				SaveRatings sr = SaveRatings.SaveRatingInstance;
                sr._guestPhone = guestPhoneEditor.Text;
            };

            guestPhoneEditor.Completed += delegate
            {
                guestMailEditor.Focus();
            };

            var guestMailLabel = new Label
            {
                Text = "E Mail Address",
                FontSize = 18,
                TextColor = Color.White,
                VerticalOptions = LayoutOptions.Start,
                HorizontalTextAlignment = TextAlignment.Start,
                VerticalTextAlignment = TextAlignment.Center,
                HeightRequest = 40,
            };

            guestMailEditor = new Entry
            {
                Placeholder = "Your e mail",
                HeightRequest = 40,
                Text = SaveRatings.SaveRatingInstance._guestEmail,
                Keyboard = Keyboard.Email
            };

            /*
             * Event        :   guestMailEditor Completed Event
             * Task         :   Sets entered email to 'SaveRatings' properties
             */
            guestMailEditor.TextChanged += delegate
            {

                if (validator.EmailValidator(guestMailEditor.Text))
                {
                    guestMailEditor.BackgroundColor = Color.LimeGreen;
                    validated = true;
                }
                else
                {
                    guestMailEditor.BackgroundColor = Color.Red;
                    validated = false;
                }

                SaveRatings sr = SaveRatings.SaveRatingInstance;
                sr._guestEmail = guestMailEditor.Text;
			};


            var backtapRecognizer = new TapGestureRecognizer();
            backtapRecognizer.Tapped += (s, e) =>
            {
                Navigation.PopAsync();
            };

            var NexttapRecognizer = new TapGestureRecognizer();
            NexttapRecognizer.Tapped += (s, e) =>
            {
                if(validated){
                    
                    ActivityLogger.AddLogger("Contact details entered and validated");

                    Navigation.PushAsync(new EndPage());
                }

            };

            backBtn.GestureRecognizers.Add(backtapRecognizer);
            nextBtn.GestureRecognizers.Add(NexttapRecognizer);

            //---------------------------------------------------------

            layout.Children.Add(titleImage);
            layout.Children.Add(titleLabel);
            layout.Children.Add(formLayout);
            layout.Children.Add(baseLayout);

            formLayout.Children.Add(guestPhoneLabel);
            formLayout.Children.Add(guestPhoneEditor);
            formLayout.Children.Add(guestMailLabel);
            formLayout.Children.Add(guestMailEditor);

            formLayout.Padding = new Thickness(150, 10, 150, 10);

            layout.Padding = 10;
            layout.Spacing = 10;

            Content = layout;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            guestPhoneEditor.Focus();

        }
    }
}
