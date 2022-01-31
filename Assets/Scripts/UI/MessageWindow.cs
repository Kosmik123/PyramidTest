using TMPro;
using UnityEngine;

namespace PyramidGamesTest.UI
{
    public class MessageWindow : Window
    {
        [Header("To Link")] 
        [SerializeField] 
        private TextMeshProUGUI messageTMP;

        [Header("Properties")]
        [Multiline] [SerializeField] 
        private string _message;
        public string Message
        {
            get => _message;
            set 
            {
                _message = value;
                Refresh();
            }
        }

        public override void Refresh()
        {
            base.Refresh();

            messageTMP.text = _message;
        }


    }

}

