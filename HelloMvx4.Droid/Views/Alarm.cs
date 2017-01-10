﻿using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Provider;
using Android.Support.V4.Content;
using Android.Widget;
using HelloMvx4.Droid.Views;
using MvvmCross.Droid.Views;

namespace HelloMvx4.Droid
{
	[BroadcastReceiver]
	public class Alarm : BroadcastReceiver
	{
		public override void OnReceive(Context context, Intent intent)
		{
			Console.WriteLine(intent.GetStringExtra("hour") + "AAAAAAAAA");
			Console.WriteLine(intent.GetStringExtra("min") + "AAAAAAAAA");
			Console.WriteLine(intent.GetStringExtra("more") + "AAAAAAAAA");
			var resultIntent = new Intent(context, typeof(FourView));
			resultIntent.PutExtra("title", intent.GetStringExtra("title"));
			resultIntent.PutExtra("hour", intent.GetStringExtra("hour"));
			resultIntent.PutExtra("min", intent.GetStringExtra("min"));
			resultIntent.PutExtra("more", intent.GetStringExtra("more"));
			resultIntent.PutExtra("soundId", intent.GetStringExtra("soundId"));
			resultIntent.SetFlags(ActivityFlags.NewTask);
			context.StartActivity(resultIntent);
			TimeSpan ts1 = (DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0));
			long currTime = (long)ts1.TotalMilliseconds;
		}
	}
}
