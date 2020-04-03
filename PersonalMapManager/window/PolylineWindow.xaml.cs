using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
using MyCartographyObjects;
using Color = System.Windows.Media.Color;
using ColorConverter = System.Windows.Media.ColorConverter;

namespace PersonalMapManager.window
{
	public partial class PolylineWindow : Window,INotifyPropertyChanged
	{
		//Variables Membres
		public event PropertyChangedEventHandler PropertyChanged;
		public MyCartographyObjects.Polyline _polyline;
		private MyCartographyObjects.Polyline _temp = new MyCartographyObjects.Polyline();
		private bool hasAppliquerBeenClicked = false;
		private string _stringLatitude;
		private string _stringLongitude;
		public string _couleur = "";
		public string _epaisseur = "1";

		//Constructeur
		public PolylineWindow()
		{
			InitializeComponent();
			DataContext = this;
			Latitude = "0,000";
			Longitude = "0,000";

			foreach (PropertyInfo property in typeof(System.Drawing.Color).GetProperties(BindingFlags.Static | BindingFlags.Public))
				if (property.PropertyType == typeof(System.Drawing.Color))
					ComboBoxColors.Items.Add(property.Name);
			//Ajouteur les couleurs dans la combobox
			Couleur = "Black";
		}

		//Propriétés
		public MyCartographyObjects.Polyline Polyline
		{
			set
			{
				_polyline = value;
				OnPropertyChanged();
			}
			get
			{
				return _polyline;
			}
		}
		public string Couleur
		{
			set
			{
				_couleur = value;
				OnPropertyChanged();
			}
			get
			{
				return _couleur;
			}
		}
		public string Epaisseur
		{
			set
			{
				_epaisseur = value;
				OnPropertyChanged();
			}
			get
			{
				return _epaisseur;
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

		//Méthodes
		private void ButtonAjouter_Click(object sender, RoutedEventArgs e)
		{
			double outLatitude;
			double outLongitude;
			double.TryParse(Latitude.Replace(",", "."), NumberStyles.Any, CultureInfo.InvariantCulture, out outLatitude);
			double.TryParse(Longitude.Replace(",", "."), NumberStyles.Any, CultureInfo.InvariantCulture, out outLongitude);
			_temp.Collection.Add(new Coordonnees(outLatitude,outLongitude));
			ListBoxCoordonnees.Items.Add(new Coordonnees(outLatitude, outLongitude).ToString());
			ListBoxCoordonnees.SelectedIndex = ListBoxCoordonnees.Items.Count - 1;
		}
		private void ButtonRetirer_Click(object sender, RoutedEventArgs e)
		{
			if(ListBoxCoordonnees.Items.Count != 0)
			{ 
				int numeroIndex = ListBoxCoordonnees.SelectedIndex;
				Coordonnees coords = _temp.Collection[numeroIndex];
				_temp.Collection.Remove(coords);
				ListBoxCoordonnees.Items.RemoveAt(numeroIndex);
				ListBoxCoordonnees.SelectedIndex = ListBoxCoordonnees.Items.Count - 1;
			}
		}
		private void ButtunOk_Click(object sender, RoutedEventArgs e)
		{
			if(hasAppliquerBeenClicked)
			{
				_polyline = _temp;
				Hide();
			}
		}
		private void ButtonAppliquer_Click(object sender, RoutedEventArgs e)
		{
			if(_temp == null)
			{
				_temp = new MyCartographyObjects.Polyline();
			}
			_temp.Color = (Color)ColorConverter.ConvertFromString(Couleur);
			_temp.Epaisseur = int.Parse(Epaisseur);
			hasAppliquerBeenClicked = true;
		}
		private void ButtonAnnuler_Click(object sender, RoutedEventArgs e)
		{
			Polyline = null;
			Hide();
		}
		private void Window_Closing(object sender, CancelEventArgs e)
		{
			Polyline = null;
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
