using System;
using System.Linq;

namespace AlloCine
{
	// Note: This a replciate of https://docs.microsoft.com/en-us/dotnet/api/system.device.location.geocoordinate?view=netframework-4.8
	//		 which is not available in .netstandard 2.0 and which is easy enough to not add another dependency for it!

	public class GeoCoordinate
	{
		/// <summary>
		/// Latitude. May range from -90.0 to 90.0.
		/// </summary>
		public double Latitude { get; set; }

		/// <summary>
		/// Longitude. May range from -180.0 to 180.0
		/// </summary>
		public double Longitude { get; set; }
	}
}