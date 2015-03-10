using DataObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Online2Shop
{
    public partial class ItemDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String idItem = Request.QueryString["idItem"];
            int Num;
            bool isNum = int.TryParse(idItem, out Num);
            if (isNum) {
                createHTMLItemDetails(idItem);
            }
        }

        private void createHTMLItemDetails(String idItem) {
            /*I retrieve the item passed*/
            Controller.ItemController itemsController = new Controller.ItemController();
            DataObject.Items item = itemsController.getItemByID(idItem);

            HtmlGenericControl itemName = new HtmlGenericControl("p");
            itemName.Attributes.Add("id", "itemName");
            itemName.InnerText = item.NameItem;
            itemNameWrapper.Controls.Add(itemName);

            HtmlGenericControl img = new HtmlGenericControl("img");
            img.Attributes.Add("id", "imgDetails");
            img.Attributes["src"] = item.MainPicture;
            wrapperItemDetailsInternal.Controls.Add(img);

            HtmlGenericControl descriptionDetails = new HtmlGenericControl("div");
            descriptionDetails.Attributes.Add("id", "descriptionDetails");
            wrapperItemDetailsInternal.Controls.Add(descriptionDetails);

            HtmlGenericControl description = new HtmlGenericControl("p");
            description.Attributes.Add("class", "description");
            description.InnerText = "Item description";

            HtmlGenericControl labelDescription = new HtmlGenericControl("p");
            labelDescription.Attributes.Add("class", "labelDescription");
            labelDescription.InnerText = item.Description;

            HtmlGenericControl labelPrice = new HtmlGenericControl("p");
            labelPrice.Attributes.Add("class", "labelPrice");
            Double priceDouble = -1;
            Double Num;
            bool isNum = Double.TryParse(item.Price, out Num);
            if (isNum) {
                priceDouble = Convert.ToDouble(item.Price);
            }
            labelPrice.InnerText = "$" + priceDouble;

            descriptionDetails.Controls.Add(description);
            descriptionDetails.Controls.Add(labelDescription);

            descriptionDetails.Controls.Add(labelPrice);

            if (User.Identity.IsAuthenticated)
            {
                Controller.UserController userController = new Controller.UserController();
                Users user = userController.getUser(User.Identity.Name);

                HtmlGenericControl form = new HtmlGenericControl("form");
                //form.Attributes.Add("id", "paypalForm");
                form.Attributes.Add("action", "https://www.paypal.com/cgi-bin/webscr");
                form.Attributes.Add("method", "post");
                form.Attributes.Add("target", "paypal");
                HtmlGenericControl input1 = new HtmlGenericControl("input");
                input1.Attributes.Add("type", "hidden");
                input1.Attributes.Add("name", "cmd");
                input1.Attributes.Add("value", "_s-xclick");

                HtmlGenericControl input2 = new HtmlGenericControl("input");
                input2.Attributes.Add("type", "hidden");
                input2.Attributes.Add("name", "hosted_button_id");
                String paypalCode = item.PaypalCode.ToString();
  
                if (user.Discount.Equals("1"))
                {
                    HtmlGenericControl labelPriceDiscount = new HtmlGenericControl("p");
                    labelPriceDiscount.Attributes.Add("class", "labelPrice"); 
                    labelPriceDiscount.InnerText = "10% off";
                    descriptionDetails.Controls.Add(labelPriceDiscount);

                    String paypalDiscountCode = item.PaypalDiscountCode.ToString();
                    input2.Attributes.Add("value", paypalDiscountCode);
                }
                else
                {
                    input2.Attributes.Add("value", paypalCode);
                }

                HtmlGenericControl input3 = new HtmlGenericControl("input");
                input3.Attributes.Add("type", "image");
                input3.Attributes.Add("id", "itemDetailPayButton");
                input3.Attributes.Add("src", "https://www.paypalobjects.com/en_AU/i/btn/btn_cart_LG.gif");
                input3.Attributes.Add("border", "0");
                input3.Attributes.Add("name", "submit");
                input3.Attributes.Add("alt", "PayPal — The safer, easier way to pay online.");

                HtmlGenericControl imgForm = new HtmlGenericControl("img");
                imgForm.Attributes.Add("alt", "");
                imgForm.Attributes.Add("border", "0");
                imgForm.Attributes["src"] = "https://www.paypalobjects.com/en_AU/i/scr/pixel.gif";
                imgForm.Attributes.Add("width", "1");
                imgForm.Attributes.Add("height", "1");

                form.Controls.Add(input1);
                form.Controls.Add(input2);
                form.Controls.Add(input3);
                form.Controls.Add(imgForm);

                descriptionDetails.Controls.Add(form);
            }
            else
            {

                HtmlGenericControl loginBeforePaypal = new HtmlGenericControl("input");
                loginBeforePaypal.Attributes.Add("type", "button");
                loginBeforePaypal.Attributes.Add("value", "Login or Register");
                loginBeforePaypal.Attributes.Add("class", "loginBeforePaypal");
                loginBeforePaypal.Attributes.Add("id", "loginBeforePaypalID");

                loginBeforePaypal.Attributes.Add("src", "https://www.paypalobjects.com/en_AU/i/btn/btn_cart_LG.gif");
                descriptionDetails.Controls.Add(loginBeforePaypal);
            }

            //descriptionDetails.Controls.Add(labelQuantity);
            //descriptionDetails.Controls.Add(quantityText);
            //descriptionDetails.Controls.Add(buyButton);
           
            HtmlGenericControl otherImagesDetails = new HtmlGenericControl("div");
            otherImagesDetails.Attributes.Add("id", "otherImagesDetails");
            wrapperItemDetailsInternal.Controls.Add(otherImagesDetails);
            
            foreach(String image in item.Pictures){
                HtmlGenericControl otherImg = new HtmlGenericControl("img");
                otherImg.Attributes.Add("class", "smallImgDetails");
                otherImg.Attributes["src"] = image;
                otherImagesDetails.Controls.Add(otherImg);
            }
             
        }
    }
}