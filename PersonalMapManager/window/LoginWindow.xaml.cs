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
using System.Runtime.CompilerServices;

namespace PersonalMapManager
{
	/// <summary>
	/// Interaction logic for Login.xaml
	/// </summary>
	public partial class LoginWindow : Window, INotifyPropertyChanged
	{
		//Variables Memebres
		string _nom = "";
		string _prenom = "";
		string _email = "";
		public event PropertyChangedEventHandler PropertyChanged;

		//Contructeur
		public LoginWindow()
		{
			InitializeComponent();
			DataContext = this;
		}

		//Propriétés
		public string Nom
		{
			set
			{
				_nom = value;
				OnPropertyChanged();
			}
			get
			{
				return _nom;
			}
		}
		public string Prenom
		{
			set
			{
				_prenom = value;
				OnPropertyChanged();
			}
			get
			{
				return _prenom;
			}
		}
		public string Email
		{
			set
			{
				_email = value;
				OnPropertyChanged();
			}
			get
			{
				return _email;
			}
		}

		private void SeConnecter_Click(object sender, RoutedEventArgs e)
		{
			MyPersonalMapData temp = new MyPersonalMapData();
			if (temp.Load(Prenom, Nom))
			{
				TextBoxInfo.Text = "Ce compte n'existe pas!";
				return;
			}
			MainWindow mainWindow = new MainWindow();
			this.Hide();
			mainWindow.myPersonalMapData.Nom = Nom;
			mainWindow.myPersonalMapData.Prenom = Prenom;
			mainWindow.Show();
			this.Close();
		}

		private void CréeUnCompte_Click(object sender, RoutedEventArgs e)
		{
			if (Nom.Length == 0 || Prenom.Length == 0 || Email.Length == 0)
			{
				TextBoxInfo.Text = "Un champs est vide!";
				return;
			}

			MyPersonalMapData temp = new MyPersonalMapData(Nom, Prenom, Email, new ObservableCollection<ICartoObj> { });
			temp.Save();
			MainWindow mainWindow = new MainWindow();
			this.Hide();
			mainWindow.myPersonalMapData.Nom = Nom;
			mainWindow.myPersonalMapData.Prenom = Prenom;
			mainWindow.myPersonalMapData.Email = Email;
			mainWindow.Show();
			this.Close();
		}

		private void LoginWindow_Closing(object sender, CancelEventArgs e)
		{

		}

		//Interfaces
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
