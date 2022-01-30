using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PyramidGamesTest
{
    public class PositionConstraints : MonoBehaviour
    {
        private Transform _transform;

        [Header("Settings")]
        [SerializeField]
        private Bounds bounds;

        private void Awake()
        {
            _transform = transform;
        }

        public Vector3 GetLimitedPosition(Vector3 position)
        {
            float x = Mathf.Clamp(position.x, bounds.min.x, bounds.max.x);
            float y = Mathf.Clamp(position.y, bounds.min.y, bounds.max.y);
            float z = Mathf.Clamp(position.z, bounds.min.z, bounds.max.z);

            return new Vector3(x, y, z);
        }

#if UNITY_EDITOR
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireCube(bounds.center, bounds.size);
        }
#endif
    }
}