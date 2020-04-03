using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
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
	public partial class PolygonWindow : Window,INotifyPropertyChanged
	{
		//Variables Membres
		public Polygon _polygon;
		private Polygon _temp = new Polygon();
		private double _opacite;
		private string _stringOpacite;
		private string _remplissage;
		private string _contour;
		private string _latitude;
		private string _longitude;
		private bool hasAppliquerBeenClicked = false;
		public event PropertyChangedEventHandler PropertyChanged;

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
		private void ButtonAnnuler_Click(object sender, RoutedEventArgs e)
		{

		}
		private void ButtonAppliquer_Click(object sender, RoutedEventArgs e)
		{

		}
		private void ButtunOk_Click(object sender, RoutedEventArgs e)
		{

		}
		private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{

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
