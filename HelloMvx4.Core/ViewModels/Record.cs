using System;
namespace HelloMvx4.Core
{
	public class Record
	{
		public int Day { get; set; }
		public int Month { get; set; }
		public int Year { get; set; }
		public string RecordDate { 
			get
			{
				return string.Format("{0}/{1}/{2}", Day, Month, Year);
			} 
		}

		public string Name { get; set; }
		public int Hour { get; set; }
		public int Min { get; set; }
		public string TimeRepeat { get; set; }
		public string Sound { get; set; }
		public int SoundId { get; set; }
		public string More { get; set; }
	}
}
