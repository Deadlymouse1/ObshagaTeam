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
				container.AddRecord(record);
			}
		}

		public Record record { get; set; }

		public void setRecordObject(int index)
		{
			record = container.GetRecord(index);
		}
		public int getRecordsCount()
		{
			return container.getCountRecords;
		}

		public static RecordContainer container = new RecordContainer();

		public string getRecordDate(int index)
		{
			return container.GetRecordDate(index);
		}

		public string getRecordName(int index)
		{
			return container.GetRecord(index).Name;
		}

		public int getRecordSoundId(int index)
		{
			return container.GetRecord(index).SoundId;
		}

		public void deleteRecord(int index)
		{
			container.Remove(index);
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
			ShowViewModel<SecondViewModel>(new Record() { Day = DayModel, Month = MonthModel, Year = YearModel});
		}

		private IMvxCommand _onButtonClickCommand1;
		public IMvxCommand MyButtonCommand1
		{
			get
			{
				if (_onButtonClickCommand1 == null)
					_onButtonClickCommand1 = new MvxCommand(OnButtonClicked1);
				return _onButtonClickCommand1;
			}
		}
		private void OnButtonClicked1()
		{
			ShowViewModel<SecondViewModel>(record);
		}
	}
}
