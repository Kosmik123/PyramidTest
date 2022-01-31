﻿using System.Collections;
using UnityEngine;

namespace PyramidGamesTest.RoomGeneration
{



    [RequireComponent(typeof(RoomData))]
    public class RoomGenerator : MonoBehaviour
    {
        private RoomData room;

        [Header("To Link")]
        public OnWallGenerator doorGenerator;
        public WallGenerator wallGenerator;
        public ObjectGenerator chestGenerator;

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
            var doorPositions = doorGenerator.GetRandomWallPositions(doorGenerator.objectsCount);

            // intantiate doors
            doorGenerator.InstantiateObjects(doorPositions);

            wallGenerator.GenerateWalls(doorPositions, doorGenerator.objectsSize);

            chestGenerator.Generate();
        }

        private void ResizeFloor()
        {
            if (floor != null)
                floor.localScale = new Vector3(room.size.x, 1, room.size.y);
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