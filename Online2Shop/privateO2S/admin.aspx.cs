using DataObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Online2Shop.privateO2S
{
    public partial class admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.Identity.IsAuthenticated)
            {
                Controller.UserController userController = new Controller.UserController();
                String username = User.Identity.Name;
                Users user = userController.getUser(username);
                if (!user.Admin.Equals("1"))
                {
                    Response.Redirect("../home.aspx");
                }
            }
            else
            {
                Response.Redirect("../home.aspx");
            }
        }

        protected void ActivateAll(object sender, EventArgs e)
        {
            Controller.UserController userController = new Controller.UserController();
            userController.activateAllDiscount();
            Response.Redirect(Request.RawUrl);
        }

        protected void DisactivateAll(object sender, EventArgs e)
        {
            Controller.UserController userController = new Controller.UserController();
            userController.disactivateAllDiscount();
            Response.Redirect(Request.RawUrl);
        }


        protected void Activate(object sender, EventArgs e)
        {
            /* I retrieve the clicked button */
            Button clickedButton = sender as Button;
            CheckBox checkDiscount = clickedButton.Parent.FindControl("DiscountCheck") as CheckBox;
            String email = emailRetrieved.InnerText;
            Boolean isChecked = checkDiscount.Checked;

            Controller.UserController userController = new Controller.UserController();

            if (isChecked)
            {
                userController.activateDiscount(email);
                //emailRetrieved.InnerText = "Discount Active";
            }
            else
            {
                userController.disactivateDiscount(email);
                //emailRetrieved.InnerText = "Discount not Active";
            }


            Response.Redirect(Request.RawUrl);
        }

        protected void SearchUser(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            TextBox mailRetrieved = clickedButton.Parent.FindControl("InputEMail") as TextBox;
            String email = mailRetrieved.Text;

            Controller.UserController userController = new Controller.UserController();
            Users user = userController.getUserByEmail(email);

            if (user != null)
            {
                DiscountCheck.Checked = user.Discount.Equals("1");
                emailRetrieved.InnerText = user.Email.ToString();
            }
            else
            {
                emailRetrieved.InnerText = "Not Found";
            }
        }

    }
}