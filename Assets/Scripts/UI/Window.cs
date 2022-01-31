using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PyramidGamesTest.UI
{
    public class Window : MonoBehaviour
    {
        public void Close()
        {
            Destroy(gameObject);
        }

        public virtual void Refresh()
        {
            
        }
    }

}

