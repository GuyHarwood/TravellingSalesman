using System;
using System.Collections.Generic;

namespace GuyHarwood.TravellingSalesman
{
	class Program
	{
		static void Main(string[] args)
		{
			//a queue for the locations that will be used to establish all available roads (a complete graph)
			var locQ = new Queue<Location>(5);

			//create the locations(vertexes), and queue them ...
			locQ.Enqueue(new Location("Derby", 52.9230, -1.480));
			locQ.Enqueue(new Location("Nottingham", 52.9546, -1.163));
			locQ.Enqueue(new Location("Manchester", 53.4750, -2.252));
			locQ.Enqueue(new Location("Sheffield", 53.378, -1.468));
			locQ.Enqueue(new Location("Reading", 51.444, -0.989));

			//create an array to reference all locations as we establish roads
			var locs = new Location[5];
			locQ.CopyTo(locs, 0);

			//to store the roads we need to look up
			var roads = new List<Road>();
			//prepare the first location
			var current = locQ.Dequeue();

			while (current != null)
			{
				for (int i = locs.Length - 1; i >= 0; i--)
				{
					if (current != locs[i])
					{
						var road = new Road()
						{
							From = current,
							To = locs[i]
						};
						if (roads.Contains(road) == false)
						{
							roads.Add(road);
							Console.WriteLine("Adding {0} to {1}", road.From.Name, road.To.Name);
						}
					}
				}
				current = locQ.Count > 0 ? locQ.Dequeue() : null;
			}

			Console.WriteLine("There are {0} roads", roads.Count);

			//create the roads (edges)...
			//var dby2nts = new Road( dby, nts);
			//var dby2mcr = new Road(dby, mcr);
			//var dby2shf = new Road( dby, shf);
			//var dby2rdg = new Road( dby, rdg);
			//var nts2mcr = new Road(nts, mcr);
			//var nts2shf = new Road(nts, shf);
			//var nts2rdg = new Road(nts, rdg);
			//var mcr2shf = new Road(mcr, shf);
			//var mcr2rdg = new Road(mcr, rdg);
			//var shf2rdg = new Road(shf, rdg);

			//var manualRoads = new [] {dby2nts, dby2mcr, dby2shf, dby2rdg, nts2mcr, nts2shf, nts2rdg, mcr2shf, mcr2rdg, shf2rdg};

			//calculate shortest route between...
			//var satNav = new RouteCalculator(manualRoads);
			//satNav.AddDestination(dby);
			//satNav.AddDestination(nts);
			//satNav.AddDestination(mcr);

			//var route = satNav.CalculateShortestRoute();

			//foreach(var place in route)
			//{
			//	Console.WriteLine(place.Name);
			//}
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
			if (destination == null)
				throw new ArgumentNullException("destination");

			_destinations.Add(destination);
		}

		public Queue<Location> CalculateShortestRoute()
		{
			throw new NotImplementedException();
		}
	}
}
