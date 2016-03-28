using UnityEngine;
using System.Collections;

public class GooShoot : MonoBehaviour {
	public Rigidbody2D redbullet;
    public Rigidbody2D bluebullet;
    public Rigidbody2D greenbullet;
	public float bulletforce;
    private Vector2 movedir;
    private short colorint = 0;
    private short unlockedcolor = 3;
    public SpriteRenderer light;
    public Sprite[] lights;
    private Vector2 shootdir;

	// Use this for initialization
	void Start () {

        light.sprite = lights[colorint];
	
	}
	
	// Update is called once per frame
	void Update () {
        if (CharacterLogic.faceright)
        {
            shootdir = Vector2.right;
        }

        else if (CharacterLogic.faceleft)
        {
            shootdir = Vector2.left;
        }

		if (Input.GetKeyDown("b"))
        {
            Rigidbody2D clone;
            clone = Instantiate(redbullet, transform.position, Quaternion.identity) as Rigidbody2D;
            clone.AddForce(Vector2.right * bulletforce, ForceMode2D.Impulse);
        }

        if (Input.GetKeyDown("n"))
        {
            Rigidbody2D clone;
            clone = Instantiate(bluebullet, transform.position, Quaternion.identity) as Rigidbody2D;
            clone.AddForce(Vector2.right * bulletforce, ForceMode2D.Impulse);
        }

        if (Input.GetKeyDown("m"))
        {
            Rigidbody2D clone;
            clone = Instantiate(greenbullet, transform.position, Quaternion.identity) as Rigidbody2D;
            clone.AddForce(Vector2.right * bulletforce, ForceMode2D.Impulse);
        }


	}

    public void ToggleColor()
    {
        colorint++;
        if(colorint >= unlockedcolor)
        {
            colorint = 0;
        }
        light.sprite = lights[colorint];
    }

    public void ShootGoo()
    {
        
        if (colorint == 0)
        {
            Rigidbody2D clone;
            clone = Instantiate(redbullet, transform.position, Quaternion.identity) as Rigidbody2D;
            clone.AddForce(shootdir * bulletforce, ForceMode2D.Impulse);
        }

        if (colorint == 1)
        {
            Rigidbody2D clone;
            clone = Instantiate(bluebullet, transform.position, Quaternion.identity) as Rigidbody2D;
            clone.AddForce(shootdir * bulletforce, ForceMode2D.Impulse);
        }

        if (colorint == 2)
        {
            Rigidbody2D clone;
            clone = Instantiate(greenbullet, transform.position, Quaternion.identity) as Rigidbody2D;
            clone.AddForce(shootdir * bulletforce, ForceMode2D.Impulse);
        }
    }
}
