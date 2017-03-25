using System;

namespace Assets.Source.Effects
{
    [Serializable]
    public class ShakeController
    {
        public float Magnitude;
        public bool Continuous = true;
        public float FadeOutTime;
        public bool UseScaledTime;
        [NonSerialized]
        public bool Completed = true;
    }
}