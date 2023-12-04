using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    PlayerBaseState currentState;
    PlayerBaseState NormalState = new NormalState();
    PlayerBaseState PoisinState = new PoisinState();
    PlayerBaseState StunnState = new StunnState();
    PlayerBaseState FrozenState = new FrozenState();
    // Start is called before the first frame update
    void Start()
    {
        currentState = NormalState;
        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }
    public void SwitchState(PlayerBaseState state){
        currentState = state;
        state.EnterState(this);
    }

    void OnTriggerEnter2D(Collider2D collider2D){

        currentState.OnTriggerEnter2D(this, collider2D);
    }
}
