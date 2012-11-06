using System;

namespace GuyHarwood.TravellingSalesman
{
	public class Road
	{
		private double? _distance;

		public Road()
		{
		}

		public Road(Location from, Location to)
		{
			From = from;
			To = to;
		}

		public Location From { get; set; }
		public Location To { get; set; }
		
		public double Distance()
		{
			if (_distance != null)
				return _distance.Value;

			double theta = From.Lat - To.Lat;
			double dist = Math.Sin(Deg2Rad(From.Lat)) * Math.Sin(Deg2Rad(To.Lat)) + Math.Cos(Deg2Rad(From.Lat)) * Math.Cos(Deg2Rad(To.Lat)) * Math.Cos(Deg2Rad(theta));
			dist = Math.Acos(dist);
			dist = Rad2Deg(dist);
			_distance = dist * 60 * 1.1515;
			return _distance.Value;
		}

		private static double Deg2Rad(double deg)
		{
			return (deg * Math.PI / 180.0);
		}

		private static double Rad2Deg(double rad)
		{
			return (rad / Math.PI * 180.0);
		}
	}
}