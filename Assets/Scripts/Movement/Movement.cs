using Secrets.Core;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.SocialPlatforms;

namespace Secrets.Movement
{
    public class Movement : MonoBehaviour, IAction
    {
        [SerializeField] float movementSpeed = 3f;

        float currentSpeed = 0f;
        float speedSmoothVelocity = 0f;
        float speedSmoothTime = 0.1f;
        float rotationSpeed = 0.1f;
        float gravity = 3f;

        Transform mainCamera;
        CharacterController controller;
        Animator animator;

        void Start()
        {
            controller = GetComponent<CharacterController>();
            animator = GetComponent<Animator>();
            mainCamera = Camera.main.transform;
        }

        void Update()
        {
            Move();
        }

        private void Move()
        {
            GetComponent<ActionScheduler>().StartAction(this);
            Vector2 movementInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

            Vector3 forward = mainCamera.forward.normalized;
            Vector3 right = mainCamera.right.normalized;
            forward.y = 0;
            right.y = 0;

            Vector3 moveDirection = (forward * movementInput.y + right * movementInput.x).normalized;
            Vector3 gravityVector = Vector3.zero;

            //if (!controller.isGrounded)
            //{
            //    gravityVector -= Physics.gravity;
            //}

            if (moveDirection != Vector3.zero)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveDirection), rotationSpeed);
            }

            float targetSpeed = movementSpeed * movementInput.magnitude;
            currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedSmoothVelocity, speedSmoothTime);

            controller.Move(moveDirection * currentSpeed * Time.deltaTime);
            //controller.Move(gravityVector * Time.deltaTime);
        }

        public void Cancel()
        {
            throw new System.NotImplementedException();
        }

    }
}

