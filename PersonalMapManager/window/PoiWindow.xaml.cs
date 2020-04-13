using MyCartographyObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
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
	public partial class PoiWindow : Window,INotifyPropertyChanged
	{
		//Variables Membres
		public POI _poi = null;
		private POI temp = null;
		private POI debut = null;

		public string _stringLatitude = "0,000";
		public string _stringLongitude = "0,000";
		public string _description = "";
		private bool hasAppliquerBeenClicked = false;
		public event PropertyChangedEventHandler PropertyChanged;
		bool modifier = false;

		//Constructeur
		public PoiWindow()
		{
			InitializeComponent();
			DataContext = this;
		}
		public PoiWindow(POI newPoi)
		{
			InitializeComponent();
			DataContext = this;
			temp = newPoi;
			Poi = newPoi;
			Latitude = newPoi.Latitude.ToString();
			Longitude = newPoi.Longitude.ToString();
			Description = newPoi.Description;
			hasAppliquerBeenClicked = true;
			modifier = true;
		}

		//Propriétés
		public POI Poi
		{
			set
			{
				_poi = value;
				debut = value;
				OnPropertyChanged();
			}
			get
			{
				return _poi;
			}
		}
		public string Latitude
		{
			set
			{
				_stringLatitude = value;
				OnPropertyChanged();
			}
			get
			{
				return _stringLatitude;
			}
		}
		public string Longitude
		{
			set
			{
				_stringLongitude = value;
				OnPropertyChanged();
			}
			get
			{
				return _stringLongitude;
			}
		}
		public string Description
		{
			set
			{
				_description = value;
				OnPropertyChanged();
			}
			get
			{
				return _description;
			}
		}

		//Méthodes
		private void ButtunOk_Click(object sender, RoutedEventArgs e)
		{
			if(hasAppliquerBeenClicked)
			{
				_poi = temp;
				Hide();
			}
		}
		private void ButtonAppliquer_Click(object sender, RoutedEventArgs e)
		{
			double outLatitude;
			double outLongitude;
			hasAppliquerBeenClicked = true;
			if(temp == null)
			{
				temp = new POI();
			}
			double.TryParse(Latitude.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture,out outLatitude);
			double.TryParse(Longitude.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture,out outLongitude);
			temp.Latitude = outLatitude;
			temp.Longitude = outLongitude;
			temp.Description = Description;
		}
		private void ButtonAnnuler_Click(object sender, RoutedEventArgs e)
		{
			if(modifier)
			{
				Hide();
			}
			else
			{
				Poi = null;
				Hide();
			}
		}
		private void POIWindow_Closing(object sender, CancelEventArgs e)
		{
			if(!modifier)
			{
				Poi = null;
			}
			else
			{
				Hide();
			}
		}

		//Interfaces
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
