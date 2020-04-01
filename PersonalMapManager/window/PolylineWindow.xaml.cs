using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
		public MyCartographyObjects.Polyline _polyline = null;
		public MyCartographyObjects.Polyline _temp = null;
		public MyCartographyObjects.Polyline _debut = null;
		private bool hasAppliquerBeenClicked = false;
		public string _couleur = "";
		public string _epaisseur = "1";


		//Constructeur
		public PolylineWindow()
		{
			InitializeComponent();
			DataContext = this;

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
				_debut = value;
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

		private void ButtonRetirer_Click(object sender, RoutedEventArgs e)
		{
			ListBoxCoordonnees.Items.Add("Retirer");
		}
		private void ButtonAjouter_Click(object sender, RoutedEventArgs e)
		{
			ListBoxCoordonnees.Items.Add("Ajouter");
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
			_temp.Collection = new List<Coordonnees> { };
			//Ajouter le contenu de la collection
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
