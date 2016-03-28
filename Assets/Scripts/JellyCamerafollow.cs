using UnityEngine;
using System.Collections;

public class JellyCamerafollow : MonoBehaviour {
	private GameObject followTarget;
    private Vector3 height;

	// Use this for initialization
	void Start () {
	
		followTarget = GameObject.Find ("Regularman");
        height = new Vector3(0, 3, 0);
	}
	
	// Update is called once per frame
	void Update () {

		transform.position = followTarget.transform.position + height;
	
	}
}
