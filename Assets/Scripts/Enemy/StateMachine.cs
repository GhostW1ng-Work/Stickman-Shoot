using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    //private BaseState _currentState;

    //public void SetState(BaseState state)
    //{
    //    _currentState = state;
    //}

    //private void Start()
    //{
    //    if(_currentState != null)
    //    {
    //        _currentState.Enter();
    //    }
    //}

    //private void Update()
    //{
    //    if(_currentState != null)
    //    {
    //        _currentState.UpdateLogic();
    //    }
    //}

    //private void LateUpdate()
    //{
    //    if(_currentState != null)
    //    {
    //        _currentState.UpdatePhysics();
    //    }
    //}

    //public void ChangeState(BaseState newState)
    //{
    //    _currentState.Exit();

    //    _currentState = newState;
    //    _currentState.Enter();
    //}
}
