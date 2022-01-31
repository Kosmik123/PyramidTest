using UnityEngine;

namespace PyramidGamesTest.RoomGeneration
{
    public class ObjectGenerator : MonoBehaviour
    {
        [Header("To Link")]
        public RoomData room;

        [Header("Prefabs")]
        public GameObject objectPrefab;

        [Header("Settings")]
        public int objectCount;
        public float minimalDistanceFromWalls;

        public void Generate()
        {
            Vector2 spawnArea = new Vector2(
                room.size.x - 2 * minimalDistanceFromWalls,
                room.size.y - 2 * minimalDistanceFromWalls);

            for (int i = 0; i < objectCount; i++)
                InstantiateObjectAtRandom(spawnArea);
        }

        private void InstantiateObjectAtRandom(Vector2 availableArea)
        {
            float randomX = Random.Range(-availableArea.x * 0.5f, +availableArea.x * 0.5f);
            float randomY = Random.Range(-availableArea.y * 0.5f, +availableArea.y * 0.5f);
            var obj = Instantiate(objectPrefab, transform);
            obj.transform.localPosition = new Vector3(randomX, 0, randomY);
            obj.transform.localRotation = Quaternion.AngleAxis(Random.Range(0, 360), Vector3.up);
        }
    }
}