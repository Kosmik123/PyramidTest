using System;
using System.Collections.Generic;
using UnityEngine;

namespace PyramidGamesTest.RoomGeneration
{
    public class WallGenerator : MonoBehaviour
    {
        public struct WallProperties
        {
            public Vector3 centerPosition;
            public Quaternion rotation;
            public float width;

            public WallProperties(Vector3 position, Quaternion rotation, float width)
            {
                centerPosition = position;
                this.rotation = rotation;
                this.width = width;
            }
        }

        public enum StructureType
        {
            Quad, Cube
        }

        [Header("To Link")]
        public RoomData room;

        [Header("Settings")]
        public StructureType structureType;
        public float wallHeight;
        public float wallThicknes;

        public void GenerateWalls(WallPosition[] holePositions, Vector2 holeSize)
        {
            var holePositionsByWallIndex = CreateListsOfHoles(holePositions);

            for (int i = 0; i < 4; i++)
            {
                if (holePositionsByWallIndex[i].Count == 0)
                    CreateWall(i);
                else
                    CreateModularWall(i, holePositionsByWallIndex[i], holeSize);
            }
        }

        private static List<WallPosition>[] CreateListsOfHoles(WallPosition[] holePositions)
        {
            List<WallPosition>[] holePositionsByWallIndex = new List<WallPosition>[4];
            for (int i = 0; i < 4; i++)
                holePositionsByWallIndex[i] = new List<WallPosition>();

            foreach (var holePos in holePositions)
            {
                int index = holePos.wallIndex;
                holePositionsByWallIndex[index].Add(holePos);
            }

            return holePositionsByWallIndex;
        }

        private void CreateWall(int wallIndex)
        {
            WallProperties wallProperties = GetWallProperties(wallIndex);

            var wall = InstantiateWallModule();
            wall.name = "Wall";
            wall.localPosition = wallProperties.centerPosition + 0.5f * wallHeight * Vector3.up;
            wall.localRotation = wallProperties.rotation;
            wall.localScale = new Vector3(wallProperties.width, wallHeight, wallThicknes);
        }

        private WallProperties GetWallProperties(int wallIndex)
        {
            Quaternion rotation = Quaternion.AngleAxis(wallIndex * 90, Vector3.up);
            Vector3 wallPosition = rotation * Vector3.forward * room.GetRoomExtent(wallIndex);
            float wallWidth = room.GetRoomSize(wallIndex);
        
            return new WallProperties(wallPosition, rotation, wallWidth);
        }

        private void CreateModularWall(int wallIndex, List<WallPosition> holes, Vector2 holeSize)
        {
            var wallProperties = GetWallProperties(wallIndex);

            CreateTopModule(wallProperties, holeSize.y);

            holes.Sort(new WallPosition.DistanceComparer());
            for (int i = 0; i <= holes.Count; i++)
            {
                float moduleLeftPos = i == 0 ? -0.5f * wallProperties.width : holes[i - 1].distanceFromCenter + 0.5f * holeSize.x;
                float moduleRightPos = i == holes.Count ? +0.5f * wallProperties.width : holes[i].distanceFromCenter - 0.5f * holeSize.x;

                float distanceFromCenter = (moduleLeftPos + moduleRightPos) / 2f;
                float moduleWidth = Mathf.Abs(moduleRightPos - moduleLeftPos);
                CreateBottomModule(wallProperties, distanceFromCenter, moduleWidth, holeSize.y);
            }
        }

        private void CreateTopModule(WallProperties properties, float holeHeight)
        {
            float topY = 0.5f * (wallHeight + holeHeight);
            var module = InstantiateWallModule();
            module.name = "Wall Module";
            module.localPosition = properties.centerPosition + topY * Vector3.up;
            module.localRotation = properties.rotation;
            module.localScale = new Vector3(properties.width, wallHeight - holeHeight, wallThicknes);
        }

        private void CreateBottomModule(WallProperties properties, float distanceFromCenter, float width, float holeHeight)
        {
            var module = InstantiateWallModule();
            module.name = "Wall Module";
            module.localPosition = properties.centerPosition
                + 0.5f * holeHeight * Vector3.up
                + properties.rotation * Vector3.right * distanceFromCenter;
            module.localRotation = properties.rotation;
            module.localScale = new Vector3(width, holeHeight, wallThicknes);
        }

        private Transform InstantiateWallModule()
        {
            PrimitiveType type = structureType == StructureType.Cube ? PrimitiveType.Cube : PrimitiveType.Quad;
            var obj = GameObject.CreatePrimitive(type);
            obj.transform.parent = transform;

            return obj.transform;
        }
    }
}
