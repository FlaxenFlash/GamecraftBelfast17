using System;
using System.Collections;
using UnityEngine;

public static class ComponentExtensions
{
	public static Coroutine RunWhenTrue(this MonoBehaviour component, Func<bool> condition, Action action)
	{
		if (component.isActiveAndEnabled)
			return component.StartCoroutine(DelayAction(condition, action));

	    Debug.LogWarning("Can't start Coroutine on in active object: " + component);
	    return null;
	}

    private static IEnumerator DelayAction(Func<bool> condition, Action action)
    {
        yield return new WaitUntil(condition);

        action.Invoke();
    }

	public static Coroutine RunDelayedAction(this MonoBehaviour component, float delayInSeconds, Action action)
	{
		if (component.isActiveAndEnabled)
			return component.StartCoroutine(DelayAction(delayInSeconds, action));

	    Debug.LogWarning("Can't start Coroutine on in active object: " + component);
	    return null;
	}

	private static IEnumerator DelayAction(float delay, Action action, bool useUnscaledTime = true)
	{
        if(useUnscaledTime)
        {
            var startTime = Time.unscaledTime;
            yield return new WaitWhile(() => Time.unscaledTime - startTime < delay);
        }
        else yield return new WaitForSeconds(delay);

		action.Invoke();
	}
}