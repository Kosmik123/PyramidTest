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



        public void Open()
        {
            if (GameManager.instance.hasKey)
                OpenSuccessfully();
            else
                ShowMessage(cantOpenText);
        }

        private void OpenSuccessfully()
        {

        }
    }
}