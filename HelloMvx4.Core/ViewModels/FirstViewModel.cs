using System;
using System.Collections.Generic;
using MvvmCross.Core.ViewModels;

namespace HelloMvx4.Core.ViewModels
{
    public class FirstViewModel 
        : MvxViewModel
	{
		public void Init(Record record)
		{
			if (record.Day != 0)
			{
				Records.Add(record);
			}
		}

		public static List<Record> Records = new List<Record>();
		public int getCountRecords
		{
			get { return Records.Count; }
		}

		public int getDayRecords (int numberInRecords)
		{
			return Records[numberInRecords].Day;				
		}

		public int getMonthRecords(int numberInRecords)
		{
			return Records[numberInRecords].Month;
		}
		public int getYearRecords(int numberInRecords)
		{
			return Records[numberInRecords].Year;
		}


		private int _day;
		public int DayModel
		{
			get { return _day; }
			set { SetProperty(ref _day, value); }
		}

		private int _month;
		public int MonthModel
		{
			get { return _month; }
			set { SetProperty(ref _month, value); }
		}

		private int _year;
		public int YearModel
		{
			get { return _year; }
			set { SetProperty(ref _year, value); }
		}

		private IMvxCommand _onButtonClickCommand;
		public IMvxCommand MyButtonCommand
		{
			get
			{
				if (_onButtonClickCommand == null)
					_onButtonClickCommand = new MvxCommand(OnButtonClicked);
				return _onButtonClickCommand; 
			}
		}
		private void OnButtonClicked()
		{
			ShowViewModel<SecondViewModel>(new Data() { Day = DayModel, Month = MonthModel, Year = YearModel });
		}
	}
}
