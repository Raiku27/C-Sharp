using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MyCartographyObjects
{
	public class MyPersonalMapData
	{
		//Variables membres
		private string _nom;
		private string _prenom;
		private string _email;
		private ObservableCollection<ICartoObj> _observableCollection;
		private string path = "C:\\Users\\Vincent\\OneDrive - Enseignement de la Province de Liège\\Cours\\B2\\C#\\MyCartographyObjects\\data\\";

		//Constructeurs
		public MyPersonalMapData() : this("","","",new ObservableCollection<ICartoObj> { })
		{
			Debug.Log("[MyPersonalMapData][Constructeur]");
		}
		public MyPersonalMapData(string newNom, string newPrenom, string newEmail, ObservableCollection<ICartoObj> newObservableCollection) : base()
		{
			Debug.Log("[MyPersonalMapData][Constructeur]newNom: {0} newPrenom: {1} newEmail: {2} newObservableCollection: {3}",newNom,newPrenom,newEmail,newObservableCollection);
			Nom = newNom;
			Prenom = newPrenom;
			Email = newEmail;
			this.setObservableCollection(newObservableCollection);
		}

		//Propriétés
		public string Nom
		{
			set
			{
				Debug.Log("[MyPersonalMapData][Nom]set {0}",value);
				if (value != null)
				{
					_nom = value;
				}
			}
			get 
			{
				Debug.Log("[MyPersonalMapData][Nom]get {0}",_nom);
				return _nom;
			}
		}
		public string Prenom
		{
			set
			{
				Debug.Log("[MyPersonalMapData][Prenom]set {0}",value);
				if (value != null)
				{
					_prenom = value;
				}
			}
			get
			{
				Debug.Log("[MyPersonalMapData][Prenom]get {0}",_prenom);
				return _prenom;
			}
		}
		public string Email
		{
			set
			{
				Debug.Log("[MyPersonalMapData][Email]set {0}",value);
				if (value != null)
				{
					_email = value;
				}
			}
			get
			{
				Debug.Log("[MyPersonalMapData][Email]get {0}",_email);
				return _email;
			}
		}
		public ObservableCollection<ICartoObj> ObservableCollection
		{
			get
			{
				Debug.Log("[MyPersonalMapData][ObservableCollection]get {0}",_observableCollection);
				return _observableCollection;
			}
		}

		//Méthodes
		public int setObservableCollection(ObservableCollection<ICartoObj> newObservableCollection)
		{
			Debug.Log("[MyPersonalMapData][setObservableCollection]newObservableCollection = {0}",newObservableCollection);
			if (newObservableCollection != null)
			{
				_observableCollection = newObservableCollection;
				return 0;
			}
			else
			{
				return 1;
			}
		}
		public bool Reset()
		{
			Debug.Log("[MyPersonalMapData][Reset]");
			_observableCollection.Clear();
			return false;
		}
		public bool Save()
		{
			Debug.Log("[MyPersonalMapData][Save]");
			BinaryFormatter binFormat = new BinaryFormatter();
			Stream fStream = new FileStream(path + Prenom + Nom + ".dat", FileMode.Create, FileAccess.Write, FileShare.None);
			binFormat.Serialize(fStream,Prenom);
			binFormat.Serialize(fStream,Nom);
			binFormat.Serialize(fStream,Email);
			binFormat.Serialize(fStream, ObservableCollection);
			fStream.Close();
			return false;
		}
		public bool Load(string loadPrenom = null,string loadNom = null)
		{
			Debug.Log("[MyPersonalMapData][Load]");
			if(loadNom == null && loadPrenom != null || loadNom != null && loadPrenom == null)
			{
				//Erreur car 1 param et non 2
				return true;
			}
			if (loadNom == null)
				loadNom = Nom;
			if (loadPrenom == null)
				loadPrenom = Prenom;

			BinaryFormatter binFormat = new BinaryFormatter();
			try
			{
				Stream fStream = new FileStream(path + loadPrenom + loadNom + ".dat", FileMode.Open, FileAccess.Read);
				if (fStream == null)
					return true;
				Prenom = (string)binFormat.Deserialize(fStream);
				Nom = (string)binFormat.Deserialize(fStream);
				Email = (string)binFormat.Deserialize(fStream);
				this.setObservableCollection((ObservableCollection<ICartoObj>)binFormat.Deserialize(fStream));
				fStream.Close();
			}
			catch(Exception)
			{
				return true;
			}
			return false;
		}
		public void Draw()
		{
			Debug.Log("[MyPersonalMapData][Draw]");
			Console.WriteLine(this);
			foreach (CartoObj c in _observableCollection)
			{
				Console.Write("\t-");
				if(c is Coordonnees)
				{
					Coordonnees coords = c as Coordonnees;
					Console.WriteLine(coords);
				}
				if(c is Polyline)
				{
					Polyline poly = c as Polyline;
					Console.WriteLine(poly);
				}
				if(c is Polygon)
				{
					Polygon polyg = c as Polygon;
					Console.WriteLine(polyg);
				}
			}
		}

		//Surchage Opérateurs
		public override string ToString()
		{
			Debug.Log("[MyPersonalMapData][ToString]");
			return string.Format("Nom: {0} Prenom: {1} Email: {2}",_nom,_prenom,_email);
		}
	}
}
