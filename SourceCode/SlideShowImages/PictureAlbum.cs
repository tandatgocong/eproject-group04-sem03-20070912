using System;
using System.Collections.Generic;
using System.Xml.Linq; // had to add reference to this in project
using System.Net;

namespace SlideShowImages
{
	public class PictureAlbum
	{
		#region Private Member Variables
	
		private List<SlideShowImage> slideShowImages;
		private double imageWidth;
		private double imageHeight;
		private XDocument xdoc; 
		public delegate void PictureAlbumLoaded(object sender, PictureAlbumLoadedEventArgs a);
		public event PictureAlbumLoaded pictureAlbumLoaded;
        

		#endregion

		#region Constructors
	
		/// <summary>
		/// Creates new instance of PictureAlbum.
		/// </summary>
		public PictureAlbum()
		{
		}

		#endregion

		#region Public Methods

		/// <summary>
		/// Asynchronously gets SlideShowImages.xml file.
		/// </summary>
        public void LoadPictureAlbumXMLFile(int tmp)
        {
            if (tmp == 1)
            {
                WebClient xmlClient = new WebClient();
                xmlClient.DownloadStringCompleted += new DownloadStringCompletedEventHandler(XMLFileLoaded);
                xmlClient.DownloadStringAsync(new Uri("SlideShowImages02.xml", UriKind.RelativeOrAbsolute));
            }
            else
            {
                WebClient xmlClient = new WebClient();
                xmlClient.DownloadStringCompleted += new DownloadStringCompletedEventHandler(XMLFileLoaded);
                xmlClient.DownloadStringAsync(new Uri("SlideShowImages01.xml", UriKind.RelativeOrAbsolute));


            }
        }  
		#endregion

		#region Private Methods
		
		/// <summary>
		/// Parses SlideShowImages.xml file and loads contents into slideShowImages collection.  
		/// Then fires pictureAlbumLoadedEvent.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void XMLFileLoaded(object sender, DownloadStringCompletedEventArgs e)
		{
			if (e.Error == null)
			{
				Int32 buttonNumber = 0;
				slideShowImages = new List<SlideShowImage>();
				PictureAlbumLoadedEventArgs pictureAlbumLoadedCompletedSuccessfully = null;

				try
				{
					xdoc = XDocument.Parse(e.Result);

					imageWidth = Convert.ToDouble(xdoc.Element("PictureAlbum").Attribute("ImageWidth").Value);
					imageHeight = Convert.ToDouble(xdoc.Element("PictureAlbum").Attribute("ImageHeight").Value);

					foreach (XElement item in xdoc.Elements("PictureAlbum").Elements("SlideShowImage"))
					{
						if (item.Element("DisplayImage").Value.ToLower() == "true")
						{
							SlideShowImage slideShowImage = new SlideShowImage();

							if (item.Element("ImageUri").Value.Contains("http"))
								slideShowImage.ImageUri = new Uri(item.Element("ImageUri").Value, UriKind.Absolute);
							else
								slideShowImage.ImageUri = new Uri(item.Element("ImageUri").Value, UriKind.Relative);

							slideShowImage.RedirectLink = item.Element("RedirectLink").Value;
							slideShowImage.Order = Convert.ToInt32(item.Element("Order").Value);
							slideShowImage.ButtonNumber = buttonNumber++;
							slideShowImages.Add(slideShowImage);
						}
					}

					pictureAlbumLoadedCompletedSuccessfully = new PictureAlbumLoadedEventArgs(true);
				}
				catch
				{
					pictureAlbumLoadedCompletedSuccessfully = new PictureAlbumLoadedEventArgs(false);
				}
				finally
				{
					// Fire off pictureAlbumLoadedHandler so the listeners can respond.
					pictureAlbumLoaded(this, pictureAlbumLoadedCompletedSuccessfully); 
				}				
			}
		}

		#endregion

		#region Properties

		/// <summary>
		/// Collection of SlideShowImage's obtained loaded from SlideShowImages.xml file.
		/// </summary>
		public List<SlideShowImage> SlideShowImages
		{
			get { return slideShowImages; }
		}

		/// <summary>
		/// Width of images obtained from SlideShowImages.xml file.
		/// </summary>
		public double ImageWidth
		{
			get { return imageWidth; }
		}

		/// <summary>
		/// Height of images obtained from SlideShowImages.xml file.
		/// </summary>
		public double ImageHeight
		{
			get { return imageHeight; }
		}

		#endregion
	}
}
