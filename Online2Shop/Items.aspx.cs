using DataObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Online2Shop
{
    public partial class Items : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           createHTMLListItemsPerRow();
        }

        private void createHTMLListItemsPerRow() { 
            Controller.ItemController itemsController = new Controller.ItemController();
            String valueCategory = Request.QueryString["idCategory"];
            String valueTerm = Request.QueryString["term"];
            List<DataObject.Items> itemsList = new List<DataObject.Items>();
            
            int Num;
            bool isNum = int.TryParse(valueCategory, out Num);
            if (isNum)
            {
                itemsList = itemsController.getItemsByCategory(valueCategory);
            }

            if (valueTerm != null && !valueTerm.Equals("")) {
                itemsList = itemsController.searchItemsByTerm(valueTerm);
            }

            int count = 4;
            HtmlGenericControl itemsRow = null;

            Controller.CategoryController categoryController = new Controller.CategoryController();
            DataObject.Categories category = categoryController.getCategoryByID(valueCategory);
            String categoryString = category.NameCategory;
                
            HtmlGenericControl pCategory = new HtmlGenericControl("p");
            pCategory.Attributes.Add("id", "location");
            pCategory.InnerText = "You are now shopping " + categoryString;

            itemsWrapper.Controls.Add(pCategory);

            foreach (DataObject.Items currentItem in itemsList)
            {
                /*Every 4 items I create a new Row*/
                if (count % 4 == 0) {
                    /* I create a new ItemsRow div and add it to the row list div */
                    itemsRow = new HtmlGenericControl("div");
                    itemsRow.Attributes.Add("class", "itemsRow");
                    itemsWrapper.Controls.Add(itemsRow);
                }

                createHTMLListOfItems(currentItem, itemsRow);
                count++;
            }

        }

        private void addToCart(object sender, EventArgs e)
        {
            /* I retrieve the clicked button */
            Button clickedButton = sender as Button;

            String idItem = clickedButton.Attributes["idItem"];
            

            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("Login.aspx");
            }
            else {
                String idUser = "-1";
                String username = User.Identity.Name;
                Controller.UserController userController = new Controller.UserController();
                DataObject.Users user = userController.getUser(username);
                if (user != null) {
                    idUser = user.IdUser;
                }

                Controller.OrdersController ordersController = new Controller.OrdersController();
                ordersController.createOrder(idItem, idUser, "1");
                /* I redirect the page to MyCart*/
                Response.Redirect("MyCart.aspx");
            }
        }


        private void createHTMLListOfItems(DataObject.Items item, HtmlGenericControl itemsRow)
        {
            HtmlGenericControl itemBox = new HtmlGenericControl("div");
            itemBox.Attributes.Add("class", "itemBox");
            itemsRow.Controls.Add(itemBox);

            HtmlGenericControl img = new HtmlGenericControl("img");
            img.Attributes.Add("class", "imgItemBox");
            img.Attributes["src"] = item.MainPicture;
            itemBox.Controls.Add(img);

            HtmlGenericControl a = new HtmlGenericControl("a");
            HtmlGenericControl strong = new HtmlGenericControl("strong");
            
            strong.Attributes.Add("class", "itemName");
            strong.InnerText = item.NameItem;
            a.Attributes.Add("href", "ItemDetails.aspx?idItem="+item.IdItem);
            a.Controls.Add(strong);
            itemBox.Controls.Add(a);

            HtmlGenericControl buyAction = new HtmlGenericControl("div");
            buyAction.Attributes.Add("class", "buyAction");
            itemBox.Controls.Add(buyAction);

            HtmlGenericControl priceItem = new HtmlGenericControl("div");
            priceItem.Attributes.Add("class", "priceItem");
            buyAction.Controls.Add(priceItem);

            HtmlGenericControl boxPrice = new HtmlGenericControl("span");
            boxPrice.Attributes.Add("class", "boxPrice");
            priceItem.Controls.Add(boxPrice);

            HtmlGenericControl price = new HtmlGenericControl("span");
            price.Attributes.Add("class", "price");
            boxPrice.Controls.Add(price);

            HtmlGenericControl span = new HtmlGenericControl("span");
            price.Controls.Add(span);
            Double priceDouble = -1;
            Double Num;
            bool isNum = Double.TryParse(item.Price, out Num);
            if (isNum)
            {
                priceDouble = Convert.ToDouble(item.Price);
            }

            price.InnerText = "$" + priceDouble;

            
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
                String paypalDiscountCode = item.PaypalDiscountCode.ToString();

                if (user.Discount.Equals("1"))
                {
                    HtmlGenericControl priceDiscount = new HtmlGenericControl("span");
                    priceDiscount.Attributes.Add("class", "price");
                    boxPrice.Controls.Add(priceDiscount);
                    
                    input2.Attributes.Add("value", paypalDiscountCode);


                    double priceDiscountDouble = (priceDouble * 90) / 100;
                    priceDiscount.InnerText = "10% off";
                }
                else
                {
                    input2.Attributes.Add("value", paypalCode);
                }
                HtmlGenericControl input3 = new HtmlGenericControl("input");
                input3.Attributes.Add("type", "image");
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

                buyAction.Controls.Add(form);
            }
            else {
                
                HtmlGenericControl loginBeforePaypal = new HtmlGenericControl("input");
                loginBeforePaypal.Attributes.Add("type", "button");
                loginBeforePaypal.Attributes.Add("value", "Login or Register");
                loginBeforePaypal.Attributes.Add("class", "loginBeforePaypal");
                
           
                loginBeforePaypal.Attributes.Add("src", "https://www.paypalobjects.com/en_AU/i/btn/btn_cart_LG.gif");
                buyAction.Controls.Add(loginBeforePaypal);
            }
            

            

        }
    }
}