using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Global;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace Assets.Scripts.TimeManagement
{
    public class TimeManagement : MonoBehaviour
    {
        public List<TimeOfDayValues> daySegments;

        public Jukebox jukebox;

        private float _currentTimeSegmentTimer;
        private int _dayTimeIndex = 0;
        private TimeOfDayValues currentDayValues;

        public TextMeshProUGUI timeOfDayText;
        public TextMeshProUGUI debugText;
        public int dayNumber = 1;

        public void Start()
        {
            currentDayValues = daySegments[_dayTimeIndex];
            
            jukebox.SetTracks(currentDayValues.musicTracks, false, false);

            jukebox.PlayNewTrackImmediate(currentDayValues.musicTracks.FirstOrDefault(), true);


            SetDayText(currentDayValues);
            _currentTimeSegmentTimer = 0;
        }

        public void LateUpdate()
        {
            _currentTimeSegmentTimer += Time.deltaTime;
            if (_currentTimeSegmentTimer > currentDayValues.timeLength)
            {
                _dayTimeIndex++;
                if (_dayTimeIndex >= daySegments.Count)
                {
                    _dayTimeIndex = 0;
                    dayNumber++;
                }

                currentDayValues = daySegments[_dayTimeIndex];
                ActivateTimeChange(currentDayValues);
            }

            debugText.text = _currentTimeSegmentTimer.ToString("000");

        }


        private void ActivateTimeChange(TimeOfDayValues newDayValues, bool initialStart = false)
        {
            if (newDayValues.musicTracks.Any())
            {
                jukebox.SetTracks(newDayValues.musicTracks, newDayValues.playNewTrackImmediately);
            }

            timeOfDayText.text = $"Day {dayNumber} - {newDayValues.timeName}";
            _currentTimeSegmentTimer = 0;
        }

        private void SetDayText(TimeOfDayValues newDayValues) => timeOfDayText.text = $"Day {dayNumber} - {newDayValues.timeName}";

    }
}
