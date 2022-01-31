using System;
using System.Collections;
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

        public void Regenerate()
        {
            Clear();
            GenerateRoom();
        }

        private void Awake()
        {
            room = GetComponent<RoomData>();
        }

        private void OnEnable()
        {
            GameManager.OnGameStarted += Regenerate;
        }

        public void GenerateRoom()
        {
            ResizeFloor();

            var doorPositions = doorGenerator.GetRandomWallPositions(doorGenerator.objectsCount);
            doorGenerator.InstantiateObjects(doorPositions);

            wallGenerator.GenerateWalls(doorPositions, doorGenerator.objectsSize);

            chestGenerator.Generate();
        }

        public void Clear()
        {
            doorGenerator.Clear();
            wallGenerator.Clear();
            chestGenerator.Clear();
        }


        private void ResizeFloor()
        {
            if (floor != null)
                floor.localScale = new Vector3(room.size.x, 1, room.size.y);
        }


        private void OnDisable()
        {
            GameManager.OnGameStarted -= Regenerate;
        }


    }
}