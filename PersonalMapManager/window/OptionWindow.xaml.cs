using Microsoft.Office.Interop.Excel;
using MyCartographyObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Brushes = System.Windows.Media.Brushes;
using Window = System.Windows.Window;

namespace PersonalMapManager.window
{
	public partial class OptionWindow : Window,INotifyPropertyChanged
	{
		private string _path;
		private string _background;
		private string _foreground;
		private bool hasAppliquerBeenClicked = false;

		public event PropertyChangedEventHandler PropertyChanged;

		public delegate void UpdateGUIEventHandler(object source, UpdateGUIEventArgs args);
		public event UpdateGUIEventHandler UpdateGUI;


		public OptionWindow(MainWindow owner)
		{
			InitializeComponent();
			DataContext = this;
			Owner = owner;
			foreach (PropertyInfo property in typeof(System.Drawing.Color).GetProperties(BindingFlags.Static | BindingFlags.Public))
			{
				if (property.PropertyType == typeof(System.Drawing.Color))
				{
					ComboBoxBackground.Items.Add(property.Name);
					ComboBoxForeground.Items.Add(property.Name);
				}
			}
			Path = ((MainWindow)Owner).myPersonalMapData.Path;
			BackgroundColor = MainWindow.GetBrushName(((MainWindow)Owner).ListBox.Background as SolidColorBrush);
			ForegroundColor = MainWindow.GetBrushName(((MainWindow)Owner).ListBox.Foreground as SolidColorBrush);
		}
		public string BackgroundColor
		{
			set
			{
				_background = value;
				OnPropertyChanged();
			}
			get
			{
				return _background;
			}
		}
		public string ForegroundColor
		{
			set
			{
				_foreground = value;
				OnPropertyChanged();
			}
			get
			{
				return _foreground;
			}
		}
		public string Path
		{
			set
			{
				_path = value;
				OnPropertyChanged();
			}
			get
			{
				return _path;
			}
		}

		private void Parcourir_Click(object sender, RoutedEventArgs e)
        {
			FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
			folderBrowserDialog.SelectedPath = null;
			folderBrowserDialog.ShowDialog();

			((MainWindow)Owner).myPersonalMapData.Path = folderBrowserDialog.SelectedPath;
			Path = folderBrowserDialog.SelectedPath;
        }
		private void ButtonAnnuler_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}
		private void ButtonAppliquer_Click(object sender, RoutedEventArgs e)
		{
			hasAppliquerBeenClicked = true;
			OnUpdateGUI();
		}
		private void ButtunOk_Click(object sender, RoutedEventArgs e)
		{
			if(hasAppliquerBeenClicked)
			{
				Close();
			}
		}
		protected virtual void OnUpdateGUI()
		{
			if (UpdateGUI != null)
				UpdateGUI(this, new UpdateGUIEventArgs(BackgroundColor,ForegroundColor));
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
