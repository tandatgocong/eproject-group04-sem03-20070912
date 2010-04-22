using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayers
{
    public class Books : InterfaceDataLayer.IBooks
    {
        DataAccessLayers.BooksDAL dataAccess = new DataAccessLayers.BooksDAL();
        #region IBooks Members
        
        public IList<DataModelLayers.BookInfo> getListBooks()
        {
            return dataAccess.getListBooks();
        }

        public IList<DataModelLayers.BookInfo> SearchBooks(string _bookName)
        {
            return dataAccess.SearchBooks(_bookName);
        }

        public bool InsertBook(DataModelLayers.BookInfo info)
        {
            return dataAccess.InsertBook(info);
        }

        public bool UpdateBook(DataModelLayers.BookInfo info)
        {
            return dataAccess.UpdateBook(info);
        }

        public bool DeleteBook(string bookID)
        {
            return dataAccess.DeleteBook(bookID);
        }

        public DataModelLayers.BookInfo getBookInfo(string _bookId)
        {
            return dataAccess.getBookInfo(_bookId);
        }
        public IList<DataModelLayers.BookInfo> getBookDetail(string _bookId)
        {
            return dataAccess.getBookDetail(_bookId);
        }
        #endregion
        
    }
}
