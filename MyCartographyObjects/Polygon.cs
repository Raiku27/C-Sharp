﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Media;

namespace MyCartographyObjects
{
	[Serializable]
	public class Polygon : CartoObj, IIsPointClose, ICartoObj, INotifyPropertyChanged
	{
		//Variables Membres
		private List<Coordonnees> _collection;
		private string _remplissage;
		private string _contour;
		private double _opacite;
		private string _description;

		//Constructeurs
		public Polygon() : this("",new List<Coordonnees> { },Colors.Black,Colors.Black,1)
		{
			Debug.Log("[Polygon][Constructeur]");
		}
		public Polygon(string newDescription,List<Coordonnees> newCollection,Color newRemplissage,Color newContour,double newOpacite) : base()
		{
			Debug.Log("[Polygon][Constructeur]newCollection,newRemplissage,newCountour,newOpacite");
			Description = newDescription;
			Collection = newCollection;
			RemplissageColor = newRemplissage;
			ContourColor = newContour;
			Opacite = newOpacite;
		}

		//Propriétés
		public string Description
		{
			set
			{
				Debug.Log("[POI][Desciption]set");
				_description = value;
				OnPropertyChanged();
			}
			get
			{
				Debug.Log("[POI][Desciption]get");
				return _description;
			}
		}
		public List<Coordonnees> Collection
		{
			set 
			{
				Debug.Log("[Polygon][Collection]set");
				_collection = value;
				OnPropertyChanged();
			}
			get 
			{
				Debug.Log("[Polygon][Collection]get");
				return _collection; 
			}
		}
		public Color RemplissageColor
		{
			set 
			{
				Debug.Log("[Polygon][RemplissageColor]set");
				_remplissage = value.ToString();
				OnPropertyChanged();
			}
			get
			{
				Debug.Log("[Polygon][RemplissageColor]get");
				return (Color)ColorConverter.ConvertFromString(_remplissage); 
			}
		}
		public string RemplissageString
		{
			set
			{
				Debug.Log("[Polygon][RemplissageString]set");
				_remplissage = value; 
				OnPropertyChanged();
			}
			get
			{
				Debug.Log("[Polygon][RemplissageString]get");
				return _remplissage;
			}
		}
		public Color ContourColor
		{
			set
			{
				Debug.Log("[Polygon][ContourColor]set");
				_contour = value.ToString();
				OnPropertyChanged();
			}
			get
			{
				Debug.Log("[Polygon][ContourColor]get");
				return (Color)ColorConverter.ConvertFromString(_contour);
			}
		}
		public string ContourString
		{
			set
			{
				Debug.Log("[Polygon][ContourString]set");
				_contour = value;
				OnPropertyChanged();
			}
			get
			{
				Debug.Log("[Polygon][ContourString]get");
				return _contour;
			}
		}
		public double Opacite
		{
			set 
			{
				Debug.Log("[Polygon][Opacite]set");
				if (value > 0 && value < 1)
				{
					_opacite = value;
					OnPropertyChanged();
				}
			}
			get
			{
				Debug.Log("[Polygon][Opacite]get");
				return _opacite;
			}
		}
		public int NbPoints
		{
			get
			{
				Debug.Log("[Polygon][NbPoints]get");
				return _collection.Select(a => a.Id).Distinct().Count();
			}
		}

		//Methodes
		public override void Draw()
		{
			Debug.Log("[Polygon][Draw]");
			Console.WriteLine(this);
			foreach(Coordonnees c in Collection)
			{
				Console.WriteLine("\t-");
				Console.WriteLine(c);
			}
		}

		//Interfaces
		public bool IsPointClose(Coordonnees coords, double precisionn)
		{
			Debug.Log("[Polygon][IsPointClose]");
			double valMax_X = 0, valMax_Y = 0, valMin_X, valMin_Y;
			int i;
			for (i = 0; i < _collection.Count; i++)
			{
				if (valMax_X < _collection[i].Latitude)
					valMax_X = _collection[i].Latitude;
				if (valMax_Y < _collection[i].Longitude)
					valMax_Y = _collection[i].Longitude;
			}

			valMin_X = valMax_X;
			valMin_Y = valMax_Y;
			for (i = 0; i < _collection.Count; i++)
			{
				if (valMin_X > _collection[i].Latitude)
					valMin_X = _collection[i].Latitude;
				if (valMin_Y > _collection[i].Longitude)
					valMin_Y = _collection[i].Longitude;
			}

			//coordonnées des sommets du rectangle ou carré (bouding Box)
			//A._________.B
			// |         |
			// |         |
			//C._________.D
			/*Coordonnees coordonneesA = new Coordonnees(valMin_X, valMax_Y);
            Coordonnees coordonneesB = new Coordonnees(valMax_X, valMax_Y);
            Coordonnees coordonneesC = new Coordonnees(valMin_X, valMin_Y);
            Coordonnees coordonneesD = new Coordonnees(valMax_X, valMin_Y);*/

			if (coords.Latitude <= valMax_X && coords.Latitude >= valMin_X)
			{
				if (coords.Longitude <= valMax_Y && coords.Longitude >= valMin_Y)
				{
					return true;
				}
				else { return false; }
			}
			else { return false; }
		}

		//Surchage Opérateurs
		public override string ToString()
		{
			Debug.Log("[Polygon][ToString]");
			return string.Format("ID: {0}", Id) + " Description: " + Description +  " Remplissage: " + RemplissageColor + " Contour: " + ContourColor + string.Format(" Opacité: {0,3:0.0}",Opacite);
		}
	}
}
