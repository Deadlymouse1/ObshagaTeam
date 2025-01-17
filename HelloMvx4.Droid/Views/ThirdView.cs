﻿using Java.IO;
using Android.App;
using Android.OS;
using Android.Widget;
using MvvmCross.Droid.Views;
using Android.Media;
using System.Collections.Generic;
using HelloMvx4.Core.ViewModels;

namespace HelloMvx4.Droid.Views
{
	[Activity(Label = "View for ThirdView", Theme = "@style/MyTheme")]
	public class ThirdView : MvxActivity
	{
		Button fileDialog;
		ListView listAudio;
		MediaPlayer _player = new MediaPlayer();
		List<string> AudioList = new List<string>();
		Toolbar toolbar;
		public new ThirdViewModel ViewModel { get { return base.ViewModel as ThirdViewModel; } }

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			SetContentView(Resource.Layout.ThirdView);
			listAudio = FindViewById<ListView>(Resource.Id.audioView);

			AudioList.Add("Dead By April - What Can I Say ");
			AudioList.Add("Skillet - Comatose");
			AudioList.Add("Three Days Grace - Last to Know");
			AudioList.Add("Руки Вверх - Забери Ключи");

			ArrayAdapter<string> adapter = new ArrayAdapter<string>(this,Android.Resource.Layout.SimpleListItem1, AudioList);
			listAudio.Adapter = adapter;

			listAudio.ItemClick += (object sender, AdapterView.ItemClickEventArgs e) =>
			{
				if (e.Position == 0)
				{
					_player.Stop();
					_player = MediaPlayer.Create(this, Resource.Raw.sound);
					_player.Start();
					ViewModel.record.Sound = "Dead By April - What Can I Say";
					ViewModel.record.SoundId = 0;
				}
				else if (e.Position == 1)
				{
					_player.Stop();
					_player = MediaPlayer.Create(this, Resource.Raw.sound1);
					_player.Start();
					ViewModel.record.Sound = "Skillet - Comatose";
					ViewModel.record.SoundId = 1;
				}
				else if (e.Position == 2)
				{
					_player.Stop();
					_player = MediaPlayer.Create(this, Resource.Raw.sound2);
					_player.Start();
					ViewModel.record.Sound = "Three Days Grace - Last to Know";
					ViewModel.record.SoundId = 2;
				}
				else if (e.Position == 3)
				{
					_player.Stop();
					_player = MediaPlayer.Create(this, Resource.Raw.sound3);
					_player.Start();
					ViewModel.record.Sound = "Руки Вверх - Забери Ключи";
					ViewModel.record.SoundId = 3;
				}
			}; 

			fileDialog = FindViewById<Button>(Resource.Id.musicButton1);

			fileDialog.Click += (sender, e) =>
			{
				_player.Stop();
				ViewModel.MyButtonCommand.Execute();
			};

			toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
			SetActionBar(toolbar);

			ActionBar.Title = "Выбор музыки";



			// Create your application here
		}

	}
}
