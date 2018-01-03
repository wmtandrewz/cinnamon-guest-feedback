using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using CCFS.Helpers;
using Newtonsoft.Json;
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
     * Class    :   ConfigSettings
     * Remark   :   This is the ConfigSettings Content page class
     */
    public partial class ConfigSettings : ContentPage
    {

        string SelectedHotel;
        string HotelCode;
        Picker hotelPicker;
        Label swicherStatLabel;

        public ConfigSettings()
        {
            InitComp(); //  Execute the method 'InitComp' for initialize User Interface elements
            BackgroundColor = Color.Black;

        }


        /*
		 * Method       :   InitComp
         * Task         :   Creates Page UI Dynamically
         */
        private void InitComp()
        {
            var layout = new StackLayout();
            layout.BackgroundColor = Color.Black;
            layout.VerticalOptions = LayoutOptions.CenterAndExpand;

            var titleLabel = new Label
            {
                Text = "App Configurations",
                FontSize = 24,
                TextColor = Color.White,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                VerticalTextAlignment = TextAlignment.Center,
                HeightRequest = 100

            };

            var formLayout = new StackLayout();
            formLayout.BackgroundColor = Color.DarkSlateGray;
            formLayout.Orientation = StackOrientation.Vertical;
            formLayout.VerticalOptions = LayoutOptions.Center;


            var hotelLabel = new Label
            {
                Text = "Hotel",
                FontSize = 18,
                TextColor = Color.White,
                VerticalOptions = LayoutOptions.Start,
                VerticalTextAlignment = TextAlignment.End,
                HeightRequest = 40

            };

            var hotelList = new List<string>();
            hotelList.Add("Cinnamon Grand");
            hotelList.Add("Cinnamon Lakeside");
            hotelList.Add("Cinnamon Red");
            hotelList.Add("Cinnamon Bey");
            hotelList.Add("Cinnamon Lodge");
            hotelList.Add("Cinnamon Citadel");
            hotelList.Add("Cinnamon Wild");
            hotelList.Add("Trinco Blu By Cinnamon");
            hotelList.Add("Habarana Village By Cinnamon");
            hotelList.Add("Bentota Beach By Cinnamon");
            hotelList.Add("Hikka Tranz By Cinnamon");
            hotelList.Add("Cinnamon Dhonveli Maldives");
            hotelList.Add("Cinnamon Hakuraa Huraa Maldives");
            hotelList.Add("Ellaidhoo Maldives By Cinnamon");

            hotelPicker = new Picker
            {
                Title = "Select your place",
                ItemsSource = hotelList,
                TextColor = Color.Black,
                HeightRequest = 40,
                SelectedItem=Settings.HotelName
            };

            var hotelNumber = new Label
            {
                Text = "Hotel No:",
                FontSize = 18,
                TextColor = Color.White,
                VerticalOptions = LayoutOptions.Start,
                VerticalTextAlignment = TextAlignment.End,
                HeightRequest = 40,

            };

            var hotelNumberEditor = new Entry
            {
                Placeholder = "Hotel Number",
                HeightRequest = 40,
                TextColor = Color.Black,
                IsEnabled = false,
                Text=Settings.HotelNumber
            };

            var hotelCode = new Label
            {
                Text = "Hotel Code:",
                FontSize = 18,
                TextColor = Color.White,
                VerticalOptions = LayoutOptions.Start,
                VerticalTextAlignment = TextAlignment.End,
                HeightRequest = 40,

            };

            var hotelCodeEditor = new Entry
            {
                Placeholder = "Hotel Code",
                HeightRequest = 40,
                TextColor = Color.Black,
                IsEnabled = false,
                Text=Settings.HotelCode
            };

            var developmentLabel = new Label
            {
                Text = "Development API",
                FontSize = 18,
                TextColor = Color.White,
                VerticalOptions = LayoutOptions.Start,
                VerticalTextAlignment = TextAlignment.End,
                HeightRequest = 40,

            };

            var DevelopmentEntry = new Entry
            {
                Text = Settings.DevelopmentUrl,
                Placeholder = "Development Uri",
                HeightRequest = 40,
                TextColor = Color.Black,
            };

            var ProductionLabel = new Label
            {
                Text = "Production API",
                FontSize = 18,
                TextColor = Color.White,
                VerticalOptions = LayoutOptions.Start,
                VerticalTextAlignment = TextAlignment.End,
                HeightRequest = 40,

            };

            var ProductionEntry = new Entry
            {
                Text = Settings.ProductionUrl,
                Placeholder = "Get Guest Details API",
                HeightRequest = 40,
                TextColor = Color.Black,
            };


            var APIMsubkeyDevLabel = new Label
            {
                Text = "APIM Dev Subscription Key",
                FontSize = 18,
                TextColor = Color.White,
                VerticalOptions = LayoutOptions.Start,
                VerticalTextAlignment = TextAlignment.End,
                HeightRequest = 40,

            };

            var APIMsubkeyDevEntry = new Entry
            {
                Text = Settings.SubscriptionKey_Dev,
                Placeholder = "Sub key dev",
                HeightRequest = 40,
                TextColor = Color.Black,
            };

            var APIMsubkeyPrdLabel = new Label
            {
                Text = "APIM PRD Subscription Key",
                FontSize = 18,
                TextColor = Color.White,
                VerticalOptions = LayoutOptions.Start,
                VerticalTextAlignment = TextAlignment.End,
                HeightRequest = 40,

            };

            var APIMsubkeyPrdEntry = new Entry
            {
                Text = Settings.SubscriptionKey_Prd,
                Placeholder = "Sub key Prd",
                HeightRequest = 40,
                TextColor = Color.Black,
            };

            var DevDateLabel = new Label
            {
                Text = "Dev Guest Inhouse Date",
                FontSize = 18,
                TextColor = Color.White,
                VerticalOptions = LayoutOptions.Start,
                VerticalTextAlignment = TextAlignment.End,
                HeightRequest = 40,

            };

            var DevDateEntry = new Entry
            {
                Text = Settings.DevelopmentInhouseDate,
                Placeholder = "Dev Date",
                HeightRequest = 40,
                TextColor = Color.Black,
            };

            var switcherLayout = new StackLayout();
            switcherLayout.Orientation = StackOrientation.Horizontal;
            switcherLayout.VerticalOptions = LayoutOptions.Center;

            var swicherLabel = new Label
            {
                Text = "Switch Production Domain",
                FontSize = 18,
                TextColor = Color.White,
                VerticalOptions = LayoutOptions.Center,
                VerticalTextAlignment = TextAlignment.Center,
                HeightRequest = 40,

            };

             swicherStatLabel = new Label
            {

                Text = "Development",
                FontSize = 18,
                TextColor = Color.Red,
                VerticalOptions = LayoutOptions.Center,
                VerticalTextAlignment = TextAlignment.Center,
                HeightRequest = 40,
                WidthRequest = 200

            };

            var switcher = new Switch
            {
                VerticalOptions = LayoutOptions.Center,
                IsToggled = Settings.DomainSwitcher
            };

            switcher.Toggled += delegate
            {
                if (switcher.IsToggled)
                {
                    swicherStatLabel.Text = "Production";
                    swicherStatLabel.TextColor = Color.LightGreen;
                    Settings.DomainSwitcher = true;
                }
                else
                {
                    swicherStatLabel.Text = "Development";
                    swicherStatLabel.TextColor = Color.Red;
                    Settings.DomainSwitcher = false;
                }
            };

            switcherLayout.Children.Add(swicherLabel);
            switcherLayout.Children.Add(switcher);
            switcherLayout.Children.Add(swicherStatLabel);

            var buttonLayout = new StackLayout();
            buttonLayout.BackgroundColor = Color.DarkSlateGray;
            buttonLayout.Orientation = StackOrientation.Horizontal;
            buttonLayout.VerticalOptions = LayoutOptions.Center;

            var submitButton = new Button
            {
                Text = "Submit",
                FontSize = 36,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                HeightRequest = 60,
                WidthRequest = 150
            };

            var loggerButton = new Button
            {
                Text = "Activity Logger",
                FontSize = 20,
                TextColor = Color.Yellow,
                HorizontalOptions = LayoutOptions.End,
                VerticalOptions = LayoutOptions.End,
                HeightRequest = 60,
                WidthRequest = 200
            };

            hotelPicker.SelectedIndexChanged += delegate
           {
               if ((string)hotelPicker.ItemsSource[hotelPicker.SelectedIndex] == "Cinnamon Grand")
               {
                   hotelNumberEditor.Text = "3000";
                   SelectedHotel = "Cinnamon Grand";
                   HotelCode = "CNG";
                   hotelCodeEditor.Text = "CNG";
               }
               else if ((string)hotelPicker.ItemsSource[hotelPicker.SelectedIndex] == "Cinnamon Lakeside")
               {
                   hotelNumberEditor.Text = "3005";
                   SelectedHotel = "Cinnamon Lakeside";
                   HotelCode = "CNL";
                   hotelCodeEditor.Text = "CNL";
               }
               else if ((string)hotelPicker.ItemsSource[hotelPicker.SelectedIndex] == "Cinnamon Red")
               {
                   hotelNumberEditor.Text = "3015";
                   SelectedHotel = "Cinnamon Red";
                   HotelCode = "RED";
                   hotelCodeEditor.Text = "RED";
               }
               else if ((string)hotelPicker.ItemsSource[hotelPicker.SelectedIndex] == "Bentota Beach By Cinnamon")
               {
                   hotelNumberEditor.Text = "3100";
                   SelectedHotel = "Bentota Beach By Cinnamon";
                   HotelCode = "BBH";
                   hotelCodeEditor.Text = "BBH";
               }
               else if ((string)hotelPicker.ItemsSource[hotelPicker.SelectedIndex] == "Cinnamon Citadel")
               {
                   hotelNumberEditor.Text = "3110";
                   SelectedHotel = "Cinnamon Citadel";
                   HotelCode = "CIT";
                   hotelCodeEditor.Text = "CIT";
               }
               else if ((string)hotelPicker.ItemsSource[hotelPicker.SelectedIndex] == "Cinnamon Lodge")
               {
                   hotelNumberEditor.Text = "3115";
                   SelectedHotel = "Cinnamon Lodge";
                   HotelCode = "LOD";
                   hotelCodeEditor.Text = "LOD";
               }
               else if ((string)hotelPicker.ItemsSource[hotelPicker.SelectedIndex] == "Habarana Village By Cinnamon")
               {
                   hotelNumberEditor.Text = "3120";
                   SelectedHotel = "Habarana Village By Cinnamon";
                   HotelCode = "VIL";
                   hotelCodeEditor.Text = "VIL";
               }
               else if ((string)hotelPicker.ItemsSource[hotelPicker.SelectedIndex] == "Cinnamon Wild")
               {
                   hotelNumberEditor.Text = "3150";
                   SelectedHotel = "Cinnamon Wild";
                   HotelCode = "WLD";
                   hotelCodeEditor.Text = "WLD";
               }
               else if ((string)hotelPicker.ItemsSource[hotelPicker.SelectedIndex] == "Cinnamon Bey")
               {
                   hotelNumberEditor.Text = "3160";
                   SelectedHotel = "Cinnamon Bey";
                   HotelCode = "BEY";
                   hotelCodeEditor.Text = "BEY";
               }
               else if ((string)hotelPicker.ItemsSource[hotelPicker.SelectedIndex] == "Trinco Blu By Cinnamon")
               {
                   hotelNumberEditor.Text = "3165";
                   SelectedHotel = "Trinco Blu By Cinnamon";
                   HotelCode = "BLU";
                   hotelCodeEditor.Text = "BLU";
               }
               else if ((string)hotelPicker.ItemsSource[hotelPicker.SelectedIndex] == "Hikka Tranz By Cinnamon")
               {
                   hotelNumberEditor.Text = "3170";
                   SelectedHotel = "Hikka Tranz By Cinnamon";
                   HotelCode = "TRA";
                   hotelCodeEditor.Text = "TRA";
               }
               else if ((string)hotelPicker.ItemsSource[hotelPicker.SelectedIndex] == "Ellaidhoo Maldives By Cinnamon")
               {
                   hotelNumberEditor.Text = "3300";
                   SelectedHotel = "Ellaidhoo Maldives By Cinnamon";
                   HotelCode = "ELL";
                   hotelCodeEditor.Text = "ELL";
               }
               else if ((string)hotelPicker.ItemsSource[hotelPicker.SelectedIndex] == "Cinnamon Dhonveli Maldives")
               {
                   hotelNumberEditor.Text = "3310";
                   SelectedHotel = "Cinnamon Dhonveli Maldives";
                   HotelCode = "DHO";
                   hotelCodeEditor.Text = "DHO";
               }
               else if ((string)hotelPicker.ItemsSource[hotelPicker.SelectedIndex] == "Cinnamon Hakuraa Huraa Maldives")
               {
                   hotelNumberEditor.Text = "3305";
                   SelectedHotel = "Cinnamon Hakuraa Huraa Maldives";
                   HotelCode = "HAK";
                   hotelCodeEditor.Text = "HAK";
               }
               else
               {
                    //Do Nothing
                }
           };


            submitButton.Clicked += async delegate
            {

                Settings.DomainSwitcher = switcher.IsToggled;
                Settings.HotelName = SelectedHotel;
                Settings.HotelNumber = hotelNumberEditor.Text;
                Settings.DevelopmentUrl = DevelopmentEntry.Text;
                Settings.ProductionUrl = ProductionEntry.Text;
                Settings.SubscriptionKey_Dev = APIMsubkeyDevEntry.Text;
                Settings.SubscriptionKey_Prd = APIMsubkeyPrdEntry.Text;
                Settings.HotelCode = HotelCode;
                Settings.DevelopmentInhouseDate = DevDateEntry.Text;

                ActivityLogger.AddLogger("App Configuration Settings Changed.");

                await Navigation.PopToRootAsync();
            };

            loggerButton.Clicked += async delegate
            {
                await Navigation.PushAsync(new LoggerView());
            };

            buttonLayout.Children.Add(submitButton);
            switcherLayout.Children.Add(loggerButton);

            formLayout.Children.Add(titleLabel);

            formLayout.Children.Add(switcherLayout);
            formLayout.Children.Add(hotelLabel);
            formLayout.Children.Add(hotelPicker);
            formLayout.Children.Add(hotelNumber);
            formLayout.Children.Add(hotelNumberEditor);
            formLayout.Children.Add(hotelCode);
            formLayout.Children.Add(hotelCodeEditor);
            formLayout.Children.Add(developmentLabel);
            formLayout.Children.Add(DevelopmentEntry);
            formLayout.Children.Add(ProductionLabel);
            formLayout.Children.Add(ProductionEntry);
            formLayout.Children.Add(APIMsubkeyDevLabel);
            formLayout.Children.Add(APIMsubkeyDevEntry);
            formLayout.Children.Add(APIMsubkeyPrdLabel);
            formLayout.Children.Add(APIMsubkeyPrdEntry);
            formLayout.Children.Add(DevDateLabel);
            formLayout.Children.Add(DevDateEntry);
            formLayout.Children.Add(buttonLayout);


            formLayout.Padding = new Thickness(150, 10, 150, 10);

            var sv = new ScrollView
            {
                Orientation = ScrollOrientation.Vertical,
                Content = formLayout
            }; // Sets dynamic layout to page 'Content' Property

            layout.Children.Add(sv);


            layout.Padding = 10;
            layout.Spacing = 10;

            Content = layout;
        }
        //---------------------------------------------- End Of InitComp --------------------------------------
        protected override void OnAppearing()
        {
            base.OnAppearing();
            hotelPicker.Focus();
            if(Settings.DomainSwitcher){
                swicherStatLabel.Text = "Production";
                swicherStatLabel.TextColor = Color.LawnGreen;
            }else{
                swicherStatLabel.Text = "Development";
                swicherStatLabel.TextColor = Color.Red;
            }

        }
    }

}
