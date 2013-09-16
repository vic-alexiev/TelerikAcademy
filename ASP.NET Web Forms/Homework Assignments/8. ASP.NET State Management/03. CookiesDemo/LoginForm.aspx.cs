using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CookiesDemo
{
    public partial class LoginForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            byte[] username = Encoding.ASCII.GetBytes(TextBoxUsername.Text);

            SHA1 sha1 = new SHA1CryptoServiceProvider();

            // This is one implementation of the abstract class SHA1.
            byte[] hash = sha1.ComputeHash(username);

            HttpCookie cookie = new HttpCookie("User", Encoding.ASCII.GetString(hash));
            cookie.Expires = DateTime.Now.AddMinutes(1);

            Response.Cookies.Add(cookie);
            Response.Redirect("~/HomePage.aspx");
        }
    }
}