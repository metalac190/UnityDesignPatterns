using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchBotSearchState : IState
{
    SearchBotSM _searchBotSM;
    Rigidbody _rb;

    Material _eyeMat;
    Color _startingEyeColor;
    Color _searchEyeColor = Color.red;

    // if we need specific components we should send them through the constructor
    public SearchBotSearchState(SearchBotSM searchBotSM, Material eyeMat, Rigidbody rb)
    {
        _searchBotSM = searchBotSM;
        _eyeMat = eyeMat;
        _rb = rb;
    }

    public void Enter()
    {
        Debug.Log("STATE CHANGE - Search");
        // searching state visuals
        _startingEyeColor = _eyeMat.color;
        _eyeMat.color = _searchEyeColor;
    }

    public void Exit()
    {
        // undo searching state visuals
        _eyeMat.color = _startingEyeColor;
    }

    public void Tick()
    {

    }

    public void FixedTick()
    {
        // instead of listening for the 'NewTarget' event, we can optionally just look at data belonging to the SM
        // this is useful if you have shared data that's important to multiple states... unit health, etc.
        float distanceFromTarget = Vector3.Distance(_searchBotSM.TargetPosition, _rb.position);
        // if we're close enough to the target, enter 'detect state
        if (distanceFromTarget < .1f)
        {
            _searchBotSM.ChangeState(_searchBotSM.FoundState);
        }
        // otherwise, keep moving
        else
        {
            RotateTowardsTarget();
            MoveTowardsTarget();
        }
    }

    void RotateTowardsTarget()
    {
        Quaternion lookRotation = Quaternion.LookRotation(_searchBotSM.TargetPosition - _rb.position);
        lookRotation = Quaternion.Slerp(_rb.rotation, lookRotation, _searchBotSM.RotateSpeed * Time.deltaTime);
        _rb.MoveRotation(lookRotation);
    }

    void MoveTowardsTarget()
    {
        Vector3 moveOffset = _searchBotSM.transform.forward * _searchBotSM.MoveSpeed;
        _rb.MovePosition(_rb.position + moveOffset);
    }
}
