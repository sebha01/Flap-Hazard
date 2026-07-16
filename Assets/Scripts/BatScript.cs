using UnityEngine;
using UnityEngine.InputSystem;

public class BatScript : MonoBehaviour
{
    //private
    private InputAction JumpAction;

    //public
    public Rigidbody2D myRigidBody;
    public float jumpStrength = 2.0f;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        JumpAction = InputSystem.actions.FindAction("Jump");
    }

    // Update is called once per frame
    void Update()
    {
        if (JumpAction.IsPressed())
        {      
            myRigidBody.linearVelocity = Vector2.up * jumpStrength; 
        }
    }
}
