using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayers
{
    public class Category : InterfaceDataLayer.ICategory
    {
        DataAccessLayers.CategoryDAL dataAccess = new DataAccessLayers.CategoryDAL();
        #region ICategory Members

        public IList<DataModelLayers.CategoryInfo> getListCategorys()
        {
            return dataAccess.getListCategorys();
        }

        public IList<DataModelLayers.CategoryInfo> SearchCategorys(string _categoryName)
        {
            return dataAccess.SearchCategorys(_categoryName);
        }

        public bool InsertCategory(DataModelLayers.CategoryInfo info)
        {
            return dataAccess.InsertCategory(info);
        }

        public bool UpdateCategory(DataModelLayers.CategoryInfo info)
        {
            return dataAccess.UpdateCategory(info);
        }

        public bool DeleteCategory(string _categoryID)
        {
            return dataAccess.DeleteCategory(_categoryID);
        }

        public DataModelLayers.CategoryInfo getCategoryInfo(string _categoryID)
        {
            return dataAccess.getCategoryInfo(_categoryID);
        }

        #endregion
    }
}
