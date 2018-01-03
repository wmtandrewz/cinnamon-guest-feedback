using System;
using Xamarin.Forms;

/*
 * Authors  :   Thimira Andradi
 * Date     :   10th July 2017
 * Company  :   CHML IT - Development
 * Legal    :   All Rights Reserved | CHML IT | Development Team
 */
namespace CCFS
{
	/*
     * Class    :   ContentPage_parser
     * Remark   :   This class is for convert dynamic view UI s to Content Page
     */
	public partial class ContentPage_parser : ContentPage
    {
        protected int pageCountNow = 0;
        protected bool isSetCount = false;
        protected Editor focusedEditor;

        public ContentPage_parser(View content,Editor e)
        {
			Constants con = Constants.Instance;
			con.SetCount(); // Sets page count on 'Constants.pageCount'

			pageCountNow = con.GetCount(); //Gets current page count and Sets the current index at 'Constants.pageList' of the page into attribute
			isSetCount = true;

            Console.WriteLine(con.GetCount());

            NavigationPage.SetHasNavigationBar(this, false);

            focusedEditor = e;
            InitComp(content);

		}

        private void InitComp(View content){
			Content = content; // Sets param 'content' as Content of the page
		}

		/*
         * Method       :   Override -> OnAppearing()
         * Task         :   Set current page count as per currently active page  at 'Constants.pageCount' attribute
         */
		protected override void OnAppearing()
        {
            base.OnAppearing();
            if(isSetCount){
                Constants con = Constants.Instance;
                con.SetCount(pageCountNow);
            }

            //If page is a comment view it will request cursor focus to Editor
            if(focusedEditor !=null){
                focusedEditor.Focus();
            }
        }
    }
}
