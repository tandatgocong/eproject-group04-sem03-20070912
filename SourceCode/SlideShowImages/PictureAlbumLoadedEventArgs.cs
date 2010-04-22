using System;

namespace SlideShowImages
{
	public class PictureAlbumLoadedEventArgs: EventArgs
	{
		#region Private Member Variables

		private bool pictureAlbumLoaded;

		#endregion

		#region Public Methods
		/// <summary>
		/// Argument indicating if Picture album has loaded.
		/// </summary>
		/// <param name="loadCompleted"></param>
		public PictureAlbumLoadedEventArgs(bool loadCompleted) 
		{
			pictureAlbumLoaded = loadCompleted; 
		}

		#endregion

		#region Properties

		/// <summary>
		/// Indicates if PictureAlbum was loaded successfully from SlideShowImages file.
		/// </summary>
		public bool PictureAlbumLoadedSuccessfully
		{
			get { return pictureAlbumLoaded; }
		}

		#endregion
	}
}
