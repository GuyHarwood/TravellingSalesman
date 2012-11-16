using System;
using System.Collections.Generic;

namespace GuyHarwood.TravellingSalesman
{
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

		public Queue<Location> CalculateShortestRoute(Location startingFrom)
		{
			if(startingFrom == null)
				throw new ArgumentNullException("startingFrom");
			
			if(_destinations.Count == 0)
				throw new InvalidOperationException("No Destinations entered");
			
			//enumerate each destination and find closest...

		}
	}
}