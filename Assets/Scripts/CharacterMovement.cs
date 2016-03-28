using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {
	private Rigidbody2D jm;
	public static Vector2 moveDirection = Vector3.zero;
	public float movespeed;
	public float jumpspeed;
	private bool onGround = true;
    public bool moveRight = false;
    public bool moveLeft = false;
    public static bool faceleft = false;
    public static bool faceright = true;
	private Vector2 temp1;
	private Vector2 temp2;
    


	// Use this for initialization
	void Start () {
		jm = GetComponent<Rigidbody2D> ();

		temp1 = transform.localScale;
		temp2 = transform.localScale;
		temp2.x *= -1;
	}


	// Update is called once per frame
	void FixedUpdate () {

        if (onGround)
        {
            moveDirection = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
            moveDirection *= movespeed;

            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpspeed;
                jm.AddForce(Vector3.up, ForceMode2D.Impulse);
                //onGround = false;
            }
        }

        if (moveLeft && onGround)
        {
            transform.localScale = temp2;
            //jm.velocity = Vector2.left * 7;
            jm.AddForce(Vector2.left * 0.5f, ForceMode2D.Impulse);
        }

        if (moveRight && onGround)
        {
            transform.localScale = temp1;
            //jm.velocity = Vector2.right * 7;
            jm.AddForce(Vector2.right * 0.5f, ForceMode2D.Impulse);
        }

	}

	void OnCollisionEnter2D(Collision2D other)
	{
        //if(other.gameObject.tag == "ground" || other.gameObject.tag == "wall")
		if (other.gameObject.tag == "red") {
			//moveDirection.y = 7;
			jm.AddForce (Vector2.up * 7, ForceMode2D.Impulse);
		}

		if (other.gameObject.tag == "green") {
			//jm.AddForce(-moveDirection * 10, ForceMode2D.Impulse);
		}
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if (other.gameObject.tag == "blue") {
			jm.AddForce(moveDirection * 4,ForceMode2D.Impulse);
		}

		if (other.gameObject.tag == "purple") {
			Vector2 suckaim = other.transform.position - transform.position;
			jm.AddForce(suckaim * 20, ForceMode2D.Force);
			if(Input.GetKeyDown("space"))
			{
				jm.AddForce(Vector2.up * -70, ForceMode2D.Impulse);
			}

		}
	}

    public void moverightOn()
    {
        moveRight = true;
        faceright = true;
        if(faceleft)
        {
            faceleft = false;
        }
    }

    public void moverightOff()
    {
        moveRight = false;
        jm.velocity = Vector2.zero;
    }

    public void moveleftOn()
    {
        moveLeft = true;
        faceleft = true;
        if(faceright)
        {
            faceright = false;
        }
    }

    public void moveleftOff()
    {
        moveLeft = false;
        jm.velocity = Vector2.zero;
    }

    public void Jump()
    {
        jm.AddForce(Vector2.up * 7, ForceMode2D.Impulse);
    }
}
