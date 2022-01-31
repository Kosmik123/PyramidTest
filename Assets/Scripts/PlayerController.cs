using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PyramidGamesTest
{
    public class PlayerController : MonoBehaviour
    {
        public CameraControl.RTSCameraController cameraController;

        private void OnEnable()
        {
            GameManager.OnGameStarted += ResetPlayer;
            GameManager.OnGameFinished += DisableCameraController;
        }
        private void ResetPlayer()
        {
            cameraController.enabled = true;
            cameraController.transform.position = Vector3.zero;
        }

        private void DisableCameraController()
        {
            cameraController.enabled = false;
        }

        private void OnDisable()
        {
            GameManager.OnGameStarted -= ResetPlayer;
            GameManager.OnGameFinished -= DisableCameraController;
        }
    }
}