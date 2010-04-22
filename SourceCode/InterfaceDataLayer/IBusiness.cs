using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterfaceDataLayer
{
    public interface IBusiness
    {
        bool CheckLogin(string UserName, string Password);
        void WriteXML(string path, string orderby);
    }
}
