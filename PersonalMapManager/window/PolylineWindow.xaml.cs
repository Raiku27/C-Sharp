using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
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
	/// <summary>
	/// Interaction logic for PolylineWindow.xaml
	/// </summary>
	public partial class PolylineWindow : Window
	{
		public PolylineWindow()
		{
			InitializeComponent();
			foreach(var colorValue in Enum.GetValues(typeof(KnownColor)))
			{
				Color color = Color.FromKnownColor((KnownColor)colorValue);

			}
		}

		private void ButtunOk_Click(object sender, RoutedEventArgs e)
		{
			
		}

		private void ButtonAppliquer_Click(object sender, RoutedEventArgs e)
		{
			
		}

		private void ButtonAnnuler_Click(object sender, RoutedEventArgs e)
		{
	
		}

		
	}
}
