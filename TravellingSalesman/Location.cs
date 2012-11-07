using System;

namespace GuyHarwood.TravellingSalesman
{
	public class Location
	{
		protected bool Equals(Location other)
		{
			return Lat.Equals(other.Lat) && Lng.Equals(other.Lng);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				return (Lat.GetHashCode()*397) ^ Lng.GetHashCode();
			}
		}

		public Location()
		{}

		public Location(string name, double lat, double lng)
		{
			Name = name;
			Lat = lat;
			Lng = lng;
		}

		public string Name;
		public double Lat, Lng;

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((Location) obj);
		}
	}
}