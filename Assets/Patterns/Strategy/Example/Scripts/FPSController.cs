using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Based on FPS Controller on Sharp Coder Blog
/// https://sharpcoderblog.com/blog/unity-3d-fps-controller
/// This is just to give us basic character movement
/// </summary>

namespace Examples.Strategy
{
    [RequireComponent(typeof(CharacterController))]
    public class FPSController : MonoBehaviour
    {
        [SerializeField] float _walkingSpeed = 7.5f;
        [SerializeField] float _runningSpeed = 11.5f;
        [SerializeField] float _jumpSpeed = 8.0f;
        [SerializeField] float _gravity = 20.0f;

        [SerializeField] Camera _playerCamera = null;
        [SerializeField] float _lookSpeed = 2.0f;
        [SerializeField] float _lookXLimit = 45.0f;

        CharacterController _characterController;
        Vector3 _moveDirection = Vector3.zero;
        float _rotationX = 0;

        bool _canMove = true;

        void Awake()
        {
            _characterController = GetComponent<CharacterController>();

            // Lock cursor
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        void Update()
        {
            // We are grounded, so recalculate move direction based on axes
            Vector3 forward = transform.TransformDirection(Vector3.forward);
            Vector3 right = transform.TransformDirection(Vector3.right);
            // Press Left Shift to run
            bool isRunning = Input.GetKey(KeyCode.LeftShift);
            float curSpeedX = _canMove ? (isRunning ? _runningSpeed : _walkingSpeed) * Input.GetAxis("Vertical") : 0;
            float curSpeedY = _canMove ? (isRunning ? _runningSpeed : _walkingSpeed) * Input.GetAxis("Horizontal") : 0;
            float movementDirectionY = _moveDirection.y;
            _moveDirection = (forward * curSpeedX) + (right * curSpeedY);

            if (Input.GetButton("Jump") && _canMove && _characterController.isGrounded)
            {
                _moveDirection.y = _jumpSpeed;
            }
            else
            {
                _moveDirection.y = movementDirectionY;
            }

            // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
            // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
            // as an acceleration (ms^-2)
            if (!_characterController.isGrounded)
            {
                _moveDirection.y -= _gravity * Time.deltaTime;
            }

            // Move the controller
            _characterController.Move(_moveDirection * Time.deltaTime);

            // Player and Camera rotation
            if (_canMove)
            {
                _rotationX += -Input.GetAxis("Mouse Y") * _lookSpeed;
                _rotationX = Mathf.Clamp(_rotationX, -_lookXLimit, _lookXLimit);
                _playerCamera.transform.localRotation = Quaternion.Euler(_rotationX, 0, 0);
                transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * _lookSpeed, 0);
            }
        }
    }
}
