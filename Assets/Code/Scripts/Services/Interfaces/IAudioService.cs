using System;
using UnityEngine;

namespace Game.Interfaces.Services
{
    /// <summary>
    /// Interface for managing audio in the game.
    /// </summary>
    public interface IAudioService
    {
        /// <summary>
        /// Gets or sets the master volume.
        /// </summary>
        float MasterVolume { get; set; }

        /// <summary>
        /// Gets or sets whether the master audio is muted.
        /// </summary>
        bool MasterMuted { get; set; }

        /// <summary>
        /// Gets or sets the sound volume.
        /// </summary>
        float SoundVolume { get; set; }

        /// <summary>
        /// Gets or sets whether the sound audio is muted.
        /// </summary>
        bool SoundMuted { get; set; }

        /// <summary>
        /// Gets or sets the music volume.
        /// </summary>
        float MusicVolume { get; set; }

        /// <summary>
        /// Gets or sets whether the music audio is muted.
        /// </summary>
        bool MusicMuted { get; set; }

        /// <summary>
        /// Plays a sound effect.
        /// </summary>
        /// <param name="sound">The sound effect to play.</param>
        /// <param name="transform">The transform to play the sound effect from.</param>
        void PlaySound<T>(T sound, Transform transform = null) where T : Enum;

        /// <summary>
        /// Stops a sound effect.
        /// </summary>
        /// <param name="sound">The sound effect to stop.</param>
        /// <param name="transform">The transform to stop the sound effect from.</param>
        /// <param name="stopInstantly">Whether to stop the sound effect instantly.</param>
        void StopSound<T>(T sound, Transform transform = null, bool stopInstantly = true) where T : Enum;

        /// <summary>
        /// Plays a music track.
        /// </summary>
        /// <param name="music">The music track to play.</param>
        /// <param name="transform">The transform to play the music track from.</param>
        void PlayMusic<T>(T music, Transform transform = null) where T : Enum;

        /// <summary>
        /// Stops a music track.
        /// </summary>
        /// <param name="music">The music track to stop.</param>
        /// <param name="transform">The transform to stop the music track from.</param>
        /// <param name="stopInstantly">Whether to stop the music track instantly.</param>
        void StopMusic<T>(T music, Transform transform = null, bool stopInstantly = true) where T : Enum;
    }
}