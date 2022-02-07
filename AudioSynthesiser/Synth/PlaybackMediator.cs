using System;

namespace AudioSynthesiser.Synth
{
    /// <summary>
    /// Sends global start/stop playing events
    /// </summary>
    public static class PlaybackMediator
    {
        public static event Action StopPlaying;
        public static void OnStopPlaying() => StopPlaying?.Invoke();

        public static event Action StartPlaying;
        public static void OnStartPlaying() => StartPlaying?.Invoke();
    }
}
