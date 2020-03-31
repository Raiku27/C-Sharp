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
		public POI _poi;
		private POI temp;
		private POI debut;

		public string _stringLatitude = "0,000";
		public string _stringLongitude = "0,000";
		public string _description = "";
		private bool hasAppliquerBeenClicked = false;
		public event PropertyChangedEventHandler PropertyChanged;

		//Constructeur
		public PoiWindow()
		{
			InitializeComponent();
			DataContext = this;
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
			Poi = null;
			Hide();
		}

		//Interfaces
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
