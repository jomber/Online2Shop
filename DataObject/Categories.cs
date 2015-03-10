using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataObject
{
    public class Categories
    {
        private String idCategory;
        private String nameCategory;

        public Categories() { }

        public Categories(String idCategory, String nameCategory) {
            this.idCategory = idCategory;
            this.nameCategory = nameCategory;
        }

        public String IdCategory
        {
            get { return idCategory; }
            set { idCategory = value; }
        }

        public String NameCategory
        {
            get { return nameCategory; }
            set { nameCategory = value; }
        }
    }
}
