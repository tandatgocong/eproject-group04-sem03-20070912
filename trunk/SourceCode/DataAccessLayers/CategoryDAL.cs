using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InterfaceDataLayer;
using DataModelLayers;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayers
{
   public class CategoryDAL : InterfaceDataLayer.ICategory
    {
        #region CategoryInfo Members

        private CategoryInfo Convert(DataRow Row)
        {
            CategoryInfo info = new CategoryInfo(Row["categoryID"].ToString(), Row["categoryName"].ToString());
            return info;
        }
        public DataModelLayers.CategoryInfo getCategoryInfo(string _categoryID)
        {
            DatabaseConnect Conn = new DatabaseConnect();
            SqlParameter[] Params = new SqlParameter[]{
                new SqlParameter("categoryID",_categoryID)
            };

            DataTable Result = Conn.CreateDataTable("select * from  Category where categoryID=@categoryID", Params);
            if (Result.Rows.Count != 1)
            {
                return new CategoryInfo();
            }
            DataRow row = Result.Rows[0];
            return Convert(row);
        }
        public IList<DataModelLayers.CategoryInfo> getListCategorys()
        {
            DatabaseConnect Conn = new DatabaseConnect();
            DataTable Result = Conn.CreateDataTable("select * from Category");
            List<CategoryInfo> List = new List<CategoryInfo>();
            foreach (DataRow row in Result.Rows)
            {
                List.Add(Convert(row));
            }
            return List;
        }

        public IList<DataModelLayers.CategoryInfo> SearchCategorys(string _categoryName)
        {
            DatabaseConnect Conn = new DatabaseConnect();
            DataTable Result = Conn.CreateDataTable("select * from Category WHERE categoryName like '%" + _categoryName.Trim().ToString() + "%'");
            List<CategoryInfo> List = new List<CategoryInfo>();
            foreach (DataRow row in Result.Rows)
            {
                List.Add(Convert(row));
            }
            return List;
        }

        public bool InsertCategory(DataModelLayers.CategoryInfo info)
        {
            throw new NotImplementedException();
        }

        public bool UpdateCategory(DataModelLayers.CategoryInfo info)
        {
            throw new NotImplementedException();
        }

        public bool DeleteCategory(string _categoryID)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
