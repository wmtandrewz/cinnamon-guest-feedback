using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace CCFS.Helpers
{
  /// <summary>
  /// This is the Settings static class that can be used in your Core solution or in any
  /// of your client applications. All settings are laid out the same exact way with getters
  /// and setters. 
  /// </summary>

      public static class Settings
    {

    	private static ISettings AppSettings
    	{
    		get
    		{
    			return CrossSettings.Current;
    		}
    	}


    	public static string HotelNumber
    	{
    		get
    		{
    			return AppSettings.GetValueOrDefault("HotelNumber", "3000");
    		}
    		set
    		{
    			AppSettings.AddOrUpdateValue("HotelNumber", value);
    		}
    	}

		public static string HotelCode
		{
			get
			{
				return AppSettings.GetValueOrDefault("HotelCode", "CNG");
			}
			set
			{
				AppSettings.AddOrUpdateValue("HotelCode", value);
			}
		}

		public static string Language
		{
			get
			{
				return AppSettings.GetValueOrDefault("Language", "en-US");
			}
			set
			{
				AppSettings.AddOrUpdateValue("Language", value);
			}
		}

		public static string HotelName
		{
			get
			{
				return AppSettings.GetValueOrDefault("HotelName", "Cinnamon Grand");
			}
			set
			{
				AppSettings.AddOrUpdateValue("HotelName", value);
			}
		}

        public static string UserName
        {
            get
            {
                return AppSettings.GetValueOrDefault("UserName", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("UserName", value);
            }
        }

        public static string Password
        {
            get
            {
                return AppSettings.GetValueOrDefault("Password", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("Password", value);
            }
        }

        public static bool DomainSwitcher
        {
            get
            {
                return AppSettings.GetValueOrDefault("DomainSwitcher", false);
            }
            set
            {
                AppSettings.AddOrUpdateValue("DomainSwitcher", value);
            }
        }

        public static string BaseDomainURL
        {
            get
            {
                if(DomainSwitcher)
                {
                    return AppSettings.GetValueOrDefault("ProductionUrl", "");
                }
                else
                {
                    return AppSettings.GetValueOrDefault("DevelopmentUrl", "");
                }
            }

        }

        public static string SubscriptionKey
        {
            get
            {
                if (DomainSwitcher)
                {
                    
                    return AppSettings.GetValueOrDefault("SubscriptionKey_Prd", "c96b7f401241458290ce8544207eb43d");
                }
                else
                {
                    return AppSettings.GetValueOrDefault("SubscriptionKey_Dev", "d0fbb5e7bebc454e8df6ff295fa73905");
                }
            }

        }

        public static string DevelopmentUrl
        {
            get
            {
                return AppSettings.GetValueOrDefault("DevelopmentUrl", "https://jkhapimdev.azure-api.net/api/beta/v1/");
            }
            set
            {
                AppSettings.AddOrUpdateValue("DevelopmentUrl", value);

            }
        }

        public static string DevelopmentInhouseDate
        {
            get
            {
                return AppSettings.GetValueOrDefault("DevelopmentInhouseDate", "2017-03-18");
            }
            set
            {
                AppSettings.AddOrUpdateValue("DevelopmentInhouseDate", value);

            }
        }

        public static string SMTPPassword
        {
            get
            {
                return AppSettings.GetValueOrDefault("SMTPPassword", "hp##2009");
            }
            set
            {
                AppSettings.AddOrUpdateValue("SMTPPassword", value);

            }
        }

        public static string ProductionUrl
        {
            get
            {
                return AppSettings.GetValueOrDefault("ProductionUrl", "https://cheetah.azure-api.net/api/v1/");
            }
            set
            {
                AppSettings.AddOrUpdateValue("ProductionUrl", value);

            }
        }

        public static string SubscriptionKey_Dev
        {
            get
            {
                return AppSettings.GetValueOrDefault("SubscriptionKey_Dev", "d0fbb5e7bebc454e8df6ff295fa73905");
            }
            set
            {
                AppSettings.AddOrUpdateValue("SubscriptionKey_Dev", value);
            }
        }

        public static string SubscriptionKey_Prd
        {
            get
            {
                return AppSettings.GetValueOrDefault("SubscriptionKey_Prd", "c96b7f401241458290ce8544207eb43d");
            }
            set
            {
                AppSettings.AddOrUpdateValue("SubscriptionKey_Prd", value);
            }
        }

    }
}

