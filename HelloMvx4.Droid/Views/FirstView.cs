using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using Com.GrapeCity.Xuni.Calendar;
using Com.GrapeCity.Xuni.Core;
using HelloMvx4.Core.ViewModels;
using MvvmCross.Droid.Views;


namespace HelloMvx4.Droid.Views
{
    [Activity(Label = "View for FirstViewModel")]
	public class FirstView : MvxActivity
	{
		XuniCalendar calendar;

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			LicenseManager.Key = License.Key;
			SetContentView(Resource.Layout.FirstView);

			// get chart from view
			calendar = FindViewById<XuniCalendar>(Resource.Id.calendar);


			// for vertical scrolling set Orientation
			calendar.Orientation = CalendarOrientation.Horizontal;

			// set maximum selected days
			calendar.MaxSelectionCount = 1;

			calendar.SelectionChanged += (object sender, CalendarSelectionChangedEventArgs e) =>
			{
				(ViewModel as FirstViewModel).MyButtonCommand.Execute();
			};

			// change appearance
			calendar.DaySlotLoading += Calendar_DaySlotLoading;

		}

		private void Calendar_DaySlotLoading(object sender, CalendarDaySlotLoadingEventArgs e)
		{
			// get day
			Java.Util.Date date = e.Date;
			Java.Util.Calendar cal = Java.Util.Calendar.GetInstance(Java.Util.Locale.English);
			cal.Time = date;
			int day = cal.Get(Java.Util.CalendarField.DayOfMonth);


			// create day slot layout container
			CalendarDaySlotBase layout = new CalendarDaySlotBase(ApplicationContext);
			layout.SetGravity(GravityFlags.Top);
			layout.SetVerticalGravity(GravityFlags.Top);
			layout.Orientation = Orientation.Vertical;
			layout.SetBackgroundColor(Android.Graphics.Color.Red);
			layout.SetPadding(5, 5, 5, 5);
			LinearLayout.LayoutParams linearLayoutParams1 = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.FillParent, LinearLayout.LayoutParams.FillParent);
			layout.LayoutParameters = linearLayoutParams1;

			// create text element
			TextView tv = new TextView(ApplicationContext);
			LinearLayout.LayoutParams linearLayoutParams = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MatchParent, LinearLayout.LayoutParams.WrapContent);
			tv.LayoutParameters = linearLayoutParams;
			tv.Gravity = GravityFlags.Top;   //текст цифр
			tv.Text = day.ToString();

			if (e.AdjacentDay)
			{
				// format adjacent day text
				tv.SetTextColor(Android.Graphics.Color.Green); //цвет неактивных дней
			}

			// add text element to layout
			layout.AddView(tv);


			// add weather image for certain days
			if (day >= 14 && day <= 23)
			{
				ImageView iv = new ImageView(ApplicationContext);
				switch (day % 5)
				{
					case 0:
						//iv.SetImageResource(Resource.Drawable.Cloudy);
						break;
					case 1:
						//iv.SetImageResource(Resource.Drawable.PartlyCloudy);
						break;
					case 2:
						//iv.SetImageResource(Resource.Drawable.Rain);
						break;
					case 3:
						//iv.SetImageResource(Resource.Drawable.Storm);
						break;
					case 4:
						//iv.SetImageResource(Resource.Drawable.Sun);
						break;

				}
				layout.AddView(iv);

			}

			// finally, set layout to day slot
			e.DaySlot = layout;
		}
	}
}
