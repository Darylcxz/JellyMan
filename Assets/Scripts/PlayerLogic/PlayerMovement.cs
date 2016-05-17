using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
    Rigidbody rb;
    Animator jmAnim;
    [SerializeField]float speed;
    [SerializeField]float jumpspeed;
    [SerializeField]float airspeed;
    [SerializeField]float jumpmultiplier;
    [SerializeField]float maxhangtime;
    [SerializeField]float gravity;
    float hori;
    float hangtime;
    Vector3 targetrot;
    bool jumpboosted;
    bool OnGround;
    bool slide;
    GameObject groundtag;
    public LayerMask layer;
    ParticleSystem healeffect;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        groundtag = transform.GetChild(0).gameObject;
        slide = false;
        healeffect = transform.GetChild(1).GetComponent<ParticleSystem>();
        jmAnim = GetComponent<Animator>();
	}
	void Update()
    {
        hori = Input.GetAxis("Horizontal");
        OnGround = Physics.Linecast(transform.position, groundtag.transform.position, layer);
        if(Input.GetButtonDown("Jump") && OnGround)
        {
            Jump();
            jmAnim.SetTrigger("jump");
        }
        if(Input.GetButton("Jump") && !jumpboosted)
        {
            rb.AddForce(Vector3.up * jumpspeed * jumpmultiplier, ForceMode.Acceleration);
            hangtime += Time.deltaTime;
        }

        if (Input.GetButtonDown("Jump") && !OnGround)
            jmAnim.SetTrigger("Hover");

        if(hangtime > maxhangtime && !jumpboosted)
        {
            //rb.AddForce(Vector3.up * 100);
            jumpboosted = true;
            hangtime = 0;
        }

        if(Input.GetButtonUp("Jump"))
        {
            jumpboosted = false;
            hangtime = 0;
        }

        if(!OnGround )
        {
            rb.AddForce(Vector3.down * gravity, ForceMode.Acceleration);
        }
    }
	// Update is called once per frame
	void FixedUpdate () {
        
        if(!OnGround)
        {
            JumpMove(hori);
        }
        else if(OnGround)
        {
            Move(hori);
        }

        Rotate(hori);
	}

    void Move(float h)
    {
        // velocity movement
        float input = Mathf.Abs(hori);
        jmAnim.SetFloat("speed", input);
        Vector3 movedir = rb.velocity;
        movedir.x = h * speed;
        rb.velocity = movedir;
        
        // Addforce movement
        //Vector3 movedir = new Vector3(h * speed, 0, 0);
        //rb.AddForce(movedir, ForceMode.VelocityChange);
    }

    void Rotate(float horizontal)
    {
        
        if(hori > 0.1f)
        {
            targetrot = Vector3.right;
        }

        else if(hori < -0.1f)
        {
            targetrot = Vector3.left;
        }
        Quaternion rotation = Quaternion.LookRotation(targetrot);
        rb.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 10);
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpspeed, ForceMode.VelocityChange);
        //rb.velocity += Vector3.up * jumpspeed;
        Debug.Log("jump");
    }

    void JumpMove(float h)
    {
        Vector3 movedir = rb.velocity;
        movedir.x = h * airspeed;
        rb.velocity = movedir;
        //if (h < 0.1f)
        //{
        //    rb.drag = 0;
        //}
        //Vector3 movedir = new Vector3(h * airspeed, 0, 0);
        //rb.AddForce(movedir, ForceMode.VelocityChange);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Healing"))
        {
            healeffect.Play();
            HP.recover(2);
            Destroy(other.gameObject);
        }

        if(other.CompareTag("Spikes"))
        {
            HP.damage(5);
        }
    }
}
