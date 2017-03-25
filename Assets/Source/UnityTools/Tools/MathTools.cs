using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Source.Tools
{
    public static class MathTools
    {
	    public static bool ApproximatelyEqualTo(this float mainValue, float value)
	    {
		    return Mathf.Approximately(mainValue, value);
	    }

        public static float GetAngleBetweenVectors(Vector3 a, Vector3 b)
        {
            return Vector3.Angle(a, b);
        }
        public static T ChooseRandomObject<T>(List<T> objects, Func<T, float> getWeighting)
        {
            if (objects == null)
            {
                Debug.LogError("Tried to choose random object from null list");
                return default(T);
            }
            float totalWeight = 0;
            foreach (var o in objects)
            {
                totalWeight += getWeighting.Invoke(o);
            }

            var pickedValue = Random.Range(0f, totalWeight);

            if (totalWeight == 0)
                return default(T);

            totalWeight = 0;
            foreach (var o in objects)
            {
                totalWeight += Mathf.Abs(getWeighting.Invoke(o));
                if (totalWeight >= pickedValue)
                    return o;
            }
            return default(T);
        }
        public static T ChooseRandomObject<T>(List<T> objects)
        {
            return ChooseRandomObject(objects, x => 1);
        }
    }
}
