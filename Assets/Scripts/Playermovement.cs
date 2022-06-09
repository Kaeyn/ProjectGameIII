using UnityEngine;

public class Playermovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float speed;
    private Rigidbody2D body;
    private Animator anim;
    private bool grounded;

    private void Awake()
    {
        //Grab references
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput* speed ,body.velocity.y);
        // Flip Character
        if (horizontalInput > 0.01f)
        {
            transform.localScale = Vector3.one;
        }
        else if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            Jump();
            
        }

        //Set animator parameters
        anim.SetBool("Run", horizontalInput != 0); // Neu key k duoc nhan thi input = 0 nhan vat khong chay
        anim.SetBool("Grounded", grounded);
    }
    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, speed);
        anim.SetTrigger("Jump");
        grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }
}
