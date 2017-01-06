using System;
using MvvmCross.Core.ViewModels;

namespace HelloMvx4.Core.ViewModels
{
	public class ThirdViewModel
		: MvxViewModel
	{

		public void Init(Data data)
		{
			if (data.Day != 0)
			{
				DayModel = data.Day;
				MonthModel = data.Month;
				YearModel = data.Year;
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

		private string _pathMusic;
		public string PathMusicModel
		{
			get { return _pathMusic; }
			set { SetProperty(ref _pathMusic, value); }
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
			ShowViewModel<SecondViewModel>(new Data() { Day = DayModel, Month = MonthModel, Year = YearModel, PathMusic = PathMusicModel });
		}
	}
}
