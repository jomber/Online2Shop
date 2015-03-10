using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataObject
{
    public class DetailsUser
    {
        private String idDetails;
        private String address;
        private String suburb;
        private String postcode;
        private String country;
        private String telephone;

        public DetailsUser() { }

        public DetailsUser(String idDetails, String address, String suburb, String postcode, String country, String telephone) {
            this.idDetails = idDetails;
            this.address = address;
            this.suburb = suburb;
            this.postcode = postcode;
            this.country = country;
            this.telephone = telephone;
        }

        public String IdDetails
        {
            get { return idDetails; }
            set { idDetails = value; }
        }

        public String Address
        {
            get { return address; }
            set { address = value; }
        }

        public String Suburb
        {
            get { return suburb; }
            set { suburb = value; }
        }

        public String Postcode
        {
            get { return postcode; }
            set { postcode = value; }
        }

        public String Country
        {
            get { return country; }
            set { country = value; }
        }

        public String Telephone
        {
            get { return telephone; }
            set { telephone = value; }
        }

    }
}
