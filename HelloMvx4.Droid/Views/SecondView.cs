using System;
using Android.App;
using Android.OS;
using Android.Widget;
using HelloMvx4.Core.ViewModels;
using Java.Text;
using Java.Util;
using MvvmCross.Binding.Droid.Views;
using MvvmCross.Droid.Views;

namespace HelloMvx4.Droid.Views
{
	[Activity(Label = "View for SecondViewModel")]
	public class SecondView : MvxActivity
	{
		TextView view;
		EditText name;
		MvxTimePicker time;
		EditText timeRepeat;
		Button sound;
		EditText more;
		Button addButton;
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			SetContentView(Resource.Layout.SecondView);

			view = FindViewById<TextView>(Resource.Id.dateTextView1);
			int i = (ViewModel as SecondViewModel).DayModel;
			int b = (ViewModel as SecondViewModel).MonthModel;
			int c = (ViewModel as SecondViewModel).YearModel;
			string a = string.Format("{0}/{1}/{2}", i, b, c);
			view.SetText(a, TextView.BufferType.Normal);

			SimpleDateFormat sdf = new SimpleDateFormat("dd/MM/yyyy");
			Date strDate = sdf.Parse(a);

			name = FindViewById<EditText>(Resource.Id.nameEditView);
			time = FindViewById<MvxTimePicker>(Resource.Id.timePicker);
			timeRepeat = FindViewById<EditText>(Resource.Id.intervalEdit);
			sound = FindViewById<Button>(Resource.Id.musicButton);
			more = FindViewById<EditText>(Resource.Id.lastEditText);
			addButton = FindViewById<Button>(Resource.Id.addButton);

			addButton.Click += (object sender, System.EventArgs e) =>
			{
				(ViewModel as SecondViewModel).NameModel = name.Text;
				(ViewModel as SecondViewModel).TimeModel = time.Value;
				(ViewModel as SecondViewModel).TimeRepeatModel = timeRepeat.Text;
				(ViewModel as SecondViewModel).SoundModel = sound.Text;
				(ViewModel as SecondViewModel).MoreModel = more.Text;
				(ViewModel as SecondViewModel).MyButtonCommand2.Execute();				
			};
		}
	}
}
