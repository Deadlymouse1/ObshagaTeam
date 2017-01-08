
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using HelloMvx4.Droid.Views;
using MvvmCross.Droid.Views;

namespace HelloMvx4.Droid
{
	[Activity(Label = "FourView")]
	public class FourView : Activity
	{
		TextView text;
		Button button;
		MediaPlayer _player = new MediaPlayer();
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.FourView);
			text = FindViewById<TextView>(Resource.Id.Name);
			text.Text = Intent.GetStringExtra("title");
			button = FindViewById<Button>(Resource.Id.StopButton);
			//_player = MediaPlayer.Create(this, (Android.Net.Uri)Intent.GetStringExtra("soundId"));
			//_player.Start();
			button.Click += (object sender, EventArgs e) =>
			{
				//_player.Stop();
				var resultIntent = new Intent(this, typeof(FirstView));
				resultIntent.SetFlags(ActivityFlags.NewTask);
				StartActivity(resultIntent);
			};


			// Create your application here
		}
	}
}
