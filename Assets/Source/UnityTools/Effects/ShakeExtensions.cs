using System.Collections;
using UnityEngine;

namespace Assets.Source.Effects
{
    public static class ShakeExtensions
    {
        //Default Settings
        //46 oscillations per second
        public static float Frequency = 46 * Mathf.PI / 2;
        public static float MinAmplitude = 0.1f;
        public static int NoisePeriod1 = 17;
        public static int NoisePeriod2 = 23;
        public static float AngleRange = Mathf.PI;
        public static float NoiseMagnitude = 0.1f;

        public static IEnumerator Shake(GameObject gameObject, float magnitude, float durationSeconds, bool useScaledTime = false)
        {
            if (Mathf.Approximately(0, magnitude) || Mathf.Approximately(0, durationSeconds))
            {
                yield break;
            }

            var relativePosition = Vector3.zero;
            var dampingFactor = CalculateDampingFactor(durationSeconds);
            var startTime = GetCurrentTime(useScaledTime);

            while (GetCurrentTime(useScaledTime) - startTime < durationSeconds)
            {
                var elapsedTime = GetCurrentTime(useScaledTime) - startTime;

                var curveValue = GetPositionOnCurve(elapsedTime, elapsedTime, dampingFactor);
                var newRelativePosition = ApplyShake(gameObject, curveValue, relativePosition, magnitude, AngleRange);

                relativePosition = newRelativePosition;

                yield return null;
            }

            gameObject.transform.localPosition -= relativePosition;
        }
        public static IEnumerator Shake(GameObject gameObject, ShakeController controller, ShakeSettings settings)
        {
            controller.Completed = false;

            if (!controller.Continuous && Mathf.Approximately(0, controller.FadeOutTime))
            {
                controller.Completed = true;
                yield break;
            }

            var relativePosition = Vector3.zero;
            var fadeStart = GetCurrentTime(controller.UseScaledTime);
            var startTime = GetCurrentTime(controller.UseScaledTime);

            while (controller.Continuous || GetCurrentTime(controller.UseScaledTime) - fadeStart < controller.FadeOutTime)
            {
                if (controller.Continuous) fadeStart = GetCurrentTime(controller.UseScaledTime);
                var dampingFactor = CalculateDampingFactor(controller.FadeOutTime, settings);
                var elapsedTime = GetCurrentTime(controller.UseScaledTime) - startTime;
                var fadeTime = GetCurrentTime(controller.UseScaledTime) - fadeStart;

                var curveValue = GetPositionOnCurve(elapsedTime, fadeTime, dampingFactor, settings);
                var newRelativePosition = ApplyShake(gameObject, curveValue, relativePosition, controller.Magnitude, settings.AngleRange);

                relativePosition = newRelativePosition;

                yield return null;
            }

            gameObject.transform.localPosition -= relativePosition;
            controller.Completed = true;
        }

        private static Vector3 ApplyShake(GameObject gameObject, float curveValue, Vector3 relativePosition, float magnitude, float angleRange)
        {
            var angle = curveValue*angleRange;
            var shakeVector = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0.0f)*(magnitude/100f);
            var newRelativePosition = shakeVector*curveValue;

            gameObject.transform.localPosition += newRelativePosition - relativePosition;
            return newRelativePosition;
        }

        private static float GetCurrentTime(bool useScaledTime)
        {
            return useScaledTime ? Time.time : Time.unscaledTime;
        }

        private static float GetPositionOnCurve(float elapsedTime, float fadeTime, float dampingFactor, ShakeSettings settings = null)
        {
            var frequency = settings == null ? Frequency : settings.Frequency;
            var noisePeriod1 = settings == null ? NoisePeriod1 : settings.NoisePeriod1;
            var noisePeriod2 = settings == null ? NoisePeriod2 : settings.NoisePeriod2;
            var noiseMagnitude = settings == null ? NoiseMagnitude : settings.NoiseMagnitude;

            var t = elapsedTime * frequency;
            var tF = fadeTime * frequency;

            //Curve defined as (cos(t) + (cos(t*p1) + cos(t*p2)) * nM)/((t*t) / d + 1))
            //cos(t) for basic spring effect
            //+ (cos(t*p1) + cos(t*p2)) * nM adds two curves onto the orignal to create noise with p1/p2 controling their period and nM their magnitude
            //((t*t) / d) + 1) dampens the curve over time with d controling the strength of the dampening effect and + 1 preventing a divide by 0

            var damping = tF * tF / dampingFactor + 1;
            var x = (Mathf.Cos(t) + (Mathf.Cos(t * noisePeriod1) + Mathf.Cos(t * noisePeriod2)) * noiseMagnitude) / damping;

            return x;
        }

        private static float CalculateDampingFactor(float durationSeconds, ShakeSettings settings = null)
        {
            var minAmplitude = settings == null ? MinAmplitude : settings.MinAmplitude;
            var frequency = settings == null ? Frequency : settings.Frequency;
            var tAtLastPeak = (durationSeconds - Mathf.PI / 2) * frequency;

            var tSquared = tAtLastPeak * tAtLastPeak;
            return (tSquared / Mathf.Abs(1 + (Mathf.Cos(tAtLastPeak) / minAmplitude)));
        }
    }
}