using System;
using UnityEngine;

namespace Assets.Source.Effects
{
    [Serializable]
    public class ShakeSettings
    {
        public float Frequency = 46 * Mathf.PI / 2;
        public float MinAmplitude = 0.1f;
        public int NoisePeriod1 = 17;
        public int NoisePeriod2 = 23;
        public float AngleRange = Mathf.PI;
        public float NoiseMagnitude = 0.1f;
    }
}