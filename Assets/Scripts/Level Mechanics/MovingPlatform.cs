using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {
    public Transform[] waypoints;
    [SerializeField] bool pauses;
    Vector3 currstart;
    Vector3 currEnd;
    int currwaypt;
    bool moving;
    bool forward;
    float factor;
    float pausetime;
    [SerializeField] float speedmultiplier;
	// Use this for initialization
	void Start () {
        if (pauses)
            pausetime = 1.5f;
        else if (!pauses)
            pausetime = 0.1f;

        currwaypt = 0;
        factor = 0;
        forward = true;
        moving = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (factor >= 1)
        {
            Debug.Log("stopped");
            moving = false;
            Invoke("MoveAgain", pausetime);
            factor = 0;
            if (forward)
                currwaypt += 1;
            else if (!forward)
                currwaypt -= 1;

            if (currwaypt + 1 == waypoints.Length)
            {
                forward = false;
            }

            else if(currwaypt == 0)
            {
                forward = true;
            }
            
        }

        if (forward)
        {
            currstart = waypoints[currwaypt].position;
            currEnd = waypoints[currwaypt + 1].position;
        }

        else if(!forward)
        {
            currstart = waypoints[currwaypt].position;
            currEnd = waypoints[currwaypt - 1].position;
        }

        
        if(moving)
        {
            factor += Time.deltaTime * speedmultiplier;
            transform.position = Vector3.Lerp(currstart, currEnd, factor);
        }
	}

    void MoveAgain()
    {
        moving = true;
    }

}
