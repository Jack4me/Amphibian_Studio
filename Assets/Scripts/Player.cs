using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField] private float forcePower;
    [SerializeField] public float rotateSpeed;
    private QuestBookVisual _currentQuestBookVisual;
    private bool _isHolding = false;
    private PickableItem currentInteractable;
    private Item _item;
    private Item _lastSelectedItem;
    private Vector3 directionRotation;
    [SerializeField] private float jumpForce = 4.4f;
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _speed;
    [SerializeField]private QuestBookVisual _questBookVisual;
    private bool _isGrounded = true;
    private Rigidbody _rigidbody;
    private bool _isWalking;
    private Vector3 moveDir;
    public bool IsPressedE{ get; private set; }
    public static Player InstantPlayer{ get; set; }
    public event EventHandler OnPressButtonE;

    private void Awake(){
        if (InstantPlayer != null){
            Debug.LogError("We are have more than one INSTANCE");
        }
        InstantPlayer = this;
        _rigidbody = GetComponent<Rigidbody>();
        _playerInput = GetComponent<PlayerInput>();
    }

    private void Update(){
        HandleMovement();
        if (Input.GetKeyDown(KeyCode.F)){
            Equip();
        }
        if (Input.GetKeyDown(KeyCode.E)){
            IsPressedE = true;
            OnPressButtonE?.Invoke(this, EventArgs.Empty);
            if (_isHolding && GetCurrentItem().TryGetComponent(out Eatable eatable)){
                Debug.Log("EAT ITEM");
                eatable.EatItem();
                ClearSelectedItem();
                if (eatable.TryGetComponent(out PickableItem pickableItem)){
                    pickableItem.Drop();
                    _isHolding = false;
                }
            }
        }
        if (Input.GetKeyUp(KeyCode.E)){
            IsPressedE = false;
        }
        RaycastHit hit;
        bool _isGrounded = Physics.Raycast(transform.position, Vector3.down, out hit, 0.1f);
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded){
            Jump();
        }
    }

    public void Equip(){
        if (GetCurrentItem() != null){
            if (GetCurrentItem().TryGetComponent(out PickableItem pickableItem) && !_isHolding){
                pickableItem.Pickup();
                _isHolding = true;
            }
            else{
                print("DROP");
                pickableItem.Drop();
                _isHolding = false;
                SetSelectedItem(null);
            }
        }
    }

    public bool IsHolding(){
        if (_questBookVisual.IsCanPickUp){
            
            return _isHolding ;
        }
        return  false;
    }

    public void ChangeHold(){
        _isHolding = false;
    }

    

    public Item GetCurrentItem(){
        return _item;
    }

    public void SetSelectedItem(Item _item){
        this._item = _item;
    }

    public void ClearSelectedItem(){
        _item = null;
    }

    public void HandleMovement(){
        Vector3 inputVector = _playerInput.InputVectorNormalize();
        directionRotation = new Vector3(inputVector.x, 0, inputVector.y);
        float distance = _speed * Time.deltaTime;
        float playerHeight = 0.2f;
        float playerRadius = 0.2f;
        _isWalking = directionRotation != Vector3.zero;
        transform.position += directionRotation * distance;
        transform.forward = Vector3.Slerp(transform.forward, directionRotation, Time.deltaTime * rotateSpeed);
    }

    private void Jump(){
        _rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    public bool IsWalking(){
        return _isWalking && _isGrounded;
    }

    private void OnTriggerEnter(Collider other){
        if (other.transform.TryGetComponent(out PickableItem pickableItem) && !_isHolding){
            SetSelectedItem(pickableItem);
        }
    }

    private void OnTriggerExit(Collider other){
        if (other.transform.TryGetComponent(out PickableItem interactableObj) && !_isHolding){
            SetSelectedItem(null);
            Debug.Log("CLEAR = null");
            currentInteractable = null;
        }
    }

    public bool IsGruonded(){
        RaycastHit hit;
        bool _isGrounded = Physics.Raycast(transform.position, Vector3.down, out hit, 0.1f);
        return _isGrounded;
    }
}