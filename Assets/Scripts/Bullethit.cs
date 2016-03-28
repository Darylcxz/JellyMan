using UnityEngine;
using System.Collections;

public class Bullethit : MonoBehaviour {
    public GameObject redsplash;
    public GameObject bluesplash;
    public GameObject greensplash;
	// Use this for initialization
	void Start () {
	
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if (gameObject.tag == "Redbullet" && other.collider.tag == "ground")
        {
            GameObject clone1;
            clone1 = Instantiate(redsplash, transform.position, Quaternion.identity) as GameObject;
            Destroy(gameObject);
        }

        if (gameObject.tag == "Bluebullet" && other.collider.tag == "ground")
        {
            GameObject clone2;
            clone2 = Instantiate(bluesplash, transform.position, Quaternion.identity) as GameObject;
            Destroy(gameObject);
        }

        if (gameObject.tag == "Greenbullet" && other.collider.tag == "ground")
        {
            GameObject clone3;
            clone3 = Instantiate(greensplash, transform.position, Quaternion.identity) as GameObject;
            Destroy(gameObject);
        }

        if (gameObject.tag == "Redbullet" && other.collider.tag == "wall")
        {
            GameObject clone4;
            clone4 = Instantiate(redsplash, transform.position, Quaternion.Euler(0, 0, 90)) as GameObject;
            Destroy(gameObject);
        }

        if (gameObject.tag == "Bluebullet" && other.collider.tag == "wall")
        {
            GameObject clone5;
            clone5 = Instantiate(bluesplash, transform.position, Quaternion.Euler(0, 0, 90)) as GameObject;
            Destroy(gameObject);
        }

        if (gameObject.tag == "Greenbullet" && other.collider.tag == "wall")
        {
            GameObject clone6;
            clone6 = Instantiate(greensplash, transform.position, Quaternion.Euler(0, 0, 90)) as GameObject;
            Destroy(gameObject);
        }
    }
}
