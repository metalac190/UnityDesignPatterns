using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

/// <summary>
/// This is the State Machine for the SearchBot. All of its states are created and activated here,
/// and any major data or references that the state needs can be accessed through here as well.
/// Technically, you can create a StateMachine without a MonoBehaviour, but Unity offers a few
/// benefits with MonoBehaviours that works well with state machines (such as component references).
/// In this structure I'm opting for the StateMachine as a MonoBehaviour, and the states as traditional
/// C# classes.
/// </summary>

namespace Examples.State
{
    public class SearchBotSM : StateMachineMB
    {
        public SearchBotIdleState IdleState { get; private set; }
        public SearchBotSearchState SearchState { get; private set; }
        public SearchBotFoundState FoundState { get; private set; }

        [Header("Required References")]
        // we can get references in the Inspector and pass it into the states
        [SerializeField] TargetAssigner _targetAssigner = null;
        [SerializeField] Rigidbody _rb = null;
        [SerializeField] AudioSource _audioSource = null;

        [Header("Movement Settings")]
        [SerializeField] float _rotateSpeed = 5;
        public float RotateSpeed => _rotateSpeed;
        [SerializeField] float _moveSpeed = 5;
        public float MoveSpeed => _moveSpeed;

        [Header("Feedback")]
        [SerializeField] MeshRenderer _eyeMesh = null;
        [SerializeField] AudioClip _foundSound = null;

        // if we have data that multiple states need access to, we can keep it here for them all to see
        public Vector3 TargetPosition { get; set; }

        private void Awake()
        {
            IdleState = new SearchBotIdleState(this, _eyeMesh.material, _targetAssigner);
            // if our state needs specific components, we can send them through the constructor
            SearchState = new SearchBotSearchState(this, _eyeMesh.material, _rb);
            FoundState = new SearchBotFoundState(this, _eyeMesh.material, _foundSound, _audioSource);
        }

        private void OnEnable()
        {
            _targetAssigner.NewTargetAcquired += OnNewTargetAcquired;
        }

        private void OnDisable()
        {
            _targetAssigner.NewTargetAcquired -= OnNewTargetAcquired;
        }

        private void Start()
        {
            ChangeState(IdleState);
        }

        void OnNewTargetAcquired(Vector3 newTarget)
        {
            Debug.Log("Acquired new target: " + newTarget.ToString());
            TargetPosition = newTarget;
        }
    }
}

