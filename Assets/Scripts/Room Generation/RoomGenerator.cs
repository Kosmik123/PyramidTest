using System.Collections;
using UnityEngine;

namespace PyramidGamesTest.RoomGeneration
{
    [RequireComponent(typeof(RoomData))]
    public class RoomGenerator : MonoBehaviour
    {
        private RoomData room;

        [Header("Prefabs")]
        public GameObject chestPrefab;

        [Header("To Link")]
        public OnWallGenerator doorGenerator;
        public Transform floor;

        [Header("States")]
        public bool generateRoom;

        private void Awake()
        {
            room = GetComponent<RoomData>();
        }

        public void GenerateRoom()
        {
            ResizeFloor();

            // decide door positions
            var doorPositions = doorGenerator.GetRandomWallPositions(doorGenerator.doorsCount);

            // intantiate doors
            doorGenerator.InstantiateDoors(doorPositions);


            // fill ther rest with walls
            GenerateWalls(doorPositions, doorGenerator.doorSize);

            // tile wall textures correctly

            // instantiate chest
        }

        private void ResizeFloor()
        {
            if (floor != null)
                floor.localScale = new Vector3(room.size.x, 1, room.size.y);
        }

        private void CreateWall()
        {
            for (int i = 0; i < 4; i++)
            {
                float wallDist = room.GetWallDistance(i);
            }
            GameObject.CreatePrimitive(PrimitiveType.Quad);
        }



        private void GenerateWalls(WallPosition[] holePositions, float holeWidth)
        {

        }



        private void OnValidate()
        {
            if (generateRoom)
            {
                generateRoom = false;
                GenerateRoom();
            }
        }
    }
}