using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MyCartographyObjects
{
	[Serializable]
	public abstract class CartoObj : INotifyPropertyChanged
	{
		//Variables memebres
		private static int _compteur = 0;
		private int _id;

		public event PropertyChangedEventHandler PropertyChanged;

		//Constructeurs
		public CartoObj()
		{
			Debug.Log("[CartoObj][Constructeur]");
			_compteur++;
			_id = _compteur;
		}

		//Destructeur
		~CartoObj()
		{
			Debug.Log("[CartoObj][Destructeur]");
		}
		
		//Propriétés
		public int Id
		{
			get 
			{
				Debug.Log("[CartoObj][Id]get");
				return _id;
			}
			set
			{
				Debug.Log("[CartoObj][Id]set");
				_id = value;
				OnPropertyChanged();
			}
		}

		//Méthodes
		public virtual void Draw()
		{
			Debug.Log("[CartoObj][Draw]");
			Console.WriteLine(this);
		}

		public static bool IsPointCloseAB(Coordonnees coords, Coordonnees pointA, Coordonnees pointB, double precision)
		{
			Debug.Log("[CartoObj][IsPointCloseAB]");
			//1 tester si le point recherché est proche de A ou de B ?
			if (pointA.IsPointClose(coords, precision)) { return true; }
			if (pointB.IsPointClose(coords, precision)) { return true; }

			//2 si le point recherché n'est pas proche du point A ou B, --> tester s'il est proche de la droite

			//recherche des max et min sur l'axe des x et y
			double maxLat, minLat, maxLong, minLong;
			//maxLat
			if (pointA.Latitude > pointB.Latitude) { maxLat = pointA.Latitude; }
			else { maxLat = pointB.Latitude; }

			//minLat
			if (pointA.Latitude < pointB.Latitude) { minLat = pointA.Latitude; }
			else { minLat = pointB.Latitude; }

			//maxLong
			if (pointA.Longitude > pointB.Longitude) { maxLong = pointA.Longitude; }
			else { maxLong = pointB.Longitude; }

			//minLong
			if (pointA.Longitude < pointB.Longitude) { minLong = pointA.Longitude; }
			else { minLong = pointB.Longitude; }

			//cas d'une droite verticale
			if (pointA.Latitude == pointB.Latitude)
			{
				if (coords.Longitude <= maxLong && coords.Longitude >= minLong)
				{
					double differenceLatitude;
					differenceLatitude = Math.Abs(pointA.Latitude - coords.Latitude);
					if (differenceLatitude <= precision) { return true; }
					else { return false; }
				}
				else { return false; }
			}

			//cas d'une droite horizontale
			if (pointA.Longitude == pointB.Longitude)
			{
				if (coords.Latitude <= maxLat && coords.Latitude >= minLat)
				{
					double differenceLongitude;
					differenceLongitude = Math.Abs(pointA.Longitude - coords.Longitude);
					if (differenceLongitude <= precision) { return true; }
					else { return false; }
				}
				else { return false; }
			}

			//cas d'une droite oblique

			//y = mx +p
			double m = (pointB.Longitude - pointA.Longitude) / (pointB.Latitude - pointA.Latitude);
			double p = pointA.Longitude - (m * pointA.Latitude);

			Coordonnees pointDeLaDroite = new Coordonnees();
			for (double x = minLat; x <= maxLat; x += precision)
			{
				double y = m * x + p;
				pointDeLaDroite.Latitude = x;
				pointDeLaDroite.Longitude = y;
				if (pointDeLaDroite.IsPointClose(coords, precision)) { return true; }
			}

			//si on arrive ici c'est que le point n'est pas proche de la  droite AB
			return false;
		}

		//Interfaces
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null)
				handler(this, new PropertyChangedEventArgs(propertyName));
		}

		//Surcharge Opérateurs
		public override string ToString()
		{
			Debug.Log("[CartoObj][ToString]");
			return string.Format("Id: {0}",Id);
		}
	}
}

