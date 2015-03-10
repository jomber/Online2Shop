using DataObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Online2Shop
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void searchTerm(object sender, EventArgs e)
        {
            String term = searchBox.Text;
            Response.Redirect("Items.aspx?term=" + term);
        }

        protected void Authentication(object sender, AuthenticateEventArgs e)
        {
            Controller.UserController userController = new Controller.UserController();
            
            String username = Login1.UserName;
            String password = Login1.Password;
            
            Boolean authenticate = userController.authenticateUser(username, password);
            
            
            if (!authenticate)
            {
                loginDiv.Style.Add("display", "block");
                overlayLayer.Style.Add("display", "block");
            }
            else {
                
                Users user = userController.getUser(username);
                if (user.Admin.Equals("1")) {
                    loginDiv.Style.Add("display", "none");
                    overlayLayer.Style.Add("display", "none");
                    Response.Redirect("http://d2838170.i239.quadrahosting.com.au/privateO2S/admin.aspx");
                }
            }

            e.Authenticated = authenticate;
        }


        protected void CreateUser(object sender, EventArgs e)
        {
            Controller.UserController userController = new Controller.UserController();
            Users userN = userController.getUser(mailingName.Text);
            Users userMail = userController.getUserByEmail(mailingEmail.Text);

            if (validationRegistration())
            {
                
                if (userN == null && userMail == null)
                {
                    String username = mailingName.Text;
                    //encrypt password here
                    String password = mailingPassword.Text;
                    String email = mailingEmail.Text;
                    String postcode = mailingPostcode.Text;
                    userController.createUser(username, password, "0", email);
                    validationText.InnerText = "Thank you for registering!";
                    clearForm();
                }

            }
            
            dontCloseRegistration();
           
        }

        protected void dontCloseRegistration()
        {
            popupMailing.Style.Add("display", "block");
            overlayLayer.Style.Add("display", "block");
            loginDiv.Style.Add("display", "none");
        }
        
        private void clearForm(){
            mailingName.Text = "";
            mailingPostcode.Text = "";
            mailingEmail.Text = "";
        }

        private Boolean validationRegistration(){
            Controller.UserController userController = new Controller.UserController();
            Users userN = userController.getUser(mailingName.Text);
            Users userMail = userController.getUserByEmail(mailingEmail.Text);
            
            //username already used
            if (userN != null)
            {
                validationText.InnerText = "Username already used!";
                return false;
            }
            else 
            {
                validationText.InnerText = "";
            }

            //mail already used
            if (userMail != null)
            {
                validationText.InnerText = "Email already used!";
                return false;
            }
            else 
            {
                validationText.InnerText = "";
            }

            
            if (mailingName.Text.Equals("") || mailingName.Text == null)
            {
                nameValidatorLabel.InnerText = "*";
                return false;
            }
            else 
            {
                nameValidatorLabel.InnerText = "";
            }
            if (mailingPassword.Text.Equals("") || mailingPassword.Text == null)
            {
                passwordValidatorLabel.InnerText = "*";
                return false;
            }
            else
            {
                passwordValidatorLabel.InnerText = "";
            }
            if (mailingConfirmPassword.Text.Equals(""))
            {
                confirmValidatorLabel.InnerText = "*";
                return false;
            }
            else 
            {
                confirmValidatorLabel.InnerText = "";
            }
            if (mailingEmail.Text.Equals(""))
            {
                mailValidatorLabel.InnerText = "*";
                return false;
            }
            else 
            {
                mailValidatorLabel.InnerText = "";
            }
            if (mailingPostcode.Text.Equals(""))
            {
                postcodeValidatorLabel.InnerText = "*";
                return false;
            }
            else 
            {
                postcodeValidatorLabel.InnerText = "";
            }

            if (!mailingPassword.Text.Equals(mailingConfirmPassword.Text))
            {
                validationText.InnerText = "Password Confirmed must be similar to Password";
                return false;
            }
            else {
                validationText.InnerText = "";
            }


            return true;
        }

        protected void ShowLogin(object sender, EventArgs e)
        {
            loginDiv.Style.Add("display", "block");
            popupMailing.Style.Add("display", "none");
            overlayLayer.Style.Add("display", "block");

        }
        /*
        protected void ContinueRegistration(object sender, EventArgs e)
        {
            registerDiv.Style.Add("display", "none");
            loginDiv.Style.Add("display", "none");
            overlayLayer.Style.Add("display", "none");
        }
        */

    }
}