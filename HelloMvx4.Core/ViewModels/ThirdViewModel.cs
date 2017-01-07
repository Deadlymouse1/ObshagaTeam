using System;
using MvvmCross.Core.ViewModels;

namespace HelloMvx4.Core.ViewModels
{
	public class ThirdViewModel
		: MvxViewModel
	{

		public void Init(Record record)
		{
			if (record != null)
			{
				this.record = record;
			}
		}
		public Record record;

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
			ShowViewModel<SecondViewModel>(record);
		}
	}
}
