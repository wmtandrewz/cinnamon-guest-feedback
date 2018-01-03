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
     * Class    :   LoggerView
     * Remark   :   This is the LoggerView Content page class
     */
    public partial class LoggerView : ContentPage
    {
        Editor commentEditor;
        string loggerDetails = null;

        public LoggerView()
        {
            ReadLogger();
            InitComp(); //  Execute the method 'InitComp' for initialize User Interface elements
            BackgroundColor = Color.Black;

            ActivityLogger.AddLogger("Activity Logger Viewed");

		}


		/*
		 * Method       :   InitComp
         * Task         :   Creates Page UI Dynamically
         */
		private void InitComp(){
			var layout = new StackLayout();
            layout.BackgroundColor = Color.Black;

            var titleLabel = new Label
            {
                Text = "Activity Logger",
                FontSize = 24,
                TextColor = Color.White,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions=LayoutOptions.Center,
                VerticalTextAlignment = TextAlignment.Center,
                HeightRequest = 100

            };

            commentEditor = new Editor();
            commentEditor.BackgroundColor = Color.Black;
            commentEditor.TextColor = Color.LightGreen;
            commentEditor.VerticalOptions = LayoutOptions.StartAndExpand;
            commentEditor.HeightRequest = 500;

            var clearButton = new Button
            {
                Text = "Clear",
                FontSize = 24,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                HeightRequest = 60,
                WidthRequest = 150
            };

            clearButton.Clicked+=async delegate {
                await ActivityLogger.ClearLogger().ConfigureAwait(false);
                ReadLogger();

                Device.StartTimer(TimeSpan.FromSeconds(1), () =>
                {
                    commentEditor.Text = loggerDetails;
                    return false;
                });
            };

            layout.Children.Add(titleLabel);
            layout.Children.Add(commentEditor);
            layout.Children.Add(clearButton);


			layout.Padding = 10;
			layout.Spacing = 10;

            Content = new ScrollView{
                Orientation = ScrollOrientation.Horizontal,
                Content = layout
            }; // Sets dynamic layout to page 'Content' Property

            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                commentEditor.Text = loggerDetails;
                return false;
            });
        }
		//---------------------------------------------- End Of InitComp --------------------------------------

        private async void ReadLogger(){
            loggerDetails = await ActivityLogger.ReadLogger();
            Console.WriteLine(loggerDetails);
        }

    }

}
