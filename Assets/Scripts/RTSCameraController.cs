using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PyramidGamesTest
{
    public class RTSCameraController : MonoBehaviour
    { 
        private Controls controls;

        [Header("To Link")]
        [SerializeField]
        private new Camera camera;
        [SerializeField]
        private PositionConstraints positionConstraints;

        [Header("Settings")]
        [SerializeField]
        private float moveSpeed;
        [SerializeField]
        private float rotateSpeed;
        [SerializeField]
        private float cameraDistance;

        [Header("States")]
        [Range(0,90f)]
        public float pitchAngle;

        [SerializeField]
        private Vector3 moveDirection;
        [SerializeField]
        private float yawDirection;

        private void Awake()
        {
            controls = new Controls();    
        }

        private void OnEnable()
        {
            controls.RTSCamera.Enable();
            RefreshAngle();
        }

        private void Update()
        {
            UpdateInput();
            UpdateMovement();
        }

        private void UpdateInput()
        {
            moveDirection = controls.RTSCamera.Movement.ReadValue<Vector2>();
            yawDirection = controls.RTSCamera.Rotation.ReadValue<float>();
        }

        private void UpdateMovement()
        {
            transform.rotation *= Quaternion.AngleAxis(
                yawDirection * rotateSpeed * Time.deltaTime, Vector3.up);
            transform.position += moveSpeed * Time.deltaTime * transform.forward * moveDirection.y;
            transform.position += moveSpeed * Time.deltaTime * transform.right * moveDirection.x;
            if (positionConstraints != null)
                transform.position = positionConstraints.GetLimitedPosition(transform.position);
        }

        private void RefreshAngle()
        {
            if (camera == null)
                return;

            Quaternion pitch = Quaternion.AngleAxis(pitchAngle, Vector3.right);
            camera.transform.localRotation = pitch;
            camera.transform.localPosition = pitch * Vector3.back * cameraDistance;
        }

        private void OnDisable()
        {
            controls.RTSCamera.Disable();
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            RefreshAngle();
        }
#endif
    }
}