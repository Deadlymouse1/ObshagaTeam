using System;
namespace HelloMvx4.Droid
{
	public class CalRecord
	{
		public CalRecord(int day, int month, int year)
		{
			Day = day;
			Month = month;
			Year = year;
		}
		public int Day { get; set; }
		public int Month { get; set; }
		public int Year { get; set; }
	}
}
