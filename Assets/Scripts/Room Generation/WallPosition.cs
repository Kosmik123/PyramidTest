using System.Collections.Generic;
using UnityEngine;

namespace PyramidGamesTest.RoomGeneration
{
    [System.Serializable]
    public class WallPosition
    {
        public int wallIndex;
        public float distanceFromCenter;

        public WallPosition(int wallIndex, float distanceFromCenter)
        {
            this.wallIndex = wallIndex;
            this.distanceFromCenter = distanceFromCenter;
        }

        public bool IsTooClose(WallPosition other, float minDistance)
        {
            if (wallIndex != other.wallIndex)
                return false;

            float distance = Mathf.Abs(distanceFromCenter - other.distanceFromCenter);
            if (distance > minDistance)
                return false;

            return true;
        }

        public class DistanceComparer : IComparer<WallPosition>
        {
            public int Compare(WallPosition a, WallPosition b)
            {
                return a.distanceFromCenter.CompareTo(b.distanceFromCenter);
            }
        }


    }
}