using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PyramidGamesTest.Interactions
{
    public class Key : InteractableObject
    {
        public void PickUp()
        {
            GiveChoice("Take?", Take);
        }

        public void Take()
        {
            GameManager.instance.hasKey = true;
            GetComponent<Animator>().SetTrigger("Disappear");
        }


    }
}