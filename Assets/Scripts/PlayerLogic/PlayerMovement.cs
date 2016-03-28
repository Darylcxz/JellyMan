using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
    Rigidbody rb;
    [SerializeField]float speed;
    [SerializeField]float jumpspeed;
    bool OnGround;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Move(Input.GetAxisRaw("Horizontal"));
	}

    void Move(float h)
    {
        Vector3 movedir = Vector3.right * h * speed;
        rb.velocity = movedir;
    }
}
