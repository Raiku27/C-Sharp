using System;

namespace MyCartographyObjects
{
	public class POI : Coordonnees, ICartoObj
	{
		//Variables membres
		private string _description;

		//Contructeurs
		public POI() : this("Quai Gloesener",new Coordonnees(50.620090, 5.581406))
		{
			Debug.Log("[POI][Constructeur]");
			Description = null;
		}
		public POI(string newDescription, Coordonnees newCoordonnees) : base(newCoordonnees.Latitude,newCoordonnees.Longitude)
		{
			Debug.Log("[POI][Constructeur]newDescription,newCoordonnees");
			Description = newDescription;
		}
		public POI(POI copie) : this(copie.Description, new Coordonnees(copie.Latitude,copie.Longitude))
		{
			Debug.Log("[POI][Constructeur]copie");
		}
		//Destructeur
		~POI()
		{
			Debug.Log("[POI][Destructeur]");
		}

		//Propriétés
		public string Description
		{
			set 
			{
				Debug.Log("[POI][Desciption]set");
				_description = value;
			}
			get 
			{
				Debug.Log("[POI][Desciption]get");
				return _description;
			}
		}

		//Surcharge Opérateurs
		public override string ToString()
		{
			Debug.Log("[POI][ToString]");
			if (Description == null)
				return string.Format("Id: {0}",Id) + " Desciprtion: / " + string.Format("Coordonnees({0,6:0.000};{1,6:0.000})",Latitude, Longitude);
			else
				return string.Format("Id: {0}", Id) + " Desciption: " + Description + " " + string.Format("Coordonnees({0,6:0.000};{1,6:0.000})",Latitude, Longitude);
		}
	}
}
