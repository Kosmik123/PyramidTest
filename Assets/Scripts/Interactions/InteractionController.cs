using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PyramidGamesTest.Interactions
{
    public class InteractionController : MonoBehaviour
    {
        private Controls controls;

        [Header("To Link")]
        public Camera viewCamera;

        private void Awake()
        {
            controls = new Controls();
        }

        private void OnEnable()
        {
            controls.InteractionPointer.Enable();
            controls.InteractionPointer.Click.performed += OnClick;
        }

        private void OnClick(InputAction.CallbackContext ctx)
        {
            if (ctx.performed)
            {
                var screenPos = controls.InteractionPointer.Position.ReadValue<Vector2>();
            
            }
        }

        private void OnDisable()
        {
            controls.InteractionPointer.Click.performed -= OnClick;
            controls.InteractionPointer.Disable();
        }
    }
}