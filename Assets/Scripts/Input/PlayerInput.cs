using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {
    public Transform interactObjectPoint;
    private PlayerInputAction _playerInputAction;

    private void Awake(){
        _playerInputAction = new PlayerInputAction();
        _playerInputAction.Enable();
    }

    public Vector2 InputVectorNormalize(){
        
        Vector2 moveDir = _playerInputAction.Player.Move.ReadValue<Vector2>();
        moveDir = moveDir.normalized;
        return moveDir;
    }
}
