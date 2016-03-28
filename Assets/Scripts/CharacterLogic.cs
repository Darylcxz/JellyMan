using UnityEngine;
using System.Collections;

public class CharacterLogic : MonoBehaviour {
    private Rigidbody2D jm;
    public Transform groundcheck;
    public LayerMask playermask;
    public float movespeed;
    public float jumpspeed;
    private bool onGround = true;
    private Vector2 temp1;
    private Vector2 temp2;
    public float hInput;
    public static bool faceleft = false;
    public static bool faceright;

	void Start () {

        jm = this.GetComponent<Rigidbody2D>();

        temp1 = transform.localScale;
        temp2 = transform.localScale;
        temp2.x *= -1;
	}
	
	void FixedUpdate () {
        onGround = Physics2D.Linecast(transform.position, groundcheck.position, playermask);

        Move(Input.GetAxisRaw("Horizontal"));
        //Move(hInput);
        if(Input.GetButtonDown("Jump") && onGround)
        {
            Jump();
        }
	
	}

    public void Move(float horizontalInput)
    {
        if (!onGround)
            horizontalInput /= 3;

        Vector2 movement = new Vector2(horizontalInput, 0);
        movement *= movespeed;
        jm.velocity = movement;

        if(horizontalInput < 0)
        {
            transform.localScale = temp2;
        }

        else if (horizontalInput > 0)
        {
            transform.localScale = temp1;
        }
    }

    public void Jump()
    {
        //jm.AddForce(jumpspeed * Vector2.up, ForceMode2D.Impulse);
    }

    public void StartMove(float horizontal)
    {
        hInput = horizontal;
        if(horizontal > 0 && !faceright)
        {
            faceright = true;
        }

        if(horizontal < 0)
        {
            faceleft = true;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "red")
        {
            jm.AddForce(Vector2.up * jumpspeed, ForceMode2D.Impulse);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "blue")
        {
            jm.AddForce(Vector2.right * 10, ForceMode2D.Impulse);
        }
    }


}
