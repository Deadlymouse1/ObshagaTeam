package md5df95e84fad9ebfbb08b2d808e3008025;


public class CSharpObservableList
	extends com.grapecity.xuni.core.ObservableList
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Xuni.Android.Core.CSharpObservableList, Xuni.Android.Core, Version=2.3.20163.151, Culture=neutral, PublicKeyToken=null", CSharpObservableList.class, __md_methods);
	}


	public CSharpObservableList () throws java.lang.Throwable
	{
		super ();
		if (getClass () == CSharpObservableList.class)
			mono.android.TypeManager.Activate ("Xuni.Android.Core.CSharpObservableList, Xuni.Android.Core, Version=2.3.20163.151, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

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
