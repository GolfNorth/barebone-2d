using UnityEngine;

namespace Game.Interfaces.Services
{
    public interface IAudioChannelHelper
    {
        bool Reversed { get; set; }
        float Volume { get; set; }
        AudioSource Play();
        void Stop(bool stopInstantly = true);
    }
}