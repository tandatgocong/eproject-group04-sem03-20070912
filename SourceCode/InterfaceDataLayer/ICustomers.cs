using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using DataModelLayers;
namespace InterfaceDataLayer
{
    public interface ICustomers
    {
        
        IList<CustomerInfo> getListCustomers();
        IList<CustomerInfo> SearchCustomers(string _customerName);
        bool InsertCustomer(CustomerInfo info);
        bool UpdateCustomer(CustomerInfo info);
        bool DeleteCustomer(string _customerId);
        CustomerInfo getCustomerInfo(string _customerId);
 
    }
}
