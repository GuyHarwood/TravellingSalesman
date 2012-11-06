namespace GuyHarwood.TravellingSalesman
{
	public class Location
	{
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
	}
}