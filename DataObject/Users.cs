using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataObject
{
    public class Users
    {
        private String idUser;
        private String username;
        private String password;
        private String admin;
        private String email;
        private String discount;

        public Users() { }

        public Users(String idUser, String username, String password, String admin, String email, String discount) {
            this.idUser = idUser;
            this.username = username;
            this.password = password;
            this.admin = admin;
            this.email = email;
            this.discount = discount;
        }

        public String IdUser
        {
            get { return idUser; }
            set { idUser = value; }
        }


        public String Username
        {
            get { return username; }
            set { username = value; }
        }

        public String Password
        {
            get { return password; }
            set { password = value; }
        }

        public String Admin
        {
            get { return admin; }
            set { admin = value; }
        }

        public String Email
        {
            get { return email; }
            set { email = value; }
        }

        public String Discount
        {
            get { return discount; }
            set { discount = value; }
        }

    }
}
