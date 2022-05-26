using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFinisherScript : MonoBehaviour
{
    [SerializeField] private AudioSource _soundEffect;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (!_soundEffect.isPlaying)
        {
            LevelLoader.LoadStartScreen();
        }
    }
}
