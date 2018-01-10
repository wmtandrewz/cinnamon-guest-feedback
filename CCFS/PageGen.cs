using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Timers;
using CCFS.Helpers;
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
     * Class    :   Pages
     * Remark   :   This is the PageGen Content page class
     */
    public partial class PageGen : ContentPage
    {

        public static string pageID;

        String[] otherQuestionsArray;
        String comment = "";
        double loadDelay = 0.5;//sets 500ms delay time for loading a page
        uint emoTime = 250; //emoji animation time

        public PageGen()
        {
            Title = "Language & Region";    //Sets Page Title
            InitComp(); //  Execute the method 'InitComp' for initialize User Interface elements
            BackgroundColor = Color.Black;
        }


        private void InitComp()
        {
            var layout = new StackLayout();
            layout.BackgroundColor = Color.Black;
            layout.Orientation = StackOrientation.Vertical;
            layout.VerticalOptions = LayoutOptions.CenterAndExpand;

            var titleImage = new Image { Aspect = Aspect.AspectFit };
            titleImage.Source = ImageSource.FromFile("images/cinnamon.png");
            titleImage.HeightRequest = 150;

            var welcomeLabel = new Label
            {
                Text = "Please Select Your Language",
                FontSize = 24,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                TextColor = Color.White,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                HeightRequest = 200

            };

            StackLayout upperLayer = new StackLayout();
            upperLayer.Orientation = StackOrientation.Horizontal;
            upperLayer.VerticalOptions = LayoutOptions.Center;
            upperLayer.HorizontalOptions = LayoutOptions.Center;
            upperLayer.BackgroundColor = Color.Black;

            StackLayout bottomLayer = new StackLayout();
            bottomLayer.Orientation = StackOrientation.Horizontal;
            bottomLayer.VerticalOptions = LayoutOptions.Center;
            bottomLayer.HorizontalOptions = LayoutOptions.Center;
            bottomLayer.BackgroundColor = Color.Black;


            //---------------------------------------English----------------------------------------//

            StackLayout enLayout = new StackLayout();
            enLayout.Orientation = StackOrientation.Vertical;
            enLayout.VerticalOptions = LayoutOptions.Center;
            enLayout.HorizontalOptions = LayoutOptions.Center;
            enLayout.BackgroundColor = Color.Black;

            var _ukFlag = new Image { Aspect = Aspect.AspectFit };
            _ukFlag.Source = ImageSource.FromFile("images/en.png");
            _ukFlag.HeightRequest = 60;

            var _eng = new Label
            {
                Text = "English",
                TextColor = Color.White,
                FontSize = 16,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                HeightRequest = 60,
            };

            enLayout.Children.Add(_ukFlag);
            enLayout.Children.Add(_eng);



            /*
             * Event        :   _eng Flag 'Tapped' Event
             * Task         :   Asynchronously pushing content page object 'Pages' into the Navigation stack
             */

            bool enIstapped = true;

            var enTapRecognizer = new TapGestureRecognizer();
            enTapRecognizer.Tapped += async delegate
            {
                if (enIstapped)
                {
                    enIstapped = false;

                    //Animating
                    await _ukFlag.ScaleTo(2, emoTime, Easing.CubicIn);
                    await _ukFlag.ScaleTo(1, emoTime, Easing.CubicOut);

                    try
                    {
                        Constants con = Constants.Instance;
                        var type = con.GetListElement();

                        LoadPages(type, "lang");
                        enIstapped = true;

                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        enIstapped = true;
                    }
                }
            };

            _ukFlag.GestureRecognizers.Add(enTapRecognizer);


            //---------------------------------------Chinese----------------------------------------//

            StackLayout znLayout = new StackLayout();
            znLayout.Orientation = StackOrientation.Vertical;
            znLayout.VerticalOptions = LayoutOptions.Center;
            znLayout.HorizontalOptions = LayoutOptions.Center;
            znLayout.BackgroundColor = Color.Black;

            var _znFlag = new Image { Aspect = Aspect.AspectFit };
            _znFlag.Source = ImageSource.FromFile("images/zh.png");
            _znFlag.HeightRequest = 60;

            var _zh = new Label
            {
                Text = "中文",
                TextColor = Color.White,
                FontSize = 16,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                HeightRequest = 60,
            };

            znLayout.Children.Add(_znFlag);
            znLayout.Children.Add(_zh);



            /*
             * Event        :   _zhFlag 'Tapped' Event
             * Task         :   Asynchronously pushing content page object 'Pages' into the Navigation stack
             */

            bool znTapped = true;

            var znTapRecognizer = new TapGestureRecognizer();
            znTapRecognizer.Tapped += async delegate
            {

                if (znTapped)
                {
                    znTapped = false;

                    //Animating
                    await _znFlag.ScaleTo(2, emoTime, Easing.CubicIn);
                    await _znFlag.ScaleTo(1, emoTime, Easing.CubicOut);

                    try
                    {
                        Constants con = Constants.Instance;
                        var type = con.GetListElement();
                        LoadPages(type, "lang");
                        znTapped = true;


                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        znTapped = true;
                    }
                }
            };

            _znFlag.GestureRecognizers.Add(znTapRecognizer);

            //---------------------------------------Deutsche----------------------------------------//

            StackLayout deLayout = new StackLayout();
            deLayout.Orientation = StackOrientation.Vertical;
            deLayout.VerticalOptions = LayoutOptions.Center;
            deLayout.HorizontalOptions = LayoutOptions.Center;
            deLayout.BackgroundColor = Color.Black;

            var _deFlag = new Image { Aspect = Aspect.AspectFit };
            _deFlag.Source = ImageSource.FromFile("images/de.png");
            _deFlag.HeightRequest = 60;

            var _de = new Label
            {
                Text = "Deutsche",
                TextColor = Color.White,
                FontSize = 16,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                HeightRequest = 60,
            };

            deLayout.Children.Add(_deFlag);
            deLayout.Children.Add(_de);



            /*
             * Event        :   _de Flag 'Tapped' Event
             * Task         :   Asynchronously pushing content page object 'Pages' into the Navigation stack
             */
            bool deIsTapped = true;

            var deTapRecognizer = new TapGestureRecognizer();
            deTapRecognizer.Tapped += async (s, e) =>
            {
                if (deIsTapped)
                {
                    deIsTapped = false;
                    //Animating
                    await _deFlag.ScaleTo(2, emoTime, Easing.CubicIn);
                    await _deFlag.ScaleTo(1, emoTime, Easing.CubicOut);

                    try
                    {
                        Constants con = Constants.Instance;
                        var type = con.GetListElement();
                        LoadPages(type, "lang");
                        deIsTapped = true;

                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        deIsTapped = true;
                    }
                }
            };

            _deFlag.GestureRecognizers.Add(deTapRecognizer);


            //---------------------------------------Français----------------------------------------//

            StackLayout frLayout = new StackLayout();
            frLayout.Orientation = StackOrientation.Vertical;
            frLayout.VerticalOptions = LayoutOptions.Center;
            frLayout.HorizontalOptions = LayoutOptions.Center;
            frLayout.BackgroundColor = Color.Black;

            var _frFlag = new Image { Aspect = Aspect.AspectFit };
            _frFlag.Source = ImageSource.FromFile("images/fr.png");
            _frFlag.HeightRequest = 60;

            var _fr = new Label
            {
                Text = "Français",
                TextColor = Color.White,
                FontSize = 16,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                HeightRequest = 60,
            };

            frLayout.Children.Add(_frFlag);
            frLayout.Children.Add(_fr);



            /*
             * Event        :   _fr Flag 'Tapped' Event
             * Task         :   Asynchronously pushing content page object 'Pages' into the Navigation stack
             */
            bool frIsTapped = true;

            var frTapRecognizer = new TapGestureRecognizer();
            frTapRecognizer.Tapped += async (s, e) =>
            {
                if (frIsTapped)
                {
                    frIsTapped = false;
                    //Animating
                    await _frFlag.ScaleTo(2, emoTime, Easing.CubicIn);
                    await _frFlag.ScaleTo(1, emoTime, Easing.CubicOut);

                    try
                    {
                        Constants con = Constants.Instance;
                        var type = con.GetListElement();
                        LoadPages(type, "lang");
                        frIsTapped = true;

                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        frIsTapped = true;
                    }
                }
            };

            _frFlag.GestureRecognizers.Add(frTapRecognizer);


            upperLayer.Children.Add(enLayout);
            upperLayer.Children.Add(znLayout);
            upperLayer.Spacing = 50;

            bottomLayer.Children.Add(deLayout);
            bottomLayer.Children.Add(frLayout);
            bottomLayer.Spacing = 50;

            layout.Children.Add(titleImage);
            layout.Children.Add(welcomeLabel);
            layout.Children.Add(upperLayer);
            layout.Children.Add(bottomLayer);

            layout.Padding = 10;
            layout.Spacing = 10;

            Content = layout;
        }
        //---------------------------------------------- End Of InitComp --------------------------------------

        /*
		 * Method       :   LoadPages
         * Task         :   Creates Page content Structure Dynamically | This is a Evently Handled Recursive method
         * Params       :   Type of the Question (String) --> type
         * Arguments    :   Next Page Structure (StackLayout) --> layout
         */
        StackLayout imLayout;

        private void LoadPages(string type, string pageid)
        {

            if (pageID != pageid)
            {

                pageID = pageid;

                var layout = new StackLayout();

                layout.BackgroundColor = Color.Black;

                var titleImage = new Image { Aspect = Aspect.AspectFit };
                titleImage.Source = ImageSource.FromFile("images/cinnamon.png");
                titleImage.HeightRequest = 150;

                var titleLabel = new Label
                {
                    Text = "Error in Connection",
                    FontSize = 36,
                    HorizontalTextAlignment = TextAlignment.Center,
                    VerticalTextAlignment = TextAlignment.Center,
                    TextColor = Color.White,
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    HeightRequest = 250

                };

                imLayout = new StackLayout();

                ElementController ec = new ElementController();

                /*
                 * Remark       :   Emoji Layout
                 * Condition    :   If Question Type (var type) is null 
                 *                  Program will creates emoji rating layout
                 */
                if (type == "")
                {
                    try
                    {
                        Constants cons = Constants.Instance;
                        var qu = cons.GetQuestion();    // Gets Question From 'Constants.questionList'
                        titleLabel.Text = qu;   // Sets question (var qu) to title Label 

                        var emojiRootLayout = ec.GetRatingLayout(); // Gets Relevent Content Structure (Multi Option layout) from 'ElementController'

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

                        baseLayout.Children.Add(emojiRootLayout);
                        baseLayout.Children.Add(buttonPanel);

                        imLayout = baseLayout;

                        var backtapRecognizer = new TapGestureRecognizer();
                        backtapRecognizer.Tapped += (s, e) =>
                        {
                            Navigation.PopAsync();
                        };

                        var nexttapRecognizer = new TapGestureRecognizer();
                        nexttapRecognizer.Tapped += (s, e) =>
                        {
                            try
                            {
                                Console.WriteLine("optional : "+cons.GetIsOptional());

                                if (cons.GetIsOptional() == "True")
                                {
                                    var _qcode = cons.GetQuestionCode(); // Gets Current Question Code
                                    var _qid = cons.GetQuestionID(); //Gets Current Question ID
                                    String _RJson =
                                                                        "{\"CommID\":0," +
                                                                        "\"QId\":" + _qid + "," +
                                                                        "\"Rating\":" + "0" +
                                                                        "}";

                                    SaveRatings sr = SaveRatings.SaveRatingInstance;
                                    sr.RemoveRating(_qcode);
                                    sr.SetRatings(_qcode, _RJson);

                                    ActivityLogger.AddLogger(_RJson);

                                    var ele1 = cons.GetListElement(); // Gets Next Question Type from 'Constants.pageList'
                                    var pID = cons.GetQuestionID();
                                    LoadPages(ele1, pID);
                                }

                                if (cons.GetTempValue(cons.GetQuestionID()) != null)
                                {
                                    var ele1 = cons.GetListElement(); // Gets Next Question Type from 'Constants.pageList'
                                    var pID = cons.GetQuestionID();
                                    LoadPages(ele1, pID);
                                }
                            }
                            catch (ArgumentOutOfRangeException)
                            {
                                Navigation.PushAsync(new NewsLetters());
                            }
                            catch (Exception) { }
                        };

                        backBtn.GestureRecognizers.Add(backtapRecognizer);
                        nextBtn.GestureRecognizers.Add(nexttapRecognizer);


                        //------------------------------------------------


                        if (cons.GetDisplayType() == "Slider")
                        {

                            imLayout = null;
                            //imLayout = ec.GetSliderLayout();

                            //-------------------------------------------------Heat bar-----------------------------------------------------------

                            var rootLayout = new StackLayout();
                            rootLayout.Orientation = StackOrientation.Horizontal;
                            rootLayout.HorizontalOptions = LayoutOptions.Center;
                            rootLayout.VerticalOptions = LayoutOptions.Center;

                            List<Color> colorList = new List<Color>();

                            colorList.Add(Color.FromRgb(240, 60, 40)); //Red
                            colorList.Add(Color.FromRgb(220, 85, 35));
                            colorList.Add(Color.FromRgb(210, 100, 30));
                            colorList.Add(Color.FromRgb(190, 117, 25));
                            colorList.Add(Color.FromRgb(175, 130, 20));
                            colorList.Add(Color.FromRgb(157, 147, 16));
                            colorList.Add(Color.FromRgb(140, 160, 12));
                            colorList.Add(Color.FromRgb(133, 183, 8));
                            colorList.Add(Color.FromRgb(126, 206, 4));
                            colorList.Add(Color.FromRgb(119, 229, 0)); //Green


                            List<Button> heatbuttonList = new List<Button>();

                            for (int i = 0; i < 10; i++)
                            {
                                var button = new Button
                                {
                                    BackgroundColor = Color.White,
                                    Text = (i + 1).ToString(),
                                    StyleId = i.ToString(),
                                    TextColor = Color.Black,
                                    FontSize = 20,
                                    HeightRequest = 60,
                                    WidthRequest = 60

                                };

                                heatbuttonList.Add(button);

                                try
                                {
                                //Set Heat Bar Temp Data
                                var tempQID = cons.GetNextQuestionID();
                                var heatTemp = cons.GetTempValue(tempQID);


                                    if (heatTemp != null)
                                    {
                                        int sequ = 0;

                                        foreach (var item in heatbuttonList)
                                        {
                                            item.BackgroundColor = Color.White;
                                            item.TextColor = Color.Black;
                                        }

                                        foreach (var item in heatbuttonList)
                                        {
                                            item.BackgroundColor = colorList[sequ];
                                            item.TextColor = Color.White;
                                            sequ++;

                                            if (sequ == Convert.ToInt32(heatTemp))
                                            {
                                                break;
                                            }
                                        }
                                    }
                                }
                                catch (Exception) { }

                                //Click heat event 

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

                                        if (styleBtnID == sequ.ToString())
                                        {
                                            Console.WriteLine("Heat :" + (sequ + 1));
                                            //--------------------------------------------save selection----------------------------------


                                            try
                                            {
                                                Constants con = Constants.Instance;

                                                var _qcode = con.GetQuestionCode(); // Gets Current Question Code
                                                var _qid = con.GetQuestionID(); //Gets Current Question ID
                                                String _RJson =
                                                                        "{\"CommID\":0," +
                                                                        "\"QId\":" + _qid + "," +
                                                                        "\"Rating\":" + (sequ + 1) +
                                                                        "}";

                                                SaveRatings sr = SaveRatings.SaveRatingInstance;
                                                sr.RemoveRating(_qcode);
                                                sr.SetRatings(_qcode, _RJson);

                                                ActivityLogger.AddLogger(_RJson);

                                                //Save Temp Selection Data
                                                con.RemoveFromTempNVC(_qid);
                                                con.AddToTempNVC(_qid, (sequ + 1).ToString());

                                                var ele1 = con.GetListElement(); // Gets Next Question Type from 'Constants.pageList'

                                                //Set 500ms delay for loading next page
                                                Device.StartTimer(TimeSpan.FromSeconds(loadDelay), () =>
                                                        {
                                                            try
                                                            {
                                                                LoadPages(ele1, _qid);
                                                            }
                                                            catch (ArgumentOutOfRangeException)
                                                            {
                                                                Navigation.PushAsync(new NewsLetters());
                                                            }
                                                            catch (Exception) { }

                                                            return false;
                                                        });
                                            }
                                            catch (ArgumentOutOfRangeException)
                                            {
                                                 Navigation.PushAsync(new NewsLetters());
                                            }
                                            catch (Exception) { }

                                            //--------------------------------------------------------------------------------------------


                                            break;
                                        }

                                        sequ++;
                                    }
                                };


                                rootLayout.Children.Add(button);

                            }


                            //Heat bar Navigation Panel
                            var baseLayoutht = new StackLayout();
                            baseLayoutht.Orientation = StackOrientation.Vertical;
                            baseLayoutht.HorizontalOptions = LayoutOptions.Center;
                            baseLayoutht.VerticalOptions = LayoutOptions.Center;

                            var buttonPanelht = new StackLayout();
                            buttonPanelht.Orientation = StackOrientation.Horizontal;
                            buttonPanelht.HorizontalOptions = LayoutOptions.Center;

                            var nextBtnHt = new Image { Aspect = Aspect.AspectFit };
                            nextBtnHt.Source = ImageSource.FromFile("images/next.png");
                            nextBtnHt.WidthRequest = 60;
                            nextBtnHt.HeightRequest = 60;
                            nextBtnHt.HorizontalOptions = LayoutOptions.EndAndExpand;
                            nextBtnHt.Margin = new Thickness(820, 60);

                            var backBtnHt = new Image { Aspect = Aspect.AspectFit };
                            backBtnHt.Source = ImageSource.FromFile("images/back.png");
                            backBtnHt.WidthRequest = 60;
                            backBtnHt.HeightRequest = 60;
                            backBtnHt.HorizontalOptions = LayoutOptions.StartAndExpand;
                            backBtnHt.Margin = new Thickness(10, 60);

                            buttonPanelht.Children.Add(backBtnHt);
                            buttonPanelht.Children.Add(nextBtnHt);


                            var note = new Label();
                            note.Text = "\"1\" is the lowest rating and \"10\" is the Highest rating";
                            note.VerticalOptions = LayoutOptions.Center;
                            note.HorizontalTextAlignment = TextAlignment.Center;
                            note.VerticalTextAlignment = TextAlignment.Center;
                            note.FontSize = 18;
                            note.HeightRequest = 100;
                            note.TextColor = Color.MediumPurple;

                            baseLayoutht.Children.Add(rootLayout);
                            baseLayoutht.Children.Add(note);
                            baseLayoutht.Children.Add(buttonPanelht);

                            imLayout = baseLayoutht;

                            var htBacktapRecognizer = new TapGestureRecognizer();
                            htBacktapRecognizer.Tapped += (s, e) =>
                            {
                                Navigation.PopAsync();
                            };

                            var htNexttapRecognizer = new TapGestureRecognizer();
                            htNexttapRecognizer.Tapped += (s, e) =>
                            {
                                try
                                {
                                    if (cons.GetTempValue(cons.GetQuestionID()) != null)
                                    {
                                        var ele1 = cons.GetListElement(); // Gets Next Question Type from 'Constants.pageList'
                                        var pID = cons.GetQuestionID();
                                        LoadPages(ele1, pID);
                                    }
                                }
                                catch (ArgumentOutOfRangeException)
                                {
                                    Navigation.PushAsync(new NewsLetters());
                                }
                                catch (Exception) { }
                            };

                            backBtnHt.GestureRecognizers.Add(htBacktapRecognizer);
                            nextBtnHt.GestureRecognizers.Add(htNexttapRecognizer);


                            //------------------------------------------------------------------------------------------------------------

                            /*
                            ec.finishBtn.Clicked += delegate
                            {
                                Constants con = Constants.Instance;
                                var ele1 = con.GetListElement(); // Gets Next Question Type from 'Constants.pageList'

                                var _qcode = con.GetQuestionCode(); // Gets Current Question Code
                                var _qid = con.GetQuestionID(); //Gets Current Question ID
                                String _RJson =
                                                "{\"CommID\":0," +
                                                "\"QCode\":\"" + _qcode + "\"," +
                                                "\"Rating\":" + ec.progressValue + "," +
                                                "\"QId\":" + _qid + "}";

                                SaveRatings sr = SaveRatings.SaveRatingInstance;
                                sr.RemoveRating(_qcode);
                                sr.SetRatings(_qcode, _RJson);

                                LoadPages(ele1);
                            }; */
                        }
                        else
                        {

                            //Sets Emoji initial state to color all
                            ec.bad.Opacity = 1;
                            ec.angry.Opacity = 1;
                            ec.ok.Opacity = 1;
                            ec.good.Opacity = 1;
                            ec.excellant.Opacity = 1;


                            //Set Temp Data
                            var tempQID = cons.GetNextQuestionID();
                            var heatTemp = cons.GetTempValue(tempQID);

                            if (heatTemp == "1")
                            {
                                //Fading
                                ec.bad.Opacity = 0.25;
                                ec.angry.Opacity = 1;
                                ec.ok.Opacity = 0.25;
                                ec.good.Opacity = 0.25;
                                ec.excellant.Opacity = 0.25;

                                ec.val01Label.TextColor = Color.Red;
                                ec.badValLabel.TextColor = Color.FromRgb(40, 40, 40);
                                ec.okValLabel.TextColor = Color.FromRgb(40, 40, 40);
                                ec.goodValLabel.TextColor = Color.FromRgb(40, 40, 40);
                                ec.excellantValLabel.TextColor = Color.FromRgb(40, 40, 40);

                            }
                            else if (heatTemp == "2")
                            {
                                //Fading
                                ec.bad.Opacity = 1;
                                ec.angry.Opacity = 0.25;
                                ec.ok.Opacity = 0.25;
                                ec.good.Opacity = 0.25;
                                ec.excellant.Opacity = 0.25;

                                ec.val01Label.TextColor = Color.FromRgb(40, 40, 40);
                                ec.badValLabel.TextColor = Color.Orange;
                                ec.okValLabel.TextColor = Color.FromRgb(40, 40, 40);
                                ec.goodValLabel.TextColor = Color.FromRgb(40, 40, 40);
                                ec.excellantValLabel.TextColor = Color.FromRgb(40, 40, 40);

                            }
                            else if (heatTemp == "3")
                            {
                                //Fading
                                ec.bad.Opacity = 0.25;
                                ec.angry.Opacity = 0.25;
                                ec.ok.Opacity = 1;
                                ec.good.Opacity = 0.25;
                                ec.excellant.Opacity = 0.25;

                                ec.val01Label.TextColor = Color.FromRgb(40, 40, 40);
                                ec.badValLabel.TextColor = Color.FromRgb(40, 40, 40);
                                ec.okValLabel.TextColor = Color.Yellow;
                                ec.goodValLabel.TextColor = Color.FromRgb(40, 40, 40);
                                ec.excellantValLabel.TextColor = Color.FromRgb(40, 40, 40);
                            }
                            else if (heatTemp == "4")
                            {
                                //Fading
                                ec.bad.Opacity = 0.25;
                                ec.angry.Opacity = 0.25;
                                ec.ok.Opacity = 0.25;
                                ec.good.Opacity = 1;
                                ec.excellant.Opacity = 0.25;

                                ec.val01Label.TextColor = Color.FromRgb(40, 40, 40);
                                ec.badValLabel.TextColor = Color.FromRgb(40, 40, 40);
                                ec.okValLabel.TextColor = Color.FromRgb(40, 40, 40);
                                ec.goodValLabel.TextColor = Color.LightGreen;
                                ec.excellantValLabel.TextColor = Color.FromRgb(40, 40, 40);
                            }
                            else if (heatTemp == "5")
                            {
                                //Fading
                                ec.bad.Opacity = 0.25;
                                ec.angry.Opacity = 0.25;
                                ec.ok.Opacity = 0.25;
                                ec.good.Opacity = 0.25;
                                ec.excellant.Opacity = 1;

                                ec.val01Label.TextColor = Color.FromRgb(40, 40, 40);
                                ec.badValLabel.TextColor = Color.FromRgb(40, 40, 40);
                                ec.okValLabel.TextColor = Color.FromRgb(40, 40, 40);
                                ec.goodValLabel.TextColor = Color.FromRgb(40, 40, 40);
                                ec.excellantValLabel.TextColor = Color.Green;
                            }
                            else if (heatTemp == null)
                            {
                                //Do Nothing
                            }


                            /* Event        :   Emoji image 'Tapped' Event
                             * Task         :   Sets Tap Recognizers to Angry emoji and fadeout other emojis and
                             *                  Execute LoadPages method to push Content page objects into Navigation Stack
                             * Arguments    :   Next Question Type (String) --> ele
                             */
                            bool IsAngryTapped = true;

                            var angryTapRecognizer = new TapGestureRecognizer();
                            angryTapRecognizer.Tapped += async delegate
                            {
                                if (IsAngryTapped)
                                {
                                    IsAngryTapped = false;

                                    //Fading
                                    ec.bad.Opacity = 0.25;
                                    ec.angry.Opacity = 1;
                                    ec.ok.Opacity = 0.25;
                                    ec.good.Opacity = 0.25;
                                    ec.excellant.Opacity = 0.25;

                                    //Animating
                                    await ec.angry.ScaleTo(2, emoTime, Easing.CubicIn);
                                    await ec.angry.ScaleTo(1, emoTime, Easing.CubicOut);

                                    ec.goodValLabel.Text = "Highly Dissatisfied";

                                    ec.val01Label.TextColor = Color.Red;
                                    ec.badValLabel.TextColor = Color.FromRgb(40, 40, 40);
                                    ec.okValLabel.TextColor = Color.FromRgb(40, 40, 40);
                                    ec.goodValLabel.TextColor = Color.FromRgb(40, 40, 40);
                                    ec.excellantValLabel.TextColor = Color.FromRgb(40, 40, 40);

                                    try
                                    {
                                        Constants con = Constants.Instance;

                                        var _qcode = con.GetQuestionCode(); // Gets Current Question Code
                                        var _qid = con.GetQuestionID(); //Gets Current Question ID
                                        String _RJson =
                                                                "{\"CommID\":0," +
                                                                "\"QId\":" + _qid + "," +
                                                                "\"Rating\":1" +
                                                                "}";

                                        SaveRatings sr = SaveRatings.SaveRatingInstance;
                                        sr.RemoveRating(_qcode);
                                        sr.SetRatings(_qcode, _RJson);

                                        ActivityLogger.AddLogger(_RJson);

                                        //Save Temp Selection Data
                                        con.RemoveFromTempNVC(_qid);
                                        con.AddToTempNVC(_qid, "1");

                                        var ele = con.GetListElement(); // Gets Next Question Type from 'Constants.pageList'

                                        //Set 500ms delay for loading next page
                                        Device.StartTimer(TimeSpan.FromSeconds(loadDelay), () =>
                                                {

                                                    LoadPages(ele, _qid);
                                                    IsAngryTapped = true;

                                                    return false;
                                                });
                                    }
                                    catch (ArgumentOutOfRangeException)
                                    {
                                        await Navigation.PushAsync(new NewsLetters());
                                    }
                                    catch (Exception) { }
                                }


                            };

                            /* Event        :   Emoji image 'Tapped' Event
                             * Task         :   Sets Tap Recognizers to Bad emoji and fadeout other emojis and 
                             *                  Execute LoadPages method to push Content page objects into Navigation Stack
                             * Arguments    :   Next Question Type (String) --> ele
                             */
                            bool IsBadTapped = true;

                            var badTapRecognizer = new TapGestureRecognizer();
                            badTapRecognizer.Tapped += async delegate
                            {
                                if (IsBadTapped)
                                {
                                    IsBadTapped = false;

                                    //Fading
                                    ec.bad.Opacity = 1;
                                    ec.angry.Opacity = 0.25;
                                    ec.ok.Opacity = 0.25;
                                    ec.good.Opacity = 0.25;
                                    ec.excellant.Opacity = 0.25;


                                    //Animating
                                    await ec.bad.ScaleTo(2, emoTime, Easing.CubicIn);
                                    await ec.bad.ScaleTo(1, emoTime, Easing.CubicOut);

                                    ec.goodValLabel.Text = "Dissatisfied";

                                    ec.val01Label.TextColor = Color.FromRgb(40, 40, 40);
                                    ec.badValLabel.TextColor = Color.Orange;
                                    ec.okValLabel.TextColor = Color.FromRgb(40, 40, 40);
                                    ec.goodValLabel.TextColor = Color.FromRgb(40, 40, 40);
                                    ec.excellantValLabel.TextColor = Color.FromRgb(40, 40, 40);

                                    try
                                    {
                                        Constants con = Constants.Instance;

                                        var _qcode = con.GetQuestionCode(); // Gets Current Question Code
                                        var _qid = con.GetQuestionID(); //Gets Current Question ID

                                        String _RJson =
                                                            "{\"CommID\":0," +
                                                                "\"QId\":" + _qid + "," +
                                                                "\"Rating\":2" +
                                                                "}";

                                        SaveRatings sr = SaveRatings.SaveRatingInstance;
                                        sr.RemoveRating(_qcode);
                                        sr.SetRatings(_qcode, _RJson);

                                        ActivityLogger.AddLogger(_RJson);

                                        //Save Temp Selection Data
                                        con.RemoveFromTempNVC(_qid);
                                        con.AddToTempNVC(_qid, "2");

                                        var ele = con.GetListElement(); // Gets Next Question Type from 'Constants.pageList'

                                        //Set 500ms delay for loading next page
                                        Device.StartTimer(TimeSpan.FromSeconds(loadDelay), () =>
                                                {

                                                    LoadPages(ele, _qid);
                                                    IsBadTapped = true;

                                                    return false;
                                                });
                                    }
                                    catch (ArgumentOutOfRangeException)
                                    {
                                        await Navigation.PushAsync(new NewsLetters());
                                    }
                                    catch (Exception) { }
                                }
                            };

                            /* Event        :   Emoji image 'Tapped' Event
                             * Task         :   Sets Tap Recognizers to OK emoji and fadeout other emojis and
                             *                  Execute LoadPages method to push Content page objects into Navigation Stack
                             * Arguments    :   Next Question Type (String) --> ele
                             */
                            bool IsOKTapped = true;

                            var okTapRecognizer = new TapGestureRecognizer();
                            okTapRecognizer.Tapped += async delegate
                            {
                                if (IsOKTapped)
                                {
                                    IsOKTapped = false;

                                    //Fading
                                    ec.bad.Opacity = 0.25;
                                    ec.angry.Opacity = 0.25;
                                    ec.ok.Opacity = 1;
                                    ec.good.Opacity = 0.25;
                                    ec.excellant.Opacity = 0.25;

                                    //Animating
                                    await ec.ok.ScaleTo(2, emoTime, Easing.CubicIn);
                                    await ec.ok.ScaleTo(1, emoTime, Easing.CubicOut);


                                    ec.goodValLabel.Text = "Neutral";

                                    ec.val01Label.TextColor = Color.FromRgb(40, 40, 40);
                                    ec.badValLabel.TextColor = Color.FromRgb(40, 40, 40);
                                    ec.okValLabel.TextColor = Color.Yellow;
                                    ec.goodValLabel.TextColor = Color.FromRgb(40, 40, 40);
                                    ec.excellantValLabel.TextColor = Color.FromRgb(40, 40, 40);

                                    try
                                    {
                                        Constants con = Constants.Instance;

                                        var _qcode = con.GetQuestionCode(); // Gets Current Question Code
                                        var _qid = con.GetQuestionID(); //Gets Current Question ID

                                        String _RJson =
                                                            "{\"CommID\":0," +
                                                                "\"QId\":" + _qid + "," +
                                                                "\"Rating\":3" +
                                                                "}";

                                        SaveRatings sr = SaveRatings.SaveRatingInstance;
                                        sr.RemoveRating(_qcode);
                                        sr.SetRatings(_qcode, _RJson);

                                        ActivityLogger.AddLogger(_RJson);

                                        //Save Temp Selection Data
                                        con.RemoveFromTempNVC(_qid);
                                        con.AddToTempNVC(_qid, "3");

                                        var ele = con.GetListElement(); // Gets Next Question Type from 'Constants.pageList'

                                        //Set 500ms delay for loading next page
                                        Device.StartTimer(TimeSpan.FromSeconds(loadDelay), () =>
                                                {

                                                    LoadPages(ele, _qid);
                                                    IsOKTapped = true;


                                                    return false;
                                                });
                                    }
                                    catch (ArgumentOutOfRangeException)
                                    {
                                        await Navigation.PushAsync(new NewsLetters());
                                    }
                                    catch (Exception) { }
                                }
                            };

                            /* Event        :   Emoji image 'Tapped' Event
                             * Task         :   Sets Tap Recognizers to Good emoji and fadeout other emojis and
                             *                  Execute LoadPages method to push Content page objects into Navigation Stack
                             * Arguments    :   Next Question Type (String) --> ele
                             */

                            bool IsGoodTapped = true;

                            var goodTapRecognizer = new TapGestureRecognizer();
                            goodTapRecognizer.Tapped += async delegate
                            {
                                if (IsGoodTapped)
                                {
                                    IsGoodTapped = false;

                                    //Fading
                                    ec.bad.Opacity = 0.25;
                                    ec.angry.Opacity = 0.25;
                                    ec.ok.Opacity = 0.25;
                                    ec.good.Opacity = 1;
                                    ec.excellant.Opacity = 0.25;

                                    //Animating
                                    await ec.good.ScaleTo(2, emoTime, Easing.CubicIn);
                                    await ec.good.ScaleTo(1, emoTime, Easing.CubicOut);

                                    ec.goodValLabel.Text = "Satisfied";

                                    ec.val01Label.TextColor = Color.FromRgb(40, 40, 40);
                                    ec.badValLabel.TextColor = Color.FromRgb(40, 40, 40);
                                    ec.okValLabel.TextColor = Color.FromRgb(40, 40, 40);
                                    ec.goodValLabel.TextColor = Color.LightGreen;
                                    ec.excellantValLabel.TextColor = Color.FromRgb(40, 40, 40);


                                    try
                                    {
                                        Constants con = Constants.Instance;

                                        var _qcode = con.GetQuestionCode(); // Gets Current Question Code
                                        var _qid = con.GetQuestionID(); //Gets Current Question ID

                                        String _RJson =
                                                            "{\"CommID\":0," +
                                                                "\"QId\":" + _qid + "," +
                                                                "\"Rating\":4" +
                                                                "}";

                                        SaveRatings sr = SaveRatings.SaveRatingInstance;
                                        sr.RemoveRating(_qcode);
                                        sr.SetRatings(_qcode, _RJson);

                                        ActivityLogger.AddLogger(_RJson);

                                        //Save Temp Selection Data
                                        con.RemoveFromTempNVC(_qid);
                                        con.AddToTempNVC(_qid, "4");

                                        var ele = con.GetListElement();// Gets Next Question Type from 'Constants.pageList'

                                        //Set 500ms delay for loading next page
                                        Device.StartTimer(TimeSpan.FromSeconds(loadDelay), () =>
                                                {

                                                    LoadPages(ele, _qid);
                                                    IsGoodTapped = true;

                                                    return false;
                                                });
                                    }
                                    catch (ArgumentOutOfRangeException)
                                    {
                                        await Navigation.PushAsync(new NewsLetters());
                                    }
                                    catch (Exception) { }
                                }
                            };

                            /* Event        :   Emoji image 'Tapped' Event
                             * Task         :   Sets Tap Recognizers to Excellant emoji and fadeout other emojis and
                             *                  Execute LoadPages method to push Content page objects into Navigation Stack
                             * Arguments    :   Next Question Type (String) --> ele
                             */
                            bool IsExcTapped = true;

                            var excellentTapRecognizer = new TapGestureRecognizer();
                            excellentTapRecognizer.Tapped += async delegate
                            {
                                if (IsExcTapped)
                                {
                                    IsExcTapped = false;

                                    //Fading
                                    ec.bad.Opacity = 0.25;
                                    ec.angry.Opacity = 0.25;
                                    ec.ok.Opacity = 0.25;
                                    ec.good.Opacity = 0.25;
                                    ec.excellant.Opacity = 1;

                                    //Animating
                                    await ec.excellant.ScaleTo(2, emoTime, Easing.CubicIn);
                                    await ec.excellant.ScaleTo(1, emoTime, Easing.CubicOut);

                                    ec.badValLabel.Text = "Highly Satisfied";

                                    ec.val01Label.TextColor = Color.FromRgb(40, 40, 40);
                                    ec.badValLabel.TextColor = Color.FromRgb(40, 40, 40);
                                    ec.okValLabel.TextColor = Color.FromRgb(40, 40, 40);
                                    ec.goodValLabel.TextColor = Color.FromRgb(40, 40, 40);
                                    ec.excellantValLabel.TextColor = Color.Green;

                                    try
                                    {
                                        Constants con = Constants.Instance;

                                        var _qcode = con.GetQuestionCode(); // Gets Current Question Code
                                        var _qid = con.GetQuestionID(); //Gets Current Question ID

                                        String _RJson =
                                                            "{\"CommID\":0," +
                                                                "\"QId\":" + _qid + "," +
                                                                "\"Rating\":5" +
                                                                "}";



                                        SaveRatings sr = SaveRatings.SaveRatingInstance;
                                        sr.RemoveRating(_qcode);
                                        sr.SetRatings(_qcode, _RJson);

                                        ActivityLogger.AddLogger(_RJson);

                                        //Save Temp Selection Data
                                        con.RemoveFromTempNVC(_qid);
                                        con.AddToTempNVC(_qid, "5");

                                        var ele = con.GetListElement(); // Gets Next Question Type from 'Constants.pageList'

                                        //Set 500ms delay for loading next page
                                        Device.StartTimer(TimeSpan.FromSeconds(loadDelay), () =>
                                                {

                                                    LoadPages(ele, _qid);
                                                    IsExcTapped = true;

                                                    return false;
                                                });
                                    }
                                    catch (ArgumentOutOfRangeException)
                                    {
                                        await Navigation.PushAsync(new NewsLetters());
                                    }
                                    catch (Exception) { }
                                }
                            };

                            ec.angry.GestureRecognizers.Add(angryTapRecognizer);
                            ec.bad.GestureRecognizers.Add(badTapRecognizer);
                            ec.ok.GestureRecognizers.Add(okTapRecognizer);
                            ec.good.GestureRecognizers.Add(goodTapRecognizer);
                            ec.excellant.GestureRecognizers.Add(excellentTapRecognizer);

                            //------------------------------------------------ End of Emoji Layout Condition -------------------------------------
                        }
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        Navigation.PushAsync(new NewsLetters());
                    }
                    catch (Exception) { }
                }

                /*
                 * Remark       :   Yes / No Layout
                 * Condition    :   If Question Type (var type) is Y 
                 *                  Program will creates Yes / No option layout
                 * Arguments    :   yes (String) , No (String)
                 */

                else if (type == "Y")
                {
                    try
                    {
                        Constants cons = Constants.Instance;
                        var qu = cons.GetQuestion();    // Gets Next Question Type from 'Constants.pageList'
                        titleLabel.Text = qu;

                        imLayout = null;
                        var rootLayout = ec.GetDualOptionLayout("Yes", "No");

                        //----------------------------------------------------------
                        //Navigation Panel
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

                        baseLayout.Children.Add(rootLayout);
                        baseLayout.Children.Add(buttonPanel);

                        imLayout = baseLayout;

                        //Set Temp Data
                        var tempQID = cons.GetNextQuestionID();
                        var heatTemp = cons.GetTempValue(tempQID);

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

                                    cons.SetCount();
                                    var ele1 = cons.GetListElement(); // Gets Next Question Type from 'Constants.pageList'
                                    var pID = cons.GetQuestionID();
                                    LoadPages(ele1, pID);

                                }
                                else if (heatTemp == "1")
                                {

                                    var ele1 = cons.GetListElement(); // Gets Next Question Type from 'Constants.pageList'
                                    var pID = cons.GetQuestionID();
                                    LoadPages(ele1, pID);


                                }
                                else
                                {

                                }
                            }
                            catch (ArgumentOutOfRangeException)
                            {
                                Navigation.PushAsync(new NewsLetters());
                            }
                            catch (Exception) { }
                        };

                        backBtn.GestureRecognizers.Add(backtapRecognizer);
                        nextBtn.GestureRecognizers.Add(NexttapRecognizer);
                        //--------------------------------------------------------


                        /* Event        :   Yes pic  'Tapped' Event
                         * Task         :   Execute LoadPages method to push Content page objects into Navigation Stack and
                         * Arguments    :   Next Question Type (String) --> ele
                         */
                        var yesTapRecognizer = new TapGestureRecognizer();
                        yesTapRecognizer.Tapped += async (s, e) =>
                        {
                            try
                            {
                                ec.yesPic.Opacity = 1;
                                ec.noPic.Opacity = 0.25;

                                //Animating 
                                await ec.yesPic.ScaleTo(2, 150, Easing.SinIn);
                                await ec.yesPic.ScaleTo(1, 150, Easing.SinOut);

                                ec.firstLabel.TextColor = Color.Green;
                                ec.secondLabel.TextColor = Color.Gray;


                                Constants con = Constants.Instance;

                                var _qcode = con.GetQuestionCode(); // Gets Current Question Code
                                var _qid = con.GetQuestionID(); //Gets Current Question ID

                                String _RJson =
                                                            "{\"CommID\":0," +
                                                            "\"QId\":" + _qid + "," +
                                                            "\"Rating\":1" +
                                                            "}";

                                SaveRatings sr = SaveRatings.SaveRatingInstance;
                                sr.RemoveRating(_qcode);
                                sr.SetRatings(_qcode, _RJson);

                                ActivityLogger.AddLogger(_RJson);

                                //Save Temp Selection Data
                                con.RemoveFromTempNVC(_qid);
                                con.AddToTempNVC(_qid, "1");

                                var ele = con.GetListElement(); // Gets Next Question Type from 'Constants.pageList'

                                //Set 500ms delay for loading next page
                                Device.StartTimer(TimeSpan.FromSeconds(loadDelay), () =>
                                        {
                                            LoadPages(ele, _qid);
                                            return false;
                                        });

                            }
                            catch (ArgumentOutOfRangeException)
                            {
                                await Navigation.PushAsync(new NewsLetters());
                            }
                            catch (Exception) { }
                        };

                        /* Event        :   No pic  'Tapped' Event
                         * Task         :   Execute LoadPages method to push Content page objects into Navigation Stack and
                         * Arguments    :   Next Question Type (String) --> ele
                         */

                        var noTapRecognizer = new TapGestureRecognizer();
                        noTapRecognizer.Tapped += async (s, e) =>
                        {

                            try
                            {
                                ec.yesPic.Opacity = 0.25;
                                ec.noPic.Opacity = 1;

                                //Animating 
                                await ec.noPic.ScaleTo(2, 150, Easing.SinIn);
                                await ec.noPic.ScaleTo(1, 150, Easing.SinOut);

                                ec.firstLabel.TextColor = Color.Gray;
                                ec.secondLabel.TextColor = Color.Red;


                                Constants con = Constants.Instance;

                                var _qidnow = con.GetQuestionID(); //Gets Current Question ID
                                var _qcode = con.GetQuestionCode(); // Gets Current Question Code

                                con.SetCount();

                                //Save Temp Selection Data
                                con.RemoveFromTempNVC(_qidnow);
                                con.AddToTempNVC(_qidnow, "0");

                                Console.WriteLine(_qidnow + "n0");

                                String _RJson =
                                                    "{\"CommID\":0," +
                                                    "\"QId\":" + _qidnow + "," +
                                                    "\"Rating\":0" +
                                                    "}";

                                SaveRatings sr = SaveRatings.SaveRatingInstance;
                                sr.RemoveRating(_qcode);
                                sr.SetRatings(_qcode, _RJson);

                                ActivityLogger.AddLogger(_RJson);

                                var ele = con.GetListElement(); // Gets Next Question Type from 'Constants.pageList'

                                //Set 500ms delay for loading next page
                                Device.StartTimer(TimeSpan.FromSeconds(loadDelay), () =>
                                        {
                                            LoadPages(ele, _qidnow);
                                            return false;
                                        });
                            }
                            catch (ArgumentOutOfRangeException)
                            {
                                await Navigation.PushAsync(new NewsLetters());
                            }
                            catch (Exception) { }
                        };

                        ec.yesPic.GestureRecognizers.Add(yesTapRecognizer);
                        ec.noPic.GestureRecognizers.Add(noTapRecognizer);

                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        Navigation.PushAsync(new NewsLetters());
                    }
                    catch (Exception) { }

                    //------------------------------------------------ End of Yes/No Layout Condition -------------------------------------
                }

                /*
                 * Remark       :   Multi Options Layout
                 * Condition    :   If Question Type (var type) is O 
                 *                  Program will creates Multi option layout
                 */
                else if (type == "O")
                {
                    try
                    {
                        Constants cons = Constants.Instance;
                        var qu = cons.GetQuestion();    // Gets Question From 'Constants.questionList'
                        otherQuestionsArray = cons.GetOtherQuestionArray(); // Gets Other Options array from 'Constants.otherQuestionsArrayList'

                        titleLabel.Text = qu; // Sets question (var qu) to title Label 


                        imLayout = null;

                        StackLayout optionsRootLayout;
                        //StackLayout genderRootLayout;

                        //-----------------------------------------------------------------------------

                        var optionSize = otherQuestionsArray.Length;
                        var mulOptionsLayout = new StackLayout();
                        mulOptionsLayout.Orientation = StackOrientation.Vertical;
                        mulOptionsLayout.HorizontalOptions = LayoutOptions.CenterAndExpand;
                        mulOptionsLayout.VerticalOptions = LayoutOptions.StartAndExpand;

                        //options  Navigation Panel
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

                        List<Label> labelList = new List<Label>();
                        NameValueCollection SelectedOps = new NameValueCollection();

                        //Get saved vales
                        var temp = cons.GetTempOQValue(cons.GetNextQuestionID());

                        if (temp != null)
                        {
                            SelectedOps.Clear();

                            string[] values = temp.Split(',');

                            for (int ii = 0; ii < values.Length; ii++)
                            {
                                SelectedOps.Add(values[ii], values[ii]);
                                Console.WriteLine("value :" + values[ii]);
                            }

                            Console.WriteLine("Selected Ops :" + SelectedOps.Count);
                        }

                        //---------------------------------------------------------

                        for (int i = 0; i < optionSize; i++)
                        {

                            var label = new Label()
                            {
                                BackgroundColor = Color.Purple,
                                TextColor = Color.White,
                                FontSize = 20,
                                Text = otherQuestionsArray[i],
                                HorizontalTextAlignment = TextAlignment.Center,
                                VerticalTextAlignment = TextAlignment.Center,
                                WidthRequest = 500,
                                HeightRequest = 40

                            };

                            labelList.Add(label);

                            //-------------------Single selection event---------------------------
                            var tapRecognizer = new TapGestureRecognizer();
                            tapRecognizer.Tapped += (s, e) =>
                            {

                                int seq = 0;
                                string selected = "1";

                                foreach (var item in labelList)
                                {
                                    item.BackgroundColor = Color.FromRgb(60, 0, 70);
                                    item.TextColor = Color.White;
                                    if (item.Id == ((Label)s).Id)
                                    {
                                        item.BackgroundColor = Color.Purple;
                                        item.TextColor = Color.White;
                                        selected = seq.ToString();
                                        Console.WriteLine("selected item :" + selected);
                                    }

                                    seq++;
                                }

                                ItemSelected(selected); //save selected item

                            };

                            //-------------------End of single selection event---------------------------

                            //------------------- Multi single selection event---------------------------

                            var multiTapRecognizer = new TapGestureRecognizer();
                            multiTapRecognizer.Tapped += (s, e) =>
                            {
                                int index = 1;

                                foreach (var item in labelList)
                                {
                                    if (item.Id == ((Label)s).Id)
                                    {
                                        if (item.BackgroundColor == Color.Purple)
                                        {
                                            item.BackgroundColor = Color.FromRgb(60, 0, 70);
                                            SelectedOps.Remove(index.ToString());
                                        }
                                        else
                                        {
                                            item.BackgroundColor = Color.Purple;
                                            SelectedOps.Remove(index.ToString());
                                            SelectedOps.Add(index.ToString(), index.ToString());
                                        }

                                        item.TextColor = Color.White;
                                    }

                                    index++;
                                }

                                Console.WriteLine("Selected Ops Count :" + SelectedOps.Count);

                            };

                            //------------------- End of Multi single selection event--------------------


                            if (cons.GetUIControlCode() == "cbl")
                            {
                                label.GestureRecognizers.Add(multiTapRecognizer);
                                label.BackgroundColor = Color.FromRgb(60, 0, 70);
                            }
                            else
                            {
                                label.GestureRecognizers.Add(tapRecognizer);
                            }


                            mulOptionsLayout.Children.Add(label);
                        }

                        optionsRootLayout = mulOptionsLayout;
                        baseLayout.Children.Add(optionsRootLayout);

                        //-----------------------------------------------------------------------------

                        //imLayout = ec.GetMultiOptionsLayout(otherQuestionsArray);
                        //ec.listView.ItemSelected += ItemSelected;

                        //------------------------------------------------- End of Multi OPtion Layout Condition -------------------------------
                        //}
                        //----------------------------------------------------------------------------

                        baseLayout.Children.Add(buttonPanel);

                        imLayout = baseLayout;


                        //Set Temp Data
                        if (cons.GetUIControlCode() != "cbl")
                        {
                            var tempQID = cons.GetNextQuestionID();
                            var valueTemp = cons.GetTempValue(tempQID);

                            try
                            {
                                if (valueTemp != null)
                                {
                                    int seq = 0;

                                    foreach (var item in labelList)
                                    {
                                        item.BackgroundColor = Color.FromRgb(60, 0, 70);
                                        item.TextColor = Color.White;
                                        if (seq == Convert.ToInt32(valueTemp))
                                        {
                                            item.BackgroundColor = Color.Purple;
                                            item.TextColor = Color.White;
                                        }

                                        seq++;
                                    }
                                }
                            }
                            catch (Exception) { }
                        }
                        else
                        {
                            //Multi selection ---> UI Control cbl

                            var tempQID = cons.GetNextQuestionID();
                            string valueTemp = cons.GetTempOQValue(tempQID);
                            int seq = 1;
                            int index = 0;

                            if (valueTemp != null)
                            {
                                string[] values = valueTemp.Split(',');

                                foreach (var item in labelList)
                                {
                                    item.BackgroundColor = Color.FromRgb(60, 0, 70);
                                    item.TextColor = Color.White;

                                    try
                                    {
                                        if (seq == Convert.ToInt32(values[index]))
                                        {
                                            item.BackgroundColor = Color.Purple;
                                            item.TextColor = Color.White;
                                            index++;
                                        }
                                    }
                                    catch (Exception)
                                    {

                                    }

                                    seq++;
                                }
                            }


                        }

                        //-----------------------------------------------------------------

                        var backtapRecognizer = new TapGestureRecognizer();
                        backtapRecognizer.Tapped += (s, e) =>
                        {
                            Navigation.PopAsync();
                        };

                        var NexttapRecognizer = new TapGestureRecognizer();
                        NexttapRecognizer.Tapped += (s, e) =>
                        {

                            if (cons.GetTempValue(cons.GetQuestionID()) != null)
                            {
                                var ele1 = cons.GetListElement(); // Gets Next Question Type from 'Constants.pageList'
                                var pID = cons.GetQuestionID();
                                LoadPages(ele1, pID);
                            }

                        };

                        var NextMultitapRecognizer = new TapGestureRecognizer();
                        NextMultitapRecognizer.Tapped += (s, e) =>
                        {

                            try
                            {
                                MultiItemSelected(SelectedOps);

                                var ele1 = cons.GetListElement(); // Gets Next Question Type from 'Constants.pageList'
                                var pID = cons.GetQuestionID();
                                LoadPages(ele1, pID);
                            }
                            catch (ArgumentOutOfRangeException)
                            {
                                Navigation.PushAsync(new NewsLetters());
                            }
                            catch (Exception) { }

                        };

                        backBtn.GestureRecognizers.Add(backtapRecognizer);

                        if (cons.GetUIControlCode() == "cbl")
                        {
                            nextBtn.GestureRecognizers.Add(NextMultitapRecognizer);
                        }
                        else
                        {
                            nextBtn.GestureRecognizers.Add(NexttapRecognizer);
                        }
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        Navigation.PushAsync(new NewsLetters());
                    }
                    catch (Exception) { }
                    //--------------------------------------------------------
                }

                /*
                 * Remark       :   Comment Layout
                 * Condition    :   If Question Type (var type) is C 
                 *                  Program will creates Comment layout
                 * Events       :   comment Editor 'Completed' Event --> StatementCompleted
                 */
                else if (type == "C")
                {
                    try
                    {
                        Constants cons = Constants.Instance;
                        var qu = cons.GetQuestion();

                        titleLabel.Text = qu;

                        imLayout = null;
                        imLayout = ec.GetCommentLayout();

                        var buttonPanel = new StackLayout();
                        buttonPanel.Orientation = StackOrientation.Horizontal;
                        buttonPanel.HorizontalOptions = LayoutOptions.Center;

                        var nextBtn = new Image { Aspect = Aspect.AspectFit };
                        nextBtn.Source = ImageSource.FromFile("images/next.png");
                        nextBtn.WidthRequest = 60;
                        nextBtn.HeightRequest = 60;
                        nextBtn.HorizontalOptions = LayoutOptions.EndAndExpand;
                        nextBtn.Margin = new Thickness(720, 60);

                        var backBtn = new Image { Aspect = Aspect.AspectFit };
                        backBtn.Source = ImageSource.FromFile("images/back.png");
                        backBtn.WidthRequest = 60;
                        backBtn.HeightRequest = 60;
                        backBtn.HorizontalOptions = LayoutOptions.StartAndExpand;
                        backBtn.Margin = new Thickness(10, 60);

                        buttonPanel.Children.Add(backBtn);
                        buttonPanel.Children.Add(nextBtn);

                        imLayout.Children.Add(buttonPanel);

                        var tempQID = cons.GetNextQuestionID();
                        var cmmTemp = cons.GetTempValue(tempQID);

                        try
                        {
                            if (cmmTemp != null || cmmTemp != "\n")
                            {
                                ec.commentEditor.Text = cmmTemp;
                                ec.commentEditor.Focus();
                            }
                            else
                            {
                                ec.commentEditor.Text = "";
                                ec.commentEditor.Focus();
                            }
                        }
                        catch (Exception) { }

                        ec.commentEditor.TextChanged += delegate
                        {

                            comment = ec.commentEditor.Text; // Get comment on comment editor
                            comment = comment.Replace('\n', ' ');

                            //If Enter pressed sets unfocus keyboard
                            if (ec.commentEditor.Text.Contains("\n"))
                            {
                                ec.commentEditor.Unfocus();
                                comment = comment.Replace('\n', ' ');
                                ec.commentEditor.Text = comment;
                            }
                        };


                        var backtapRecognizer = new TapGestureRecognizer();
                        backtapRecognizer.Tapped += (s, e) =>
                        {
                            Navigation.PopAsync();
                        };

                        backBtn.GestureRecognizers.Add(backtapRecognizer);

                        var tapRecognizer = new TapGestureRecognizer();
                        tapRecognizer.Tapped += (s, e) =>
                        {

                            try
                            {
                                Constants con = Constants.Instance;

                                var _qcode = con.GetQuestionCode(); // Gets Current Question Code
                                var _qid = con.GetQuestionID(); //Gets Current Question ID

                                String _CommJson =
                                        "{\"CommID\":0," +
                                        "\"QId\":" + _qid + "," +
                                        "\"Comment\":\"" + comment + "\"" +
                                        "}";


                                SaveRatings sr = SaveRatings.SaveRatingInstance;
                                try { sr.RemoveComment(_qcode); } catch (NullReferenceException) { }
                                sr.SetComments(_qcode, _CommJson);

                                ActivityLogger.AddLogger(_CommJson);

                                //Save Temp Selection Data
                                con.RemoveFromTempNVC(_qid);
                                con.AddToTempNVC(_qid, comment);

                                var ele = con.GetListElement(); // Gets Next Question Type from 'Constants.pageList'

                                LoadPages(ele, _qid);

                            }
                            catch (ArgumentOutOfRangeException)
                            {
                                Constants con = Constants.Instance;

                                var _qcode = con.GetQuestionCode(); // Gets Current Question Code
                                var _qid = con.GetQuestionID(); //Gets Current Question ID

                                String _CommJson =
                                        "{\"CommID\":0," +
                                        "\"QId\":" + _qid + "," +
                                        "\"Comment\":\"" + comment + "\"" +
                                        "}";

                                SaveRatings sr = SaveRatings.SaveRatingInstance;
                                try { sr.RemoveComment(_qcode); } catch (NullReferenceException) { }
                                sr.SetComments(_qcode, _CommJson);

                                ActivityLogger.AddLogger(_CommJson);

                                //Save Temp Selection Data
                                con.RemoveFromTempNVC(_qid);
                                con.AddToTempNVC(_qid, comment);

                                Navigation.PushAsync(new NewsLetters());

                            }
                        };

                        nextBtn.GestureRecognizers.Add(tapRecognizer);
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        Navigation.PushAsync(new NewsLetters());
                    }
                    catch (Exception) { }


                    //------------------------------------------------- End of Comment Layout Condition -------------------------------
                }
                else
                {
                    titleLabel.Text = "End";
                    imLayout = new StackLayout();
                }

                var progressLabel = new Label()
                {
                    VerticalOptions = LayoutOptions.Start,
                    HorizontalTextAlignment = TextAlignment.Center,
                    VerticalTextAlignment = TextAlignment.Center,
                    TextColor = Color.Green,
                    FontSize = 18
                };

                //For showing how many questins completed
                var progressBar = new ProgressBar
                {
                    VerticalOptions = LayoutOptions.Start,
                    Progress = .05,


                };

                Constants c = Constants.Instance;
                double pListSize = c.GetPagesListSize();
                double curPageCount = c.GetCount();
                double completedCount = (curPageCount / pListSize);

                Console.WriteLine("Progress" + ":" + completedCount);
                progressBar.Progress = completedCount;
                progressLabel.Text = (curPageCount + 1) + " of " + pListSize;

                layout.Children.Add(progressLabel);
                layout.Children.Add(progressBar);
                layout.Children.Add(titleImage);
                layout.Children.Add(titleLabel);
                layout.Children.Add(imLayout);


                layout.Padding = new Thickness(20, 10, 20, 10);
                layout.Spacing = 10;

                LoadNext(layout, ec.commentEditor);   // Self call - Recursive
            }
            else
            {
                return;
            }
        }

        /*
         * Method       :   ItemSelected
         * Task         :   Handle Multi options ItemSelected event
         * 
         */
        private void ItemSelected(string selected)
        {
            try
            {
                Constants con = Constants.Instance;

                var depID = con.GetDependantQID();
                var depVal = con.GetDependantValue();
                var nextQCode = con.GetNextQuestionCode();

                var _qcode = con.GetQuestionCode(); // Gets Current Question Code
                var _qid = con.GetQuestionID(); //Gets Current Question ID

                String _OqJson =
                            "{\"CommID\":0," +
                            "\"QId\":" + _qid + "," +
                            "\"OQID\":\"" + selected + "\"" +
                            "}";

                SaveRatings sr = SaveRatings.SaveRatingInstance;
                try { sr.RemoveOtherQu(_qcode); } catch (NullReferenceException) { }
                sr.SetOtherQuestions(_qcode, _OqJson);

                ActivityLogger.AddLogger(_OqJson);

                //Save Temp Selection Data
                con.RemoveFromTempNVC(_qid);
                con.AddToTempNVC(_qid, selected);

                var ele = con.GetListElement(); // Gets Next Question Type from 'Constants.pageList'

                //Set 500ms delay for loading next page
                Device.StartTimer(TimeSpan.FromSeconds(loadDelay), () =>
                {
                    if (depID == nextQCode && depVal == selected)
                    {
                        con.SetCount();
                        ele = con.GetListElement();
                        LoadPages(ele, _qid);
                        return false;
                    }

                    LoadPages(ele, _qid);
                    return false;
                });
            }
            catch (ArgumentOutOfRangeException)
            {
                Navigation.PushAsync(new NewsLetters());
            }
            catch (Exception) { }
        }

        /*
         * Method       :   MultiItemSelected
         * Task         :   Handle Multi options MultiItemSelected event
         * 
         */
        private void MultiItemSelected(NameValueCollection selected)
        {
            try
            {
                Constants con = Constants.Instance;

                var _qcode = con.GetQuestionCode(); // Gets Current Question Code
                var _qid = con.GetQuestionID(); //Gets Current Question ID
                var otherListJason = "";


                //Clear Temp Data
                con.RemoveFromTempOQNVC(_qid);

                bool isSetOtherQ = false;
                //Create Other Question List JSON
                for (int i = 0; i < selected.Count; i++)
                {
                    if (isSetOtherQ)
                    {
                        otherListJason = otherListJason + "," + "{\"CommID\":0," +
                            "\"QId\":" + _qid + "," +
                            "\"OQID\":\"" + selected.Get(i) + "\"" +
                            "}";
                    }
                    else
                    {
                        otherListJason = "{\"CommID\":0," +
                            "\"QId\":" + _qid + "," +
                            "\"OQID\":\"" + selected.Get(i) + "\"" +
                            "}";

                        isSetOtherQ = true;
                    }

                    //Save Temp Selection Data
                    con.AddToTempOQNVC(_qid, selected.Get(i));
                }

                SaveRatings sr = SaveRatings.SaveRatingInstance;
                try { sr.RemoveOtherQu(_qcode); } catch (NullReferenceException) { }
                sr.SetOtherQuestions(_qcode, otherListJason);

                ActivityLogger.AddLogger(otherListJason);

                Console.WriteLine(otherListJason);
            }
            catch (ArgumentOutOfRangeException)
            {
                Navigation.PushAsync(new NewsLetters());
            }
            catch (Exception) { }


        }


        /*
         * Method       :   LoadNext
         * Task         :   Push next pages into Navigation Stack asynchronously
         * Params       :   Structure of next page (View) --> layout ,  Editor for request keyboard focusing (Editor) --> e
         * Arguments    :   Next Question Page (ContentPage) --> ContentPage_parser(layout) , Comment Editor (Editor) --> ElementController.comment editor
         */
        private void LoadNext(View layout, Editor e)
        {
            Navigation.PushAsync(new ContentPage_parser(layout, e));
        }


        /*
         * Method       :   Override -> OnAppearing()
         * Task         :   Set Starting page count as 0 at 'Constants.pageCount' attribute
         */
        protected override void OnAppearing()
        {
            base.OnAppearing();
            Constants con = Constants.Instance;
            con.SetCount(0);
        }
    }
}
