using System;

namespace GuyHarwood.TravellingSalesman
{
	public class Road
	{
		public override int GetHashCode()
		{
			unchecked
			{
				return ((From != null ? From.GetHashCode() : 0)*397) ^ (To != null ? To.GetHashCode() : 0);
			}
		}

		protected bool Equals(Road other)
		{
			//It doesnt matter which location is at either end of the road, its just a road between the two
			return ((Equals(From, other.From)) || (Equals(From, other.To))) && ((Equals(To, other.To)) || Equals(To, other.From));
			//return Equals(From, other.From) && Equals(To, other.To);
		}

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
			double theta = From.Lat - To.Lat;
			double dist = Math.Sin(Deg2Rad(From.Lat)) * Math.Sin(Deg2Rad(To.Lat)) + Math.Cos(Deg2Rad(From.Lat)) * Math.Cos(Deg2Rad(To.Lat)) * Math.Cos(Deg2Rad(theta));
			dist = Math.Acos(dist);
			dist = Rad2Deg(dist);
			return dist * 60 * 1.1515;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((Road) obj);
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