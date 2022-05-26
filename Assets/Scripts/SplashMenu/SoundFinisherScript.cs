using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFinisherScript : MonoBehaviour
{
    [SerializeField] private AudioSource _soundEffect;
    private LevelLoader _loader;


    // Start is called before the first frame update
    void Start()
    {
        _loader = GetComponent<LevelLoader>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_soundEffect.isPlaying)
        {
            _loader.LoadStartScreen();
        }
    }
}
