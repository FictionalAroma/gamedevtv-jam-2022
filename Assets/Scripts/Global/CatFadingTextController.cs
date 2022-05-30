using System;
using System.Collections;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Global
{
    public class CatFadingTextController : MonoBehaviour
    {

        public static CatFadingTextController Instance = null;
        private Coroutine runningCoroutine;
        private static readonly int FadeOut = Animator.StringToHash("fadeOut");

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private TextMeshProUGUI CatSpeechText { get; set; }
        public Animator CatSpeechAnimator { get; set; }
        public bool isSpeechActive { get; set; }


        // Start is called before the first frame update
        void Start()
        {
            CatSpeechText = GetComponent<TextMeshProUGUI>();
            CatSpeechAnimator = GetComponent<Animator>();
        }




        public void StartCatTalk(string speechString, int numberOfSecondsDisplayed = 5)
        {
            CatSpeechText.alpha = 1f;
            if (isSpeechActive)
            {
                StopCoroutine(runningCoroutine);
                CatSpeechAnimator.StopPlayback();
                CatSpeechText.text = string.Empty;
            }

            CatSpeechText.text = speechString;
            CatSpeechAnimator.StartPlayback();
            runningCoroutine = StartCoroutine(TextFadeTimer(numberOfSecondsDisplayed));
        }

        private IEnumerator TextFadeTimer(int delayTime)
        {
            isSpeechActive = true;
            yield return new WaitForSeconds(delayTime + 1);
            isSpeechActive = false;

        }

        public void Update()
        {
            if (!isSpeechActive && CatSpeechText.alpha > 0f)
            {
                CatSpeechText.alpha -= Time.deltaTime;
            }
        }
    }
}
