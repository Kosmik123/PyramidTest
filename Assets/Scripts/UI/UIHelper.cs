using UnityEngine;

namespace PyramidGamesTest.UI
{
    public static class UIHelper
    {
        public static string FormatTime(float time)
        {
            int seconds = Mathf.FloorToInt(time);
            int miliseconds = (int)(1000 * (time - seconds));
            int minutes = seconds / 60;

            return $"{minutes}:{(seconds % 60):D2}.{miliseconds:D3}";

        }
    }

}




