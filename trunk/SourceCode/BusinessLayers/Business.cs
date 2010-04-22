using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InterfaceDataLayer;
using System.Xml;
namespace BusinessLayers
{
    public class Business : InterfaceDataLayer.IBusiness
    {
        DataAccessLayers.BusinessDAL dataAccess = new DataAccessLayers.BusinessDAL();
        #region IBusiness Members

        public bool CheckLogin(string UserName, string Password)
        {
            return dataAccess.CheckLogin(UserName, Password);
        }

        public void WriteXML(string path, string orderby)
        {
            dataAccess.WriteXML(path, orderby);
        }
        #endregion
    }
}
