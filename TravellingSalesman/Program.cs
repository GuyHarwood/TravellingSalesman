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
			
			//calculate shortest route between...
			var satNav = new RouteCalculator(roads);
			satNav.AddDestination(locs[1]);
			satNav.AddDestination(locs[2]);
			satNav.AddDestination(locs[3]);

			var route = satNav.CalculateShortestRoute(locs[0]);

			foreach (var place in route)
			{
				Console.WriteLine(place.Name);
			}
			Console.WriteLine("Press any key to exit...");
			Console.ReadKey();
		}
	}
}
