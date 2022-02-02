using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
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
        public RectTransform loadScreen;

        [Header("To Link")]
        public TMP_Text timeIndicator;
        public Canvas windowsContainer;
        public Image windowsContainerPanel;


        private void Awake()
        {
            instance = Singleton.MakeInstance(this, instance);
        }

        private void OnEnable()
        {
            GameManager.OnApplicationLoaded += ShowMainMenu;
            GameManager.OnPlaytimeChanged += RefreshTimer;
            GameManager.OnGameFinished += ShowGameover;
        }

        private void ShowMainMenu()
        {
            loadScreen.gameObject.SetActive(false);
            ChangeScreen(menuScreen);
        }

        private void ShowGameover()
        {
            ChangeScreen(gameoverScreen);
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
            timeIndicator.text = UIHelper.FormatTime(time);
        }

        public void ShowMessageWindow(string message)
        {
            var obj = Instantiate(messageWindowPrefab, windowsContainer.transform);
            MessageWindow window = obj.GetComponent<MessageWindow>();
            window.Message = message;
        }

        public void ShowChoiceWindow(string message, UnityAction yesAction, UnityAction noAction = null)
        {
            var obj = Instantiate(yesNoWindowPrefab, windowsContainer.transform);
            var window = obj.GetComponent<YesNoWindow>();
            window.Message = message;
            window.SetYesAction(yesAction);
            if (noAction != null)
                window.SetNoAction(noAction);
        }

        private void OnDisable()
        {
            GameManager.OnApplicationLoaded -= ShowMainMenu;
            GameManager.OnPlaytimeChanged -= RefreshTimer;
            GameManager.OnGameFinished -= ShowGameover;
        }
    }
}
