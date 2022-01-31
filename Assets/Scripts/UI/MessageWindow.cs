using TMPro;
using UnityEngine;

namespace PyramidGamesTest.UI
{
    public class MessageWindow : Window
    {
        [Header("To Link")]
        public TextMeshProUGUI messageTMP;

        [Header("Properties")]
        [Multiline]
        public string message;


        public override void Refresh()
        {
            base.Refresh();

            messageTMP.text = message;
        }


    }

}

