using UnityEngine;
using System.Collections;

public class camerafollow : MonoBehaviour {
    GameObject target;
    bool zoomout;
    bool zoomin;
    float zoom;
    float time;
    Camera maincam;
	// Use this for initialization
	void Start () {
        target = GameObject.Find("player");
        maincam = GetComponentInChildren<Camera>();
        zoomin = false;
        zoomout = false;
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.T))
        {
            time = 0;
            if (!zoomout)
            {
                zoomout = true;
                zoomin = false;
            }
                
            else if (!zoomin && zoomout)
            {
                zoomin = true;
                zoomout = false;
            }
        }
        transform.position = target.transform.position;
	    if(zoomout)
        {
            time += Time.deltaTime;
            float fov = Mathf.Lerp(60, 100, time);
            maincam.fieldOfView = fov;
            
        }
        if(zoomin)
        {
            time += Time.deltaTime;
            float fov = Mathf.Lerp(100, 60, time);
            maincam.fieldOfView = fov;

        }
	}
}
