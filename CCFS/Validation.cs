using System;
using System.Text.RegularExpressions;

namespace CCFS
{
    public class Validation
    {
        public Validation()
        {
        }

		public bool MobileNumberValidator(String strNumber)
		{
			//Regex mobilePattern = new Regex("(3|4|5|6|7|8|9){1}[0-9]{9}"); 

            Regex plus = new Regex("^[+][1-9][0-9]{9,13}$");
            Regex zero = new Regex("0[1-9][0-9]{10}$");
            Regex zeroes = new Regex("^00[1-9][0-9]{9,13}$");

            if(plus.IsMatch(strNumber) || zero.IsMatch(strNumber) || zeroes.IsMatch(strNumber)){
                return true;
            }else{
                return false;
            }

		}

        public bool EmailValidator(string strEmail)
        {
			Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
			Match match = regex.Match(strEmail);
            if (match.Success){
                return true;
            }else{
                return false;
            }
        }
    }
}
