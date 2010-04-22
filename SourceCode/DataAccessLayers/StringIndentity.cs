using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;


namespace DataAccessLayers
{
    public class StringIndentity
    {
        public string IDIndentity(string Field, string Table,string CharDefault,string MaskedString)
        {
            string _default = CharDefault + MaskedString.Substring(0, MaskedString.Length - 1) + "1";
            try
            {
                DatabaseConnect Conn = new DatabaseConnect();
                String_Indentity.String_Indentity obj = new String_Indentity.String_Indentity();               
                DataTable dataTable = Conn.CreateDataTable("SELECT MAX("+ Field  +") FROM "+Table + "");
                if (dataTable.Rows.Count > 0)
                {
                    string maxID = dataTable.Rows[0][0].ToString();
                    return obj.ID(CharDefault, maxID, MaskedString);
                }
                else
                {
                    return _default;
                }
            }
            catch (Exception)
            {
                return _default;
            }
            
        }
    }
}
