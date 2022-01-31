using System.Collections.Generic;
using UnityEngine;

namespace PyramidGamesTest.RoomGeneration
{
    public class OnWallGenerator : MonoBehaviour
    {
        public class CantGenerateOnWallException : System.Exception
        { }

        private const int GENERATION_ATTEMPTS = 100;

        [Header("To Link")]
        public RoomData room;

        [Header("Prefabs")]
        public GameObject objectPrefab;

        [Header("Settings")]
        public int objectsCount;
        public Vector2 objectsSize;

        public WallPosition[] GetRandomWallPositions(int count)
        {
            var positions = new List<WallPosition>();
            for (int i = 0; i < count; i++)
                positions.Add(CreateRandomWallPosition(positions));

            return positions.ToArray();
        }

        private WallPosition CreateRandomWallPosition(List<WallPosition> positionsSoFar)
        {
            for (int attempt = 0; attempt < GENERATION_ATTEMPTS; attempt++)
            {
                int wallIndex = Random.Range(0, 4);

                float wallSize = wallIndex % 2 == 0 ? room.size.x : room.size.y;
                float position = Random.Range(
                    -0.5f * (wallSize - objectsSize.x), 
                    +0.5f * (wallSize - objectsSize.x));

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
                if (roomPosition.IsTooClose(other, objectsSize.x))
                    return true;

            return false;
        }

        public void InstantiateObjects(WallPosition[] positions)
        {
            int index = 0;
            foreach (var position in positions)
            {
                var obj = IntantiateObject(position);
                obj.name = $"{objectPrefab.name} {index}";
                index++;
            }
        }

        private GameObject IntantiateObject(WallPosition position)
        {
            var obj = Instantiate(objectPrefab, transform);
            float wallDist = room.GetRoomExtent(position.wallIndex);
            Vector3 unrotatedPosition = new Vector3(position.distanceFromCenter, 0, wallDist);
            Quaternion rotation = Quaternion.AngleAxis(position.wallIndex * 90, Vector3.up);

            obj.transform.localPosition = rotation * unrotatedPosition;
            obj.transform.localRotation = rotation;
            return obj;
        }
    }
}