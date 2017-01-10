using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using Com.GrapeCity.Xuni.Calendar;
using Com.GrapeCity.Xuni.Core;
using HelloMvx4.Core.ViewModels;
using Java.Interop;
using Java.Text;
using Java.Util;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Droid.Views;


namespace HelloMvx4.Droid.Views
{
	[Activity(Label = "View for FirstViewModel", Theme = "@style/MyTheme")]
	public class FirstView : MvxActivity
	{
		XuniCalendar calendar;
		List<CalRecord> records = new List<CalRecord>();
		TextView SoonViewName;
		TextView SoonViewTime;
		TextView SoonViewMore;
		Button button;
		AlarmManager am;
		Toolbar toolbar;

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			LicenseManager.Key = License.Key;
			SetContentView(Resource.Layout.FirstView);

			am = GetSystemService(AlarmService).JavaCast<AlarmManager>();

			string date;
			for (int i = 0; i < (ViewModel as FirstViewModel).getRecordsCount(); i++)
			{
				date = (ViewModel as FirstViewModel).getRecordDate(i);
				records.Add(new CalRecord(date.Split('/')[0],
				                          date.Split('/')[1],
				                          date.Split('/')[2]));
			}

			// get chart from view
			calendar = FindViewById<XuniCalendar>(Resource.Id.calendar);
			button = FindViewById<Button>(Resource.Id.invisibleButton);
			SoonViewName = FindViewById<TextView>(Resource.Id.SoonEventName);
			SoonViewTime = FindViewById<TextView>(Resource.Id.SoonEventTime);
			SoonViewMore = FindViewById<TextView>(Resource.Id.SoonEventMore);
			if ((ViewModel as FirstViewModel).record != null)
			{
				SoonViewName.Text = (ViewModel as FirstViewModel).record.Name;
				SoonViewTime.Text = (ViewModel as FirstViewModel).record.RecordDate + " " + (ViewModel as FirstViewModel).record.Hour + ":" + (ViewModel as FirstViewModel).record.Min;
				SoonViewMore.Text = (ViewModel as FirstViewModel).record.More;
			}


			// for vertical scrolling set Orientation
			calendar.Orientation = CalendarOrientation.Horizontal;
			calendar.FirstDayOfWeek = Com.GrapeCity.Xuni.Calendar.DayOfWeek.Monday;

			// set maximum selected days
			calendar.MaxSelectionCount = 1;

			calendar.SelectionChanged += (object sender, CalendarSelectionChangedEventArgs e) =>
			{
				bool a = false;
				for (int i = 0; i < records.Count; i++)
				{
					date = (ViewModel as FirstViewModel).getRecordDate(i);
					if (calendar.SelectedDate.Day.ToString() == date.Split('/')[0] &&
					    calendar.SelectedDate.Month.ToString() == date.Split('/')[1] &&
					    calendar.SelectedDate.Year.ToString() == date.Split('/')[2])
					{
						a = true;
						showPopupMenu(i);
					}
				}

				if (!a) {
					(ViewModel as FirstViewModel).DayModel = calendar.SelectedDate.Day;
					(ViewModel as FirstViewModel).MonthModel = calendar.SelectedDate.Month;
					(ViewModel as FirstViewModel).YearModel = calendar.SelectedDate.Year;
					(ViewModel as FirstViewModel).MyButtonCommand.Execute();
				}

			};

			// change appearance
			calendar.DaySlotLoading += Calendar_DaySlotLoading;
			calendar.SelectionBackgroundColor = Android.Graphics.Color.White;

			toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
			SetActionBar(toolbar);

			ActionBar.Title = "Календарь";

		}

		private void showPopupMenu(int i)
		{
			PopupMenu popupMenu = new PopupMenu(this, button);
			popupMenu.Inflate(Resource.Menu.popupmenu);
			popupMenu.MenuItemClick += (sender, e) =>
			{
				int indexIndent = calendar.SelectedDate.Day * 1000000 + calendar.SelectedDate.Month * 10000 + calendar.SelectedDate.Year;
				var alarmIntent = new Intent(this, typeof(Alarm));
				var pending = PendingIntent.GetBroadcast(this, indexIndent, alarmIntent, PendingIntentFlags.UpdateCurrent);
				am.Cancel(pending);
				if (e.Item.TitleFormatted.ToString() == "Удалить")
				{
					records.RemoveAt(i);
					(ViewModel as FirstViewModel).deleteRecord(i);
					(ViewModel as FirstViewModel).setSoonView();
					if ((ViewModel as FirstViewModel).record != null)
					{
						SoonViewName.Text = (ViewModel as FirstViewModel).record.Name;
						SoonViewTime.Text = (ViewModel as FirstViewModel).record.RecordDate + " " + (ViewModel as FirstViewModel).record.Hour + ":" + (ViewModel as FirstViewModel).record.Min;
						SoonViewMore.Text = (ViewModel as FirstViewModel).record.More;
					}
					if ((ViewModel as FirstViewModel).getRecordsCount() == 0)
					{
						SoonViewName.Text = "";
						SoonViewTime.Text = "";
						SoonViewMore.Text = "";
					}
				}
				else
				{
					(ViewModel as FirstViewModel).setRecordObject(i);
					(ViewModel as FirstViewModel).MyButtonCommand1.Execute();
				}
			};

			popupMenu.DismissEvent += (sender, e) =>
			{
				calendar.Selected = false;
				Console.WriteLine("menu dismissed");
			};

			popupMenu.Show();
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
			layout.SetBackgroundColor(Android.Graphics.Color.White);
			layout.SetPadding(5, 5, 5, 5);
			LinearLayout.LayoutParams linearLayoutParams1 = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.FillParent, LinearLayout.LayoutParams.FillParent);
			layout.LayoutParameters = linearLayoutParams1;

			// create text element
			TextView tv = new TextView(ApplicationContext);
			LinearLayout.LayoutParams linearLayoutParams = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MatchParent, LinearLayout.LayoutParams.WrapContent);
			tv.LayoutParameters = linearLayoutParams;
			tv.Gravity = GravityFlags.Center;   //текст цифр
			tv.Text = day.ToString();
			tv.SetTextColor(Android.Graphics.Color.Black);


			if (e.AdjacentDay)
			{
				// format adjacent day text
				tv.SetTextColor(Android.Graphics.Color.Gray); //цвет неактивных дней
			}

			// add text element to layout
			layout.AddView(tv);

			String Year = e.Date.ToString().Split(' ')[5];
			String Month = e.Date.ToString().Split(' ')[1];
			string intMonth = "0";

			// add weather image for certain days
			for (int i = 0; i < records.Count; i++)
			{
				if (records[i].Year == Year)
				{
					switch (Month)
					{
						case "Jan":
							intMonth = "1";
							break;
						case "Feb":
							intMonth = "2";
							break;
						case "Mar":
							intMonth = "3";
							break;
						case "Apr":
							intMonth = "4";
							break;
						case "May":
							intMonth = "5";
							break;
						case "Jun":
							intMonth = "6";
							break;
						case "Jul":
							intMonth = "7";
							break;
						case "Aug":
							intMonth = "8";
							break;
						case "Sep":
							intMonth = "9";
							break;
						case "Okt":
							intMonth = "10";
							break;
						case "Now":
							intMonth = "11";
							break;
						case "Dec":
							intMonth = "12";
							break;
						default:
							break;
					}

					if (records[i].Month == intMonth && day.ToString() == records[i].Day)
					{
						layout.SetBackgroundColor(Android.Graphics.Color.LightBlue);
					}
				}
			}

			// finally, set layout to day slot
			e.DaySlot = layout;
		}
	}
}
