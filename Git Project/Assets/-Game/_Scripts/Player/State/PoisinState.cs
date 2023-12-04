using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisinState : PlayerBaseState
{
    private PlayerController playerController;
    public override void EnterState(PlayerStateManager player){
        
        GameObject playerObject = GameObject.FindWithTag("Player");
        if(playerObject != null){
            playerController = playerObject.GetComponent<PlayerController>();
            playerController.activeMoveSpeed = playerController.moveSpeed * 0.5f;
            playerController.animator.SetTrigger("poisin");
        }

    }
    public override void UpdateState(PlayerStateManager player){

    }
    public override void OnTriggerEnter2D(PlayerStateManager player,Collider2D collider2D){

    }
}
