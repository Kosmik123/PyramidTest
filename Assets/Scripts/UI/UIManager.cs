using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PyramidGamesTest.UI
{
    public class UIManager : MonoBehaviour
    {
        [Header("Screens")]
        public Canvas menuScreen;
        public Canvas gameScreen;
        public Canvas gameoverScreen;

        [Header("To Link")]
        public TMP_Text timeIndicator;

        private void OnEnable()
        {
            GameManager.OnPlaytimeChanged += RefreshTimer;
        }


        public void ChangeScreen (Canvas newScreen)
        {
            menuScreen.gameObject.SetActive(false);
            gameScreen.gameObject.SetActive(false);
            gameoverScreen.gameObject.SetActive(false);

            newScreen.gameObject.SetActive(true);
        }

        private void RefreshTimer(float time)
        {
            timeIndicator.text = FormatTime(time);
        }

        public static string FormatTime(float time)
        {
            int seconds = Mathf.FloorToInt(time);
            int miliseconds = (int)(1000 * (time - seconds));
            int minutes = seconds / 60;

            return $"{minutes}:{(seconds%60):D2}.{miliseconds:D3}";

        }







        private void OnDisable()
        {
            GameManager.OnPlaytimeChanged -= RefreshTimer;
        }

    }


}




