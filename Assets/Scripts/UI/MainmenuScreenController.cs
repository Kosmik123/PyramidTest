using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
namespace PyramidGamesTest.UI
{
    public class MainmenuScreenController : MonoBehaviour
    {
        public TextMeshProUGUI bestTimeIndicator;

        private void OnEnable()
        {
            bestTimeIndicator.text = UIHelper.FormatTime(GameManager.instance.bestPlaytime);
        }
    }
}