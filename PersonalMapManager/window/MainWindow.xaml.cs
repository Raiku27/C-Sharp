using MyCartographyObjects;
using PersonalMapManager.window;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Polygon = MyCartographyObjects.Polygon;
using Polyline = MyCartographyObjects.Polyline;

namespace PersonalMapManager
{
	public partial class MainWindow : Window
	{
		//Variables Membres
		public MyPersonalMapData myPersonalMapData = new MyPersonalMapData();
	
		//Constructeurs
		public MainWindow()
		{
			InitializeComponent();
			DataContext = this;
			myPersonalMapData.Load("Vincent","Gerard");
			//Charger la ListBox
			foreach (ICartoObj i in myPersonalMapData.ObservableCollection)
			{
				if (i is POI)
				{
					POI p = i as POI;
					ListBox.Items.Add("POI: " + p.Description);
				}
				if (i is Polyline)
				{
					Polyline p = i as Polyline;
					ListBox.Items.Add("Trajet: " + p.Description);
				}
				if (i is Polygon)
				{
					Polygon p = i as Polygon;
					ListBox.Items.Add("Surface: " + p.Description);
				}
			}
		}

		//Méthodes
		private void MainWindow_Closing(object sender, CancelEventArgs e)
		{

		}
		private void Open_Click(object sender, RoutedEventArgs e)
		{
			//Vider la ListBox
			ListBox.Items.Clear();

			if (myPersonalMapData.Load(myPersonalMapData.Prenom, myPersonalMapData.Nom))
			{
				MessageBox.Show("Erreur: myPersonalMapData.Load(prenom,nom)");
				this.Close();
			}
			//Charger la ListBox
			foreach(ICartoObj i in myPersonalMapData.ObservableCollection)
			{
				if(i is POI)
				{
					POI p = i as POI;
					ListBox.Items.Add("POI: " + p.Description);
				}
				if(i is Polyline)
				{
					Polyline p = i as Polyline;
					ListBox.Items.Add("Trajet: " + p.Description);
				}
				if(i is Polygon)
				{
					Polygon p = i as Polygon;
					ListBox.Items.Add("Surface: " + p.Description);
				}
			}
		}
		private void Save_Click(object sender, RoutedEventArgs e)
		{
			if (myPersonalMapData.Save())
			{
				MessageBox.Show("Erreur: myPersonalMapData.Save()");
				this.Close();
			}
		}
		private void POI_Import_Click(object sender, RoutedEventArgs e)
		{

		}
		private void POI_Export_Click(object sender, RoutedEventArgs e)
		{

		}
		private void Trajet_Import_Click(object sender, RoutedEventArgs e)
		{

		}
		private void Traject_Export_Click(object sender, RoutedEventArgs e)
		{

		}
		private void Exit_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}
		private void About_Click(object sender, RoutedEventArgs e)
		{
			AboutBox1 aboutBox = new AboutBox1();
			aboutBox.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			aboutBox.Show();
		}
		public void Créer_Click(object sender, RoutedEventArgs e)
		{
			if (ComboBoxChoixObjet.SelectedIndex == 1)
			{
				//POI
				PoiWindow poiWindow = new PoiWindow();
				poiWindow.Owner = this;
				poiWindow.ShowDialog();
				if(poiWindow.Poi != null)
				{
					myPersonalMapData.ObservableCollection.Add(poiWindow.Poi);
					ListBox.Items.Add("POI: " + poiWindow.Poi.Description);
				}
			}
			else if (ComboBoxChoixObjet.SelectedIndex == 2)
			{
				//Trajet
				PolylineWindow polylineWindow = new PolylineWindow();
				polylineWindow.Owner = this;
				polylineWindow.ShowDialog();
				if(polylineWindow.Polyline != null)
				{
					myPersonalMapData.ObservableCollection.Add(polylineWindow.Polyline);
					ListBox.Items.Add("Trajet: " + polylineWindow.Polyline.Description);
				}
			}
			else if (ComboBoxChoixObjet.SelectedIndex == 3)
			{
				//Surface
				PolygonWindow polygonWindow = new PolygonWindow();
				polygonWindow.Owner = this;
				polygonWindow.ShowDialog();
				if(polygonWindow.Polygon != null)
				{
					myPersonalMapData.ObservableCollection.Add(polygonWindow.Polygon);
					ListBox.Items.Add("Surface: " + polygonWindow.Polygon.Description);
				}
			}
		}
		private void Modifier_Click(object sender, RoutedEventArgs e)
		{

		}
		private void Supprimer_Click(object sender, RoutedEventArgs e)
		{
			if(ListBox.Items.Count != 0)
			{
				int position = ListBox.SelectedIndex;
				ICartoObj temp = myPersonalMapData.ObservableCollection.ElementAt(position);
				if(temp == null)
				{
					return;
				}
				else
				{
					myPersonalMapData.ObservableCollection.RemoveAt(position);
					ListBox.Items.RemoveAt(position);
					ListBox.SelectedIndex = ListBox.Items.Count - 1;
				}
			}
		}
    }
}
