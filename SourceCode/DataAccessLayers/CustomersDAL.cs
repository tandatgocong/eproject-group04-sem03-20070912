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
   public class CustomersDAL : InterfaceDataLayer.ICustomers
    {


       #region ICustomers Members
       public CustomerInfo getCustomerInfo(string _customerId)
       {
           DatabaseConnect Conn = new DatabaseConnect();
           SqlParameter[] Params = new SqlParameter[]{
                new SqlParameter("customerId",_customerId)
            };
           DataTable Result = Conn.CreateDataTable("select * from  Customers where customerId=@customerId", Params);
           if (Result.Rows.Count != 1)
           {
               return new CustomerInfo();
           }
           DataRow row = Result.Rows[0];
           return Convert(row);
       }
       private CustomerInfo Convert(DataRow Row)
       {
           CustomerInfo info = new CustomerInfo(Row["customerID"].ToString(), Row["customerUsername"].ToString(), Row["customerName"].ToString(), Row["customerPass"].ToString(), DateTime.Parse(Row["customerDofB"].ToString()), Row["customerAddress"].ToString(), Row["customerPhone"].ToString(), Row["customerEmail"].ToString());
           return info;
       }
       public IList<DataModelLayers.CustomerInfo> getListCustomers()
       {
            DatabaseConnect Conn = new DatabaseConnect();
            DataTable Result = Conn.CreateDataTable("select * from Customers");
            List<CustomerInfo> List = new List<CustomerInfo>();
            foreach (DataRow row in Result.Rows)
            {
                List.Add(Convert(row));
            }
            return List;
        }

        public IList<DataModelLayers.CustomerInfo> SearchCustomers(string _customerName)
        {
            DatabaseConnect Conn = new DatabaseConnect();
            DataTable Result = Conn.CreateDataTable("select * from Books WHERE bookName like '%" + _customerName.Trim().ToString() + "%'");
            List<CustomerInfo> List = new List<CustomerInfo>();
            foreach (DataRow row in Result.Rows)
            {
                List.Add(Convert(row));
            }
            return List;
        }

        public bool InsertCustomer(DataModelLayers.CustomerInfo info)
        {
            StringIndentity obj = new StringIndentity();
            string id = obj.IDIndentity("customerID", "Customers", "CU", "00000000").ToString();
            SqlParameter[] Params = new SqlParameter[]{
                new SqlParameter("customerID",id),
                new SqlParameter("customerUsername", info.CustomerUsername),
                new SqlParameter("customerName", info.CustomerName),
                new SqlParameter("customerPass", info.CustomerPass),
                new SqlParameter("customerDofB", info.CustomerDofB.ToShortDateString()),
                new SqlParameter("customerAddress", info.CustomerAddress),
                new SqlParameter("customerPhone", info.CustomerPhone),
                new SqlParameter("customerEmail", info.CustomerEmail)
            };
            DatabaseConnect Conn = new DatabaseConnect();
            int result = Conn.ExcuteNonQuery("INSERT INTO Customers VALUES(@customerID, @customerUsername,@customerName,@customerPass,@customerDofB,@customerAddress,@customerPhone,@customerEmail)", Params);
            return (result == 1 ? true : false);
        }

        public bool UpdateCustomer(DataModelLayers.CustomerInfo info)
        {
            SqlParameter[] Params = new SqlParameter[]{
                new SqlParameter("customerID", info.CustomerID),
                new SqlParameter("customerUsername", info.CustomerID),
                new SqlParameter("customerName", info.CustomerName),
                new SqlParameter("customerPass", info.CustomerPass),
                new SqlParameter("customerDofB", info.CustomerDofB.ToShortDateString()),
                new SqlParameter("customerAddress", info.CustomerAddress),
                new SqlParameter("customerPhone", info.CustomerPhone),
                new SqlParameter("customerEmail", info.CustomerEmail)
            };
            DatabaseConnect Conn = new DatabaseConnect();
            int result = Conn.ExcuteNonQuery("UPDATE Customers SET customerName = @customerName,customerUsername=@customerUsername, customerPass = @customerPass, customerDofB = @customerDofB, customerAddress = @customerAddress, customerPhone = @customerPhone, customerEmail = @customerEmail where customerID=@customerID", Params);
            return (result == 1 ? true : false);
        }

        public bool DeleteCustomer(string _customerId)
        {
            SqlParameter[] Params = new SqlParameter[]{
                new SqlParameter("customerId", _customerId)
            };
            CustomerInfo tmp = this.getCustomerInfo(_customerId);
            if (!tmp.CustomerID.Equals(""))
            {
                DatabaseConnect Conn = new DatabaseConnect();
                int result = Conn.ExcuteNonQuery("DELETE Customers where customerId=@customerId", Params);
                return (result == 1 ? true : false);
            }
            return false;
        }

        #endregion
    }
}
