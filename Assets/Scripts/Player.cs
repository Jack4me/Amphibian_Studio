using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField] private float forcePower;

    private QuestObjectVisual _currentQuestObjectVisual;
    private bool _isHolding = false;
    private PickableItem currentInteractable;
    private bool canMove;
    private Item _item;
    private Item _lastSelectedItem;

    [SerializeField] private float jumpForce = 4.4f;
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _speed;
    private bool _isGrounded = true;
    private Rigidbody _rigidbody;
    private bool _isWalking;
    private Vector3 moveDir;

    public static Player InstantPlayer{ get; set; }
    public event EventHandler OnShowVisual;

    private void Awake(){
        if (InstantPlayer != null){
            Debug.LogError("We are have more than one INSTANCE");
        }
        InstantPlayer = this;
        _rigidbody = GetComponent<Rigidbody>();
        _playerInput = GetComponent<PlayerInput>();
    }

    private void Update(){
        HadnleInteractions();
        HandleMovement();
        if (Input.GetKeyDown(KeyCode.F)){
            Equip();
        }
        if (Input.GetKey(KeyCode.E)){
            Push();
            OnShowVisual?.Invoke(this, EventArgs.Empty);
            Debug.Log("Key E");
        }
        RaycastHit hit;
        bool _isGrounded = Physics.Raycast(transform.position, Vector3.down, out hit, 0.1f);
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded){
            Jump();
        }
    }

    public void Push(){
        // if (GetCurrentItem().TryGetComponent(out PushableObject pushableObject)){
        //     Rigidbody rigidbody = pushableObject.GetComponent<Rigidbody>();
        //     if (rigidbody != null){
        //         Vector3 playerToObject = pushableObject.transform.position - transform.position;
        //         playerToObject.y = 0;
        //         float angle = Vector3.Angle(transform.forward, playerToObject);
        //         // Если угол меньше 90 градусов, то толкаем, иначе тянем
        //         Vector3 forceDir = angle < 90f ? playerToObject.normalized : -playerToObject.normalized;
        //
        //         // Применяем силу
        //         rigidbody.AddForce(forceDir * forcePower, ForceMode.Impulse);
        //         Debug.Log("Pushable " + pushableObject.name);
        //     }
        // }
    }

    public void Equip(){
        if (GetCurrentItem() != null && !_isHolding){
            if (GetCurrentItem().TryGetComponent(out PickableItem pickableItem)){
                pickableItem.Pickup();
                _isHolding = true;
            }
        }
        else if (_isHolding){
            GetCurrentItem().TryGetComponent(out PickableItem pickableItem);
            pickableItem.Drop();
            ClearSelectedItem();
            _isHolding = false;
        }
        // if (_isHolding){
        //     if (GetCurrentItem().transform.TryGetComponent(out PickableItem pickableItem)){
        //         pickableItem.Drop();
        //         _isHolding = false;
        //     }
        // }
        // else if (GetCurrentItem() != null && !_isHolding){
        //     if (GetCurrentItem().transform.TryGetComponent(out PickableItem pickableItem)){
        //         pickableItem.Pickup();
        //         _isHolding = true;
        //     }
        // }
    }

    public QuestObjectVisual GetCurrentQuestObject(){
        return _currentQuestObjectVisual;
    }

    public Item GetCurrentItem(){
        return _item;
    }

    public void CurrentSelectedItem(Item _item){
        this._item = _item;
    }

    public void ClearSelectedItem(){
        _item = null;
    }

    private void HadnleInteractions(){
        Vector3 inputVector = _playerInput.InputVectorNormalize();
        Vector3 direction = new Vector3(inputVector.x, 0, inputVector.y);
        float distance = _speed * Time.deltaTime;
        float playerHeight = 0.2f;
        float playerRadius = 0.2f;
        float interactDistance = 2f;
        RaycastHit hit;
        if (Physics.CapsuleCast(transform.position, transform.position + Vector3.forward * 0.2f,
                0.2f, direction, out hit, distance)){
            if (hit.transform.TryGetComponent(out Item item)){
                if (!_isHolding){
                    CurrentSelectedItem(item);
                }
            }
        }
    }

    private void HandleMovement(){
        Vector3 inputVector = _playerInput.InputVectorNormalize();
        Vector3 direction = new Vector3(inputVector.x, 0, inputVector.y);
        float distance = _speed * Time.deltaTime;
        float playerHeight = 0.2f;
        float playerRadius = 0.2f;
        canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight,
            playerRadius, direction, distance);
        Debug.Log(canMove);
        if (!canMove){
            Vector3 moveX = new Vector3(direction.x, 0, 0).normalized;
            canMove = direction.x != 0 && !Physics.CapsuleCast(transform.position,
                transform.position + Vector3.up * playerHeight,
                playerRadius, moveX, distance);
            if (canMove){
                direction = moveX;
            }
            else{
                Vector3 moveZ = new Vector3(0, 0, direction.z).normalized;
                canMove = direction.z != 0 && !Physics.CapsuleCast(transform.position,
                    transform.position + Vector3.up * playerHeight,
                    playerRadius, moveZ, distance);
                if (canMove){
                    direction = moveZ;
                }
            }
        }
        if (canMove){
            transform.position += direction * distance;
        }
        _isWalking = direction != Vector3.zero;
        float rotateSpeed = 12;
        transform.forward = Vector3.Slerp(transform.forward, direction, Time.deltaTime * rotateSpeed);
    }

    public bool IsHolding(){
        return _isHolding;
    }

    private void Jump(){
        _rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        _isGrounded = false;
    }

    public bool IsWalking(){
        return _isWalking && canMove;
    }
    // private void OnTriggerEnter(Collider other){
    //     if (other.transform.TryGetComponent(out PickableItem interactableObj) && !_isHolding){
    //         currentInteractable = interactableObj;
    //     }
    //     if (other.transform.TryGetComponent(out QuestObjectVisual questObject)){
    //         _currentQuestObjectVisual = questObject;
    //     }
    // }
    //
    // private void OnTriggerExit(Collider other){
    //     if (other.transform.TryGetComponent(out PickableItem interactableObj) &&
    //         interactableObj == currentInteractable && !_isHolding){
    //         currentInteractable = null;
    //     }
    //     if (other.transform.TryGetComponent(out QuestObjectVisual questObject)){
    //         _currentQuestObjectVisual = null;
    //         OnShowVisual?.Invoke(this, EventArgs.Empty);
    //     }
    // }
}