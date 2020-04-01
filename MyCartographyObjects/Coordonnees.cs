using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MyCartographyObjects
{
	[Serializable]
    public class Coordonnees : CartoObj, IIsPointClose
    {
        //Variables membres
        public double _latitude;
        public double _longitude;

		//Contructeurs
		public Coordonnees() : this(0.000, 0.000)
		{
			Debug.Log("[Coordonnees][Constructeur]");
		}
		public Coordonnees(double newLatitude,double newLongitude) : base()
		{
			Debug.Log("[Coordonnees][Constructeur]newLatitude,newLongitude");
			Latitude = newLatitude;
			Longitude = newLongitude;
		}
		public Coordonnees(Coordonnees copie) : this(copie.Latitude,copie.Longitude)
		{
			Debug.Log("[Coordonnees][Constructeur]copie");
		}
		
        //Propriétés
        public double Latitude
        {
            set 
			{
				Debug.Log("[Coordonnees][Latitude]set");
				_latitude = value;
				OnPropertyChanged();
			}
            get
			{
				Debug.Log("[Coordonnees][Latitude]get");
				return _latitude; 
			}
        }
        public double Longitude
        {
            set 
			{
				Debug.Log("[Coordonnees][Longitude]set");
				_longitude = value;
				OnPropertyChanged();
			}
            get
			{
				Debug.Log("[Coordonnees][Longitude]get");
				return _longitude;
			}
        }

		//Méthodes
		public override void Draw()
		{
			Console.WriteLine(this);
		}

		//Surcharge Opérateurs
		public override string ToString()
		{
			Debug.Log("[Coordonnees][ToString]");
			return string.Format("Id: {0} Coordonnees({1,6:0.000};{2,6:0.000})",Id,Latitude,Longitude);
		}

		//Interfaces
		public bool IsPointClose(Coordonnees coords, double precisionn)
		{
			Debug.Log("[Coordonnees][IsPointClose]");
			double diffLatitude = Math.Abs(Latitude - coords.Latitude);
			double diffLongitude = Math.Abs(Longitude - coords.Longitude);
			if (diffLatitude < precisionn && diffLongitude < precisionn)
				return true;
			else
				return false;
		}
	}
}
