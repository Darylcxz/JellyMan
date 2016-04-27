using UnityEngine;
using System.Collections;

public class TempScript : MonoBehaviour {

    [SerializeField] Transform shootPoint;          //Point where the player shoots from
    [SerializeField] Rigidbody jellyPrefab;         //jelly prefab the player shoots out
    short jellyNum;                                 //keeps track of which Jelly to shoot
    [SerializeField] short bulletForce = 50;         //force of the bullet and how far it should fly
    [SerializeField] JellyBase.JellyType currJellyType = JellyBase.JellyType.RED;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        CheckInput();
	}
    void CheckInput()
    {
        bool fire1 = Input.GetMouseButtonDown(0);
        if(fire1)
        {
            Fire();
        }
    }
    void Fire()
    {
        
        Rigidbody jellyClone = (Rigidbody)Instantiate(jellyPrefab, shootPoint.position, Quaternion.identity);
        jellyClone.AddForce(shootPoint.right * bulletForce,ForceMode.Impulse);
        //maybe add object pooling shenanigans later
        CheckJellyType(jellyClone);
        
        
    }
    void CheckJellyType(Rigidbody jellyToShoot)
    {
        switch(currJellyType)
        {
            case JellyBase.JellyType.RED:
                jellyToShoot.gameObject.AddComponent<RedJelly>();
                break;
            case JellyBase.JellyType.BLUE:
                jellyToShoot.gameObject.AddComponent<BlueJelly>();
                break;
            case JellyBase.JellyType.PURPLE:
                jellyToShoot.gameObject.AddComponent<PurpleJelly>();
                break;
            case JellyBase.JellyType.YELLOW:
                jellyToShoot.gameObject.AddComponent<YellowJelly>();
                break;
            case JellyBase.JellyType.BLACK:
                jellyToShoot.gameObject.AddComponent<BlackJelly>();
                break;
            case JellyBase.JellyType.WHITE:
                jellyToShoot.gameObject.AddComponent<WhiteJelly>();
                break;


        }
    }
}
