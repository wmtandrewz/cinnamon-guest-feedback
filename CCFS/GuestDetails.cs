using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CCFS.Helpers;
using Newtonsoft.Json;
using Plugin.DeviceInfo;
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
     * Class    :   GuestDetails
     * Remark   :   This is the GuestDetails Content page class
     */
    public partial class GuestDetails : ContentPage
    {

        private string hotelNumber = Settings.HotelNumber;
        private string arriveDate = "2017-01-01";
        private string departDate = "2017-01-01";
        private string deviceID = "00000000000";
        private string guestID = "00000000";
        private string guestName = "Guest";
        private List<ReservationDetails> GuestListInBooking;
        private List<string> pickerDataSource;
        List<Label> labelList;

        private Validation validator;

        //Task<string> IsOnAPI;

        //Button submitButton;
        Entry roomNoEditor, resNoEditor, guestPhoneEditor,guestMailEditor;
        Label resNoLabel, guestNameLabel;
        StackLayout formLayout;


        public GuestDetails()
        {
            //IsOnAPI = IsGetAPILive();

            InitComp(); //  Execute the method 'InitComp' for initialize User Interface elements
            BackgroundColor = Color.Black;

            Constants con = Constants.Instance;
            con.ContactDB();

            validator = new Validation();

            //submitButton.IsEnabled = false;

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

            var titleImage = new Image { Aspect = Aspect.AspectFit };
            titleImage.Source = ImageSource.FromFile("images/cinnamon.png");
            titleImage.HeightRequest = 100;

            formLayout = new StackLayout();
            formLayout.Orientation = StackOrientation.Vertical;
            formLayout.VerticalOptions = LayoutOptions.StartAndExpand;

            //submitButton = new Button
            //{
            //    Text = "Submit",
            //    FontSize = 36,
            //    HorizontalOptions = LayoutOptions.CenterAndExpand,
            //    HeightRequest = 60,
            //    WidthRequest = 150
            //};

            var hotelLabel = new Label
            {
                Text = "Hotel",
                FontSize = 18,
                TextColor = Color.White,
                VerticalOptions = LayoutOptions.Start,
                VerticalTextAlignment = TextAlignment.End,
                HeightRequest = 40

            };

            var hotelNameLabel = new Entry
            {
                Text = Settings.HotelName,
                IsEnabled = false,
                TextColor = Color.Black,
                HeightRequest = 40,
                Keyboard = Keyboard.Default
            };

            var roomNoLabel = new Label
            {
                Text = "Room No:",
                FontSize = 18,
                TextColor = Color.White,
                VerticalOptions = LayoutOptions.Start,
                VerticalTextAlignment = TextAlignment.End,
                HeightRequest = 40,

            };

            roomNoEditor = new Entry
            {
                Placeholder = "Room Number",
                TextColor = Color.Black,
                HeightRequest = 40,
                Keyboard = Keyboard.Numeric,
            };

            var indicator = new ActivityIndicator()
            {
                IsVisible = false,
                Color = Color.Green,
                IsRunning = true,
                BindingContext = this,

            };

            resNoLabel = new Label
            {
                Text = "Reservation No:",
                FontSize = 18,
                TextColor = Color.White,
                VerticalOptions = LayoutOptions.Start,
                VerticalTextAlignment = TextAlignment.End,
                HeightRequest = 40,

            };

            resNoEditor = new Entry
            {
                Placeholder = "Reservation Number",
                HeightRequest = 40,
                TextColor = Color.Black,
                IsEnabled = false
            };

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
                HeightRequest = 40,
                Keyboard = Keyboard.Telephone
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
                Keyboard = Keyboard.Email
            };

            guestNameLabel = new Label
            {
                Text = "Tap On Your Name",
                FontSize = 18,
                IsVisible=false,
                TextColor = Color.White,
                VerticalOptions = LayoutOptions.Start,
                VerticalTextAlignment = TextAlignment.End,
                HeightRequest = 40,
            };

            roomNoEditor.TextChanged += delegate
            {

                if (!roomNoEditor.Text.All(char.IsDigit))
                {
                    roomNoEditor.Text = roomNoEditor.Text.Remove(roomNoEditor.Text.Length - 1);
                }

                if (roomNoEditor.Text.Length > 4)
                {
                    roomNoEditor.Text = roomNoEditor.Text.Remove(roomNoEditor.Text.Length - 1);
                }


            };

            indicator.SetBinding(IsVisibleProperty, "IsBusy");

            /*
             * Event        :   Room Number Editer 'Unfocused' Event
             * Task         :   Gets Reservation number from TMS System using Romm Number which is entered by Guess and
             *                  Sets it into Reservation Number Editor UI element
             * Exception    :   Exception raised 'resNoText' is sets to null
             */

            roomNoEditor.Unfocused += async delegate
            {

                if(labelList!=null){
                    for (int i = 0; i < labelList.Count(); i++)
                    {
                        formLayout.Children.Remove(labelList[i]);
                    }
                }

                labelList = new List<Label>();


                ActivityLogger.AddLogger("Room Number" +roomNoEditor.Text+" Entered");

                GuestListInBooking = new List<ReservationDetails>();
                pickerDataSource = new List<string>();

                if (roomNoEditor.Text != "")
                {
                    //submitButton.IsEnabled = false;
                }
                else
                {
                    //submitButton.IsEnabled = false;
                    guestNameLabel.IsVisible = false;
                    await DisplayAlert("Empty", "Field can't be empty. Please enter your room number", "OK");
                    ActivityLogger.AddLogger("Error\t:\tRoom Number is Empty");
                    roomNoEditor.Focus();
                    return;
                }


                this.IsBusy = true;
                indicator.IsVisible = true;
                indicator.IsRunning = true;

                var DeviceInfo = CrossDeviceInfo.Current;
                deviceID = DeviceInfo.Id;
                Console.WriteLine("Device ID:" + DeviceInfo.Id + "Model :" + DeviceInfo.Model);


                try
                {

                    string roomNo = roomNoEditor.Text; // Get room Number from User
                    string date = DateTime.Now.ToString("yyyy-MM-dd");

                    if(!Settings.DomainSwitcher){
                        date = Settings.DevelopmentInhouseDate;
                    }

                    List<ReservationDetails> reservationData = null;

                    //------------------------------------------------------------------------------

                    HttpClient client = new HttpClient();
                    client.BaseAddress = new Uri(Settings.BaseDomainURL);
                    client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", Settings.SubscriptionKey); //Production link
                    var response = await client.GetAsync("guestfeedback/Guest/GetGuestDetails/" + hotelNumber + "/" + roomNo + "/" + date);
                    //var response = await client.GetAsync("guest/Guest/GetGuestDetails/" + hotelNumber + "/" + roomNo + "/" + date);// Production link

                    var resultData = response.Content.ReadAsStringAsync().Result;

                    if (resultData != "")
                    {
                        reservationData = JsonConvert.DeserializeObject<List<ReservationDetails>>(resultData);
                        GC.KeepAlive(reservationData);
                        Console.WriteLine("JSON Guest Result Deserialized...List Size :" + resultData.Count());

                    }
                    else
                    {
                        Console.WriteLine("Service off part");
                        ActivityLogger.AddLogger("Reservation Data Null... Offline Mode Enabled.");

                        resNoLabel.IsVisible = false;
                        resNoEditor.IsVisible = false;
                        guestNameLabel.IsVisible = false;

                        foreach (var item in labelList)
                        {
                            item.IsVisible = false;
                        }

                        Random r = new Random();
                        var tempResNo = r.Next(100000) + 1000;
                        resNoEditor.Text = "00001" + tempResNo;

                        arriveDate = DateTime.Now.ToString("yyyy-MM-dd");
                        departDate = DateTime.Now.ToString("yyyy-MM-dd");

                        guestName = "Guest";

                        indicator.IsVisible = false;
                        indicator.IsRunning = false;
                        this.IsBusy = false;


                    }
                    //------------------------------------------------------------------------------



                    //String responce = "";
                    //String ad1 = "";
                    //String ad2 = "";
                    //String ad3 = "";

                    foreach (var guestData in reservationData)
                    {
                        //string responce = guestData.BookingId; // Get first element value from NVC (Reservation Number)
                        //string ad1 = guestData.ArrivalDate;//Arr Date
                        //string ad2 = guestData.DepartureDate;//Dep Date
                        //string ad3 = guestData.Name;//Guest name

                        pickerDataSource.Add(guestData.Name);

                        ReservationDetails newDataSet = new ReservationDetails();
                        newDataSet.GuestId = guestData.GuestId;
                        newDataSet.Name = guestData.Name;
                        newDataSet.Country = guestData.Country;
                        newDataSet.Nationality = guestData.Nationality;
                        newDataSet.Email = guestData.Email;
                        newDataSet.Telephone = guestData.Telephone;
                        newDataSet.Mobile = guestData.Mobile;
                        newDataSet.RoomNo = guestData.RoomNo;
                        newDataSet.BookingId = guestData.BookingId;
                        newDataSet.ArrivalDate = guestData.ArrivalDate;
                        newDataSet.DepartureDate = guestData.DepartureDate;

                        GuestListInBooking.Add(newDataSet);
                    }

                    //-----------------------Guest Selector------------------------------


                    for (int i = 0; i < pickerDataSource.Count; i++)
                    {

                        var label = new Label()
                        {
                            BackgroundColor = Color.Purple,
                            TextColor = Color.White,
                            FontSize = 20,
                            Text = pickerDataSource[i],
                            HorizontalTextAlignment = TextAlignment.Center,
                            VerticalTextAlignment = TextAlignment.Center,
                            WidthRequest = 500,
                            HeightRequest = 40

                        };

                        labelList.Add(label);

                        //-------------------Single selection event---------------------------
                        var nameTapRecognizer = new TapGestureRecognizer();
                        nameTapRecognizer.Tapped += async (s, e) =>
                        {

                            int seq = 0;
                            int selected = 1;

                            foreach (var item in labelList)
                            {
                                item.BackgroundColor = Color.FromRgb(60, 0, 70);
                                item.TextColor = Color.White;
                                if (item.Id == ((Label)s).Id)
                                {

                                    item.BackgroundColor = Color.Purple;

                                    //Animating
                                    await item.ScaleTo(2, 200, Easing.CubicIn);
                                    await item.ScaleTo(1, 200, Easing.CubicOut);

                                    item.TextColor = Color.LightGreen;
                                    selected = seq;
                                    Console.WriteLine("selected item :" + selected);
                                }

                                seq++;
                            }

                            ItemSelected(selected,s,e); //save selected item

                        };

                        label.GestureRecognizers.Add(nameTapRecognizer);

                        formLayout.Children.Add(label);
                    }

                    //-----------------------end guest selector--------------------------

                    if (GuestListInBooking[0].Name == "No reservations found")
                    {
                        indicator.IsVisible = false;
                        indicator.IsRunning = false;

                        await DisplayAlert("Alert", "Reservation not found!. Please check your room number", "OK");

                        ActivityLogger.AddLogger("Room Number" + roomNoEditor.Text + " Reservation Not Found.");

                        resNoEditor.Text = "";
                        roomNoEditor.Text = "";

                        foreach (var item in labelList)
                        {
                            item.IsVisible = false;
                        }

                        roomNoEditor.Focus();
                        //submitButton.IsEnabled = false;

                        return;

                    }
                    else if (GuestListInBooking[0].Name == "Authentication Failed")
                    {
                        indicator.IsVisible = false;
                        indicator.IsRunning = false;

                        await DisplayAlert("Error", "#401 Internal Server error (Authentication). Please Contact your System administrator", "OK");
                        ActivityLogger.AddLogger("Reservation Details Service Authentication Failed");

                        resNoEditor.Text = "";
                        roomNoEditor.Text = "";

                        foreach (var item in labelList)
                        {
                            item.IsVisible = false;
                        }

                        roomNoEditor.Focus();
                        //submitButton.IsEnabled = false;

                        return;
                    }

                    else if (GuestListInBooking[0].Name == "Unable to connect to the remote server")
                    {
                        indicator.IsVisible = false;
                        indicator.IsRunning = false;

                        await DisplayAlert("Error", "#500 Unable to connect server. Please Contact your System administrator", "OK");

                        ActivityLogger.AddLogger("Reservation Details Service Server Error");

                        resNoEditor.Text = "";
                        roomNoEditor.Text = "";

                        foreach (var item in labelList)
                        {
                            item.IsVisible = false;
                        }

                        roomNoEditor.Focus();
                        //submitButton.IsEnabled = false;

                        return;
                    }
                    else if (GuestListInBooking[0].BookingId.All(char.IsDigit))
                    {

                        resNoEditor.Text = GuestListInBooking[0].BookingId;
                        arriveDate = GuestListInBooking[0].ArrivalDate;
                        departDate = GuestListInBooking[0].DepartureDate;
                        guestPhoneEditor.Text = GuestListInBooking[0].Mobile;
                        guestMailEditor.Text = GuestListInBooking[0].Email;

                        indicator.IsVisible = false;
                        indicator.IsRunning = false;
                        this.IsBusy = false;

                        guestNameLabel.IsVisible = true;

                        return;

                    }
                    else
                    {
                        Console.WriteLine("Service off part");
                        ActivityLogger.AddLogger("Reservation Data Error... Offline Mode Enabled.");

                        resNoLabel.IsVisible = false;
                        resNoEditor.IsVisible = false;
                        guestNameLabel.IsVisible = false;

                        foreach (var item in labelList)
                        {
                            item.IsVisible = false;
                        }

                        Random r = new Random();
                        var tempResNo = r.Next(100000) + 1000;
                        resNoEditor.Text = "00001" + tempResNo;

                        arriveDate = DateTime.Now.ToString("yyyy-MM-dd");
                        departDate = DateTime.Now.ToString("yyyy-MM-dd");

                        guestName = "Guest";

                        indicator.IsVisible = false;
                        indicator.IsRunning = false;
                        this.IsBusy = false;

                        if (roomNoEditor.Text != "")
                        {
                            //submitButton.IsEnabled = true;
                        }
                        else
                        {
                            //submitButton.IsEnabled = false;
                            await DisplayAlert("Empty", "Field can't be empty. Please enter your room number", "OK");
                            roomNoEditor.Focus();
                        }
                    }


                }
                catch (Exception)
                {

                    Console.WriteLine("Service off part");
                    ActivityLogger.AddLogger("Major Server Exception Occured... Offline Mode Enabled.");

                    resNoLabel.IsVisible = false;
                    resNoEditor.IsVisible = false;
                    guestNameLabel.IsVisible = false;

                    foreach (var item in labelList)
                    {
                        item.IsVisible = false;
                    }

                    Random r = new Random();
                    var tempResNo = r.Next(100000) + 1000;
                    resNoEditor.Text = "00001" + tempResNo;

                    arriveDate = DateTime.Now.ToString("yyyy-MM-dd");
                    departDate = DateTime.Now.ToString("yyyy-MM-dd");

                    indicator.IsVisible = false;
                    indicator.IsRunning = false;
                    this.IsBusy = false;

                    if (roomNoEditor.Text != "")
                    {
                        //submitButton.IsEnabled = true;
                    }
                    else
                    {
                        //submitButton.IsEnabled = false;
                        await DisplayAlert("Empty", "Field can't be empty. Please enter your room number", "OK");
                        roomNoEditor.Focus();
                    }


                }

            };

            guestMailEditor.TextChanged += delegate
            {

                if (validator.EmailValidator(guestMailEditor.Text))
                {
                    guestMailEditor.BackgroundColor = Color.FromRgb(205, 255, 196);
                }
                else
                {
                    guestMailEditor.BackgroundColor = Color.FromRgb(255, 153, 168);
                }

            };

            guestPhoneEditor.TextChanged += delegate {

                if (guestPhoneEditor.Text.Length > 13)
                {
                    guestPhoneEditor.Text = guestPhoneEditor.Text.Remove(guestPhoneEditor.Text.Length - 1);
                }

                if (validator.MobileNumberValidator(guestPhoneEditor.Text))
                {
                    guestPhoneEditor.BackgroundColor = Color.FromRgb(205, 255, 196);
                }
                else
                {
                    guestPhoneEditor.BackgroundColor = Color.FromRgb(255, 153, 168);
                }

            };


            /*
             * Event        :   Room Number Editer 'Completed' Event
             * Task         :   Gets Reservation number from TMS System using Romm Number which is entered by Guess and
             *                  Sets it into Reservation Number Editor UI element
             * Exception    :   Exception raised 'resNoText' is sets to null
             */

            roomNoEditor.Completed += delegate
            {
                roomNoEditor.Unfocus();
            };


            //submitButton.Clicked += HandleClick;

               
            layout.Children.Add(titleImage);
            layout.Children.Add(indicator);

            formLayout.Children.Add(hotelLabel);
            formLayout.Children.Add(hotelNameLabel);
            formLayout.Children.Add(roomNoLabel);
            formLayout.Children.Add(roomNoEditor);
            formLayout.Children.Add(resNoLabel);
            formLayout.Children.Add(resNoEditor);
            formLayout.Children.Add(guestPhoneLabel);
            formLayout.Children.Add(guestPhoneEditor);
            formLayout.Children.Add(guestMailLabel);
            formLayout.Children.Add(guestMailEditor);
            formLayout.Children.Add(guestNameLabel);

            formLayout.Padding = new Thickness(150, 10, 150, 10);

            layout.Children.Add(formLayout);
            //layout.Children.Add(submitButton);

            layout.Padding = 10;
            layout.Spacing = 10;

            Content = new ScrollView
            {
                Orientation = ScrollOrientation.Horizontal,
                Content = layout
            }; // Sets dynamic layout to page 'Content' Property
        }

        private async void HandleClick(object sender, EventArgs e)
        {
            string isGiven = await CheckIsFeedbackGiven(Settings.HotelCode, resNoEditor.Text, guestID).ConfigureAwait(true);

            if (isGiven == "true")
            {
                await DisplayAlert("Hey!", "Selected person had already given a feedback", "OK");

                ActivityLogger.AddLogger("Selected Guest " + guestID + " had already given a feedback");

            }
            else
            {
                SaveRatings sr = SaveRatings.SaveRatingInstance;
                sr._hotelCode = Settings.HotelCode;
                sr._roomNum = roomNoEditor.Text;
                sr._resNum = resNoEditor.Text;
                sr._guestID = guestID;
                sr._guestName = guestName;
                sr._guestPhone = guestPhoneEditor.Text;
                sr._guestEmail = guestMailEditor.Text;
                sr._arrDate = this.arriveDate;
                sr._depDate = this.departDate;
                sr._createdBy = deviceID;

                ActivityLogger.AddLogger("Submitted Guest Details : "
                                         + sr._hotelCode + "as hotel code,"
                                         + sr._roomNum + "as room number,"
                                         + sr._resNum + "as reservation number,"
                                         + sr._guestID + "as guest ID,"
                                         + sr._guestName + "as guest name,"
                                         + sr._guestEmail + "as guest mail,"
                                         + sr._guestPhone + "as guest phone,"
                                         + sr._arrDate + "as arraival date,"
                                         + sr._depDate + "as departure date,"
                                         + sr._createdBy + "as device ID,"
                                        );

                await Navigation.PushAsync(new PageGen());

            }
        }

        private void ItemSelected(int selected,Object s, EventArgs e)
        {
            try
            {
                guestID = GuestListInBooking[selected].GuestId;
                guestName = GuestListInBooking[selected].Name;

                Console.WriteLine(guestID + ":" + guestName);

                HandleClick(s,e);

                //submitButton.IsEnabled = true;


            }catch(Exception){}

        }



        //---------------------------------------------- End Of InitComp --------------------------------------

        protected override void OnAppearing()
        {
            base.OnAppearing();

            roomNoEditor.Focus();

            ForceLayout();

        }

        private async Task<string> CheckIsFeedbackGiven(string hotelCode, string roomNo, string guestID)
        {

            string resultData = null;

            try
            {

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Settings.BaseDomainURL);
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", Settings.SubscriptionKey);
                var response = await client.GetAsync("guestfeedback/Feedback/IsFeedbackGiven/" + hotelCode + "/" + roomNo + "/" + guestID);
                resultData = response.Content.ReadAsStringAsync().Result;

                if (resultData != "")
                {
                    Console.WriteLine("Is Feedback given" + resultData);

                    return resultData;
                }
                else
                {
                    return resultData;
                }
            }
            catch (Exception)
            {

                return resultData;
            }
        }

    }
}
