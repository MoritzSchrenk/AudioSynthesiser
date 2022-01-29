namespace AudioSynthesiser.Model
{
    public abstract class SynthComponent
    {
        private bool _enabled;
        protected SynthComponent(bool enabled)
        {
            _enabled = enabled;
        }

        public bool IsEnabled() => _enabled;
    }
}
