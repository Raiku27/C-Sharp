using MyCartographyObjects;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PersonalMapManager.window
{
	/// <summary>
	/// Interaction logic for PoiWindow.xaml
	/// </summary>
	public partial class PoiWindow : Window
	{
		public POI _poi;
		private POI temp;
		private POI debut;
		public PoiWindow()
		{
			InitializeComponent();
		}

		public POI Poi
		{
			set
			{
				_poi = value;
				debut = value;
			}
		}

		private void ButtunOk_Click(object sender, RoutedEventArgs e)
		{
			_poi = temp;
			Hide();
		}

		private void ButtonAppliquer_Click(object sender, RoutedEventArgs e)
		{
			string latitudeTemp = TextBoxLatitude.Text.Replace(',', '.');
			string longitudeTemp = TextBoxLongitude.Text.Replace(',', '.');
			double outLatitude;
			double outLongitude;
			if(temp == null)
			{
				temp = new POI();
			}
			double.TryParse(latitudeTemp, NumberStyles.Any, CultureInfo.InvariantCulture,out outLatitude);
			double.TryParse(longitudeTemp, NumberStyles.Any, CultureInfo.InvariantCulture,out outLongitude);
			temp.Latitude = outLatitude;
			temp.Longitude = outLongitude;
			temp.Description = TextBoxDescription.Text;
		}

		private void ButtonAnnuler_Click(object sender, RoutedEventArgs e)
		{
			temp = null;
		}
	}
}
