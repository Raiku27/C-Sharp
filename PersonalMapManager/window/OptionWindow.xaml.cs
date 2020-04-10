using MyCartographyObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
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
	public partial class OptionWindow : Window,INotifyPropertyChanged
	{
		private string _couleur;

		public event PropertyChangedEventHandler PropertyChanged;

		public OptionWindow()
		{
			InitializeComponent();
			DataContext = this;
			foreach (PropertyInfo property in typeof(System.Drawing.Color).GetProperties(BindingFlags.Static | BindingFlags.Public))
			{
				if (property.PropertyType == typeof(System.Drawing.Color))
				{
					ComboBoxCouleur.Items.Add(property.Name);
				}
			}
			Couleur = "White";
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



		private void Parcourir_Click(object sender, RoutedEventArgs e)
        {
			//Ouvrir un popup et choisir le chemin
        }

		private void OK_Click(object sender, RoutedEventArgs e)
		{
			SolidColorBrush temp = (SolidColorBrush)new BrushConverter().ConvertFromString(Couleur);
			((MainWindow)Owner).ListBox.Background = temp;
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
