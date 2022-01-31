using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PyramidGamesTest
{
    public class RoomGenerator : MonoBehaviour
    {
        public class CantGenerateDoorsException : System.Exception
        { }

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
        }

        private const int DOOR_GENERATION_ATTEMPTS = 100;

        [Header("Prefabs")]
        public GameObject doorPrefab;
        public GameObject chestPrefab;

        [Header("To Link")]
        public Transform floor;

        [Header("Settings")]
        public Vector2 size;
        public int doorsCount;
        public float minDoorDistance;

        
        public void GenerateRoom()
        {
            ResizeFloor();
            // decide door positions
            var doorPositions = GetRandomWallPositions(doorsCount);

            // intantiate doors
            InstantiateDoors(doorPositions);
            
            
            // fill ther rest with walls
                // tile walls correctly
            // instantiate chest
        }

        private void ResizeFloor()
        {
            floor.localScale = size;
        }

        private void CreateWall()
        {
            GameObject.CreatePrimitive(PrimitiveType.Quad);
        }

        private WallPosition[] GetRandomWallPositions(int count)
        {
            var positions = new List<WallPosition>();
            for(int i = 0; i < count; i++)
                positions.Add(CreateRandomWallPosition(positions));

            return positions.ToArray();
        }

        private WallPosition CreateRandomWallPosition(List<WallPosition> positionsSoFar)
        {
            for (int attempt = 0; attempt < DOOR_GENERATION_ATTEMPTS; attempt++)
            {
                int wallIndex = Random.Range(0, 4);

                float wallSize = wallIndex % 2 == 0 ? size.x : size.y;
                float position = Random.Range(-0.5f * wallSize, +0.5f * wallSize);

                var roomPosition = new WallPosition(wallIndex, position);

                if (IsTooCloseToOtherPositions(roomPosition, positionsSoFar))
                    continue;

                return roomPosition;
            }
            throw new CantGenerateDoorsException();
        }

        private bool IsTooCloseToOtherPositions(WallPosition roomPosition, List<WallPosition> positionsSoFar)
        {
            foreach (var other in positionsSoFar)
                if (roomPosition.IsTooClose(other, minDoorDistance))
                    return true;

            return false;
        }

        private void InstantiateDoors(WallPosition[] positions)
        {
            foreach (var position in positions)
            {
                var door = Instantiate(doorPrefab, transform);
                float wallDist = 0.5f * (position.wallIndex % 2 == 0 ? size.y : size.x);
                Vector3 unrotatedPosition = new Vector3(position.distanceFromCenter, 0, wallDist);
                Quaternion rotation = Quaternion.AngleAxis(position.wallIndex * 90, Vector3.up);

                door.transform.localPosition = rotation * unrotatedPosition;
                door.transform.localRotation = rotation;
            }
        }


    }
}