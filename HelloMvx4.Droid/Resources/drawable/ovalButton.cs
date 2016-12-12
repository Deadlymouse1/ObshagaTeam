using System;

using Xamarin.Forms;

namespace HelloMvx4.Droid
{
	public class ovalButton : ContentPage
	{
		public ovalButton()
		{
			Content = new StackLayout
			{
				Children = {
					new Label { Text = "Hello ContentPage" }
				}
			};
		}
	}
}

