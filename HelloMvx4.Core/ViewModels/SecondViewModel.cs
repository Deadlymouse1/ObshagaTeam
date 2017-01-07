using System;
using System.Collections.Generic;
using MvvmCross.Core.ViewModels;


namespace HelloMvx4.Core.ViewModels
{
	public class SecondViewModel
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
			ShowViewModel<ThirdViewModel>(record);
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
			ShowViewModel<FirstViewModel>(record);
		}
	}
}
