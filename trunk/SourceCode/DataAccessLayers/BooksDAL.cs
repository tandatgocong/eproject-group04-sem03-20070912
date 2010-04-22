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
   public class BooksDAL: InterfaceDataLayer.IBooks
    {
        #region IBooks Members
        private BookInfo Convert(DataRow Row)
       {
           BookInfo info = new BookInfo(Row["bookID"].ToString(), Row["bookName"].ToString(), Row["bookAuthor"].ToString(), Row["bookImg"].ToString(), double.Parse(Row["bookPrice"].ToString()), int.Parse(Row["bookYear"].ToString()), Row["bookCategory"].ToString());
           return info;
       }
        public BookInfo getBookInfo(string _bookId)
       {
           DatabaseConnect Conn = new DatabaseConnect();
           SqlParameter[] Params = new SqlParameter[]{
                new SqlParameter("bookID",_bookId)
            };

           DataTable Result = Conn.CreateDataTable("select * from  Books where bookID=@bookID", Params);
           if (Result.Rows.Count != 1)
           {
               return new BookInfo();
           }
           DataRow row = Result.Rows[0];
           return Convert(row);
       }
        public IList<DataModelLayers.BookInfo> getListBooks()
        {
            DatabaseConnect Conn = new DatabaseConnect();
            DataTable Result = Conn.CreateDataTable("select * from Books");
            List<BookInfo> List = new List<BookInfo>();
            foreach (DataRow row in Result.Rows)
            {
                List.Add(Convert(row));
            }
            return List;
        }        
        public IList<DataModelLayers.BookInfo> SearchBooks(string _bookName)
        {
            DatabaseConnect Conn = new DatabaseConnect();
            DataTable Result = Conn.CreateDataTable("select * from Books WHERE bookName like '%" + _bookName.Trim().ToString() + "%'");
            List<BookInfo> List = new List<BookInfo>();
            foreach (DataRow row in Result.Rows)
            {
                List.Add(Convert(row));
            }
            return List;
        }
        public bool InsertBook(DataModelLayers.BookInfo info)
        {
            StringIndentity obj = new StringIndentity();
            string id = obj.IDIndentity("bookID", "Books", "BO", "00000000");
            SqlParameter[] Params = new SqlParameter[]{
                new SqlParameter("bookID", id),
                new SqlParameter("bookName", info.BookName),
                new SqlParameter("bookAuthor", info.BookAuthor),
                new SqlParameter("bookImg", info.BookImg),
                new SqlParameter("bookPrice", info.BookPrice),
                new SqlParameter("bookYear", info.BookYear),
                new SqlParameter("bookCategory", info.BookCategory)
            };
            DatabaseConnect Conn = new DatabaseConnect();
            int result = Conn.ExcuteNonQuery("INSERT INTO Books VALUES(@bookID, @bookName,@bookAuthor,@bookImg,@bookPrice,@bookYear,@bookCategory)", Params);
            return (result == 1 ? true : false);
        }
        public bool UpdateBook(DataModelLayers.BookInfo info)
        {
            SqlParameter[] Params = new SqlParameter[]{
               new SqlParameter("bookID", info.BookID),
                new SqlParameter("bookName", info.BookName),
                new SqlParameter("bookAuthor", info.BookAuthor),
                new SqlParameter("bookImg", info.BookImg),
                new SqlParameter("bookPrice", info.BookPrice),
                new SqlParameter("bookYear", info.BookYear),
                new SqlParameter("bookCategory", info.BookCategory)
            };
            DatabaseConnect Conn = new DatabaseConnect();
            int result = Conn.ExcuteNonQuery("UPDATE Books SET bookName = @bookName, bookAuthor = @bookAuthor, bookImg = @bookImg, bookPrice = @bookPrice, bookYear = @bookYear, bookCategory = @bookCategory where bookID=@bookID", Params);
            return (result == 1 ? true : false);
        }
        public bool DeleteBook(string bookID)
        {
            SqlParameter[] Params = new SqlParameter[]{
                new SqlParameter("bookID", bookID)
            };
            BookInfo tmp = this.getBookInfo(bookID);
            if (!tmp.BookID.Equals(""))
            {
                DatabaseConnect Conn = new DatabaseConnect();
                int result = Conn.ExcuteNonQuery("DELETE Books where bookID=@bookID", Params);
                return (result == 1 ? true : false);
            }
            return false;
        }       
        #endregion   
    
        #region IBooks Members


        public IList<BookInfo> getBookDetail(string _bookId)
        {
            DatabaseConnect Conn = new DatabaseConnect();
            SqlParameter[] Params = new SqlParameter[]{
                new SqlParameter("bookID",_bookId)
            };

            DataTable Result = Conn.CreateDataTable("select * from  Books where bookID=@bookID", Params);
            List<BookInfo> List = new List<BookInfo>();
            foreach (DataRow row in Result.Rows)
            {
                List.Add(Convert(row));
            }
            return List;
        }

        #endregion
    }
}
