using Android.App;
using Android.OS;
using MvvmCross.Droid.Views;


namespace HelloMvx4.Droid.Views
{
	[Activity(Label = "View for ThirdView")]
	public class ThirdView : MvxActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			SetContentView(Resource.Layout.ThirdView);


			// Create your application here
		}
	}
}
