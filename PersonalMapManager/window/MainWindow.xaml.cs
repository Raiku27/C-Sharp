using Microsoft.Maps.MapControl.WPF;
using MyCartographyObjects;
using PersonalMapManager.window;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Excel = Microsoft.Office.Interop.Excel;
using MessageBox = System.Windows.MessageBox;
using Polygon = MyCartographyObjects.Polygon;
using Polyline = MyCartographyObjects.Polyline;

namespace PersonalMapManager
{
	public partial class MainWindow : Window
	{
		//Variables Membres
		public MyPersonalMapData myPersonalMapData;
		public static string path = "C:\\Users\\Vincent\\OneDrive - Enseignement de la Province de Liège\\Cours\\B2\\C#\\MyCartographyObjects\\data\\";
	
		//Constructeurs
		public MainWindow()
		{
			InitializeComponent();
			DataContext = this;
			Map.Center = new Location(50.620090, 5.581406);
			LoginWindow loginWindow = new LoginWindow();
			Focusable = false;
			this.Show();
			loginWindow.Owner = this;
			loginWindow.ShowDialog();
			if (myPersonalMapData == null)
			{
				Close();
			}
			else
			{
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
			ListBox.SelectedIndex = 0;
		}

		//Méthodes
		private void MainWindow_Closing(object sender, CancelEventArgs e)
		{

		}
		private void Open_Click(object sender, RoutedEventArgs e)
		{
			//Vider la ListBox
			ListBox.Items.Clear();

			LoginWindow loginWindow = new LoginWindow();
			loginWindow.Owner = this;
			loginWindow.ShowDialog();
			//Charger la ListBox
			foreach (ICartoObj i in myPersonalMapData.ObservableCollection)
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
			Microsoft.Win32.OpenFileDialog openFileDlg = new Microsoft.Win32.OpenFileDialog();
			openFileDlg.DefaultExt = ".csv";
			openFileDlg.Filter = "csv document (.csv)|*.csv";
			openFileDlg.ShowDialog();
			POI newPOI = new POI();
			string[] lines = File.ReadAllLines(openFileDlg.FileName);
			if(lines.Length > 3)
			{
				//Erreur on essaye d'importer un Trajet
				MessageBox.Show("Erreur,impossible d'ajouter un traject comme POI!");
				return;
			}
			for(int i = 0; i < lines.Length; i++)
			{
				string s = lines[i];
				string[] lines2 = s.Split(';');
				newPOI.Latitude = double.Parse(lines2[0]);
				newPOI.Longitude = double.Parse(lines2[1]);
				newPOI.Description = lines2[2];
			}
			myPersonalMapData.ObservableCollection.Add(newPOI);
			ListBox.Items.Add(newPOI);
			ListBox.SelectedIndex = 0;
		}
		private void POI_Export_Click(object sender, RoutedEventArgs e)
		{
			if(myPersonalMapData.ObservableCollection.Count != 0)
			{
				ICartoObj i = myPersonalMapData.ObservableCollection[ListBox.SelectedIndex];
				if (i is POI)
				{
					POI poi = i as POI;
					string filename = poi.Description + ".csv";

					Stream fStream = new FileStream(path + filename, FileMode.Create, FileAccess.Write, FileShare.None);
					fStream.Close();
					string text = poi.Latitude.ToString() + ";" + poi.Longitude.ToString() + ";" + poi.Description;
					File.WriteAllText(path + filename, text);

					ListBox.SelectedIndex = 0;
				}
			}
		}
		private void Trajet_Import_Click(object sender, RoutedEventArgs e)
		{
	
		}
		private void Traject_Export_Click(object sender, RoutedEventArgs e)
		{
			if (myPersonalMapData.ObservableCollection.Count != 0)
			{
				ICartoObj i = myPersonalMapData.ObservableCollection[ListBox.SelectedIndex];
				if (i is Polyline)
				{
					Polyline polyline = i as Polyline;
					string filename = polyline.Description + ".csv";

					Stream fStream = new FileStream(path + filename, FileMode.Create, FileAccess.Write, FileShare.None);
					fStream.Close();
					List<string> text = new List<string> { };
					foreach (Coordonnees coords in polyline.Collection)
					{
						if(polyline.Collection.ElementAt(0) == coords)
						{
							text.Add(coords.Latitude.ToString() + ";" + coords.Longitude.ToString() + ";" + polyline.Description);
						}
						else
						{
							text.Add(coords.Latitude.ToString() + ";" + coords.Longitude.ToString());
						}
					}
					File.WriteAllLines(path + filename, text);
					ListBox.SelectedIndex = 0;
				}
			}
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
				poiWindow.Close();
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
				polylineWindow.Close();
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
				polygonWindow.Close();
			}
			ListBox.SelectedIndex = 0;
		}
		private void Modifier_Click(object sender, RoutedEventArgs e)
		{
			if(myPersonalMapData.ObservableCollection.Count == 0)
			{
				return;
			}
			int position = ListBox.SelectedIndex;

			ICartoObj i = myPersonalMapData.ObservableCollection.ElementAt(position);

			if(i is POI)
			{
				POI p = i as POI;
				PoiWindow poiWindow = new PoiWindow(p);
				poiWindow.ShowDialog();
				myPersonalMapData.ObservableCollection[position] = poiWindow.Poi;
				if(poiWindow.IsActive)
				{
					ListBox.Items[position] = "POI: " + poiWindow.Poi.Description;
					poiWindow.Close();
				}	
			}
			if (i is Polyline)
			{
				Polyline p = i as Polyline;
				PolylineWindow polylineWindow = new PolylineWindow(p);
				polylineWindow.ShowDialog();
				myPersonalMapData.ObservableCollection[position] = polylineWindow.Polyline;
				if(polylineWindow.IsActive)
				{
					ListBox.Items[position] = "Trajet: " + polylineWindow.Polyline.Description;
					polylineWindow.Close();
				}
			}
			if(i is Polygon)
			{
				Polygon p = i as Polygon;
				PolygonWindow polygonWindow = new PolygonWindow(p);
				polygonWindow.ShowDialog();
				myPersonalMapData.ObservableCollection[position] = polygonWindow.Polygon;
				if(polygonWindow.IsActive)
				{
					ListBox.Items[position] = "Surface: " + polygonWindow.Polygon.Description;
					polygonWindow.Close();
				}
			}
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
		public static string GetColorName(Color col)
		{
			PropertyInfo colorProperty = typeof(Colors).GetProperties()
				.FirstOrDefault(p => Color.AreClose((Color)p.GetValue(null), col));
			return colorProperty != null ? colorProperty.Name : "Black";
		}
	}
}
