using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using HelloMvx4.Core.ViewModels;
using Java.Interop;
using Java.Text;
using Java.Util;
using MvvmCross.Binding.Droid.Views;
using MvvmCross.Droid.Views;

namespace HelloMvx4.Droid.Views
{
	[Activity(Label = "View for SecondViewModel", Theme = "@style/MyTheme")]
	public class SecondView : MvxActivity
	{
		TextView view;
		EditText name;
		MvxTimePicker time;
		Button sound;
		EditText more;
		Button addButton;
		AlarmManager am;
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			SetContentView(Resource.Layout.SecondView);

			view = FindViewById<TextView>(Resource.Id.dateTextView1);
			int i = (ViewModel as SecondViewModel).record.Day;
			int b = (ViewModel as SecondViewModel).record.Month;
			int c = (ViewModel as SecondViewModel).record.Year;
			string a = string.Format("{0}/{1}/{2}", i, b, c);
			view.SetText(a, TextView.BufferType.Normal);

			int indexIndent = i * 1000000 + b * 10000 + c;

			SimpleDateFormat sdf = new SimpleDateFormat("dd/MM/yyyy");
			Date strDate = sdf.Parse(a);

			name = FindViewById<EditText>(Resource.Id.nameEditView);
			time = FindViewById<MvxTimePicker>(Resource.Id.timePicker);

			sound = FindViewById<Button>(Resource.Id.musicButton);
			more = FindViewById<EditText>(Resource.Id.lastEditText);
			addButton = FindViewById<Button>(Resource.Id.addButton);
			am = GetSystemService(AlarmService).JavaCast<AlarmManager>();

			sound.Click += (object sender, EventArgs e) =>
			{
				(ViewModel as SecondViewModel).record.Name = name.Text;
				(ViewModel as SecondViewModel).record.Hour = time.Value.Hours;
				(ViewModel as SecondViewModel).record.Min = time.Value.Minutes;

				(ViewModel as SecondViewModel).record.More = more.Text;
				(ViewModel as SecondViewModel).MyButtonCommand.Execute();
			};

			if ((ViewModel as SecondViewModel).record.Name != null)
			{
				name.Text = (ViewModel as SecondViewModel).record.Name;
				time.Hour = (ViewModel as SecondViewModel).record.Hour;
				time.Minute = (ViewModel as SecondViewModel).record.Min;

				sound.Text = (ViewModel as SecondViewModel).record.Sound;
				more.Text = (ViewModel as SecondViewModel).record.More;

			}

			addButton.Click += (object sender, System.EventArgs e) =>
			{
				if (name.Text == "")
				{
					Toast toast1 = Toast.MakeText(this, "Напишите название", ToastLength.Short);
					toast1.Show();
					return;
				}

				if (sound.Text == "Выберите мелодию")
				{
					Toast toast1 = Toast.MakeText(this, "Выберите музыку", ToastLength.Short);
					toast1.Show();
					return;
				}
				(ViewModel as SecondViewModel).record.Name = name.Text;
				(ViewModel as SecondViewModel).record.Hour = time.Value.Hours;
				(ViewModel as SecondViewModel).record.Min = time.Value.Minutes;
				(ViewModel as SecondViewModel).record.More = more.Text;

				var alarmIntent = new Intent(this, typeof(Alarm));
				alarmIntent.PutExtra("title", name.Text);
				alarmIntent.PutExtra("soundId", (ViewModel as SecondViewModel).record.SoundId);
				TimeSpan ts = (new DateTime(c, b, i, time.Value.Hours, time.Value.Minutes, 0) - new DateTime(1970, 1, 1, 0, 0, 0));
				long currTime = (long)ts.TotalMilliseconds - 18000000 ; 

				var pending = PendingIntent.GetBroadcast(this, indexIndent, alarmIntent, PendingIntentFlags.UpdateCurrent);
				am.Set(AlarmType.RtcWakeup, currTime, pending);

				Toast toast = Toast.MakeText(this, "Запись сделана", ToastLength.Short);
				toast.Show();

				(ViewModel as SecondViewModel).MyButtonCommand2.Execute();
			};
			var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
			SetActionBar(toolbar);

			ActionBar.Title = "Записи";
		}

	}
}
