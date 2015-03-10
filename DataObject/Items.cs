using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataObject
{
    public class Items
    {
        private String idItem;
        private String nameItem;
        private String idCategory;
        private String price;
        private String description;
        private String mainPicture;
        private List<String> pictures;
        private String paypalCode;
        private String paypalDiscountCode;

        public Items() { }

        public Items(String idItem, String nameItem, String idCategory, String price, String description, String mainPicture, List<String> pictures, String paypalCode, String paypalDiscountCode)
        {
            this.idItem = idItem;
            this.nameItem = nameItem;
            this.idCategory = idCategory;
            this.price = price;
            this.description = description;
            this.mainPicture = mainPicture;
            this.pictures = pictures;
            this.paypalCode = paypalCode;
            this.paypalDiscountCode = paypalDiscountCode;
        }

        public String IdItem
        {
            get { return idItem; }
            set { idItem = value; }
        }

        public String NameItem
        {
            get { return nameItem; }
            set { nameItem = value; }
        }

        public String IdCategory
        {
            get { return idCategory; }
            set { idCategory = value; }
        }

        public String Price
        {
            get { return price; }
            set { price = value; }
        }

        public String Description
        {
            get { return description; }
            set { description = value; }
        }

        public String MainPicture
        {
            get { return mainPicture; }
            set { mainPicture = value; }
        }

        public List<String> Pictures
        {
            get { return pictures; }
            set { pictures = value; }
        }

        public String PaypalCode
        {
            get { return paypalCode; }
            set { paypalCode = value; }
        }

        public String PaypalDiscountCode
        {
            get { return paypalDiscountCode; }
            set { paypalDiscountCode = value; }
        }
    }
}
