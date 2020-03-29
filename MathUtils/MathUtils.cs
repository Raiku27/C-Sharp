using System;

namespace MathUtils
{
	public class MathUtil
	{
		public static double Point2Point(double xA, double yA, double xB, double yB)
		{
			//On dois verifier et inverser les X/Y?
			return Math.Sqrt(Math.Pow(xB - xA, 2) + Math.Pow(yB - yA, 2));
		}
	}
}
