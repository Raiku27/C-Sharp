using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using Color = System.Drawing.Color;

namespace PersonalMapManager.window
{
	public partial class PolylineWindow : Window,INotifyPropertyChanged
	{
		//Variables Membres
		public event PropertyChangedEventHandler PropertyChanged;
		public string _couleur;
		public string _epaisseur;


		public PolylineWindow()
		{
			InitializeComponent();
			ListBoxCoordonnees.Items.Add("Debut");

			/*foreach(var colorValue in Enum.GetValues(typeof(KnownColor)))
			{
				Color color = Color.FromKnownColor((KnownColor)colorValue);

			}*/
		}

		

		private void ButtunOk_Click(object sender, RoutedEventArgs e)
		{
			ListBoxCoordonnees.Items.Add("ok");
		}

		private void ButtonAppliquer_Click(object sender, RoutedEventArgs e)
		{
			ListBoxCoordonnees.Items.Add("Appliquer");
		}

		private void ButtonAnnuler_Click(object sender, RoutedEventArgs e)
		{
			ListBoxCoordonnees.Items.Add("Annuler");
		}

		//Interfaces
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
