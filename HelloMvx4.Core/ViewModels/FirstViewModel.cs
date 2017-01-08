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
			if (record != null)
			{
				container.AddRecord(record);
			}
		}

		public Record RecordObject { get; set; }
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

		public bool getRecordState(int index)
		{
			return container.GetRecord(index).setAlarm;
		}

		public void setRecordState(int index)
		{
			container.GetRecord(index).setAlarm = true;
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

		private int _soundPath;
		public int SoundPath
		{
			get { return _soundPath; }
			set { SetProperty(ref _soundPath, value); }
		} 

		private int _currentDate;
		public int CurrentDate
		{
			get { return _currentDate; }
			set { SetProperty(ref _currentDate, value); }
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
			ShowViewModel<SecondViewModel>(new Record() { Day = DayModel, Month = MonthModel, Year = YearModel, setAlarm = false });
		}
	}
}
