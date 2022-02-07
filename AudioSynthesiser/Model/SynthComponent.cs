namespace AudioSynthesiser.Model
{
    /// <summary>
    /// A component that can be turned on or off
    /// </summary>
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
