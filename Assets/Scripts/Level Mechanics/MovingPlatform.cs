using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {
    public Transform startpt;
    public Transform endpt;
    bool direction;
    float factor;
    [SerializeField] float speedmultiplier;
	// Use this for initialization
	void Start () {
        direction = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if(direction)
        {
            factor += Time.deltaTime * speedmultiplier;
        }

        else if(!direction)
        {
            factor -= Time.deltaTime * speedmultiplier;
        }
        
        transform.position = Vector3.Lerp(startpt.position, endpt.position, factor);
        if(factor >= 1)
        {
            direction = false;
        }

        if(factor <= 0)
        {
            direction = true;
        }
	}
}
