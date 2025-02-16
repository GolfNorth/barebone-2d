using System;
using Game.Interfaces.Services;
using JSAM;
using UnityEngine;
using VContainer;

namespace Game.Services
{
    /// <summary>
    /// Implementation of IAudioService
    /// </summary>
    [Preserve]
    // ReSharper disable once ClassNeverInstantiated.Global
    public class AudioService : IAudioService
    {
        public float MasterVolume
        {
            get => AudioManager.MasterVolume;
            set => AudioManager.MasterVolume = value;
        }

        public bool MasterMuted
        {
            get => AudioManager.MasterMuted;
            set => AudioManager.MasterMuted = value;
        }

        public float SoundVolume
        {
            get => AudioManager.SoundVolume;
            set => AudioManager.SoundVolume = value;
        }

        public bool SoundMuted
        {
            get => AudioManager.SoundMuted;
            set => AudioManager.SoundMuted = value;
        }

        public float MusicVolume
        {
            get => AudioManager.MusicVolume;
            set => AudioManager.MusicVolume = value;
        }

        public bool MusicMuted
        {
            get => AudioManager.MusicMuted;
            set => AudioManager.MusicMuted = value;
        }

        public void PlaySound<T>(T sound, Transform transform = null) where T : Enum
        {
            AudioManager.PlaySound(sound, transform);
        }

        public void StopSound<T>(T sound, Transform transform = null, bool stopInstantly = true) where T : Enum
        {
            AudioManager.StopSound(sound, transform, stopInstantly);
        }

        public void PlayMusic<T>(T music, Transform transform = null) where T : Enum
        {
            AudioManager.PlayMusic(music, transform);
        }

        public void StopMusic<T>(T music, Transform transform = null, bool stopInstantly = true) where T : Enum
        {
            AudioManager.StopMusic(music, transform, stopInstantly);
        }
        
    }
}