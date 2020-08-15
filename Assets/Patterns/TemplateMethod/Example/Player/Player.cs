using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Examples.TemplateMethod
{
    [RequireComponent(typeof(BallMotor))]
    public class Player : MonoBehaviour
    {
        public event Action<int> OnCoinsCollected = delegate { };

        public int CoinCount { get; private set; } = 0;

        BallMotor _ballMotor;

        private void Awake()
        {
            _ballMotor = GetComponent<BallMotor>();
        }

        private void FixedUpdate()
        {
            ProcessMovement();
        }

        private void ProcessMovement()
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical).normalized;

            _ballMotor.Move(movement);
        }

        public void AddCoin(int numberOfCoins)
        {
            CoinCount += numberOfCoins;
            OnCoinsCollected.Invoke(CoinCount);
        }
    }
}

