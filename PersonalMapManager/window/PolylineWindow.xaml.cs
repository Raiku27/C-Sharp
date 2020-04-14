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
using Polyline = MyCartographyObjects.Polyline;

namespace PersonalMapManager.window
{
	public partial class PolylineWindow : Window,INotifyPropertyChanged
	{
		//Variables Membres
		public event PropertyChangedEventHandler PropertyChanged;
		private Polyline _polyline;
		private Polyline _temp = new Polyline();
		private bool hasAppliquerBeenClicked = false;
		private string _stringLatitude;
		private string _stringLongitude;
		public string _couleur;
		public string _epaisseur;
		public string _description;
		public string _descriptionCoordonnees;
		private bool modifier = false;

		//Constructeur
		public PolylineWindow()
		{
			InitializeComponent();
			DataContext = this;

			foreach (PropertyInfo property in typeof(System.Drawing.Color).GetProperties(BindingFlags.Static | BindingFlags.Public))
				if (property.PropertyType == typeof(System.Drawing.Color))
					ComboBoxColors.Items.Add(property.Name);
			//Ajouteur les couleurs dans la combobox
			Latitude = "0,000";
			Longitude = "0,000";
			Couleur = "Black";
			Epaisseur = "1";
			Description = "";
			DescriptionCoordonnees = "";
		}

		public PolylineWindow(Polyline newPolyline)
		{
			InitializeComponent();
			DataContext = this;
			foreach (PropertyInfo property in typeof(System.Drawing.Color).GetProperties(BindingFlags.Static | BindingFlags.Public))
				if (property.PropertyType == typeof(System.Drawing.Color))
					ComboBoxColors.Items.Add(property.Name);
			//Ajouteur les couleurs dans la combobox
			_temp = newPolyline;
			Latitude = "0,000";
			Longitude = "0,000";
			Couleur = MainWindow.GetColorName(newPolyline.Color);
			Epaisseur = newPolyline.Epaisseur.ToString();
			Description = newPolyline.Description;
			DescriptionCoordonnees = "";
			foreach (Coordonnees c in newPolyline.Collection)
			{
				ListBoxCoordonnees.Items.Add(c.ToString());
			}
			hasAppliquerBeenClicked = true;
			modifier = true;
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
		public string DescriptionCoordonnees
		{
			set
			{
				_descriptionCoordonnees = value;
				OnPropertyChanged();
			}
			get
			{
				return _descriptionCoordonnees;
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
		public List<Coordonnees> Collection
		{
			set
			{
				if(_temp.Collection == null)
				{
					_temp.Collection = new List<Coordonnees> { };
				}
				foreach (Coordonnees coords in value)
				{
					if(coords is Coordonnees)
					{
						_temp.Collection.Add(coords);
						ListBoxCoordonnees.Items.Add(coords.ToString());
					}
					else if(coords is POI)
					{
						_temp.Collection.Add((POI)coords);
						ListBoxCoordonnees.Items.Add(new POI(((POI)coords).Description, new Coordonnees(((POI)coords).Latitude, ((POI)coords).Longitude)).ToString());
					}
					ListBoxCoordonnees.SelectedIndex = ListBoxCoordonnees.Items.Count - 1;
				}
			}
		}

		
		//Méthodes
		private void ButtonAjouter_Click(object sender, RoutedEventArgs e)
		{
			//Ajouter une Coordonnee ou POI
			if(DescriptionCoordonnees.Length == 0)
			{
				double outLatitude;
				double outLongitude;
				double.TryParse(Latitude.Replace(",", "."), NumberStyles.Any, CultureInfo.InvariantCulture, out outLatitude);
				double.TryParse(Longitude.Replace(",", "."), NumberStyles.Any, CultureInfo.InvariantCulture, out outLongitude);
				_temp.Collection.Add(new Coordonnees(outLatitude,outLongitude));
				ListBoxCoordonnees.Items.Add(new Coordonnees(outLatitude, outLongitude).ToString());
				ListBoxCoordonnees.SelectedIndex = ListBoxCoordonnees.Items.Count - 1;
			}
			else
			{
				double outLatitude;
				double outLongitude;
				double.TryParse(Latitude.Replace(",", "."), NumberStyles.Any, CultureInfo.InvariantCulture, out outLatitude);
				double.TryParse(Longitude.Replace(",", "."), NumberStyles.Any, CultureInfo.InvariantCulture, out outLongitude);
				_temp.Collection.Add(new POI(DescriptionCoordonnees,new Coordonnees(outLatitude,outLongitude)));
				ListBoxCoordonnees.Items.Add(new POI(DescriptionCoordonnees, new Coordonnees(outLatitude, outLongitude)).ToString());
				ListBoxCoordonnees.SelectedIndex = ListBoxCoordonnees.Items.Count - 1;
			}
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
				_polyline.Collection = _temp.Collection;
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
			_temp.Description = Description;
			hasAppliquerBeenClicked = true;
		}
		private void ButtonAnnuler_Click(object sender, RoutedEventArgs e)
		{
			if(modifier)
			{
				Polyline = _temp;
				Hide();
			}
			else
			{
				Polyline = null;
				Hide();
			}
		}
		private void Window_Closing(object sender, CancelEventArgs e)
		{
			if(modifier)
			{
				Polyline = _temp;
			}
			else
			{
				Polyline = null;
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
