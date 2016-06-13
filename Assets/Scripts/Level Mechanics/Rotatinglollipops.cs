using UnityEngine;
using System.Collections;

public class Rotatinglollipops : MonoBehaviour {
    [SerializeField] float rotation;
    [SerializeField] bool direction;
	// Use this for initialization
	void Start () {

        if (direction)
            rotation = rotation * -1;
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.right, rotation * Time.deltaTime);
	}
}
