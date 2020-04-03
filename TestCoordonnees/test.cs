using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Windows.Media;
using System.Xml.Serialization;
using MyCartographyObjects;

namespace Projet_Test
{
    class test
    {
        static void Main(string[] args)
        {
			/*List<CartoObj> list = new List<CartoObj> { };
			POI poi1 = new POI();
			POI poi2 = new POI();
			Polyline polyline1 = new Polyline();
			Polyline polyline2 = new Polyline();
			Polygon polygon1 = new Polygon();
			Polygon polygon2 = new Polygon();

			list.Add(poi1);
			list.Add(poi2);
			list.Add(polyline1);
			list.Add(polyline2);
			list.Add(polygon1);
			list.Add(polygon2);

			Console.WriteLine("Afficher cette liste en utilisant le mot clé foreach");
			foreach(CartoObj c in list)
			{
				c.Draw();
			}

			Console.WriteLine("\nAfficher la liste des objets implémentant l’interface IPointy");
			foreach(CartoObj c in list)
			{
				if(c is IPointy)
				{
					c.Draw();
				}
			}

			Console.WriteLine("\nAfficher la liste des objets n’implémentant pas l’interface IPointy");
			foreach(CartoObj c in list)
			{
				if(!(c is IPointy))
				{
					c.Draw();
				}
			}

			Console.WriteLine("\nCréer une liste générique de 5 Polyline, l’afficher");
			List<Polyline> listePoli = new List<Polyline> { };
			listePoli.Add(new Polyline(new List<Coordonnees>{new Coordonnees(0,0),new Coordonnees(1,1) },Colors.Black,0));
			listePoli.Add(new Polyline(new List<Coordonnees>{new Coordonnees(0,0),new Coordonnees(4,5) },Colors.Black,0));
			listePoli.Add(new Polyline(new List<Coordonnees>{new Coordonnees(0,0),new Coordonnees(1,1) },Colors.Black,0));
			listePoli.Add(new Polyline(new List<Coordonnees>{new Coordonnees(0,0),new Coordonnees(10,-1) },Colors.Black,0));
			listePoli.Add(new Polyline(new List<Coordonnees>{new Coordonnees(0,0),new Coordonnees(0,10) },Colors.Black,0));
			
			foreach(Polyline p in listePoli)
			{
				p.Draw();
			}

			Console.WriteLine("\nla trier par ordre de longueur croissante");
			listePoli.Sort();

			Console.WriteLine("\nl’afficher à nouveau");
			foreach (Polyline p in listePoli)
			{
				p.Draw();
			}

			Console.WriteLine("\ntrier la liste par ordre croissant de taille de surface de la bounding box englobant la polyline");
			MyPolylineBoundingBoxComparer triSurface = new MyPolylineBoundingBoxComparer();
			listePoli.Sort(triSurface);
			foreach (Polyline p in listePoli)
			{
				p.Draw();
			}

			Console.WriteLine("\nRechercher, parmi les polyline de la liste, celles qui présentent la même taille qu’une polyline de référence");
			Polyline polyline3 = new Polyline(new List<Coordonnees> { new Coordonnees(0, 0), new Coordonnees(1, 1) }, Colors.Black, 0);
			Console.WriteLine("Find : {0}", listePoli.Find(x => x.longeur().Equals(polyline3.longeur())));

			Console.WriteLine("\nRechercher, parmi les polyline de la liste, celles qui sont proches d’un point passé en paramètre");
			Coordonnees coordonnees1 = new Coordonnees(0, 2);
			Console.WriteLine("Coordonnees1: " + coordonnees1 + " Precision: 0.5");
			foreach(Polyline p in listePoli)
			{
				if(p.IsPointClose(coordonnees1,0.5))
				{
					Console.WriteLine("Le point " + coordonnees1 + " est proche de la listePoli!");
				}
				else
				{
					Console.WriteLine("Le point " + coordonnees1 + " n'est pas proche de la listePoli!");
				}
			}
			Coordonnees coordonnees2 = new Coordonnees(0, 0);
			Console.WriteLine("Coordonnees1: " + coordonnees2 + " Precision: 1");
			foreach (Polyline p in listePoli)
			{
				if (p.IsPointClose(coordonnees2, 1))
				{
					Console.WriteLine("Le point " + coordonnees2 + " est proche de la listePoli!");
				}
				else
				{
					Console.WriteLine("Le point " + coordonnees2 + " n'est pas proche de la listePoli!");
				}
			}

			Console.WriteLine("\nMettre en place et tester un mécanisme qui permet de classer une liste d’objets CartoObj sur base du nombre d’objets Coordonnees qui le compose via un …Comparer.");
			MyNbCoordonneesComparer triNbCoordonnees = new MyNbCoordonneesComparer();
			List < CartoObj > list1 = new List<CartoObj> { };
			list1.Add(new Polyline(new List<Coordonnees> { new Coordonnees(0, 0), new Coordonnees(1, 1),new Coordonnees(2,2) }, Colors.Black, 1));
			list1.Add(new Polyline(new List<Coordonnees> {new Coordonnees(0,0)},Colors.Black,1));
			list1.Add(new Polyline(new List<Coordonnees> {new Coordonnees(0,0),new Coordonnees(1,1)},Colors.Black,1));
			Console.WriteLine("Voici la liste:");
			foreach(CartoObj c in list1)
			{
				if(c is Polyline)
				{
					Polyline p1 = c as Polyline;
					p1.Draw();
				}
				if(c is Polygon)
				{
					Polygon p1 = c as Polygon;
					p1.Draw();
				}
			}

			list1.Sort(triNbCoordonnees);

			Console.WriteLine("Voici la liste triee:");
			foreach (CartoObj c in list1)
			{
				if (c is Polyline)
				{
					Polyline p1 = c as Polyline;
					p1.Draw();
				}
				if (c is Polygon)
				{
					Polygon p1 = c as Polygon;
					p1.Draw();
				}
			}*/

			//Tester MyPersonalMapData
			/*MyPersonalMapData mapData = new MyPersonalMapData("Gerard","Vincent","mail.vincent.gerard@gmail.com",new ObservableCollection<ICartoObj> { });
			Polyline poly = new Polyline(new List<Coordonnees> { new Coordonnees(0,0),new Coordonnees(1,1)},Colors.Black,1);
			Polygon polygon = new Polygon(new List<Coordonnees> { new Coordonnees(3,3)},Colors.Black,Colors.Black,1);
			mapData.ObservableCollection.Add(poly);
			mapData.ObservableCollection.Add(polygon);
			mapData.Draw();
			mapData.Save();*/

			MyPersonalMapData mapdata = new MyPersonalMapData();
			mapdata.Load("Vincent","Gerard");
			Console.WriteLine(mapdata);
			foreach(ICartoObj i in mapdata.ObservableCollection)
			{
				if(i is Polyline)
				{
					Polyline p = i as Polyline;
					Console.WriteLine(p);

					foreach (Coordonnees c in p.Collection)
					{
						Console.Write("\t\t -");
						Console.WriteLine(c);
					}
				}
				if(i is POI)
				{
					POI p = i as POI;

					Console.WriteLine(p);
				}
				//Console.WriteLine(i);
			}

			Console.ReadLine();
		}
    }
}

