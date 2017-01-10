using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FitMe.Models.UserModel.Controller;

namespace FitMe.Helper
{
    public static class PagePermissions
    {
        internal static bool IsAllowedOnPage(System.Web.UI.Page page, User user)
        {
            Boolean isAllowedOnPage = false;

            if(user != null)
            {
                isAllowedOnPage = true;
            }

            return isAllowedOnPage;
        }

        internal static string TransferToPage(System.Web.UI.Page page, User user)
        {
            string transferToPage = Constants.Page_AccountSignIn;

            return transferToPage;
        }
    }
}