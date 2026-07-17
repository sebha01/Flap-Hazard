using UnityEngine;
using UnityEngine.InputSystem;

public class BatScript : MonoBehaviour
{
    //private
    private InputAction JumpAction;

    //public
    public Rigidbody2D myRigidBody;
    public float jumpStrength = 2.0f;
    public LogicScript logic;
    public bool batIsAlive = true;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        batIsAlive = true;
        JumpAction = InputSystem.actions.FindAction("Jump");
    }

    // Update is called once per frame
    void Update()
    {
        if (JumpAction.IsPressed() && batIsAlive)
        {      
            myRigidBody.linearVelocity = Vector2.up * jumpStrength; 
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Bounds"))
        {
            logic.GameOver();
            batIsAlive = false;
        }
    }
}
