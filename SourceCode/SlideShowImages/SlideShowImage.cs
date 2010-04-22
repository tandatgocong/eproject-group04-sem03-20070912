using System;
using System.Windows.Media.Imaging;

namespace SlideShowImages
{
	public class SlideShowImage
	{
		#region Private Member Variables

		private Uri imageUri;
		private String redirectLink;
		private Int32 order;
		private Int32 buttonNumber;
		private bool displayImage;

		#endregion

		#region Constructors
		
		/// <summary>
		/// Creates new instance of a SlideShowImage.
		/// </summary>
		public SlideShowImage()
		{
		}

		#endregion

		#region Properties

		/// <summary>
		/// Sets imageUri.
		/// </summary>
		public Uri ImageUri
		{
			set { imageUri = value; }
		}

		/// <summary>
		/// Gets BitmapImage from imageUri.
		/// </summary>
		public BitmapImage ImageSource
		{
			get { return new BitmapImage(imageUri); }
		}
		
		/// <summary>
		/// Gets/Sets image redirect link when image is clicked.
		/// </summary>
		public String RedirectLink
		{
			get { return redirectLink; }
			set { redirectLink = value; }
		}

		/// <summary>
		/// Gets/Sets order images are to be displayed.
		/// </summary>
		public Int32 Order
		{
			get { return order; }
			set { order = value; }
		}
		
		/// <summary>
		/// Gets/Sets number on image buttons.
		/// </summary>
		public Int32 ButtonNumber
		{
			get { return buttonNumber; }
			set { buttonNumber = value; }
		}

		/// <summary>
		/// Gets/Sets whether or not image is displayed.
		/// </summary>
		public bool DisplayImage
		{
			get { return displayImage; }
			set { displayImage = value; }
		}

		#endregion
	}
}
