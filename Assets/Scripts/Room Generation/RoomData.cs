using UnityEngine;

namespace PyramidGamesTest.RoomGeneration
{
    public class RoomData : MonoBehaviour
    {
        [Header("Settings")]
        public Vector2 size;

        public float GetRoomExtent(int wallIndex)
        {
            return 0.5f * (wallIndex % 2 == 0 ? size.y : size.x);
        }

        public float GetRoomSize(int wallIndex)
        {
            return (wallIndex % 2 == 0 ? size.x : size.y);
        }
    }
}