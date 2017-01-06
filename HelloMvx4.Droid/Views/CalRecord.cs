using System;
namespace HelloMvx4.Droid
{
	public class CalRecord
	{
		public CalRecord(string day, string month, string year)
		{
			Day = day;
			Month = month;
			Year = year;
		}
		public string Day { get; set; }
		public string Month { get; set; }
		public string Year { get; set; }
	}
}
