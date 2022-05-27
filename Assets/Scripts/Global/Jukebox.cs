using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Global
{
    public class Jukebox : GlobalMusicPlayer
    {
        private List<AudioClip> TrackList;

        private int _trackIndex;

        public void SetTracks(IEnumerable<AudioClip> audioClips, bool playImmediate = false)
        {
            TrackList.Clear();
            TrackList.AddRange(audioClips);
            _trackIndex = 0;
            if (playImmediate)
            {
                PlayNextTrack();
            }
        }

        public void PlayNextTrack()
        {
            if (_trackIndex >= TrackList.Count)
            {
                _trackIndex = 0;
            }
            else
            {
                _trackIndex++;
            }

            PlayNewAudio(TrackList[_trackIndex]);
        }

        public void LateUpdate()
        {
            if (currentClip.length - (defaultFadeSeconds*1.5f) > mainAudioSource.time)
            {
                PlayNextTrack();
            }
        }
    }
}
