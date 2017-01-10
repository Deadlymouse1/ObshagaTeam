
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
		TextView time;
		TextView more;
		Button button;
		MediaPlayer _player = new MediaPlayer();
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.FourView);
			text = FindViewById<TextView>(Resource.Id.Name);
			time = FindViewById<TextView>(Resource.Id.Time);
			more = FindViewById<TextView>(Resource.Id.MoreRecord);
			text.Text = Intent.GetStringExtra("title");
			time.Text = Intent.GetStringExtra("time");
			more.Text = Intent.GetStringExtra("more");
			button = FindViewById<Button>(Resource.Id.StopButton);
			int soundId = Resource.Raw.sound;
			switch (Intent.GetStringExtra("soundId"))
			{
				case "0":
					soundId = Resource.Raw.sound;
					break;
				case "1":
					soundId = Resource.Raw.sound1;
					break;
				case "2":
					soundId = Resource.Raw.sound2;
					break;
				case "3":
					soundId = Resource.Raw.sound3;
					break;
			}



			_player = MediaPlayer.Create(this, soundId);
			_player.Start();
			button.Click += (object sender, EventArgs e) =>
			{
				_player.Stop();
				var resultIntent = new Intent(this, typeof(FirstView));
				resultIntent.SetFlags(ActivityFlags.NewTask);
				StartActivity(resultIntent);

			};


			// Create your application here
		}
	}
}
