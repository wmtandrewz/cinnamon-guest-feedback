using System;
using System.Collections.Generic;
using Xamarin.Forms;

/*
 * Authors  :   Thimira Andradi
 * Date     :   10th July 2017
 * Company  :   CHML IT - Development
 * Legal    :   All Rights Reserved | CHML IT | Development Team
 */
namespace CCFS
{
	/* Class        :   ElementController
     * Remark       :   This class contains methods which are returning relevent layouts for questions
     */

	public class ElementController
    {


        public Image bad, angry, ok, good, excellant, malePic, femalePic,yesPic,noPic;
        public SwitchCell sc1, sc2, sc3, sc4;
        public ListView listView;
        public Editor commentEditor;
        public Button commentFinishBtn,finishBtn;
        public Label val01Label,badValLabel,okValLabel,goodValLabel,excellantValLabel,maleLabel,femaleLabel,firstLabel,secondLabel;

        public int progressValue = 0;

        public ElementController()
        {
			
		}

		/*
         * Method       :   GetRatingLayout
         * Task         :   Create dynamic layout for Emoji rating bar
         * Return       :   Emoji Layout (StackLayout) --> imLayout
         */
		public StackLayout GetRatingLayout(){

            var baseLayout = new StackLayout();
			baseLayout.Orientation = StackOrientation.Vertical;
			baseLayout.HorizontalOptions = LayoutOptions.Center;

            //Emogi Base layer
			var imLayout = new StackLayout();
			imLayout.Orientation = StackOrientation.Horizontal;
			imLayout.HorizontalOptions = LayoutOptions.Center;
			imLayout.HeightRequest = 100;

            //------------------------Angry------------------------------------------
            //Angry emoji Layer
            var angryLayout = new StackLayout();
            angryLayout.Orientation = StackOrientation.Vertical;
            angryLayout.HorizontalOptions = LayoutOptions.Center;
            angryLayout.VerticalOptions = LayoutOptions.Center;
            angryLayout.WidthRequest = 150;
            angryLayout.Spacing = 20;

			//Add Label for Display selected Value of Angry
			val01Label = new Label
			{
				TextColor = Color.White,
				FontSize = 14,
                Text = "Highly Dissatisfied",
				HorizontalTextAlignment = TextAlignment.Center,
				VerticalTextAlignment = TextAlignment.Center,
                HorizontalOptions=LayoutOptions.CenterAndExpand,
				HeightRequest = 200,
			};

		    angry = new Image { Aspect = Aspect.AspectFit };
			angry.Source = ImageSource.FromFile("images/angry.png");
			angry.WidthRequest = 100;

            angryLayout.Children.Add(angry);
            angryLayout.Children.Add(val01Label);

			//-----------------------------Bad-------------------------------------

			//Bad emoji Layer
			var badLayout = new StackLayout();
			badLayout.Orientation = StackOrientation.Vertical;
			badLayout.HorizontalOptions = LayoutOptions.Center;
			badLayout.VerticalOptions = LayoutOptions.Center;
			badLayout.WidthRequest = 150;
			badLayout.Spacing = 20;

			//Add Label for Display selected Value of Bad
			badValLabel = new Label
			{
				TextColor = Color.White,
				FontSize = 14,
				Text = "Dissatisfied",
				HorizontalTextAlignment = TextAlignment.Center,
				VerticalTextAlignment = TextAlignment.Center,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				HeightRequest = 200,
			};

			bad = new Image { Aspect = Aspect.AspectFit };
			bad.Source = ImageSource.FromFile("images/sad.png");
			bad.WidthRequest = 100;

			badLayout.Children.Add(bad);
			badLayout.Children.Add(badValLabel);

			//-----------------------------ok-------------------------------------


			//OK emoji Layer
			var okLayout = new StackLayout();
			okLayout.Orientation = StackOrientation.Vertical;
			okLayout.HorizontalOptions = LayoutOptions.Center;
			okLayout.VerticalOptions = LayoutOptions.Center;
			okLayout.WidthRequest = 150;
			okLayout.Spacing = 20;

			//Add Label for Display selected Value of OK
			okValLabel = new Label
			{
				TextColor = Color.White,
				FontSize = 14,
				Text = "Neutral",
				HorizontalTextAlignment = TextAlignment.Center,
				VerticalTextAlignment = TextAlignment.Center,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				HeightRequest = 200,
			};

			ok = new Image { Aspect = Aspect.AspectFit };
			ok.Source = ImageSource.FromFile("images/shy.png");
			ok.WidthRequest = 100;

			okLayout.Children.Add(ok);
			okLayout.Children.Add(okValLabel);

			//-----------------------------good-------------------------------------


			//Good emoji Layer
			var goodLayout = new StackLayout();
			goodLayout.Orientation = StackOrientation.Vertical;
			goodLayout.HorizontalOptions = LayoutOptions.Center;
			goodLayout.VerticalOptions = LayoutOptions.Center;
			goodLayout.WidthRequest = 150;
			goodLayout.Spacing = 20;

			//Add Label for Display selected Value of Good
			goodValLabel = new Label
			{
				TextColor = Color.White,
				FontSize = 14,
				Text = "Satisfied",
				HorizontalTextAlignment = TextAlignment.Center,
				VerticalTextAlignment = TextAlignment.Center,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				HeightRequest = 200,
			};

			good = new Image { Aspect = Aspect.AspectFit };
			good.Source = ImageSource.FromFile("images/surprise.png");
			good.WidthRequest = 100;

			goodLayout.Children.Add(good);
			goodLayout.Children.Add(goodValLabel);

			//-----------------------------excellant-------------------------------------


			//Good emoji Layer
			var excellantLayout = new StackLayout();
			excellantLayout.Orientation = StackOrientation.Vertical;
			excellantLayout.HorizontalOptions = LayoutOptions.Center;
			excellantLayout.VerticalOptions = LayoutOptions.Center;
			excellantLayout.WidthRequest = 150;
			excellantLayout.Spacing = 20;

			//Add Label for Display selected Value of Good
			excellantValLabel = new Label
			{
				TextColor = Color.White,
				FontSize = 14,
				Text = "Highly Satisfied",
				HorizontalTextAlignment = TextAlignment.Center,
				VerticalTextAlignment = TextAlignment.Center,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				HeightRequest = 200,
			};

			excellant = new Image { Aspect = Aspect.AspectFit };
			excellant.Source = ImageSource.FromFile("images/love.png");
			excellant.WidthRequest = 100;

			excellantLayout.Children.Add(excellant);
			excellantLayout.Children.Add(excellantValLabel);

			//------------------------------------------------------------------

            imLayout.Children.Add(angryLayout);
            imLayout.Children.Add(badLayout);
            imLayout.Children.Add(okLayout);
			imLayout.Children.Add(goodLayout);
            imLayout.Children.Add(excellantLayout);

            baseLayout.Children.Add(imLayout);

            return baseLayout;

        }

		/*
         * Method       :   GetDualOptionLayout
         * Task         :   Create dynamic layout for Yes/No Options layout
         * Return       :   Yes/No Options Layout (StackLayout) --> optionsLayout
         * Params       :   option 1 (String) , Option 2 (String)
         */
		public StackLayout GetDualOptionLayout(String option01,String Option02){
			StackLayout layout = new StackLayout();
			layout.Orientation = StackOrientation.Horizontal;
			layout.VerticalOptions = LayoutOptions.Center;
			layout.HorizontalOptions = LayoutOptions.Center;


			var firstLayout = new StackLayout();
			firstLayout.Orientation = StackOrientation.Vertical;
			firstLayout.HorizontalOptions = LayoutOptions.Center;
			firstLayout.VerticalOptions = LayoutOptions.Center;
			firstLayout.WidthRequest = 150;
			firstLayout.Spacing = 20;

            //Add Label for Display selected Value
            firstLabel = new Label
			{
				TextColor = Color.White,
				FontSize = 24,
                Text = option01,
				HorizontalTextAlignment = TextAlignment.Center,
				VerticalTextAlignment = TextAlignment.Center,
				HorizontalOptions = LayoutOptions.Center,
				HeightRequest = 100,
			};

            yesPic = new Image { Aspect = Aspect.AspectFit };
			yesPic.Source = ImageSource.FromFile("images/yes.png");
			yesPic.WidthRequest = 100;

            firstLayout.Children.Add(yesPic);
            //firstLayout.Children.Add(firstLabel);


			//------------------------------------------
			var secondLayout = new StackLayout();
			secondLayout.Orientation = StackOrientation.Vertical;
			secondLayout.HorizontalOptions = LayoutOptions.Center;
			secondLayout.VerticalOptions = LayoutOptions.Center;
			secondLayout.WidthRequest = 150;
			secondLayout.Spacing = 20;

            //Add Label for Display selected Value
            secondLabel = new Label
			{
				TextColor = Color.White,
				FontSize = 24,
                Text = Option02,
				HorizontalTextAlignment = TextAlignment.Center,
				VerticalTextAlignment = TextAlignment.Center,
				HorizontalOptions = LayoutOptions.Center,
				HeightRequest = 100,
			};

			noPic = new Image { Aspect = Aspect.AspectFit };
			noPic.Source = ImageSource.FromFile("images/no.png");
			noPic.WidthRequest = 100;

            secondLayout.Children.Add(noPic);
            //secondLayout.Children.Add(secondLabel);

			//-------------------------------------------------------------------


            layout.Children.Add(firstLayout);
			layout.Children.Add(secondLayout);
			layout.Padding = new Thickness(150, 10, 150, 10);

			return layout;
        }

		/*
         * Method       :   GetMultiOptionsLayout
         * Task         :   Create dynamic layout for Yes/No Options layout
         * Return       :   Multi Options Layout (StackLayout) --> mulOptionsLayout
         * Params       :   options list (String[]) --> array
         */
		public StackLayout GetMultiOptionsLayout(String [] array){
            var optionSize = array.Length;
            var mulOptionsLayout = new StackLayout();
			mulOptionsLayout.Orientation = StackOrientation.Vertical;
			mulOptionsLayout.HorizontalOptions = LayoutOptions.CenterAndExpand;
			mulOptionsLayout.VerticalOptions = LayoutOptions.StartAndExpand;

            listView = new ListView();
            listView.SeparatorColor = Color.Black;
            listView.BackgroundColor = Color.White;
			listView.ItemsSource = array;
            listView.HeightRequest = 50 * optionSize;

            mulOptionsLayout.Children.Add(listView);

            return mulOptionsLayout;
        }

		/*
         * Method       :   GetCommentLayout
         * Task         :   Create dynamic layout for Comment layout
         * Return       :   Comment layout Layout (StackLayout) --> commentLayout
         */
		public StackLayout GetCommentLayout(){
            var commentLayout = new StackLayout();
            commentLayout.Orientation = StackOrientation.Vertical;

            commentEditor = new Editor();
            commentEditor.BackgroundColor = Color.Purple;
            commentEditor.TextColor = Color.Yellow;
            commentEditor.HorizontalOptions = LayoutOptions.Fill;
            commentEditor.HeightRequest = 150;

            commentLayout.Padding = new Thickness(50, 10, 50, 10);

			commentLayout.Children.Add(commentEditor);

			return commentLayout;
        }

        public StackLayout GetSliderLayout(){
            var sliderLayout = new StackLayout();

            var valueLabel = new Label();
            valueLabel.TextColor = Color.White;
            valueLabel.FontSize = 24;
            valueLabel.HorizontalTextAlignment = TextAlignment.Center;
            valueLabel.VerticalTextAlignment = TextAlignment.Center;
            valueLabel.HeightRequest = 200;


            var slider = new Slider();
            slider.WidthRequest = 200;
            slider.HeightRequest = 10;

            slider.PropertyChanging += delegate
            {
                double val = slider.Value * 100;
                progressValue = (int)val/10;
                progressValue += 1;

                valueLabel.Text = (progressValue.ToString());

            };

            finishBtn = new Button();
			finishBtn.Text = "Submit";
            finishBtn.FontSize = 24;
			finishBtn.HeightRequest = 150;


            sliderLayout.Children.Add(slider);
            sliderLayout.Children.Add(valueLabel);
            sliderLayout.Children.Add(finishBtn);

            sliderLayout.Padding = new Thickness(150, 10, 150, 10);

            return sliderLayout;
        }

		/*
         * Method       :   GetHeatLayout
         * Task         :   Create dynamic layout for Heat layout
         * Return       :   Heat layout (StackLayout) --> HeatLayout
         */

        public StackLayout GetHeatLayout(){

			var baseLayout = new StackLayout();
            baseLayout.Orientation = StackOrientation.Horizontal;
			baseLayout.HorizontalOptions = LayoutOptions.Center;
            baseLayout.VerticalOptions = LayoutOptions.Center;

            List<Color> colorList = new List<Color>();
            colorList.Add(Color.FromRgb(119, 229, 0));
            colorList.Add(Color.FromRgb(126, 206, 4));
			colorList.Add(Color.FromRgb(133, 183, 8));
            colorList.Add(Color.FromRgb(140, 160, 12));
            colorList.Add(Color.FromRgb(157, 147, 16));
            colorList.Add(Color.FromRgb(175, 130, 20));
            colorList.Add(Color.FromRgb(190, 117, 25));
            colorList.Add(Color.FromRgb(210, 100, 30));
            colorList.Add(Color.FromRgb(220, 85, 35));
            colorList.Add(Color.FromRgb(240, 60, 40));

            List<Button> heatbuttonList = new List<Button>();

            for (int i = 0; i < 10; i++)
            {
                var button = new Button
                {
                    BackgroundColor = Color.White,
                    Text = (i+1).ToString(),
                    StyleId=i.ToString(),
                    TextColor = Color.Black,
                    FontSize = 20,
                    HeightRequest = 60,
                    WidthRequest=60

				};

                heatbuttonList.Add(button);

                button.Clicked += delegate
                {
                    int sequ = 0;
                    string styleBtnID = button.StyleId;

                    foreach (var item in heatbuttonList)
                    {
                        item.BackgroundColor = Color.White;
                        item.TextColor = Color.Black;
                    }

                    foreach (var item in heatbuttonList)
                    {
                        item.BackgroundColor = colorList[sequ];
                        item.TextColor = Color.White;

                        if (styleBtnID == sequ.ToString()){
                            Console.WriteLine("Heat :"+(sequ+1));
                            break;
                        }

                        sequ++;
                    }
                };


                baseLayout.Children.Add(button);
            }


            //----------------------------------------------------------------

			return baseLayout;

        }

        public StackLayout GetGenderLayout(){
            StackLayout layout = new StackLayout();
            layout.Orientation = StackOrientation.Horizontal;
            layout.VerticalOptions = LayoutOptions.Center;
            layout.HorizontalOptions = LayoutOptions.Center;


			//Male
			var maleLayout = new StackLayout();
			maleLayout.Orientation = StackOrientation.Vertical;
			maleLayout.HorizontalOptions = LayoutOptions.Center;
			maleLayout.VerticalOptions = LayoutOptions.Center;
			maleLayout.WidthRequest = 150;
			maleLayout.Spacing = 20;

			//Add Label for Display selected Value
			 maleLabel = new Label
			{
				TextColor = Color.White,
				FontSize = 20,
				Text = "Male",
				HorizontalTextAlignment = TextAlignment.Center,
				VerticalTextAlignment = TextAlignment.Center,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				HeightRequest = 200,
			};

            malePic = new Image { Aspect = Aspect.AspectFit };
			malePic.Source = ImageSource.FromFile("images/Preppy.png");
			malePic.WidthRequest = 100;

            maleLayout.Children.Add(malePic);
            maleLayout.Children.Add(maleLabel);


            //------------------------------------------
			//Feale
			var femaleLayout = new StackLayout();
			femaleLayout.Orientation = StackOrientation.Vertical;
			femaleLayout.HorizontalOptions = LayoutOptions.Center;
			femaleLayout.VerticalOptions = LayoutOptions.Center;
			femaleLayout.WidthRequest = 150;
			femaleLayout.Spacing = 20;

			//Add Label for Display selected Value
			 femaleLabel = new Label
			{
				TextColor = Color.White,
				FontSize = 20,
				Text = "Female",
				HorizontalTextAlignment = TextAlignment.Center,
				VerticalTextAlignment = TextAlignment.Center,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				HeightRequest = 200,
			};

            femalePic = new Image { Aspect = Aspect.AspectFit };
			femalePic.Source = ImageSource.FromFile("images/Girl.png");
			femalePic.WidthRequest = 100;

			femaleLayout.Children.Add(femalePic);
			femaleLayout.Children.Add(femaleLabel);

            //-------------------------------------------------------------------


            layout.Children.Add(maleLayout);
            layout.Children.Add(femaleLayout);
			layout.Padding = new Thickness(150, 10, 150, 10);

            return layout;
        }


	}
}
