using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace HelloMvx4.Droid
{
	public class Alarm : BroadcastReceiver
	{
		public override void OnReceive(Context context, Intent intent)
		{
			Toast.MakeText(context, "Alarm !!!!!!!!!!", ToastLength.Long).Show();
		}

		public void setAlarm(Context context)
		{
			AlarmManager am = (AlarmManager)context.GetSystemService(Context.AlarmService);
			Intent i = new Intent(context, this.Class); 
        	PendingIntent pi = PendingIntent.GetBroadcast(context, 0, i, 0);
			am.SetRepeating(AlarmType.RtcWakeup, SystemClock.ElapsedRealtime() + 1000, 10000, pi); // Millisec * Second * Minute
    	}
	}
}
