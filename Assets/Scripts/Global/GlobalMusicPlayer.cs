using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Global;
using UnityEngine;

public class GlobalMusicPlayer : MonoBehaviour
{
    public AudioSource mainAudioSource;
    public AudioSource interuptTrack;

    public float defaultFadeSeconds;
    public bool defaultFade;

    [SerializeField]
    protected AudioClip currentClip;
    protected AudioClip CurrentPlayingTrack => currentClip;
    protected AudioClip _nextClip;
    protected AudioClip _interuptClip;

    protected float _nextTrackFadeSeconds;
    protected bool _nextTrackCrossfade;
    protected float _trackVolume;


    public void PlayNewAudio(AudioClip clip, bool fade = true, float fadeSeconds = 5f, bool crossfade = true)
    {
        

        if (fade)
        {
            _nextClip = clip;
            _nextTrackFadeSeconds = fadeSeconds;
            _nextTrackCrossfade = crossfade;
            _trackVolume = mainAudioSource.volume;

            StartCoroutine(AudioHelperFunction.StartFade(mainAudioSource, fadeSeconds, 0f, FadeoutFinishedEvent));
        }
        else
        {
            PlayNewTrackImmediate(clip);
        }
    }

    private void FadeoutFinishedEvent()
    {
        PlayNewTrackImmediate(_nextClip);
        StartCoroutine(AudioHelperFunction.StartFade(mainAudioSource, _nextTrackFadeSeconds, _trackVolume, null));
    }

    public void PlayNewTrackImmediate(AudioClip clip)
    {
        mainAudioSource.Stop();
        mainAudioSource.clip = clip;
        mainAudioSource.Play();
    }

    public void Pause() => mainAudioSource.Pause();

    public void Play()
    {
        if (mainAudioSource.time > 0f)
        {
            mainAudioSource.UnPause();
        }
        else
        {
            mainAudioSource.Play();
        }
    }
}
