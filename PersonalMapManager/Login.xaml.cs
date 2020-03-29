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
	public partial class Login : Window
	{
		private MyPersonalMapData myPersonalMapData = null;
		public Login()
		{
			InitializeComponent();
		}

		private void Nom_TextChanged(object sender, TextChangedEventArgs e)
		{

		}
		private void Prenom_TextChanged(object sender, TextChangedEventArgs e)
		{
			
		}
		private void Email_TextChanged(object sender, TextChangedEventArgs e)
		{
			
		}

		private void SeConnecter_Click(object sender, RoutedEventArgs e)
		{
			//Verifier la connexion
			string nom = TextBoxNom.Text;
			string prenom = TextBoxPrenom.Text;
			MyPersonalMapData temp = new MyPersonalMapData();
			if(temp.Load(prenom,nom))
			{
				//Erreur
				TextBoxInfo.Text = "Ce compte n'existe pas!";
				return;
			}
			MainWindow mainWindow = new MainWindow();
			this.Hide();
			//mainWindow.myPersonalMapData = temp;
			mainWindow.myPersonalMapData.Nom = nom;
			mainWindow.myPersonalMapData.Prenom = prenom;
			mainWindow.Show();
			this.Close();
		}

		private void CréeUnCompte_Click(object sender, RoutedEventArgs e)
		{
			if (TextBoxNom.Text.Length == 0 || TextBoxPrenom.Text.Length == 0 || TextBoxEmail.Text.Length == 0)
			{
				TextBoxInfo.Text = "Un champs est vide!";
				return;
			}
				
			MyPersonalMapData temp = new MyPersonalMapData(TextBoxNom.Text, TextBoxPrenom.Text, TextBoxEmail.Text, new ObservableCollection<ICartoObj>{ });
			temp.Save();
			MainWindow mainWindow = new MainWindow();
			this.Hide();
			//mainWindow.myPersonalMapData = temp;
			mainWindow.myPersonalMapData.Nom = TextBoxNom.Text;
			mainWindow.myPersonalMapData.Prenom = TextBoxPrenom.Text;
			mainWindow.Show();
			this.Close();
		}

		private void Login_Closing(object sender, CancelEventArgs e)
		{

		}

		

		
	}
}
