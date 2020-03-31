using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Threading;
using System.ComponentModel;
using MyCartographyObjects;
using System.Collections.ObjectModel;

namespace PersonalMapManager
{
	/// <summary>
	/// Interaction logic for Login.xaml
	/// </summary>
	public partial class LoginWindow : Window
	{
		string nom = "";
		string prenom = "";
		string email = "";
		public LoginWindow()
		{
			InitializeComponent();
			DataContext = this;
		}

		private void SeConnecter_Click(object sender, RoutedEventArgs e)
		{
			MyPersonalMapData temp = new MyPersonalMapData();
			if (temp.Load(prenom, nom))
			{
				TextBoxInfo.Text = "Ce compte n'existe pas!";
				return;
			}
			MainWindow mainWindow = new MainWindow();
			this.Hide();
			mainWindow.myPersonalMapData.Nom = nom;
			mainWindow.myPersonalMapData.Prenom = prenom;
			mainWindow.Show();
			this.Close();
		}

		private void CréeUnCompte_Click(object sender, RoutedEventArgs e)
		{
			if (nom.Length == 0 || prenom.Length == 0 || email.Length == 0)
			{
				TextBoxInfo.Text = "Un champs est vide!";
				return;
			}

			MyPersonalMapData temp = new MyPersonalMapData(nom, prenom, email, new ObservableCollection<ICartoObj> { });
			temp.Save();
			MainWindow mainWindow = new MainWindow();
			this.Hide();
			mainWindow.myPersonalMapData.Nom = nom;
			mainWindow.myPersonalMapData.Prenom = prenom;
			mainWindow.myPersonalMapData.Email = email;
			mainWindow.Show();
			this.Close();
		}

		private void Login_Closing(object sender, CancelEventArgs e)
		{

		}




	}
}
