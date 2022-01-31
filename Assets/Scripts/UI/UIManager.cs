using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PyramidGamesTest.UI
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager instance;

        [Header("Prefabs")]
        public GameObject messageWindowPrefab;
        public GameObject yesNoWindowPrefab;

        [Header("Screens")]
        public Canvas menuScreen;
        public Canvas gameScreen;
        public Canvas gameoverScreen;

        [Header("To Link")]
        public TMP_Text timeIndicator;
        public Canvas windowsContainer;

        private void Awake()
        {
            instance = Singleton.MakeInstance(this, instance);
        }


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

        public void ShowMessageWindow(string message)
        {
            var obj = Instantiate(messageWindowPrefab, windowsContainer.transform);
            MessageWindow window = obj.GetComponent<MessageWindow>();
            window.Message = message;
        }


        private void OnDisable()
        {
            GameManager.OnPlaytimeChanged -= RefreshTimer;
        }

    }


}




