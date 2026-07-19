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
    
    
    Animator animator;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();

        batIsAlive = true;
        animator.SetBool("batIsAlive", batIsAlive);
        
        JumpAction = InputSystem.actions.FindAction("Jump");
    }

    // Update is called once per frame
    void Update()
    {
        if (JumpAction.IsPressed() && batIsAlive)
        {
            myRigidBody.linearVelocity = Vector2.up * jumpStrength;
        }

        if (JumpAction.WasPressedThisFrame() && batIsAlive)
        {
            GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().Play("BatFlapSfx");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Bounds") && batIsAlive)
        {
            batIsAlive = false;
            animator.SetBool("batIsAlive", batIsAlive);
            GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().Play("GameOverSfx"); 
            logic.GameOver();
        }
    }
}
