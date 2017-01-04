using System;
using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using Com.GrapeCity.Xuni.Calendar;
using Com.GrapeCity.Xuni.Core;
using HelloMvx4.Core.ViewModels;
using Java.Text;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Droid.Views;


namespace HelloMvx4.Droid.Views
{
    [Activity(Label = "View for FirstViewModel")]
	public class FirstView : MvxActivity
	{
		XuniCalendar calendar;
		List<CalRecord> records = new List<CalRecord>();
		RelativeLayout pushUp;
		TextView textView;
		Button button;
		Button addButton;
		Button editButton;
		Button deleteButton;

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			LicenseManager.Key = License.Key;
			SetContentView(Resource.Layout.FirstView);
			for (int i = 0; i < (ViewModel as FirstViewModel).getCountRecords; i++)
			{
				records.Add(new CalRecord((ViewModel as FirstViewModel).getDayRecords(i), (ViewModel as FirstViewModel).getMonthRecords(i), (ViewModel as FirstViewModel).getYearRecords(i))); 
			}

			// get chart from view
			calendar = FindViewById<XuniCalendar>(Resource.Id.calendar);
			pushUp = FindViewById<RelativeLayout>(Resource.Id.pushUp);
			textView = FindViewById<TextView>(Resource.Id.TextView);
			button = FindViewById<Button>(Resource.Id.Button);
			addButton = FindViewById<Button>(Resource.Id.AddButton);
			editButton = FindViewById<Button>(Resource.Id.EditButton);
			deleteButton = FindViewById<Button>(Resource.Id.DeleteButton);


			// for vertical scrolling set Orientation
			calendar.Orientation = CalendarOrientation.Horizontal;

			// set maximum selected days
			calendar.MaxSelectionCount = 1;

			deleteButton.Click += (sender, e) =>
			{
				
			};

			calendar.SelectionChanged += (object sender, CalendarSelectionChangedEventArgs e) =>
			{
				(ViewModel as FirstViewModel).DayModel = calendar.SelectedDate.Day;
				(ViewModel as FirstViewModel).MonthModel = calendar.SelectedDate.Month;
				(ViewModel as FirstViewModel).YearModel = calendar.SelectedDate.Year;
				for (int i = 0; i < records.Count; i++)
				{
					if (records[i].Year == calendar.SelectedDate.Year)
					{
						if (records[i].Month == calendar.SelectedDate.Month)
						{
							if (records[i].Day == calendar.SelectedDate.Day)
							{
								textView.Visibility = ViewStates.Gone;
								calendar.Visibility = ViewStates.Invisible;
								pushUp.Visibility = ViewStates.Visible;
								return;
							}
						}
					}
				}
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

			String Year = e.Date.ToString().Split(' ')[5];
			String Month = e.Date.ToString().Split(' ')[1];
			int intMonth = 0;

			// add weather image for certain days
			for (int i = 0; i < records.Count; i++)
			{
				if (records[i].Year.ToString() == Year)
				{
					switch (Month)
					{
						case "Jan":
							intMonth = 1;
							break;
						case "Feb":
							intMonth = 2;
							break;
						case "Mar":
							intMonth = 3;
							break;
						case "Apr":
							intMonth = 4;
							break;
						case "May":
							intMonth = 5;
							break;
						case "Jun":
							intMonth = 6;
							break;
						case "Jul":
							intMonth = 7;
							break;
						case "Aug":
							intMonth = 8;
							break;
						case "Sep":
							intMonth = 9;
							break;
						case "Okt":
							intMonth = 10;
							break;
						case "Now":
							intMonth = 11;
							break;
						case "Dec":
							intMonth = 12;
							break;
						default:
							break;
					}
					if (records[i].Month == intMonth)
					{
						if (day == records[i].Day)
						{
							layout.SetBackgroundColor(Android.Graphics.Color.Green);
						}
					}				
				}
			}

			// finally, set layout to day slot
			e.DaySlot = layout;
		}
	}
}
