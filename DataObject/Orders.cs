using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataObject
{
    public class Orders
    {
        private String idOrders;
        private String idUser;
        private String idItem;
        private String date;
        private String active;
        private String amount;

        public Orders() { }

        public Orders(String idOrders, String idUser, String idItem, String date, String active, String amount) {
            this.idOrders = idOrders;
            this.idUser = idUser;
            this.idItem = idItem;
            this.date = date;
            this.active = active;
            this.amount = amount;
        }

        public String IdOrders
        {
            get { return idOrders; }
            set { idOrders = value; }
        }

        public String IdUser
        {
            get { return idUser; }
            set { idUser = value; }
        }

        public String IdItem
        {
            get { return idItem; }
            set { idItem = value; }
        }

        public String Date
        {
            get { return date; }
            set { date = value; }
        }

        public String Active
        {
            get { return active; }
            set { active = value; }
        }

        public String Amount
        {
            get { return amount; }
            set { amount = value; }
        }
    }
}
