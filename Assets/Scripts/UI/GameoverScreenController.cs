using UnityEngine;
using TMPro;

namespace PyramidGamesTest.UI
{
    public class GameoverScreenController : MonoBehaviour
    {
        [Header("To Link")]
        public TextMeshProUGUI bestTimeTMP;
        public TextMeshProUGUI yourTimeTMP;

        private void OnEnable()
        {
            Refresh();
        }

        private void Refresh()
        {
            bestTimeTMP.text = UIHelper.FormatTime(GameManager.instance.bestPlaytime);
            yourTimeTMP.text = UIHelper.FormatTime(GameManager.instance.currentPlaytime);
        }

    }


}




