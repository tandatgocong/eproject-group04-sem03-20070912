using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataModelLayers
{
    public class CategoryInfo
    {
        private string categoryID;
        private string categoryName;

        public CategoryInfo()
        {
            this.CategoryID = "";
            this.CategoryName = "";
        }
        public CategoryInfo(string _categoryID, string _categoryName)
        {
            this.CategoryID = _categoryID;
            this.CategoryName = _categoryName;
        }
        public string CategoryID
        {
            get { return categoryID; }
            set { categoryID = value; }
        }
        public string CategoryName
        {
            get { return categoryName; }
            set { categoryName = value; }
        }
    }
}
