using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayers
{
    public class Customers : InterfaceDataLayer.ICustomers
    {
        #region ICustomers Members
        DataAccessLayers.CustomersDAL dataAccess = new DataAccessLayers.CustomersDAL();
        public IList<DataModelLayers.CustomerInfo> getListCustomers()
        {
            return dataAccess.getListCustomers();
        }

        public IList<DataModelLayers.CustomerInfo> SearchCustomers(string _customerName)
        {
            return dataAccess.SearchCustomers(_customerName);
        }

        public bool InsertCustomer(DataModelLayers.CustomerInfo info)
        {
            return dataAccess.InsertCustomer(info);
        }

        public bool UpdateCustomer(DataModelLayers.CustomerInfo info)
        {
            return dataAccess.UpdateCustomer(info);
        }

        public bool DeleteCustomer(string _customerId)
        {
            return dataAccess.DeleteCustomer(_customerId);
        }

        public DataModelLayers.CustomerInfo getCustomerInfo(string _customerId)
        {
            return dataAccess.getCustomerInfo(_customerId);
        }

        #endregion
    }
}
