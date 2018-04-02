using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using CCFS.Helpers;
using Newtonsoft.Json;
using Plugin.Connectivity;
using Xamarin.Forms;
using Plugin.Media;
using Plugin.Media.Abstractions;
using CCFS.iOS.Services;
using System.IO;
/*
* Author   :   Thimira Andradi
* Date     :   10th July 2017
* Company  :   CHML IT - Development
* Legal    :   All Rights Reserved | CHML IT | Development Team
*/
namespace CCFS
{
    /*
	 * Class    :   Main
	 * Remark   :   This is the Main Content page class
	 */
    public partial class Main : ContentPage
    {
        private Image titleImage;
        private MailSender ms;
        private Button startButton;

        private string AppVersionStatic = "2.2.2";
        private DateTime AppCurrDate = DateTime.Now;
        //private DateTime AppCurrDate = new DateTime(2018, 02, 07);

        private CameraStream cameraStream;

        public Main()
        {
            InitComp(); // Execute the method 'InitComp' for initialize User Interface elements
            CrossConnectivity.Current.ConnectivityChanged += Current_ConnectivityChanged;

            ms = new MailSender();

            cameraStream = DependencyService.Get<CameraStream>();
            cameraStream.SetupLiveCameraStream();
            cameraStream.SetFrontCam();

        }

        /*
         * Method       :   InitComp
         * Task         :   Creates Page UI Dynamically
         */
        private void InitComp()
        {
            var layout = new StackLayout();
            layout.BackgroundColor = Color.Black;
            layout.VerticalOptions = LayoutOptions.StartAndExpand;

            titleImage = new Image { Aspect = Aspect.AspectFit };
            titleImage.Source = ImageSource.FromFile("images/cinnamon.png");
            titleImage.HeightRequest = 150;

            //-------------------Settings panel---------------------------------

            var buttonPanel = new StackLayout();
            buttonPanel.Orientation = StackOrientation.Horizontal;
            buttonPanel.HorizontalOptions = LayoutOptions.End;
            buttonPanel.Spacing = 10;

            var settingsBtn = new Image { Aspect = Aspect.AspectFit };
            settingsBtn.Source = ImageSource.FromFile("images/settings.png");
            settingsBtn.WidthRequest = 40;
            settingsBtn.HeightRequest = 40;
            settingsBtn.HorizontalOptions = LayoutOptions.EndAndExpand;

            var closeBtn = new Image { Aspect = Aspect.AspectFit };
            closeBtn.Source = ImageSource.FromFile("images/close.png");
            closeBtn.WidthRequest = 40;
            closeBtn.HeightRequest = 40;
            closeBtn.HorizontalOptions = LayoutOptions.EndAndExpand;

            buttonPanel.Children.Add(settingsBtn);
            buttonPanel.Children.Add(closeBtn);

            layout.Children.Add(buttonPanel);

            //-------------------End of settings panel--------------------------

            var welcomeLabel = new Label
            {
                Text = "Welcome!",
                FontSize = 48,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                TextColor = Color.White,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                HeightRequest = 200

            };

            var titleLabel = new Label
            {
                Text = "Tell Us About Your Experience At Cinnamon",
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
                VerticalTextAlignment = TextAlignment.Center,
                TextColor = Color.DarkGray,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                HeightRequest = 200

            };

            var indicator = new ActivityIndicator()
            {
                IsVisible = false,
                Color = Color.Green,
                IsRunning = true,
                BindingContext = this,

            };

             startButton = new Button
            {
                Text = "Start",
                FontSize = 36,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                HeightRequest = 60,
                WidthRequest = 150,
            };

            /*
             * Event        :   Start Button 'Clicked' Event
             * Task         :   Asynchronously pushing content page object 'GuestDetails' into the Navigation stack
             * Arguments    :   Content page object (GuestDetails) --> new GuestDetails                
             */

            startButton.Clicked += async delegate
            {
                indicator.SetBinding(IsVisibleProperty, "IsBusy");

                this.IsBusy = true;
                indicator.IsVisible = true;
                indicator.IsRunning = true;

                startButton.IsEnabled = false;


                await TakePoto();

                Constants con = Constants.Instance;
                con.ClearOldData();

                bool apic = await APICheck().ConfigureAwait(true);

                Version versionCheck = await AppVersionCheck().ConfigureAwait(true);

                Global._IsMultiLangual = versionCheck.IsMultiLingual;

                int resul = DateTime.Compare(AppCurrDate, versionCheck.PriorVersionExpiryDate);

                if (versionCheck.AppVersion != AppVersionStatic || resul > 0)
                {
                    await DisplayAlert("Application is Expired", "Please update the App to latest release", "OK", "Cancel").ConfigureAwait(false);
                    await ms.SendsmtpMail("Expired device was found! in " + Settings.HotelName, "App Expired").ConfigureAwait(true);
                    Thread.CurrentThread.Abort();

                }

                if (apic != true)
                {
                    
                    await ms.SendsmtpMail("Expired device was found! in "+ Settings.HotelName,"App Expired").ConfigureAwait(true);

                    Thread.CurrentThread.Abort();
                }

                ActivityLogger.AddLogger("************** Start Button Pressed*****************");

                if (CheckInternetConnection() == false)
                {
                    bool res = await DisplayAlert("App is Exiting", "Please check your internet connection...", "OK", "Cancel");
                    ActivityLogger.AddLogger("Error : No Connection");
                    if (res)
                    {
                        Thread.CurrentThread.Abort();
                    }

                }
                else
                {
                    SaveRatings.SaveRatingInstance.ClearSavedData();
                    this.IsBusy = false;
                    indicator.IsVisible = false;

                    await Navigation.PushAsync(new GuestDetails());

                    //SaveRatings.SaveRatingInstance.ClearSavedData();

                    DateTime localDate = DateTime.Now;
                    SaveRatings.SaveRatingInstance._startTime = localDate.ToString();
                }

            };

            var closetapRecognizer = new TapGestureRecognizer();
            closetapRecognizer.Tapped += async delegate
            {
                ActivityLogger.AddLogger("App Close Button Pressed");

                var x = await DisplayAlert("Warning!", "Are you sure want to exit from App?", "Yes", "No");
                Console.WriteLine("Cansel return :" + x);

                if (x == true)
                {
                    ActivityLogger.AddLogger("App Closed");
                    Thread.CurrentThread.Abort();
                }

            };

            var settingstapRecognizer = new TapGestureRecognizer();
            settingstapRecognizer.Tapped += async delegate
            {
                ActivityLogger.AddLogger("Settings Button Pressed");

                await Navigation.PushAsync(new Login());
            };

            closeBtn.GestureRecognizers.Add(closetapRecognizer);
            settingsBtn.GestureRecognizers.Add(settingstapRecognizer);

            layout.Children.Add(titleImage);
            layout.Children.Add(welcomeLabel);
            layout.Children.Add(titleLabel);
            layout.Children.Add(indicator);
            layout.Children.Add(startButton);
            layout.Children.Add(copyrightLabel);


            layout.Padding = 10;
            layout.Spacing = 10;

            Content = layout;
        }

        public bool CheckInternetConnection()
        {

            if (CrossConnectivity.Current.IsConnected)
            {
                Console.WriteLine("Internet connection established");
                return true;
            }
            else
            {
                Console.WriteLine("Internet connection failed");
                return false;
            }

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            startButton.IsEnabled = true;

            if (CheckInternetConnection() == false)
            {
                DisplayAlert("No Connection", "Please check your internet connection...", "OK");

                return;
            }

        }

        async void Current_ConnectivityChanged(object sender, Plugin.Connectivity.Abstractions.ConnectivityChangedEventArgs e)
        {
            if (!e.IsConnected)
            {
                await DisplayAlert("Error Connection", "Network Changed. App is Exiting..", "OK").ConfigureAwait(true);
                Thread.CurrentThread.Abort();
            }
        }



        private async Task<bool> APICheck()
        {
            DateTime localDate = DateTime.Now;
            DateTime staticDate = new DateTime(2019, 01, 01);

            int res = DateTime.Compare(localDate, staticDate);

            if (res > 0)
            {
                bool b = await DisplayAlert("Application is Expired", "Please update the App to latest release", "OK", "Cancel").ConfigureAwait(false);
                return false;
            }
            else
            {
                return true;
            }

        }

        private async Task<Version> AppVersionCheck()
        {

            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://chml.keells.lk/FeedbackAPI/api/");
                var response = await client.GetAsync("Feedback/GetSystemConfiguration");
                var resultQues = response.Content.ReadAsStringAsync().Result;

                if (resultQues != "")
                {
                    Version version = JsonConvert.DeserializeObject<Version>(resultQues);
                    Console.WriteLine(resultQues);

                    return version;
                }
                else
                {
                    return null;
                }
            }

            catch (Exception)
            {
                return null;
            }

        }

        private async void TakeImageFromCamera()
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("No Camera", ":( No camera available.", "OK");
                return;
            }

            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                DefaultCamera = Plugin.Media.Abstractions.CameraDevice.Front,
                Directory = "Sample",
                Name = "test.jpg"
            });

            if (file == null)
                return;

            await DisplayAlert("File Location", file.Path, "OK");

            titleImage.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                return stream;
            });
        }

        private async Task TakePoto()
        {
            
            Byte [] imageData = await cameraStream.TakePhoto().ConfigureAwait(true);
            //titleImage.Source = ImageSource.FromStream(() => new MemoryStream(imageData));
        }

    }
}
