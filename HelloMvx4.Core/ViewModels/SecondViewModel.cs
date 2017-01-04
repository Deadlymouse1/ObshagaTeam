using System;
using MvvmCross.Core.ViewModels;


namespace HelloMvx4.Core.ViewModels
{
	public class SecondViewModel
		: MvxViewModel
	{
		private IMvxCommand _onButtonClickCommand;
		private IMvxCommand _onButtonClickCommand1;

		public IMvxCommand MyButtonCommand
		{
			get
			{
				if (_onButtonClickCommand == null)
					_onButtonClickCommand = new MvxCommand(OnButtonClicked);
				return _onButtonClickCommand;
			}
		}
		public IMvxCommand MyButtonCommand1
		{
			get
			{
				if (_onButtonClickCommand1 == null)
					_onButtonClickCommand1 = new MvxCommand(OnButtonClicked1);
				return _onButtonClickCommand1;
			}
		}


		private void OnButtonClicked()
		{
			ShowViewModel(typeof(FirstViewModel));
		}
		private void OnButtonClicked1()
		{
			ShowViewModel(typeof(ThirdViewModel));
		}
	}
}
