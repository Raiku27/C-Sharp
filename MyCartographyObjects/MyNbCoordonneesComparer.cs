using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCartographyObjects
{
	public class MyNbCoordonneesComparer : IComparer<CartoObj>
	{
		public int Compare(CartoObj x, CartoObj y)
		{
			if(x is Polyline && y is Polyline)
			{
				Polyline p1 = x as Polyline;
				Polyline p2 = y as Polyline;
				return p1.NbPoints.CompareTo(p2.NbPoints);
			}
			if(x is Polygon && y is Polygon)
			{
				Polygon p1 = x as Polygon;
				Polygon p2 = y as Polygon;
				return p1.NbPoints.CompareTo(p2.NbPoints);
			}
			//Si l'objet n'est ni un polyline ou polygon on ne peut pas les comparer donc return 0
			return 0;
		}
	}
}
