using DataObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Online2Shop
{
    public partial class TransactionClosed : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.Identity.IsAuthenticated)
            {
                Controller.UserController userController = new Controller.UserController();
                String username = User.Identity.Name;
                Users user = userController.getUser(username);
                String email = user.Email.ToString();
                userController.disactivateDiscount(email);
            }
        }
    }
}