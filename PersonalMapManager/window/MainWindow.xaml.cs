using Microsoft.Maps.MapControl.WPF;
using MyCartographyObjects;
using PersonalMapManager.window;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Runtime.CompilerServices;
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
using KeyEventArgs = System.Windows.Input.KeyEventArgs;
using KeyEventHandler = System.Windows.Input.KeyEventHandler;
using MessageBox = System.Windows.MessageBox;
using MouseEventArgs = System.Windows.Input.MouseEventArgs;
using Polygon = MyCartographyObjects.Polygon;
using Polyline = MyCartographyObjects.Polyline;

namespace PersonalMapManager
{
	public partial class MainWindow : Window
	{
		//Variables Membres
		public MyPersonalMapData myPersonalMapData;
		private OptionWindow _optionWindow;
	
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
				System.Environment.Exit(1);
			}
			UpdateMainWindow();
			Map.MouseDoubleClick += new MouseButtonEventHandler(Map_DoubleClick);
			Map.MouseRightButtonDown += new MouseButtonEventHandler(Map_RightButtonDown);
			Map.KeyDown += new KeyEventHandler(Map_KeyDown);
		}

		private MouseButtonEventHandler Map_DoubleClick()
		{
			throw new NotImplementedException();
		}

		//Méthodes
		private void MainWindow_Closing(object sender, CancelEventArgs e)
		{

		}
		private void Open_Click(object sender, RoutedEventArgs e)
		{
			LoginWindow loginWindow = new LoginWindow();
			loginWindow.Owner = this;
			loginWindow.ShowDialog();
			UpdateMainWindow();
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
			Console.WriteLine(lines.Length);
			if(lines.Length > 1)
			{
				//Erreur on essaye d'importer un Trajet
				MessageBox.Show("Erreur,impossible d'ajouter un traject comme POI!");
				return;
			}

			string s = lines[0];
			string[] lines2 = s.Split(';');
			newPOI.Latitude = double.Parse(lines2[0]);
			newPOI.Longitude = double.Parse(lines2[1]);
			newPOI.Description = lines2[2];
			
			myPersonalMapData.ObservableCollection.Add(newPOI);
			UpdateMainWindow();
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

					Stream fStream = new FileStream(myPersonalMapData.Path + "\\" + filename, FileMode.Create, FileAccess.Write, FileShare.None);
					fStream.Close();
					string text = poi.Latitude.ToString() + ";" + poi.Longitude.ToString() + ";" + poi.Description;
					File.WriteAllText(myPersonalMapData.Path + "\\" + filename, text);

					ListBox.SelectedIndex = 0;
				}
			}
		}
		private void Trajet_Import_Click(object sender, RoutedEventArgs e)
		{
			Microsoft.Win32.OpenFileDialog openFileDlg = new Microsoft.Win32.OpenFileDialog();
			openFileDlg.DefaultExt = ".csv";
			openFileDlg.Filter = "csv document (.csv)|*.csv";
			openFileDlg.ShowDialog();
			Polyline newPolyline = new Polyline();
			string[] lines = File.ReadAllLines(openFileDlg.FileName);
			Console.WriteLine(lines.Length);
			if (lines.Length < 2)
			{
				//Erreur on essaye d'importer un POI
				MessageBox.Show("Erreur,impossible d'ajouter un POI comme trajet!");
				return;
			}

			for(int i = 0; i < lines.Length; i++)
			{
				string[] lines2 = lines[i].Split(';');
				newPolyline.Collection.Add(new Coordonnees(double.Parse(lines2[0]), double.Parse(lines2[1])));
				newPolyline.Description = lines2[2];
			}

			myPersonalMapData.ObservableCollection.Add(newPolyline);
			ListBox.Items.Add("Trajet: " + newPolyline.Description);

			UpdateMainWindow();
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

					Stream fStream = new FileStream(myPersonalMapData.Path + "\\" + filename, FileMode.Create, FileAccess.Write, FileShare.None);
					fStream.Close();
					List<string> text = new List<string> { };
					foreach (Coordonnees coords in polyline.Collection)
					{
						if(coords is POI)
						{
						
						}
						if(polyline.Collection.ElementAt(0) == coords)
						{
							text.Add(coords.Latitude.ToString() + ";" + coords.Longitude.ToString() + ";" + polyline.Description);
						}
						else
						{
							text.Add(coords.Latitude.ToString() + ";" + coords.Longitude.ToString());
						}
					}
					File.WriteAllLines(myPersonalMapData.Path + "\\" + filename, text);
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
				PoiWindow poiWindow = new PoiWindow();
				poiWindow.Owner = this;
				poiWindow.ShowDialog();
				if(poiWindow.Poi != null)
				{
					myPersonalMapData.ObservableCollection.Add(poiWindow.Poi);
					UpdateMainWindow();
				}
				poiWindow.Close();
			}
			else if (ComboBoxChoixObjet.SelectedIndex == 2)
			{
				PolylineWindow polylineWindow = new PolylineWindow();
				polylineWindow.Owner = this;
				polylineWindow.ShowDialog();
				if(polylineWindow.Polyline != null)
				{
					myPersonalMapData.ObservableCollection.Add(polylineWindow.Polyline);
					UpdateMainWindow();
				}
				polylineWindow.Close();
			}
			else if (ComboBoxChoixObjet.SelectedIndex == 3)
			{
				PolygonWindow polygonWindow = new PolygonWindow();
				polygonWindow.Owner = this;
				polygonWindow.ShowDialog();
				if(polygonWindow.Polygon != null)
				{
					myPersonalMapData.ObservableCollection.Add(polygonWindow.Polygon);
					UpdateMainWindow();
				}
				polygonWindow.Close();
			}
			ListBox.SelectedIndex = 0;
		}
		private void Modifier_Click(object sender, RoutedEventArgs e)
		{
			if (myPersonalMapData.ObservableCollection.Count == 0)
			{
				return;
			}
			int position = ListBox.SelectedIndex;

			ICartoObj i = myPersonalMapData.ObservableCollection.ElementAt(position);

			if (i is POI)
			{
				POI p = i as POI;
				PoiWindow poiWindow = new PoiWindow(p);
				poiWindow.ShowDialog();
				myPersonalMapData.ObservableCollection[position] = poiWindow.Poi;
				ListBox.SelectedIndex = position;
				poiWindow.Close();
			}
			if (i is Polyline)
			{
				Polyline p = i as Polyline;
				PolylineWindow polylineWindow = new PolylineWindow(p);
				polylineWindow.ShowDialog();
				myPersonalMapData.ObservableCollection[position] = polylineWindow.Polyline;
				ListBox.SelectedIndex = position;
				polylineWindow.Close();
			}
			if (i is Polygon)
			{
				Polygon p = i as Polygon;
				PolygonWindow polygonWindow = new PolygonWindow(p);
				polygonWindow.ShowDialog();
				myPersonalMapData.ObservableCollection[position] = polygonWindow.Polygon;
				ListBox.SelectedIndex = position;
				polygonWindow.Close();
			}
			UpdateMainWindow();
		}
		private void Supprimer_Click(object sender, RoutedEventArgs e)
		{
			if(myPersonalMapData.ObservableCollection.Count != 0)
			{
				myPersonalMapData.ObservableCollection.RemoveAt(ListBox.SelectedIndex);
				ListBox.Items.RemoveAt(ListBox.SelectedIndex);
				UpdateMainWindow();	
			}		
		}
		public static string GetColorName(Color col)
		{
			PropertyInfo colorProperty = typeof(Colors).GetProperties()
				.FirstOrDefault(p => Color.AreClose((Color)p.GetValue(null), col));
			return colorProperty != null ? colorProperty.Name : "Black";
		}
		public static string GetBrushName(SolidColorBrush brush)
		{
			var results = typeof(Colors).GetProperties().Where(
			 p => (Color)p.GetValue(null, null) == brush.Color).Select(p => p.Name);
			return results.Count() > 0 ? results.First() : "Black";
		}

		private void Options_Click(object sender, RoutedEventArgs e)
		{
			if(_optionWindow == null)
			{
				_optionWindow = new OptionWindow(this);
				_optionWindow.Show();
				_optionWindow.UpdateGUI += OnUpdateGUI;
				Focusable = true;
			}
			else
			{
				if(!_optionWindow.IsLoaded)
				{
					_optionWindow = new OptionWindow(this);
					_optionWindow.Show();
					_optionWindow.UpdateGUI += OnUpdateGUI;
					Focusable = true;
				}
			}
		}
		
		public void OnUpdateGUI(object source, UpdateGUIEventArgs e)
		{
			ListBox.Background = (Brush)new BrushConverter().ConvertFromString(e.Background);
			ListBox.Foreground = (Brush)new BrushConverter().ConvertFromString(e.Foreground);
		}
		public void UpdateMainWindow()
		{
			if(myPersonalMapData != null)
			{
				Map.Children.Clear();
				ListBox.Items.Clear();
				foreach (ICartoObj i in myPersonalMapData.ObservableCollection)
				{
					if (i is POI)
					{
						POI p = i as POI;
						Pushpin pushpin = new Pushpin();
						pushpin.Opacity = 0.7;
						pushpin.Location = new Location(p.Latitude, p.Longitude);
						ListBox.Items.Add("POI: " + p.Description);
						pushpin.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Blue);
						Map.Children.Add(pushpin);
					}
					if (i is Polyline)
					{
						Polyline p = i as Polyline;
						MapPolyline mapPolyline = new MapPolyline();
						mapPolyline.Opacity = 0.7;
						mapPolyline.StrokeThickness = p.Epaisseur;
						ListBox.Items.Add("Trajet: " + p.Description);
						mapPolyline.Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Black);
						mapPolyline.Locations = new LocationCollection();
						foreach (object obj in p.Collection)
						{
							if(obj is POI)
							{
								POI poi = obj as POI;
								Pushpin pushpin = new Pushpin();
								pushpin.Opacity = 0.7;
								pushpin.Location = new Location(poi.Latitude, poi.Longitude);
								pushpin.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Blue);
								Map.Children.Add(pushpin);
							}
							mapPolyline.Locations.Add(new Location(((Coordonnees)obj).Latitude, ((Coordonnees)obj).Longitude));
						}
						Map.Children.Add(mapPolyline);
					}
					if (i is Polygon)
					{
						Polygon p = i as Polygon;
						MapPolygon mapPolygon = new MapPolygon();
						mapPolygon.Opacity = 0.7;
						mapPolygon.StrokeThickness = 3;
						ListBox.Items.Add("Surface: " + p.Description);
						mapPolygon.Fill = new System.Windows.Media.SolidColorBrush(p.RemplissageColor);
						mapPolygon.Stroke = new System.Windows.Media.SolidColorBrush(p.ContourColor);
						mapPolygon.Locations = new LocationCollection();
						foreach (Coordonnees coords in p.Collection)
						{
							mapPolygon.Locations.Add(new Location(coords.Latitude, coords.Longitude));
						}
						Map.Children.Add(mapPolygon);
					}
				}
			}
			ListBox.SelectedIndex = ListBox.Items.Count - 1;
		}
		private void Map_DoubleClick(object sender, MouseEventArgs e)
		{
			Console.WriteLine("Double click!");
			e.Handled = true;
			Point mousePosition = e.GetPosition(Map);
			Location mouseLocation = Map.ViewportPointToLocation(mousePosition);
			bool pinPresent = false;

			//Tester si on click sur une pin
			for (int i = 0; i < myPersonalMapData.ObservableCollection.Count; i++)
			{
				ICartoObj obj = myPersonalMapData.ObservableCollection[i];
				if (obj is POI)
				{
					Coordonnees coords = new Coordonnees(((POI)obj).Latitude, ((POI)obj).Longitude);
					if (coords.IsPointClose(new Coordonnees(mouseLocation.Latitude, mouseLocation.Longitude),0.001))
					{
						Console.WriteLine("trouve: des = {0}",((POI)obj).Description);
						PoiWindow poiWindow = new PoiWindow((POI)obj);
						poiWindow.ShowDialog();
						myPersonalMapData.ObservableCollection[i] = poiWindow.Poi;
						poiWindow.Close();
						pinPresent = true;
						break;
					}
				}
				if(obj is Polyline)
				{
					foreach(ICartoObj cartoObj in ((Polyline)obj).Collection)
					{
						if (((Coordonnees)cartoObj).IsPointClose(new Coordonnees(mouseLocation.Latitude, mouseLocation.Longitude), 0.001))
						{
							ListBox.SelectedItem = ((Polyline)obj).Description;
							PolylineWindow polylineWindow = new PolylineWindow((Polyline)obj);
							polylineWindow.ShowDialog();
							myPersonalMapData.ObservableCollection[ListBox.SelectedIndex] = polylineWindow.Polyline;
							polylineWindow.Close();
							pinPresent = true;
							break;
						}
					}
				}
			}

			if(!pinPresent)
			{
				//Créé une pin ou trajet
				POI poi = new POI("", new Coordonnees(mouseLocation.Latitude, mouseLocation.Longitude));
				PoiWindow poiWindow = new PoiWindow();
				poiWindow.Latitude = poi.Latitude.ToString();
				poiWindow.Longitude = poi.Longitude.ToString();
				poiWindow.Description = "";
				poiWindow.ShowDialog();
				Console.WriteLine("desc: {0}",poiWindow.Description);
				if(poiWindow.Poi != null)
					myPersonalMapData.ObservableCollection.Add(poiWindow.Poi);
				poiWindow.Close();
			}
			UpdateMainWindow();
		}
		
		private void Map_RightButtonDown(object sender, MouseEventArgs e)
		{
			e.Handled = true;
		}

		private void Map_KeyDown(object sender, KeyEventArgs e)
		{
			if(e.Key == Key.Enter)
			{
				//Cree le traject/surface
				Console.WriteLine("Coucou enter");
			}
			
			e.Handled = true;
		}
	}
}
