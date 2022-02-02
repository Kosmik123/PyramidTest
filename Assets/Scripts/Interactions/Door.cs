using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PyramidGamesTest.Interactions
{
    public class Door : InteractableObject
    {
        [Header("Settings")]
        [SerializeField]
        private string cantOpenText;
        [SerializeField]
        private string openQuestion;

        [Header("States")]
        public bool isOpen;

        public void Open()
        {
            if (isOpen)
                return;

            if (GameManager.instance.hasKey)
                GiveChoice(openQuestion, OpenSuccessfully);
            else
                ShowMessage(cantOpenText);
        }

        private void OpenSuccessfully()
        {
            isOpen = true;
            GameManager.instance.hasKey = false;
            GetComponent<Animator>().SetTrigger("Open");
        }

        public void Win()
        {
            GameManager.instance.Finish();
        }

    }
}