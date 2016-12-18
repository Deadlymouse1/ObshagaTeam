package md52df133c3acfbbfe8c099d3e9c8947c9a;


public class XuniCalendar
	extends com.grapecity.xuni.calendar.XuniCalendar
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onDaySlotLoading:(Lcom/grapecity/xuni/calendar/CalendarDaySlotLoadingEventArgs;)V:GetOnDaySlotLoading_Lcom_grapecity_xuni_calendar_CalendarDaySlotLoadingEventArgs_Handler\n" +
			"n_onDisplayModeChanged:(Lcom/grapecity/xuni/core/EventArgs;)V:GetOnDisplayModeChanged_Lcom_grapecity_xuni_core_EventArgs_Handler\n" +
			"n_onDisplayDateChanged:(Lcom/grapecity/xuni/core/EventArgs;)V:GetOnDisplayDateChanged_Lcom_grapecity_xuni_core_EventArgs_Handler\n" +
			"n_onDisplayDateChanging:(Lcom/grapecity/xuni/core/EventArgs;)V:GetOnDisplayDateChanging_Lcom_grapecity_xuni_core_EventArgs_Handler\n" +
			"n_onYearSlotLoading:(Lcom/grapecity/xuni/calendar/CalendarYearSlotLoadingEventArgs;)V:GetOnYearSlotLoading_Lcom_grapecity_xuni_calendar_CalendarYearSlotLoadingEventArgs_Handler\n" +
			"n_onMonthSlotLoading:(Lcom/grapecity/xuni/calendar/CalendarMonthSlotLoadingEventArgs;)V:GetOnMonthSlotLoading_Lcom_grapecity_xuni_calendar_CalendarMonthSlotLoadingEventArgs_Handler\n" +
			"n_onDayOfWeekSlotLoading:(Lcom/grapecity/xuni/calendar/CalendarDayOfWeekSlotLoadingEventArgs;)V:GetOnDayOfWeekSlotLoading_Lcom_grapecity_xuni_calendar_CalendarDayOfWeekSlotLoadingEventArgs_Handler\n" +
			"n_onSelectionChanging:(Lcom/grapecity/xuni/calendar/CalendarSelectionChangingEventArgs;)V:GetOnSelectionChanging_Lcom_grapecity_xuni_calendar_CalendarSelectionChangingEventArgs_Handler\n" +
			"n_onSelectionChanged:(Lcom/grapecity/xuni/calendar/CalendarSelectionChangedEventArgs;)V:GetOnSelectionChanged_Lcom_grapecity_xuni_calendar_CalendarSelectionChangedEventArgs_Handler\n" +
			"n_onHeaderLoading:(Lcom/grapecity/xuni/calendar/CalendarHeaderLoadingEventArgs;)V:GetOnHeaderLoading_Lcom_grapecity_xuni_calendar_CalendarHeaderLoadingEventArgs_Handler\n" +
			"n_onRendered:()V:GetOnRenderedHandler\n" +
			"";
		mono.android.Runtime.register ("Com.GrapeCity.Xuni.Calendar.XuniCalendar, Xuni.Android.Calendar, Version=2.3.20163.151, Culture=neutral, PublicKeyToken=null", XuniCalendar.class, __md_methods);
	}


	public XuniCalendar (android.content.Context p0) throws java.lang.Throwable
	{
		super (p0);
		if (getClass () == XuniCalendar.class)
			mono.android.TypeManager.Activate ("Com.GrapeCity.Xuni.Calendar.XuniCalendar, Xuni.Android.Calendar, Version=2.3.20163.151, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
	}


	public XuniCalendar (android.content.Context p0, android.util.AttributeSet p1) throws java.lang.Throwable
	{
		super (p0, p1);
		if (getClass () == XuniCalendar.class)
			mono.android.TypeManager.Activate ("Com.GrapeCity.Xuni.Calendar.XuniCalendar, Xuni.Android.Calendar, Version=2.3.20163.151, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:Android.Util.IAttributeSet, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0, p1 });
	}


	public void onDaySlotLoading (com.grapecity.xuni.calendar.CalendarDaySlotLoadingEventArgs p0)
	{
		n_onDaySlotLoading (p0);
	}

	private native void n_onDaySlotLoading (com.grapecity.xuni.calendar.CalendarDaySlotLoadingEventArgs p0);


	public void onDisplayModeChanged (com.grapecity.xuni.core.EventArgs p0)
	{
		n_onDisplayModeChanged (p0);
	}

	private native void n_onDisplayModeChanged (com.grapecity.xuni.core.EventArgs p0);


	public void onDisplayDateChanged (com.grapecity.xuni.core.EventArgs p0)
	{
		n_onDisplayDateChanged (p0);
	}

	private native void n_onDisplayDateChanged (com.grapecity.xuni.core.EventArgs p0);


	public void onDisplayDateChanging (com.grapecity.xuni.core.EventArgs p0)
	{
		n_onDisplayDateChanging (p0);
	}

	private native void n_onDisplayDateChanging (com.grapecity.xuni.core.EventArgs p0);


	public void onYearSlotLoading (com.grapecity.xuni.calendar.CalendarYearSlotLoadingEventArgs p0)
	{
		n_onYearSlotLoading (p0);
	}

	private native void n_onYearSlotLoading (com.grapecity.xuni.calendar.CalendarYearSlotLoadingEventArgs p0);


	public void onMonthSlotLoading (com.grapecity.xuni.calendar.CalendarMonthSlotLoadingEventArgs p0)
	{
		n_onMonthSlotLoading (p0);
	}

	private native void n_onMonthSlotLoading (com.grapecity.xuni.calendar.CalendarMonthSlotLoadingEventArgs p0);


	public void onDayOfWeekSlotLoading (com.grapecity.xuni.calendar.CalendarDayOfWeekSlotLoadingEventArgs p0)
	{
		n_onDayOfWeekSlotLoading (p0);
	}

	private native void n_onDayOfWeekSlotLoading (com.grapecity.xuni.calendar.CalendarDayOfWeekSlotLoadingEventArgs p0);


	public void onSelectionChanging (com.grapecity.xuni.calendar.CalendarSelectionChangingEventArgs p0)
	{
		n_onSelectionChanging (p0);
	}

	private native void n_onSelectionChanging (com.grapecity.xuni.calendar.CalendarSelectionChangingEventArgs p0);


	public void onSelectionChanged (com.grapecity.xuni.calendar.CalendarSelectionChangedEventArgs p0)
	{
		n_onSelectionChanged (p0);
	}

	private native void n_onSelectionChanged (com.grapecity.xuni.calendar.CalendarSelectionChangedEventArgs p0);


	public void onHeaderLoading (com.grapecity.xuni.calendar.CalendarHeaderLoadingEventArgs p0)
	{
		n_onHeaderLoading (p0);
	}

	private native void n_onHeaderLoading (com.grapecity.xuni.calendar.CalendarHeaderLoadingEventArgs p0);


	public void onRendered ()
	{
		n_onRendered ();
	}

	private native void n_onRendered ();

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
