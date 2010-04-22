using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataModelLayers
{
   public class CustomerInfo
    {
        private string customerID;
        private string customerUsername;
        private string customerName;
        private string customerPass;        
        private DateTime customerDofB;
        private string customerAddress;
        private string customerPhone;
        private string customerEmail;
        public CustomerInfo()
        {
            this.CustomerID = null;
            this.CustomerUsername = null;
            this.CustomerName = null;
            this.CustomerPass = null;
            this.CustomerDofB = DateTime.Now.Date;
            this.CustomerAddress = null;
            this.CustomerPhone = null;
            this.CustomerEmail = null;
        }
        public CustomerInfo(string _customerID, string _cusUsername, string _cusomerName, string _customerPass, DateTime _customerDofB, string _customerAddress, string _customerPhone, string _customerEmail)
        {
            this.CustomerID = _customerID;
            this.CustomerUsername = _cusUsername;
            this.CustomerName = _cusomerName;
            this.CustomerPass = _customerPass;
            this.CustomerDofB = _customerDofB;
            this.CustomerAddress = _customerAddress;
            this.CustomerPhone = _customerPhone;
            this.CustomerEmail = _customerEmail;
        }
        public string CustomerID
        {
            get { return customerID; }
            set { customerID = value; }
        }

        public string CustomerUsername
        {
            get { return customerUsername; }
            set { customerUsername = value; }
        }
        public string CustomerPass
        {
            get { return customerPass; }
            set { customerPass = value; }
        }        
        public string CustomerName
        {
            get { return customerName; }
            set { customerName = value; }
        }        
        public DateTime CustomerDofB
        {
            get { return customerDofB; }
            set { customerDofB = value; }
        }        
        public string CustomerAddress
        {
            get { return customerAddress; }
            set { customerAddress = value; }
        }        
        public string CustomerPhone
        {
            get { return customerPhone; }
            set { customerPhone = value; }
        }        
        public string CustomerEmail
        {
            get { return customerEmail; }
            set { customerEmail = value; }
        }
        
    }
}
