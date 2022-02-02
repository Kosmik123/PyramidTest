using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace PyramidGamesTest.UI
{
    public class YesNoWindow : MessageWindow
    {
        [Header("To Link")]
        [SerializeField]
        private Button yesButton;
        [SerializeField]
        private Button noButton;
    
        public void SetYesAction(UnityAction action)
        {
            yesButton.onClick.AddListener(action);
        }

        public void SetNoAction(UnityAction action)
        {
            noButton.onClick.AddListener(action);
        }




    }
}