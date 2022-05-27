using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Global;
using UnityEngine;
using UnityEngine.Serialization;

namespace Assets.Scripts.TimeManagement
{
    public class TimeManagement : MonoBehaviour
    {
        public List<TimeOfDayValues> daySegments;

        public Jukebox jukebox;

        private float _currentTimeSegmentTimer;
        private int dayTimeIndex = 0;
        private TimeOfDayValues currentDayValues;


        public void LateUpdate()
        {
            _currentTimeSegmentTimer += Time.deltaTime;
            if (_currentTimeSegmentTimer > currentDayValues.timeLength)
            {
                dayTimeIndex++;
                if (dayTimeIndex < daySegments.Count)
                {
                    dayTimeIndex = 0;
                }

                currentDayValues = daySegments[dayTimeIndex];
                ActivateTimeChange(currentDayValues);
            }
        }


        private void ActivateTimeChange(TimeOfDayValues newDayValues)
        {
            if (newDayValues.musicTracks.Any())
            {
                jukebox.SetTracks(newDayValues.musicTracks, newDayValues.playNewTrackImmediately);
            }
            //todo lucy do Light
            // todo lucy do UI
        }
    }
}
