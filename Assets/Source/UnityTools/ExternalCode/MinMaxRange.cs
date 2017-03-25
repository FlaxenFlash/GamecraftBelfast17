using UnityEngine;

namespace Assets.Source.ExternalCode
{
    [System.Serializable]
    public class MinMaxRange
    {
        public float rangeStart, rangeEnd;

        public float GetRandomValue()
        {
            return Random.Range(rangeStart, rangeEnd);
        }
        public float GetInterpolatedValue(float fraction)
        {
			return Mathf.Lerp(rangeStart, rangeEnd, fraction);
        }
    }
}