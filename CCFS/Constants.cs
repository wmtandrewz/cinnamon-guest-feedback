using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.Http;
using CCFS.Helpers;
using Newtonsoft.Json;

/*
 * Authors  :   Thimira Andradi
 * Date     :   10th July 2017
 * Company  :   CHML IT - Development
 * Legal    :   All Rights Reserved | CHML IT | Development Team
 */
namespace CCFS
{
	/* Class        :   Constants
     * Remark       :   This class contains getters setters of Data which are retriving from DB
     * Technology   :   Singleton
     */
	public class Constants
    {
		private static List<String> pageList = new List<String>();
        private static List<String> questionList = new List<String>();
        private static List<String> qIDList = new List<String>();
        private static List<String> qCodeList = new List<String>();
        private static List<String> displayTypeList = new List<String>();
        private static List<String> UIControlList = new List<String>();
        private static List<String> DependantQIDList = new List<String>();
        private static List<String> DependentValueList = new List<String>();
        private static List<String> OptionalList = new List<String>();

        private static List<String[]> otherQuestionsArrayList = new List<String[]>();
        private static List<String[]> otherQuesIDArrayList = new List<String[]>();
		private static List<String[]> ratingScaleArrayList = new List<String[]>();
        private static List<String[]> ratingScaleDescArrayList = new List<String[]>();

        private static NameValueCollection tempNVC = new NameValueCollection();
        private static NameValueCollection tempOQNVC = new NameValueCollection();

        public static int mainCategory = 0;

		private int pageCount = 0;
        private static Constants instance;
        private static List<Questions> questionData;

		private Constants() {
            Console.WriteLine("Singleton Object init...");
		}

        public void ClearOldData(){
            Console.WriteLine("Clear OLD Data...");
            pageList.Clear();
            questionList.Clear();
            qIDList.Clear();
            qCodeList.Clear();
            qCodeList.Clear();
            displayTypeList.Clear();
            UIControlList.Clear();
            DependantQIDList.Clear();
            DependentValueList.Clear();
            otherQuestionsArrayList.Clear();
            otherQuesIDArrayList.Clear();
            ratingScaleArrayList.Clear();
            ratingScaleDescArrayList.Clear();
            OptionalList.Clear();
            tempNVC.Clear();
            tempOQNVC.Clear();
            mainCategory = 0;
            pageCount = 0;
        }

        public void ContactDB(){
            Console.WriteLine("Contacting DB...");
            pageList.Clear();
            questionList .Clear();
            qIDList.Clear();
            qCodeList.Clear();
            qCodeList.Clear();
            displayTypeList.Clear();
            UIControlList.Clear();
            DependantQIDList.Clear();
            DependentValueList.Clear();
            otherQuestionsArrayList.Clear();
            otherQuesIDArrayList.Clear();
            ratingScaleArrayList .Clear();
            ratingScaleDescArrayList.Clear();
            OptionalList.Clear();
            tempNVC.Clear();
            tempOQNVC.Clear();
            mainCategory = 0;
            pageCount = 0;

            Console.WriteLine(Settings.Language);
            Console.WriteLine(Settings.HotelCode);

            GetResult(Settings.HotelCode, Settings.Language, "GC"); // Execute method for get data from DB

            ActivityLogger.AddLogger("Retrived question data from DB"
                                     + Settings.HotelCode + "as Hotel, "
                                     + Settings.Language + "as Language, "
                                     + "and area code GC"
                                    );

            Console.WriteLine("DB connection success...");
		}

        //  Returns singleton Object of Constants
		public static Constants Instance
		{
            get
            {
                if (instance == null)
                {
                    instance = new Constants();
                }
                return instance;
            }

		}

        public void AddToTempNVC(string key,string val){
            tempNVC.Add(key,val);
        }

        public void RemoveFromTempNVC(string key){
            tempNVC.Remove(key);
        }

        public string GetTempValue(string key){
            return tempNVC.Get(key);
        }

        //TempOQ

        public void AddToTempOQNVC(string key, string val)
        {
            tempOQNVC.Add(key, val);
        }

        public void RemoveFromTempOQNVC(string key)
        {
            tempOQNVC.Remove(key);
        }

        public string GetTempOQValue(string key)
        {
            return tempOQNVC.Get(key);
        }

        public void SetNullObject(){
            instance = null;
        }

        public int GetPagesListSize(){
            return pageList.Count;
        }

        //Returns page Count
		public int GetCount()
		{
            return pageCount;
		}

        //Sets Page Count
        public void SetCount(){
            pageCount++;
        }

		//Sets Page Count with param pc
		public void SetCount(int pc)
		{
            pageCount = pc;
		}

        // Substract page Count
        public void SubstractCount(){
            pageCount--;
        }

        //Returns next Question Type
		public string GetListElement()
		{
            var res = pageList[pageCount];
            return res;
		}

        //returns next question
        public String GetQuestion(){
            var qu = questionList[pageCount];
            return qu;
        }

        //returns other question array
        public String [] GetOtherQuestionArray(){
            var oQu = otherQuestionsArrayList[pageCount];
            return oQu;
        }

		//returns other question ID array
		public String[] GetOtherQuestionIDArray()
		{
            var oQuID = otherQuesIDArrayList[pageCount];
			return oQuID;
		}

        //Retruns question ID
		public String GetQuestionID()
		{
			var qid = qIDList[pageCount-1];
			return qid;
		}

		//Retruns question ID
		public String GetNextQuestionID()
		{
			var qid = qIDList[pageCount];
			return qid;
		}

		//Retruns question Code
		public String GetQuestionCode()
		{
			var qcd = qCodeList[pageCount-1];
			return qcd;
		}

        //Retruns question Code
        public String GetNextQuestionCode()
        {
            var qcd = qCodeList[pageCount];
            return qcd;
        }

		//Retruns question Code
		public String GetDisplayType()
		{
			var dtl = displayTypeList[pageCount];
			return dtl;
		}

        //Returns UI Control code
        public String GetUIControlCode()
        {
            var uic = UIControlList[pageCount];
            return uic;
        }

        //Returns Dependant QID
        public String GetDependantQID()
        {
            var dqid = DependantQIDList[pageCount-1];
            return dqid;
        }
        //Returns Dependant Q value
        public String GetDependantValue()
        {
            var dqv = DependentValueList[pageCount-1];
            return dqv;
        }

        //Returnsn Optional Q value
        public string GetIsOptional(){
            return OptionalList[pageCount - 1];
        }

        public string GetIsThisOptional()
        {
            return OptionalList[pageCount];
        }

        //------------------------------------------- End Of Getters Setters --------------------------------------------------------

        /*
         * Method       :   async GetResult
         * Task         :   Get JSON Array of questions details from Database
         * 
         */
        private async void GetResult(string hotelcode,string lang,string area)
		{
			HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri("http://feedbackapi-dev.azurewebsites.net/api/");
            client.BaseAddress = new Uri(Settings.BaseDomainURL);
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", Settings.SubscriptionKey); //production sub key
            var response = await client.GetAsync("guestfeedback/HotelQuestions/GetHotelQuestions/" + hotelcode + "/" + lang + "/" + area); //dev link
            //var response = await client.GetAsync("guest/HotelQuestions/GetHotelQuestions?hotel_code=" + hotelcode + "&Language=" + lang + "&area_code=" + area); //production link
            var resultQues = response.Content.ReadAsStringAsync().Result;

            if (resultQues != "")
            {
                 questionData = JsonConvert.DeserializeObject <List<Questions>>(resultQues);
                 GC.KeepAlive(questionData);
                Console.WriteLine("JSON Result Deserialized...");
            }

            ReadData(); //Read data from list attribute 'questionData'
		}


		/*
         * Method       :   ReadData
         * Task         :   Read data from list attribute 'questionData' and assign values to relevent list attributes
         * Exception    :   If NullReferenceException raised, will added empty object to list
         * 
         */
		private void ReadData(){
			foreach (Questions value in questionData)
			{
                questionList.Add(value.QDesc);
                pageList.Add(value.QType);
                qIDList.Add(value.QId);
                qCodeList.Add(value.QNo);
                displayTypeList.Add(value.DisplayType);
                UIControlList.Add(value.UIControl);
                DependantQIDList.Add(value.DependantQNo);
                DependentValueList.Add(value.DependantQValue);
                OptionalList.Add(value.Optional.ToString());
                mainCategory = Convert.ToInt32(value.MainCategory);

                try
                {
                    List<OtherQuestions> otherQuesData = value.OtherQuestions;
                    List<RatingScale> ratingScaleData = value.RatingScale;

                    String[] otherQuesArray = new String[otherQuesData.Count];
                    String[] otheQIDArray = new String[otherQuesData.Count];

					//String[] ratingScaleDescArray = new String[ratingScaleData.Capacity];
					//String[] ratingScaleArray = new String[ratingScaleData.Capacity];

                    int i = 0;

                    foreach (OtherQuestions data in otherQuesData)
                    {
                        otherQuesArray[i] = data.QODesc;
                        otheQIDArray[i] = data.QOId;
                        i++;
                    }

					otherQuestionsArrayList.Add(otherQuesArray);
					otherQuesIDArrayList.Add(otheQIDArray);

                }
                catch(NullReferenceException)
                {
                    otherQuestionsArrayList.Add(new string[1]);
                    otherQuesIDArrayList.Add(new string[1]);

					ratingScaleDescArrayList.Add(new string[1]);
					ratingScaleArrayList.Add(new string[1]);
                }
			}
        }

    }

    /*
     * Class        :   Questions   (Inner Class)
     * Remark       :   This is a bean class for decode the JSon array
     * 
     */

	public class Questions
	{
        [JsonProperty("MainCategory")]
	    public string MainCategory { get; set; }

        [JsonProperty("CategoryRowId")]
        public string CategoryRowId { get; set; }

        [JsonProperty("CategoryName")]
        public string CategoryName { get; set; }

        [JsonProperty("ParentId")]
        public string ParentId { get; set; }

        [JsonProperty("bc")]
        public string bc { get; set; }

        [JsonProperty("QId")]
        public string QId { get; set; }

        [JsonProperty("QNo")]
        public string QNo { get; set; }

        [JsonProperty("QDesc")]
        public string QDesc { get; set; }

        [JsonProperty("QType")]
        public string QType { get; set; }

        [JsonProperty("PageId")]
        public string PageId { get; set; }

        [JsonProperty("RatingCategory")]
        public string RatingCategory { get; set; }

        [JsonProperty("DependantQNo")]
        public string DependantQNo { get; set; }

        [JsonProperty("DependantQValue")]
        public string DependantQValue { get; set; }

        [JsonProperty("UIControl")]
        public string UIControl { get; set; }

		[JsonProperty("DisplayType")]
		public string DisplayType { get; set; }

		[JsonProperty("Optional")]
		public bool Optional { get; set; }

        [JsonProperty("OtherQuestions")]
        public List<OtherQuestions> OtherQuestions { get; set; }

		[JsonProperty("RatingScale")]
		public List<RatingScale> RatingScale { get; set; }
	}

	/*
     * Class        :   OtherQuestions   (Inner Class)
     * Remark       :   This is a bean class for decode the internal JSon bean 'OtherQuestions' in root JSon bean 'Questions'
     * 
     */
	public class OtherQuestions
	{
		[JsonProperty("QOId")]
		public string QOId { get; set; }

        [JsonProperty("QODesc")]
        public string QODesc { get; set; }
	}

    public class RatingScale{
        
		[JsonProperty("RatingScaleNo")]
		public string QORatingScaleNoId { get; set; }

		[JsonProperty("RatingScaleText")]
		public string RatingScaleText { get; set; }
    }
}
