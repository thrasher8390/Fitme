using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FitMe.Models.UserModel.Controller;

namespace FitMe.Helper
{
    public static class PagePermissions
    {

        /// <summary>
        /// Returns user access. After a page checks access policy it must call 
        /// TransferToPage to complete the permission sequence
        /// </summary>
        /// <param name="page"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        internal static bool IsAllowedOnPage(System.Web.UI.Page page, User user)
        {
            Boolean isAllowedOnPage = false;

            if(user != null)
            {
                isAllowedOnPage = true;
            }

            return isAllowedOnPage;
        }

        /// <summary>
        /// Handles sending the user to a safe page that they have access to
        /// </summary>
        /// <param name="page"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        internal static string TransferToPage(System.Web.UI.Page page, User user)
        {
            string transferToPage = Constants.Page_AccountSignIn;

            return transferToPage;
        }
    }
}