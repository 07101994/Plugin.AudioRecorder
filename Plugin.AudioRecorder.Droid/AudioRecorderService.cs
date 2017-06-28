﻿using Android.Content;
using Android.Media;
using System.IO;

namespace Plugin.AudioRecorder
{
	public partial class AudioRecorderService
	{
        partial void Init()
        {
            filePath = Path.Combine(Path.GetTempPath(), RecordingFileName);

            if (Android.OS.Build.VERSION.SdkInt > Android.OS.BuildVersionCodes.JellyBean)
			{
				var audioManager = (AudioManager)Android.App.Application.Context.GetSystemService (Context.AudioService);
				var property = audioManager.GetProperty (AudioManager.PropertyOutputSampleRate);

				int sampleRate;

				if (!string.IsNullOrEmpty (property) && int.TryParse (property, out sampleRate))
				{
					System.Diagnostics.Debug.WriteLine ($"Setting PreferredSampleRate to {sampleRate} as reported by AudioManager.PropertyOutputSampleRate");
					PreferredSampleRate = sampleRate;
				}
			}
		}
	}
}