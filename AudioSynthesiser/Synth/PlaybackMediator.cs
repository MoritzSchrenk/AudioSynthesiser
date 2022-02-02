using System;

namespace AudioSynthesiser.Synth
{
    public static class PlaybackMediator
    {
        public static event Action StopPlaying;
        public static void OnStopPlaying() => StopPlaying?.Invoke();

        public static event Action StartPlaying;
        public static void OnStartPlaying() => StartPlaying?.Invoke();
    }
}
