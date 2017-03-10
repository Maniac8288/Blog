
using IServices.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///Инфраструктура сайта.
/// </summary>
namespace Blog.Infrastructura
{
    //
    public class CustomWebViewPage : System.Web.Mvc.WebViewPage
    {
        public CustomWebViewPage()
        {
            User = WebUser.CurrentUser;
        }

        public new ModelUser User { get; set; }

        public override void Execute()
        {
            throw new NotImplementedException();
        }
    }

    public class CustomWebViewPage<T> : System.Web.Mvc.WebViewPage<T>
    {
        public CustomWebViewPage()
        {
            User = WebUser.CurrentUser;
        }
        public new ModelUser User { get; set; }
   
       

        public override void Execute()
        {
            throw new NotImplementedException();
        }
    }
}