using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitMe.Helper
{
    public class Constants
    {
        public const string SiteTitle = "Fits2Me";

        #region session constants
        public const string Session_CurrentUser = "CurrentUser";
        public const string Session_CurrentUserRatedItem = "CurrentUserRatedItem";
        #endregion
      
        #region page constants
        public const string Page_HomePage = "Default.aspx";
        public const string Page_About = "About.aspx";
        public const string Page_ContactUs = "Contact.aspx";

        public const string Page_AddItem = "AddItem.aspx";
        public const string Page_RateItem = "RateItem.aspx";

        public const string Page_AccountSignIn = "AccountSignIn.aspx";
        public const string Page_AccountSignUp = "AccountSignUp.aspx";
        public const string Page_AccountSignOut = "AccountSignOut.aspx";

        public const string Page_UserCloset = "UserCloset.aspx";
        public const string Page_UserProfile = "UserProfile.aspx";
        #endregion

        #region websites
        public const string WebSite_TrelloFeedback = "https://trello.com/b/4xTX2LuP";
        #endregion
    }
}