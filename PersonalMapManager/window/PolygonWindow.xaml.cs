using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
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
using MyCartographyObjects;
using Polygon = MyCartographyObjects.Polygon;

namespace PersonalMapManager.window
{
	public partial class PolygonWindow : Window,INotifyPropertyChanged
	{
		//Variables Membres
		public Polygon _polygon;
		public Polygon _temp = new Polygon();
		private double _opacite;
		private string _stringOpacite;
		private string _remplissage;
		private string _contour;
		private string _latitude;
		private string _longitude;
		private string _description;
		private bool hasAppliquerBeenClicked = false;
		public event PropertyChangedEventHandler PropertyChanged;
		private bool modifier = false;

		//Constructeur
		public PolygonWindow()
		{
			InitializeComponent();
			DataContext = this;
			foreach (PropertyInfo property in typeof(System.Drawing.Color).GetProperties(BindingFlags.Static | BindingFlags.Public))
			{
				if (property.PropertyType == typeof(System.Drawing.Color))
				{
					ComboBoxContour.Items.Add(property.Name);
					ComboBoxRemplissage.Items.Add(property.Name);
				}
			}
			Remplissage = "Blue";
			Contour = "Black";
			StringOpacite = "1";
			Latitude = "0,000";
			Longitude = "0,000";
			Description = "";
			ListBoxCoordonnees.SelectedIndex = 0;
		}

		public PolygonWindow(Polygon newPolygon)
		{
			InitializeComponent();
			DataContext = this;
			foreach (PropertyInfo property in typeof(System.Drawing.Color).GetProperties(BindingFlags.Static | BindingFlags.Public))
			{
				if (property.PropertyType == typeof(System.Drawing.Color))
				{
					ComboBoxContour.Items.Add(property.Name);
					ComboBoxRemplissage.Items.Add(property.Name);
				}
			}
			_temp = newPolygon;
			Remplissage = MainWindow.GetColorName(newPolygon.RemplissageColor);
			Contour = MainWindow.GetColorName(newPolygon.ContourColor);
			StringOpacite = newPolygon.Opacite.ToString();
			Latitude = "0,000";
			Longitude = "0,000";
			Description = newPolygon.Description;
			foreach (Coordonnees c in newPolygon.Collection)
			{
				ListBoxCoordonnees.Items.Add(c.ToString());
			}
			hasAppliquerBeenClicked = true;
			modifier = true;
			ListBoxCoordonnees.SelectedIndex = 0;
		}


		//Propriétés
		public Polygon Polygon
		{
			set
			{
				_polygon = value;
				OnPropertyChanged();
			}
			get
			{
				return _polygon;
			}
		}
		public string Remplissage
		{
			set
			{
				_remplissage = value;
				OnPropertyChanged();
			}
			get
			{
				return _remplissage;
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
		public string Contour
		{
			set
			{
				_contour = value;
				OnPropertyChanged();
			}
			get
			{
				return _contour;
			}
		}
		public double Opacite
		{
			set
			{
				_opacite = value;
				if(!Opacite.Equals(double.Parse(StringOpacite)))
				{
					StringOpacite = Math.Round(value, 1).ToString();
				}
				OnPropertyChanged();
			}
			get
			{
				return _opacite;
			}
		}
		public string StringOpacite
		{
			set
			{
				_stringOpacite = value;
				Opacite = double.Parse(value);
				OnPropertyChanged();
			}
			get
			{
				return _stringOpacite;
			}
		}
		

		public string Latitude
		{
			set
			{
				_latitude = value;
				OnPropertyChanged();
			}
			get
			{
				return _latitude;
			}
		}
		public string Longitude
		{
			set
			{
				_longitude = value;
				OnPropertyChanged();
			}
			get
			{
				return _longitude;
			}
		}
		//Méthodes
		private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (!modifier)
			{
				_polygon = null;
			}
			else
			{
				Polygon = _temp;
			}
		}
		private void ButtonAjouter_Click(object sender, RoutedEventArgs e)
		{
			double outLatitude;
			double outLongitude;
			double.TryParse(Latitude.Replace(",", "."), NumberStyles.Any, CultureInfo.InvariantCulture, out outLatitude);
			double.TryParse(Longitude.Replace(",", "."), NumberStyles.Any, CultureInfo.InvariantCulture, out outLongitude);
			_temp.Collection.Add(new Coordonnees(outLatitude, outLongitude));
			ListBoxCoordonnees.Items.Add(new Coordonnees(outLatitude, outLongitude).ToString());
			ListBoxCoordonnees.SelectedIndex = ListBoxCoordonnees.Items.Count - 1;
		}
		private void ButtonRetirer_Click(object sender, RoutedEventArgs e)
		{
			if (ListBoxCoordonnees.Items.Count != 0)
			{
				int numeroIndex = ListBoxCoordonnees.SelectedIndex;
				Coordonnees coords = _temp.Collection[numeroIndex];
				_temp.Collection.Remove(coords);
				ListBoxCoordonnees.Items.RemoveAt(numeroIndex);
				ListBoxCoordonnees.SelectedIndex = ListBoxCoordonnees.Items.Count - 1;
			}
		}
		private void ButtonAnnuler_Click(object sender, RoutedEventArgs e)
		{
			if(modifier)
			{
				Polygon = _temp;
				Hide();
			}
			else
			{
				Polygon = null;
				Hide();
			}
		}
		private void ButtonAppliquer_Click(object sender, RoutedEventArgs e)
		{
			if (_temp == null)
			{
				_temp = new MyCartographyObjects.Polygon();
			}
			_temp.ContourColor = (Color)ColorConverter.ConvertFromString(Contour);
			_temp.RemplissageColor = (Color)ColorConverter.ConvertFromString(Remplissage);
			_temp.Opacite = Opacite;
			_temp.Description = Description;
			hasAppliquerBeenClicked = true;
		}
		private void ButtunOk_Click(object sender, RoutedEventArgs e)
		{
			if (hasAppliquerBeenClicked)
			{
				_polygon = _temp;
				Hide();
			}
		}
		//Interfaces
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null)
				handler(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
