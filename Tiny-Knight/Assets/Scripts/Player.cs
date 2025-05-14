using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Physics")]
    [SerializeField]
    private float gravity = -9f;
    [SerializeField]
    private float terminalVelocity = -10f;
    [SerializeField]
    private float jumpSpeed = 10f;

    [Header("Raycasts")]
    [SerializeField]
    private float groundCheck = 0.1f;

    [Header("Game Objects")]
    [SerializeField]
    private GameObject playerBody;

    [Header("Layer Masks")]
    [SerializeField] 
    private LayerMask groundMask;

    [Header("Debug Toggle")]
    [SerializeField]
    private bool groundCaster;

    private Vector3 gravityVelocity;
    private Collider[] hitCollider;
    private RaycastHit hit;

    void Start()
    {
        gravityVelocity = Vector3.zero;
    }

    void FixedUpdate()
    {
        ApplyGravity();
    }

    public void Jump()
    {
        if(isOnGround())
            gravityVelocity.y = jumpSpeed;
        
    }

    public void Interact()
    {
        Debug.Log("Interacting");
    }

    public void Dodge()
    {
        Debug.Log("Dodging");
    }

    public void Swap()
    {
        Debug.Log("Swapping");
    }

    public void Move(string direction)
    {
        Debug.Log("Move " + direction);
    }

    // applies gravity to character, called in fixedUpdate()
    void ApplyGravity(){
        if(isOnGround() && gravityVelocity.y < 0)
        {
            // on a collision snap the player to the hit point to avoid clipping through
            transform.position = hit.point;
            gravityVelocity = Vector3.zero;
            return;
        }
        if(gravityVelocity.y < terminalVelocity)
            gravityVelocity.y = terminalVelocity;
        // order here matters, update gravity after applying it to transform to avoid clipping
        transform.position += gravityVelocity * Time.fixedDeltaTime;
        gravityVelocity.y += gravity * Time.fixedDeltaTime;
    }

    // check and return true if there is a collision
    public bool isOnGround()
    {
        if(groundCaster)
            Debug.DrawRay(playerBody.transform.position, Vector3.down * groundCheck, Color.red);
        return Physics.Raycast(playerBody.transform.position, Vector3.down, out hit,groundCheck);
    }
}
