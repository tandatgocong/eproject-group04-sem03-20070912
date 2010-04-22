using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Browser;
using System.Threading;

namespace SlideShowImages
{
	public partial class Page : UserControl
	{
		#region Private Member Variables

		private List<SlideShowImage> pictures = new List<SlideShowImage>();
		private double imageWidth;
		private double imageHeight;
		private int lastImageIndex = 0;
		private int nextImageIndex = 0;
		private int currentlyHighlightedIndex = 0;
		private int imageCount = 0;
		private Storyboard fadeOutStoryboard;
		private Storyboard fadeInStoryboard;
		private bool enableAutoPlay;
		private int autoPlayIntervalSeconds;
		private bool displayNumberedButtons;
		private bool displayArrows;
		private bool buttonsStopStartAutoPlay;
		private bool leavePaused;
		private bool enableAnimations;
		private bool displayImageBorder;
		private int imageBorderThickness;
		private string argbBorderColor;
		private string imageRotatorDiv;
		private string browserWindowOptions = "";
		DispatcherTimer autoPlayTimer = new System.Windows.Threading.DispatcherTimer();
		private HtmlPopupWindowOptions htmlPopupWindowOptions = new HtmlPopupWindowOptions();
		delegate void NewImagesHandler(Int32 imageIndex, Visibility visibility);
		PictureAlbum pictureAlbum = new PictureAlbum();
		static int imagesToLoadCount = 0;
		Object objLock1 = new Object();

		#endregion

		#region Constructors

		/// <summary>
		/// Overloaded contstructor that takes in InitParams and stores them into
		/// private member variables for later use.
		/// </summary>
		/// <param name="parameters"></param>
		public Page(IDictionary<string, string> parameters)
		{
			InitializeComponent();

			// retrieve the initParams, convert back any ASCII characters 
			foreach (var item in parameters)
			{
				switch (item.Key)
				{
					case "autoPlay":
						enableAutoPlay = Convert.ToBoolean(item.Value);
						break;
					case "autoPlayInterval":
						autoPlayIntervalSeconds = Convert.ToInt32(item.Value);
						break;
					case "numberedNavigation":
						displayNumberedButtons = Convert.ToBoolean(item.Value);
						break;
					case "arrowNavigation":
						displayArrows = Convert.ToBoolean(item.Value);
						break;
					case "stopStartAutoPlay":
						buttonsStopStartAutoPlay = Convert.ToBoolean(item.Value);
						break;
					case "animation":
						enableAnimations = Convert.ToBoolean(item.Value);
						break;
					case "border":
						displayImageBorder = Convert.ToBoolean(item.Value);
						break;
					case "borderThickness":
						imageBorderThickness = Convert.ToInt32(item.Value);
						break;
					case "argb":
						argbBorderColor = item.Value.ToString().Replace("|", ",");
						break;
					case "imageRotatorDiv":
						imageRotatorDiv = item.Value.ToString();
						break;
					case "browserWindowOptions":
						browserWindowOptions = item.Value.ToString().Replace("|", ",");
						break;
				}
			}

			LoadPictureAlbum(imageBorderThickness);
		}

		#endregion

		#region Private Methods

		/// <summary>
		/// Sets up event listener for when SlideShowImages.xml file is loaded and
		/// then calls method to load that file and populate the picture album.
		/// </summary>
		private void LoadPictureAlbum(int tmp)
		{
			pictureAlbum.pictureAlbumLoaded += new PictureAlbum.PictureAlbumLoaded(PictureAlbumLoaded);
			pictureAlbum.LoadPictureAlbumXMLFile(tmp);
		}

		/// <summary>
		/// Callback method that fires when LoadPictureAlbumXMFFile has completed.
		/// It creates first image right away, then asynchronously creates rest
		/// of the images.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="a"></param>
		private void PictureAlbumLoaded(object sender, PictureAlbumLoadedEventArgs args)
		{
			try
			{
				if (args.PictureAlbumLoadedSuccessfully)
				{
					imageWidth = pictureAlbum.ImageWidth;
					imageHeight = pictureAlbum.ImageHeight;

					pictures = pictureAlbum.SlideShowImages;
					imageCount = pictures.Count;

					// create first image 
					AddNewImage(0, Visibility.Visible);

					imagesToLoadCount = imageCount - 1;

					// create rest of images asynchronously 
					for (int i = 1; (i < pictures.Count); i++)
						ThreadPool.QueueUserWorkItem(ProcessSlideShowImage, i.ToString());
				}
				else
					throw new Exception("The SlideShowImages.xml file failed to load the PictureAlbum class successfully.");
			}
			finally
			{
				pictureAlbum.pictureAlbumLoaded -= new PictureAlbum.PictureAlbumLoaded(PictureAlbumLoaded);
			}
		}

		/// <summary>
		/// WaitCallback method asynchronous calls to create image controls.
		/// Image that's created must be added to page on dispatcher thread.
		/// </summary>
		/// <param name="imageIndex"></param>
		private void ProcessSlideShowImage(object imageIndex)
		{
			NewImagesHandler newImageHandler = new NewImagesHandler(AddNewImage);
			object[] args = { Convert.ToInt32(imageIndex), Visibility.Collapsed };

			Dispatcher.BeginInvoke(newImageHandler, args);
		}

		/// <summary>
		/// Creates new Image control and adds it to imageStackPanel's children collection.
		/// Once all Image controls are created call methods to setup rest of Silverlight control.
		/// </summary>
		/// <param name="imageIndex"></param>
		/// <param name="visibility"></param>
		private void AddNewImage(int imageIndex, Visibility visibility)
		{
			Image image = new Image();
			image.Width = imageWidth;
			image.Height = imageHeight;
			image.Source = pictures.ElementAt(Convert.ToInt32(imageIndex)).ImageSource;
			image.MouseLeftButtonDown += new MouseButtonEventHandler(NewWindow_Click);
			image.Visibility = visibility;

			imageStackPanel.Children.Add(image);

			lock (objLock1)
			{
				imagesToLoadCount -= 1;

				// Image control creation completed, setup rest of ImageRotator control.
				if (imagesToLoadCount == 0)
				{
					SizeUserControlAndDiv();
					SetupImageBorder();
					SetupNavication();
					SetupAutoPlayTimer();
				}
			}
		}

		/// <summary>
		/// Dynamically sizes the html container div that holds this Silverlight
		/// control.
		/// </summary>
		private void SizeUserControlAndDiv()
		{
			Width = UserControlWidth; ;
			Height = UserControlHeight; ;

			imageBorder.Width = UserControlWidth;
			imageBorder.Height = UserControlHeight;

			HtmlPage.Document.GetElementById(imageRotatorDiv).
				SetStyleAttribute("width", string.Format("{0}px", UserControlWidth ));

			HtmlPage.Document.GetElementById(imageRotatorDiv).
				SetStyleAttribute("height", string.Format("{0}px", UserControlHeight ));
		}

		/// <summary>
		/// Sets up Image control's border color and thickness.
		/// </summary>
		private void SetupImageBorder()
		{
			if (displayImageBorder)
			{
				try
				{
					string[] color = argbBorderColor.Split(new char[] { ',' });

					if (color.Length == 4
						&& (Convert.ToInt32(color[0]) >= 0 && Convert.ToInt32(color[0]) <= 255)
						&& (Convert.ToInt32(color[1]) >= 0 && Convert.ToInt32(color[1]) <= 255)
						&& (Convert.ToInt32(color[2]) >= 0 && Convert.ToInt32(color[2]) <= 255)
						&& (Convert.ToInt32(color[3]) >= 0 && Convert.ToInt32(color[3]) <= 255))
					{
						SolidColorBrush solidColorBrush =
							new SolidColorBrush(Color.FromArgb(Convert.ToByte(color[0]), Convert.ToByte(color[1]),
								Convert.ToByte(color[2]), Convert.ToByte(color[3])));
						imageBorder.BorderBrush = solidColorBrush;
						imageBorder.BorderThickness = new Thickness(imageBorderThickness);
					}
				}
				catch (Exception)
				{
					// couldn't convert border color, so just move on without any border.
				}
			}
		}

		/// <summary>
		/// Helper method to determine what navigational elements
		/// need to be setup and displayed.
		/// </summary>
		private void SetupNavication()
		{
			if (displayNumberedButtons)
				CreateNumberedButtons();

			if (!displayArrows)
			{
				arrowLeft.Visibility = Visibility.Collapsed;
				arrowRight.Visibility = Visibility.Collapsed;
			}

			if (!displayNumberedButtons && !displayArrows)
				navigationBorder.Visibility = Visibility.Collapsed;
		}

		/// <summary>
		/// Helper method to determine if auto play should be setup or not. 
		/// </summary>
		private void SetupAutoPlayTimer()
		{
			if (enableAutoPlay)
				StartAutoPlayTimer(this, null);
		}

		/// <summary>
		/// Opens new popup window with uri of the selected imagesToLoadCount
		/// redirect link.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void NewWindow_Click(object sender, RoutedEventArgs e)
		{
			string redirectLink = pictures.ElementAt(nextImageIndex).RedirectLink;

			string browserWindowOptions = this.browserWindowOptions;

            HtmlPage.Window.Navigate(new Uri(redirectLink), "_parent", browserWindowOptions);
		}

		/// <summary>
		/// Creates numbered buttons and wires up required events for interaction.
		/// </summary>
		private void CreateNumberedButtons()
		{
			for (int i = 1; i <= imageCount; i++)
			{
				TextBlock numberTextBlock = new TextBlock();
				numberTextBlock.FontWeight = FontWeights.Bold;
				numberTextBlock.Margin = new Thickness(2);
				numberTextBlock.Opacity = 1;
				numberTextBlock.Width = 15;
				numberTextBlock.VerticalAlignment = VerticalAlignment.Center;
				numberTextBlock.Text = i.ToString();
				numberTextBlock.Tag = i - 1;

				numberTextBlock.MouseLeftButtonDown += new MouseButtonEventHandler(Number_MouseLeftButtonDown);
				numberTextBlock.MouseEnter += new MouseEventHandler(Number_MouseEnter);
				numberTextBlock.MouseLeave += new MouseEventHandler(Number_MouseLeave);

				if (displayNumberedButtons == false)
					numberTextBlock.Visibility = Visibility.Collapsed;

				numberedItemsStackPanel.Children.Add(numberTextBlock);
			}
		}

		/// <summary>
		/// Contains change logic for when new image is selected.
		/// </summary>
		/// <param name="index"></param>
		private void SelectedPicture(int index)
		{
			if (displayNumberedButtons)
			{
				((TextBlock)numberedItemsStackPanel.Children.ElementAt(currentlyHighlightedIndex)).Opacity = 1;
				((TextBlock)numberedItemsStackPanel.Children.ElementAt(nextImageIndex)).Opacity = .5;
			}

			currentlyHighlightedIndex = nextImageIndex;

			autoPlayTimer.Stop();

			if (enableAnimations)
				FadeOut();
			else
				SwitchImage();
		}

		/// <summary>
		/// Contains logic to track next image to be displayed.
		/// </summary>
		/// <returns></returns>
		private int NextPictureImage()
		{
			nextImageIndex++;

			if (nextImageIndex == imageCount)
			{
				nextImageIndex = 0;
				return 0;
			}
			else
				return nextImageIndex;
		}

		/// <summary>
		/// Contains logic to track last image displayed.
		/// </summary>
		/// <returns></returns>
		private int LastPictureImage()
		{
			nextImageIndex--;

			if (nextImageIndex < 0)
			{
				nextImageIndex = imageCount - 1;
				return nextImageIndex;
			}
			else
				return nextImageIndex;
		}

		/// <summary>
		/// Contains logic to faid out current image.  
		/// </summary>
		private void FadeOut()
		{
			DoubleAnimation fadeOutDoubleAnimation = new DoubleAnimation();

			fadeOutDoubleAnimation.From = 1;
			fadeOutDoubleAnimation.To = 0;
			fadeOutDoubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(1));

			fadeOutStoryboard = new Storyboard();
			fadeOutStoryboard.Children.Add(fadeOutDoubleAnimation);
			fadeOutStoryboard.Completed += new EventHandler(FadeOutStoryboard_Completed);

			Storyboard.SetTarget(fadeOutDoubleAnimation, ((Image)imageStackPanel.Children.ElementAt(lastImageIndex)));

			Storyboard.SetTargetProperty(fadeOutDoubleAnimation, new PropertyPath(ListBox.OpacityProperty));

			layoutRoot.Resources.Add("fadeOutStoryboard", fadeOutStoryboard);

			fadeOutStoryboard.Begin();

			layoutRoot.Resources.Remove("fadeOutStoryboard");
		}

		/// <summary>
		/// Contains logic to faid in new image.  
		/// </summary>
		private void FadeIn()
		{
			DoubleAnimation fadeInDoubleAnimation = new DoubleAnimation();

			fadeInDoubleAnimation.From = 0;
			fadeInDoubleAnimation.To = 1;
			fadeInDoubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(1));

			fadeInStoryboard = new Storyboard();
			fadeInStoryboard.Children.Add(fadeInDoubleAnimation);

			Storyboard.SetTarget(fadeInDoubleAnimation, ((Image)imageStackPanel.Children.ElementAt(nextImageIndex)));

			Storyboard.SetTargetProperty(fadeInDoubleAnimation, new PropertyPath(ListBox.OpacityProperty));

			layoutRoot.Resources.Add("fadeInStoryboard", fadeInStoryboard);

			fadeInStoryboard.Begin();

			layoutRoot.Resources.Remove("fadeInStoryboard");
		}

		/// <summary>
		/// Contains logic to process image changing.
		/// </summary>
		private void SwitchImage()
		{
			((Image)imageStackPanel.Children.ElementAt(lastImageIndex)).Visibility = Visibility.Collapsed;
			((Image)imageStackPanel.Children.ElementAt(nextImageIndex)).Visibility = Visibility.Visible;

			lastImageIndex = nextImageIndex;

			if (enableAutoPlay && buttonsStopStartAutoPlay && leavePaused == false)
				autoPlayTimer.Start();
		}

		#endregion

		#region Event Handlers
		/// <summary>
		/// Sets up and starts autoplay timer.
		/// </summary>
		/// <param name="o"></param>
		/// <param name="sender"></param>
		public void StartAutoPlayTimer(object o, RoutedEventArgs sender)
		{
			if (numberedItemsStackPanel.Children.Count > 0)
				((TextBlock)numberedItemsStackPanel.Children.ElementAt(0)).Opacity = .5;

			autoPlayTimer.Interval = new TimeSpan(0, 0, 0, 0, autoPlayIntervalSeconds * 1000);
			autoPlayTimer.Tick += new EventHandler(AutoPlayTimerTicked);
			autoPlayTimer.Start();
		}

		/// <summary>
		/// Handles tick event for timer.  Selects next picture.
		/// </summary>
		/// <param name="o"></param>
		/// <param name="sender"></param>
		private void AutoPlayTimerTicked(object o, EventArgs sender)
		{
			SelectedPicture(NextPictureImage());
		}

		/// <summary>
		/// Handles storyboard animation completed event.  Fades in next image.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void FadeOutStoryboard_Completed(object sender, EventArgs e)
		{
			((Image)imageStackPanel.Children.ElementAt(lastImageIndex)).Visibility = Visibility.Collapsed;
			((Image)imageStackPanel.Children.ElementAt(nextImageIndex)).Visibility = Visibility.Visible;

			lastImageIndex = nextImageIndex;

			FadeIn();

			if ((enableAutoPlay || buttonsStopStartAutoPlay) && leavePaused == false)
				autoPlayTimer.Start();
		}

		/// <summary>
		/// Handles arrow buttons mouseenter event.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Arrow_MouseEnter(object sender, MouseEventArgs e)
		{
			((Polygon)sender).Opacity = .5;
		}

		/// <summary>
		/// Handles arrow buttons mouseleave event.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Arrow_MouseLeave(object sender, MouseEventArgs e)
		{
			((Polygon)sender).Opacity = 1;
		}

		/// <summary>
		/// Handles LeftArrow's MouseLeftButtonDown event.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void LeftArrow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			if (enableAutoPlay && buttonsStopStartAutoPlay)
				leavePaused = false;

			SelectedPicture(LastPictureImage());
		}

		/// <summary>
		/// Handles RightArrow's MouseLeftButtonDown event.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void RightArrow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			if (enableAutoPlay && buttonsStopStartAutoPlay)
				leavePaused = false;

			SelectedPicture(NextPictureImage());
		}

		/// <summary>
		/// Handles Number's MouseLeave event.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Number_MouseLeave(object sender, MouseEventArgs e)
		{
			if (nextImageIndex != Convert.ToInt32(((TextBlock)sender).Tag))
				((TextBlock)sender).Opacity = 1;
		}

		/// <summary>
		/// Handles Number's MouseEnter event.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Number_MouseEnter(object sender, MouseEventArgs e)
		{
			if (nextImageIndex != Convert.ToInt32(((TextBlock)sender).Tag))
				((TextBlock)sender).Opacity = .5;
		}

		/// <summary>
		/// Handles Numbers MouseLeftButtonDown event.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Number_MouseLeftButtonDown(object sender, RoutedEventArgs e)
		{
			if (enableAutoPlay && buttonsStopStartAutoPlay)
				leavePaused = true;

			nextImageIndex = Convert.ToInt32(((TextBlock)sender).Tag);
			SelectedPicture(nextImageIndex);
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets Image border adjusted width.
		/// </summary>
		public double UserControlWidth
		{
			get { return imageWidth + (2 * imageBorderThickness); }
		}

		/// <summary>
		/// Gets Image border adjusted height.
		/// </summary>
		public double UserControlHeight
		{
			get { return imageHeight + (2 * imageBorderThickness); }
		}

		#endregion
	}
}
