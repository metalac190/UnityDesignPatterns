using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public class SearchBotSM : StateMachineMB
{
    public SearchBotIdleState IdleState { get; private set; }
    public SearchBotSearchState SearchState { get; private set; }
    public SearchBotFoundState FoundState { get; private set; }

    // we can get references in the Inspector and pass it into the states
    [SerializeField] Rigidbody _rb = null;
    [SerializeField] MeshRenderer _eyeMesh = null;
    [SerializeField] TargetAssigner _targetAssigner = null;

    // if we have data that multiple states need access to, we can keep it here for them all to see
    public Vector3 TargetPosition { get; set; }

    [SerializeField] float _rotateSpeed = 5;
    public float RotateSpeed => _rotateSpeed;

    [SerializeField] float _moveSpeed = 5;
    public float MoveSpeed => _moveSpeed;

    private void Awake()
    {
        IdleState = new SearchBotIdleState(this, _eyeMesh.material, _targetAssigner);
        // if our state needs specific components, we can send them through the constructor
        SearchState = new SearchBotSearchState(this, _eyeMesh.material, _rb);
        FoundState = new SearchBotFoundState(this, _eyeMesh.material);
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
