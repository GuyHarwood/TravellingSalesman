using System;
using System.Collections.Generic;

namespace GuyHarwood.TravellingSalesman
{
	class Program
	{
		static void Main(string[] args)
		{
			//create the locations (vertexes)...
			var dby = new Location("Derby", 52.9230, -1.480);
			var nts = new Location("Nottingham", 52.9546, -1.163);
			var mcr = new Location("Manchester", 53.4750, -2.252);
			var shf = new Location("Sheffield", 53.378, -1.468);
			var rdg = new Location("Reading", 51.444, -0.989);

			//create the roads (edges)...
			//TODO write algo that auto creates all possible permutations of roads
			var dby2nts = new Road( dby, nts);
			var dby2mcr = new Road(dby, mcr);
			var dby2shf = new Road( dby, shf);
			var dby2rdg = new Road( dby, rdg);
			var nts2mcr = new Road(nts, mcr);
			var nts2shf = new Road(nts, shf);
			var nts2rdg = new Road(nts, rdg);
			var mcr2shf = new Road(mcr, shf);
			var mcr2rdg = new Road(mcr, rdg);
			var shf2rdg = new Road(shf, rdg);

			var roads = new [] {dby2nts, dby2mcr, dby2shf, dby2rdg, nts2mcr, nts2shf, nts2rdg, mcr2shf, mcr2rdg, shf2rdg};
			
			//calculate shortest route between...
			var satNav = new RouteCalculator(roads);
			satNav.AddDestination(dby);
			satNav.AddDestination(nts);
			satNav.AddDestination(mcr);

			var route = satNav.CalculateShortestRoute();

			foreach(var place in route)
			{
				Console.WriteLine(place.Name);
			}
			Console.WriteLine("Press any key to exit...");
			Console.ReadKey();
		}
	}

	public class RouteCalculator
	{
		private readonly IEnumerable<Road> _mapData;
		private readonly List<Location> _destinations; 
		
		public RouteCalculator(IEnumerable<Road> mapData)
		{
			_mapData = mapData;
			_destinations = new List<Location>();
		}

		public void AddDestination(Location destination)
		{
			if(destination == null)
				throw new ArgumentNullException("destination");

			_destinations.Add(destination);
		}

		public Queue<Location> CalculateShortestRoute()
		{
			throw new NotImplementedException();
		}
	}
}
