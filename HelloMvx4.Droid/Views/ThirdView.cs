using Java.IO;
using Android.App;
using Android.OS;
using Android.Widget;
using MvvmCross.Droid.Views;
using Android.Media;
using System.Collections.Generic;
using HelloMvx4.Core.ViewModels;

namespace HelloMvx4.Droid.Views
{
	[Activity(Label = "View for ThirdView")]
	public class ThirdView : MvxActivity
	{
		Button fileDialog;
		ListView listAudio;
		MediaPlayer _player = new MediaPlayer();
		List<string> AudioList = new List<string>();
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			SetContentView(Resource.Layout.ThirdView);
			listAudio = FindViewById<ListView>(Resource.Id.audioView);

			AudioList.Add("aaaa");
			AudioList.Add("bbbb");
			AudioList.Add("cccc");
			AudioList.Add("dddd");

			ArrayAdapter<string> adapter = new ArrayAdapter<string>(this,Android.Resource.Layout.SimpleListItem1, AudioList);
			listAudio.Adapter = adapter;

			listAudio.ItemClick += (object sender, AdapterView.ItemClickEventArgs e) =>
			{
				if (e.Position == 0)
				{
					_player.Stop();
					_player = MediaPlayer.Create(this, Resource.Raw.sound);
					_player.Start();
					(ViewModel as ThirdViewModel).record.SoundId = Resource.Raw.sound;
				}
				else if (e.Position == 1)
				{
					_player.Stop();
					_player = MediaPlayer.Create(this, Resource.Raw.sound1);
					_player.Start();
					(ViewModel as ThirdViewModel).record.SoundId = Resource.Raw.sound1;
				}
				else if (e.Position == 2)
				{
					_player.Stop();
					_player = MediaPlayer.Create(this, Resource.Raw.sound2);
					_player.Start();
					(ViewModel as ThirdViewModel).record.SoundId = Resource.Raw.sound2;
				}
				else if (e.Position == 3)
				{
					_player.Stop();
					_player = MediaPlayer.Create(this, Resource.Raw.sound3);
					_player.Start();
					(ViewModel as ThirdViewModel).record.SoundId = Resource.Raw.sound3;
				}
			}; 

			fileDialog = FindViewById<Button>(Resource.Id.musicButton1);

			fileDialog.Click += (sender, e) =>
			{
				_player.Stop();
				(ViewModel as ThirdViewModel).MyButtonCommand.Execute();
			};



			// Create your application here
		}
	}
}
