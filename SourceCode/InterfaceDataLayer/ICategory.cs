using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataModelLayers;

namespace InterfaceDataLayer
{
    public interface ICategory
    {
        IList<CategoryInfo> getListCategorys();
        IList<CategoryInfo> SearchCategorys(string _categoryName);
        bool InsertCategory(CategoryInfo info);
        bool UpdateCategory(CategoryInfo info);
        bool DeleteCategory(string _categoryID);
        CategoryInfo getCategoryInfo(string _categoryID);
    }
}
