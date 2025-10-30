using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    InputSystem_Actions actions;
    private Vector3 input;
    public float speed = 1;
    public float gasConsumption = 1;
    

    private BoxCollider2D bc;

    public Action OnCollisionAction;
    public Action OnTrigerAction;
    public Action OnUnTriggerAction;
    
    private StateTransitioner stateTransitioner;
    
    private void Awake()
    {
        actions = new InputSystem_Actions();

        actions.Player.Move.performed += context =>
        {
            input = context.ReadValue<Vector2>();
            
        };

        actions.Player.Move.canceled += context =>
        {
            input =  context.ReadValue<Vector2>();
        };
        
        actions.Player.Move.Enable();
        
        bc = GetComponent<BoxCollider2D>();

        stateTransitioner = new StateTransitioner();
        stateTransitioner.OwnerPlayer = this;
    }

    private void OnDestroy()
    {
        actions.Dispose();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        

    }

    
    // Update is called once per frame
    private void Update()
    {
        transform.position += input * (Time.deltaTime * speed);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        OnCollisionAction.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        OnTrigerAction.Invoke();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        OnUnTriggerAction.Invoke();
    }

    public void TransitionToState(StateInterface newState)
    {
        newState.Do(this);
    }
}
