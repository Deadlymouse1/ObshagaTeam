using System;
using System.Collections.Generic;
using MvvmCross.Core.ViewModels;


namespace HelloMvx4.Core.ViewModels
{
	public class SecondViewModel
		: MvxViewModel
	{
		public void Init(Data data)
		{
			if (data.Day != 0)
			{
				DayModel = data.Day;
				MonthModel = data.Month;
				YearModel = data.Year;
				SoundPathModel = data.PathMusic;
			}
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

		private string _name;
		public string NameModel
		{
			get { return _name; }
			set { SetProperty(ref _name, value); }
		}

		private TimeSpan _time;
		public TimeSpan TimeModel
		{
			get { return _time; }
			set { SetProperty(ref _time, value); }
		}

		private string _timeRepeat;
		public string TimeRepeatModel
		{
			get { return _timeRepeat; }
			set { SetProperty(ref _timeRepeat, value); }
		}

		private string _sound;
		public string SoundModel
		{
			get { return _sound; }
			set { SetProperty(ref _sound, value); }
		}

		private string _soundPath;
		public string SoundPathModel
		{
			get { return _soundPath; }
			set { SetProperty(ref _soundPath, value); }
		}

		private string _more;
		public string MoreModel
		{
			get { return _more; }
			set { SetProperty(ref _more, value); }
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
			ShowViewModel<ThirdViewModel>(new Data() { Day = DayModel, Month = MonthModel, Year = YearModel });
		}

		private IMvxCommand _onButtonClickCommand2;
		public IMvxCommand MyButtonCommand2
		{
			get
			{
				if (_onButtonClickCommand2 == null)
					_onButtonClickCommand2 = new MvxCommand(OnButtonClicked2);
				return _onButtonClickCommand2;
			}
		}

		private void OnButtonClicked2()
		{
			ShowViewModel<FirstViewModel>(new Record() { Day = DayModel,
				Month = MonthModel, Year = YearModel,
				Name = NameModel, Time = TimeModel,
				TimeRepeat = TimeRepeatModel, Sound = SoundModel,
				SoundPath = SoundPathModel, More = MoreModel});
		}
	}
}
