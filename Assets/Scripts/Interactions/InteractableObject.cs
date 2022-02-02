using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;


namespace PyramidGamesTest.Interactions
{
    public class InteractableObject : MonoBehaviour
    {
        public void ShowMessage(string message)
        {
            UI.UIManager.instance.ShowMessageWindow(message);
        }

        public void GiveChoice(string question, UnityAction yesAction, UnityAction noAction = null)
        {
            UI.UIManager.instance.ShowChoiceWindow(question, yesAction, noAction);
        }


    }
}