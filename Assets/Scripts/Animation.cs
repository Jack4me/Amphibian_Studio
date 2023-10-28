using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour {
    private const string IsWalking = "IsWalking";
    private const string IsStartPushing = "IsStartPushing";
    private const string IsCarry = "IsCarry";
    [SerializeField] Push push;
    private Animator animator;

    [SerializeField] private Player player;
    [SerializeField] private PickableItem _pickableItem;

    private void Awake(){
        animator = GetComponent<Animator>();
    }

    private void Update(){
        animator.SetBool(IsCarry, player.IsHolding());
        animator.SetBool(IsWalking, player.IsWalking());
        animator.SetBool(IsStartPushing, push.IsPushing());
    }
}