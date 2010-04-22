using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataModelLayers;

namespace InterfaceDataLayer
{
    public interface IBooks
    {
        IList<BookInfo> getListBooks();
        IList<BookInfo> getBookDetail(string _bookId);
        IList<BookInfo> SearchBooks(string _bookName);
        bool InsertBook(BookInfo info);
        bool UpdateBook(BookInfo info);
        bool DeleteBook(string bookID);
        BookInfo getBookInfo(string _bookId);
    }
}
