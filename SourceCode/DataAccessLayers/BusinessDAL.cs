using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using InterfaceDataLayer;
using System.Xml;

namespace DataAccessLayers
{
  public class BusinessDAL : InterfaceDataLayer.IBusiness
    {

        #region IBusiness Members

        public bool CheckLogin(string UserName, string Password)
        {
            DatabaseConnect Conn = new DatabaseConnect();
            SqlParameter[] Params = new SqlParameter[]{
                new SqlParameter("UserName",UserName),
                new SqlParameter("Password",Password)
            };
            DataTable Result = Conn.CreateDataTable("select * from  Customers where customerUsername=@UserName and customerPass=@Password", Params);
            if (Result.Rows.Count != 1)
            {
                return false;
            }
            return true;
        }
        public void WriteXML(string path, string orderby)
        {
            try
            {
                XmlTextWriter writer = new XmlTextWriter(path, null);
                writer.Formatting = Formatting.Indented;
                writer.WriteStartDocument();
                writer.WriteStartElement("PictureAlbum");
                writer.WriteAttributeString("ImageWidth", "480");
                writer.WriteAttributeString("ImageHeight", "360");
                DatabaseConnect Conn = new DatabaseConnect();
                string sql = "SELECT TOP(10) bookID,bookImg FROM Books ORDER BY bookID " + orderby;
                DataTable table = Conn.CreateDataTable(sql);
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    writer.WriteStartElement("SlideShowImage");
                    writer.WriteStartElement("ImageUri");
                    writer.WriteString(@"../Images/" + table.Rows[i][1].ToString());
                    writer.WriteEndElement();

                    writer.WriteStartElement("RedirectLink");
                    writer.WriteString("http://localhost/eProject_GROUP_04/WebUsers/BookDetails.aspx?id=" + table.Rows[i][0].ToString());
                    writer.WriteEndElement();

                    writer.WriteStartElement("Order");
                    writer.WriteString((i + 1).ToString());
                    writer.WriteEndElement();

                    writer.WriteStartElement("DisplayImage");
                    writer.WriteString("True");
                    writer.WriteEndElement();

                    writer.WriteEndElement();
                }

                writer.WriteEndElement();

                writer.Flush();
                writer.Close();

            }
            catch (Exception)
            {
                
               
            }
            
        }
        
        #endregion
      
  }
}
