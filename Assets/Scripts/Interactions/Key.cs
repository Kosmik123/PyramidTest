using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PyramidGamesTest.Interactions
{
    public class Key : MonoBehaviour
    {
        public void PickUp()
        {
            GameManager.instance.hasKey = true;
        }

        public void DestroyObject()
        {
            Destroy(gameObject);
        }
    }
}