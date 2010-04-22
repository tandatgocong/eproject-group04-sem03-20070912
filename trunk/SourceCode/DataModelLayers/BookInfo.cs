using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataModelLayers
{
    public class BookInfo
    {
        private string bookID;
        private string bookName;
        private string bookAuthor;
        private string bookImg;
        private double bookPrice; 
        private int bookYear;
        private string bookCategory;
        public BookInfo()
        {
            this.BookID = null;
            this.BookName = null;
            this.BookAuthor = null;
            this.BookImg = null;
            this.BookPrice= 0;
            this.BookYear= 1900;
            this.BookCategory = null;
        }
        public BookInfo(string _bookID, string _bookName, string _bookAuthor, string _bookImg, double _bookPrice, int _bookYear, string _bookCategory)
        {
            this.BookID = _bookID;
            this.BookName = _bookName;
            this.BookAuthor = _bookAuthor;
            this.BookImg = _bookImg;
            this.BookPrice = _bookPrice;
            this.BookYear = _bookYear;
            this.BookCategory = _bookCategory;
        }
        public string BookID
        {
            get { return bookID; }
            set { bookID = value; }
        }   
        public string BookName
        {
            get { return bookName; }
            set { bookName = value; }
        }
        public string BookAuthor
        {
            get { return bookAuthor; }
            set { bookAuthor = value; }
        }
        public int BookYear
        {
            get { return bookYear; }
            set { bookYear = value; }
        }
        public string BookImg
        {
            get { return bookImg; }
            set { bookImg = value; }
        }
        public double BookPrice
        {
            get { return bookPrice; }
            set { bookPrice = value; }
        }
        public string BookCategory
        {
            get { return bookCategory; }
            set { bookCategory = value; }
        }
    }
}
