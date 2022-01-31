using System.Collections.Generic;
using UnityEngine;

namespace PyramidGamesTest.RoomGeneration
{
    public class OnWallGenerator : MonoBehaviour
    {
        public class CantGenerateOnWallException : System.Exception
        { }

        private const int DOOR_GENERATION_ATTEMPTS = 100;

        [Header("To Link")]
        public RoomData room;

        [Header("Prefabs")]
        public GameObject doorPrefab;

        [Header("Settings")]
        public int doorsCount;
        public float doorSize;


        public WallPosition[] GetRandomWallPositions(int count)
        {
            var positions = new List<WallPosition>();
            for (int i = 0; i < count; i++)
                positions.Add(CreateRandomWallPosition(positions));

            return positions.ToArray();
        }

        private WallPosition CreateRandomWallPosition(List<WallPosition> positionsSoFar)
        {
            for (int attempt = 0; attempt < DOOR_GENERATION_ATTEMPTS; attempt++)
            {
                int wallIndex = Random.Range(0, 4);

                float wallSize = wallIndex % 2 == 0 ? room.size.x : room.size.y;
                float position = Random.Range(-0.5f * wallSize, +0.5f * wallSize);

                var roomPosition = new WallPosition(wallIndex, position);

                if (IsTooCloseToOtherPositions(roomPosition, positionsSoFar))
                    continue;

                return roomPosition;
            }
            throw new CantGenerateOnWallException();
        }

        private bool IsTooCloseToOtherPositions(WallPosition roomPosition, List<WallPosition> positionsSoFar)
        {
            foreach (var other in positionsSoFar)
                if (roomPosition.IsTooClose(other, doorSize))
                    return true;

            return false;
        }

        public void InstantiateDoors(WallPosition[] positions)
        {
            int index = 0;
            foreach (var position in positions)
            {
                var door = IntantiateDoor(position);
                door.name = $"Door {index}";
                index++;
            }
        }

        private GameObject IntantiateDoor(WallPosition position)
        {
            var door = Instantiate(doorPrefab, transform);
            float wallDist = room.GetWallDistance(position.wallIndex);
            Vector3 unrotatedPosition = new Vector3(position.distanceFromCenter, 0, wallDist);
            Quaternion rotation = Quaternion.AngleAxis(position.wallIndex * 90, Vector3.up);

            door.transform.localPosition = rotation * unrotatedPosition;
            door.transform.localRotation = rotation;
            return door;
        }
    }
}