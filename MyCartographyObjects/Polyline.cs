using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Media;
using MathUtils;

namespace MyCartographyObjects
{
	[Serializable]
	public class Polyline : CartoObj, IIsPointClose, IPointy, IComparable<Polyline>, IEquatable<Polyline>, ICartoObj
	{
		//Variables Membres
		public List<Coordonnees> _collection;
		private string _couleur;
		private int _epaisseur;

		//Constructeurs
		public Polyline() : this(new List<Coordonnees> { },Colors.Black,1)
		{
			Debug.Log("[Polyline][Constructeur]");
		}
		public Polyline(List<Coordonnees> newCollection,Color newCouleur,int newEpaisseur) : base()
		{
			Debug.Log("[Polyline][Constructeur]newCollection,newCouleur,newEpaisseur");
			Collection = newCollection;
			Couleur = newCouleur.ToString();
			Epaisseur = newEpaisseur;
		}
		//Propriétés
		public List<Coordonnees> Collection
		{
			set 
			{
				Debug.Log("[Polyline][Collection]set");
				_collection = value; 
			}
			get 
			{
				Debug.Log("[Polyline][Collection]get");
				return _collection;
			}
		}
		public string Couleur
		{
			set 
			{
				Debug.Log("[Polyline][Couleur]set");
				_couleur = value;
			}
			get
			{
				Debug.Log("[Polyline][Couleur]get");
				return _couleur;
			}
		}
		public Color Color
		{
			set
			{
				Debug.Log("[Polyline][Color]set");
				Couleur = value.ToString();
			}
			get
			{
				Debug.Log("[Polyline][Color]get");
				return (Color)ColorConverter.ConvertFromString(_couleur);
			}
		}
		public int Epaisseur
		{
			set 
			{
				Debug.Log("[Polyline][Epaisseur]set");
				_epaisseur = value;
			}
			get 
			{
				Debug.Log("[Polyline][Epaisseur]get");
				return _epaisseur; 
			}
		}
		public int NbPoints
		{
			get
			{
				Debug.Log("[Polyline][NbPoints]get");
				return _collection.Select(a => a.Id).Distinct().Count();
			}
		}

		//Méthode
		public override void Draw()
		{
			Debug.Log("[Polyline][Draw]");
			Console.WriteLine(this.ToString());
			foreach(Coordonnees coords in Collection)
			{
				Console.Write("\t-");
				coords.Draw();
			}
		}

		public double longeur()
		{
			Debug.Log("[Polyline][longeur]");
			int compteur;
			double somme = 0;
			for(compteur = 0; compteur < NbPoints; compteur++)
			{
				if(!(compteur + 1 >= NbPoints))
				{
					somme += MathUtil.Point2Point(Collection[compteur].Latitude, Collection[compteur].Longitude, Collection[compteur + 1].Latitude, Collection[compteur + 1].Longitude);
				}
			}
			return somme;
		}

		public double surfaceBoundingBox()
		{
			double xMin = 0;
			double xMax = 0;
			double yMin = 0;
			double yMax = 0;

			foreach(Coordonnees p in _collection)
			{
				if (p.Longitude > xMax)
					xMax = p.Longitude;
				if (p.Longitude < xMin)
					xMin = p.Longitude;
				if (p.Latitude > yMax)
					yMax = p.Latitude;
				if (p.Latitude < yMin)
					yMin = p.Latitude;
			}

			return MathUtil.Point2Point(0, yMin, 0, yMax) * MathUtil.Point2Point(xMin, 0, xMax, 0);
		}

		//Interfaces
		public bool IsPointClose(Coordonnees coords,double precision)
		{
			Debug.Log("[Polyline][IsPointClose]");
			int i;
			bool resultat;
			for (i = 0; i < (_collection.Count - 1); i++)
			{
				Coordonnees pointA = new Coordonnees(this._collection[i].Latitude, this._collection[i].Longitude);
				Coordonnees pointB = new Coordonnees(this._collection[i + 1].Latitude, this._collection[i + 1].Longitude);

				resultat = CartoObj.IsPointCloseAB(coords, pointA, pointB, precision);

				if (resultat) { return true; }
			}
			//si on arrive ici c'est que le point n'est pas proche d'aucune droite de la collection
			return false;

		}

		public int CompareTo(Polyline obj)
		{
			Debug.Log("[Polyline][CompareTo]");
			return longeur().CompareTo(obj.longeur());
		}
		public bool Equals(Polyline other)
		{
			Debug.Log("[Polyline][Equals]");
			
			if(this.longeur().Equals(other.longeur()))
				return true;
			else
				return false;
		}

		//Surcharge Opérateurs
		public override string ToString()
		{
			Debug.Log("[Polyline][ToString]");
			return string.Format("Id: {0}", Id) + " Couleur: " + Couleur + string.Format(" Epaisseur: {0}", Epaisseur);
		}
	}
}
