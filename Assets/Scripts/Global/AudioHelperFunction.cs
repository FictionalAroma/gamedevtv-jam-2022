using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts.Global
{
    static class AudioHelperFunction
    {
        public delegate void CoroutineFinishedEvent();

        // i stole this method from a unity blog
        //https://johnleonardfrench.com/how-to-fade-audio-in-unity-i-tested-every-method-this-ones-the-best/
        //added the deligate tho
        public static IEnumerator StartFade(AudioSource audioSource, float duration, float targetVolume, CoroutineFinishedEvent finishedEvent)
        {
            float currentTime = 0;
            float start = audioSource.volume;
            while (currentTime < duration)
            {
                currentTime += Time.deltaTime;
                audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
                yield return null;
            }

            finishedEvent?.Invoke();

            yield break;
        }
    }
}
