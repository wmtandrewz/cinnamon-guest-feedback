using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CCFS.Helpers;
using Xamarin.Forms;

/*
 * Author   :   Thimira Andradi
 * Date     :   20th July 2017
 * Company  :   CHML IT - Development
 * Legal    :   All Rights Reserved | CHML IT | Development Team
 */

namespace CCFS
{

    /* Class        :   SaveRatings
     * Remark       :   This class contains getters setters of Data which will be sent to the DB
     * Technology   :   Singleton
     */
    public class SaveRatings
    {
        private static SaveRatings _saveRatingInstance;

        private String ratingListJson;
        private String commentListJson;
        private String otherListJason;

        private bool isSetRating = false;
        private bool isSetComment = false;
        private bool isSetOtherQ = false;

        static NameValueCollection ratingNVC = new NameValueCollection();
        static NameValueCollection commentNVC = new NameValueCollection();
        static NameValueCollection otherNVC = new NameValueCollection();

        public string _hotelCode { get; set; }
        public string _roomNum { get; set; }
        public string _resNum { get; set; }
        public string _guestID{ get; set; }
        public string _country { get; set; }
        public string _guestName { get; set; }
        public string _guestEmail { get; set; }
        public string _guestAddress { get; set; }
        public string _guestPhone { get; set; }
        public string _arrDate { get; set; }
        public string _depDate { get; set; }
        public string _createdBy { get; set; }
        public string _startTime { get; set; }
        public string _endTime { get; set; }
        public int _mainCatId { get; set; }

        public SaveRatings()
        {

        }

        //  Returns singleton Object of SaveRatings
        public static SaveRatings SaveRatingInstance
        {
            get
            {
                if (_saveRatingInstance == null)
                {
                    _saveRatingInstance = new SaveRatings();
                }
                return _saveRatingInstance;
            }
        }

        public void ClearSavedData()
        {
            Console.WriteLine("Cleared Save Data");

            ratingListJson = null;
            commentListJson = null;
            otherListJason = null;

            isSetRating = false;
            isSetComment = false;
            isSetOtherQ = false;

            ratingNVC = new NameValueCollection();
            commentNVC = new NameValueCollection();
            otherNVC = new NameValueCollection();

            _hotelCode = null;
            _roomNum = null;
            _resNum = null;
            _guestID = null;
            _country = null;
            _guestName = null;
            _guestEmail = null;
            _guestAddress = null;
            _guestPhone = null;
            _arrDate = null;
            _depDate = null;
            _startTime = null;
            _endTime = null;
            _mainCatId = 0;
        }

        //-------------------------------------------------------Start Getters Setters------------------------------------------------------------------


        //Append rating json String
        public void SetRatings(String QID, String json)
        {
            ratingNVC.Add(QID, json);
            Console.WriteLine(ratingNVC.Count);
        }
        //Append comment json String
        public void SetComments(String QID, String json)
        {
            commentNVC.Add(QID, json);
        }
        //Append other json String
        public void SetOtherQuestions(String QID, String json)
        {
            otherNVC.Add(QID, json);
        }

        //Remove specific name value from ratingNVC
        public void RemoveRating(string key)
        {
            ratingNVC.Remove(key);
        }

        //Remove specific name value from commentNVC
        public void RemoveComment(string key)
        {
            commentNVC.Remove(key);
        }

        //Remove specific name value from otherNVC
        public void RemoveOtherQu(string key)
        {
            otherNVC.Remove(key);
        }

        //-------------------------------------------------------End Getters Setters------------------------------------------------------------------

        /*
         * Method       :   CreateJsonStrings
         * Task         :   Convert NameValueCollections to relevent Json String
         */

        public bool CreateJsonStrings()
        {
            try
            {
                //Create Rating List JSON
                for (int i = 0; i < ratingNVC.Count; i++)
                {
                    if (isSetRating)
                    {
                        ratingListJson = ratingListJson + "," + ratingNVC.Get(i);
                    }
                    else
                    {
                        ratingListJson += ratingNVC.Get(i);
                        isSetRating = true;
                    }
                }

                //Create Comment List JSON
                for (int i = 0; i < commentNVC.Count; i++)
                {
                    if (isSetComment)
                    {
                        commentListJson = commentListJson + "," + commentNVC.Get(i);
                    }
                    else
                    {
                        commentListJson += commentNVC.Get(i);
                        isSetComment = true;
                    }
                }

                //Create Other Question List JSON
                for (int i = 0; i < otherNVC.Count; i++)
                {
                    if (isSetOtherQ)
                    {
                        otherListJason = otherListJason + "," + otherNVC.Get(i);
                    }
                    else
                    {
                        otherListJason += otherNVC.Get(i);
                        isSetOtherQ = true;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }

            Console.WriteLine(ratingListJson);
            Console.WriteLine(commentListJson);
            Console.WriteLine(otherListJason);
            return true;
        }

        /*
         * Method       :   SaveRating
         * Task         :   Save Rating data in DB via Azure REST Client API
         */

        public void SaveRating()
        {
            CreateJsonStrings();

            _mainCatId = Constants.mainCategory;

            string json = "{" +
                "\"HtlCode\":\"" + _hotelCode + "\"," +
                "\"RoomNo\":\"" + _roomNum + "\"," +
                "\"ReservationNo\":\"" + _resNum + "\"," +
                "\"GuestID\":\"" + _guestID + "\"," +
                "\"Country\":\"" + _country + "\"," +
                "\"GuestName\":\"" + _guestName + "\"," +
                "\"GuestEmail\":\"" + _guestEmail + "\"," +
                "\"GuestAddress\":\"" + _guestAddress + "\"," +
                "\"GuestPhone\":\"" + _guestPhone + "\"," +
                "\"ArrivalDate\":\"" + _arrDate + "\"," +
                "\"DepartureDate\":\"" + _depDate + "\"," +
                "\"CreatedBy\":\"" + _createdBy + "\"," +
                "\"StartTime\":\"" + _startTime + "\"," +
                "\"EndTime\":\"" + _endTime + "\"," +
                "\"MainCategoryId\":" + _mainCatId + "," +
                "\"RatingList\":[" + ratingListJson + "]," +
                "\"CommentList\":[" + commentListJson + "]," +
                "\"OtherList\":[" + otherListJason + "]}";

            //string json1 = "{\"HtlCode\":\"CNG\",\"RoomNo\":\"123\",\"ReservationNo\":\"000008888\",\"Country\":\"\",\"GuestName\":\"lakshman\",\"GuestEmail\":\"lakshmant@gmail.com\",\"GuestAddress\":\"\",\"GuestPhone\":\"\",\"ArrivalDate\":\"2017-01-01\",\"DepartureDate\":\"2017-01-02\",\"CreatedBy\":\"\",\"RatingList\":[{\"CommID\":0,\"QCode\":\"Q02a\",\"Rating\":4\n },{\"CommID\":0,\"QCode\":\"Q02b\",\"Rating\":3\n }],\"CommentList\":[{\"CommID\":0,\"QCode\":\"Q10a\",\"Comment\":\"Test comment1\"\n   },{\"CommID\":0,\"QCode\":\"Q10b\",\"Comment\":\"Test comment2\"}],\"OtherList\":[{\"CommID\":0,\"QCode\":\"Q52a\",\"OQID\":2},{\"CommID\":0,\"QCode\":\"Q52b\",\"OQID\":5}]}";


            using (var client = new WebClient())
            {
                try
                {
                    client.Headers[HttpRequestHeader.ContentType] = "application/json";
                    client.Headers.Add("Ocp-Apim-Subscription-Key",Settings.SubscriptionKey);

                    //client.UploadStringAsync(new Uri(Settings.Uri + "v1/guest/Feedback/Insert"), "POST", json);
                    //client.UploadStringAsync(new Uri(Settings.SaveRatingsAPI + "guest/Feedback/Insert"), "POST", json); //pilot productiom
                    client.UploadStringAsync(new Uri(Settings.BaseDomainURL + "guestfeedback/Feedback/Insert"), "POST", json);

                    client.UploadStringCompleted += (object sender, UploadStringCompletedEventArgs e) =>
                    {

                        Console.WriteLine(e.Result);

                    };

                }
                catch (Exception) { }

            }

        }

    }
}
