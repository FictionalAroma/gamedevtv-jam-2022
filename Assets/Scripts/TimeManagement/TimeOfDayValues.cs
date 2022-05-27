using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Assets.Scripts
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/TimeOfDay", order = 2)]

    public class TimeOfDayValues : ScriptableObject
    {
        public AudioClip[] musicTracks;
        public bool playNewTrackImmediately;
        public Color lightColour;

        public string timeName;

        [Tooltip("Number of in game seconds this time period lasts for")]
        public float timeLength;

        public Image timeOfDayIcon;



    }
}
