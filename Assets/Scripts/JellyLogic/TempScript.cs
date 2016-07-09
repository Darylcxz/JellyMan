using UnityEngine;
using System.Collections;

public class TempScript : MonoBehaviour {

    [SerializeField] Transform shootPoint;          //Point where the player shoots from
    [SerializeField] Rigidbody jellyPrefab;         //jelly prefab the player shoots out
    short jellyNum;                                 //keeps track of which Jelly to shoot
    short bulletForce = 5;        //force of the bullet and how far it should fly
    [Range(1.0f,10.0f)]
    [SerializeField] short shotMultiplier = 2;      //mulitplier for shooting
    [SerializeField] JellyBase.JellyType currJellyType = JellyBase.JellyType.RED;

    JellyScript jellyScript;
    int numPress = 0;                               //number of presses

    /* The idea is to let the player control which jelly type they are shooting, so once they choose the color
     * Instantiate a jelly when they click, this script sends message to the jelly making it the jelly they chose
     * Jelly script does whatever jelly effect.
     */



    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        CheckInput();
	}
    void CheckInput()
    {
        bool fire1 = Input.GetMouseButtonDown(0);                                                           //If you press left click
        if(fire1)                                                                                           
        {
            Fire();                                                                                         //shoot
        }

        #region Temp Keypress jelly switch
        
        bool fire2 = Input.GetMouseButtonDown(1);                                                           //if you press right click
        if(fire2)
        {
            numPress++;
            if(numPress > 5)
            {
                numPress = 0;
            }
            currJellyType = (JellyBase.JellyType)numPress;                                                  //changes jelly to right click
            Debug.Log(numPress + " & " + currJellyType);
        }

        #endregion
    }
    void Fire()
    {   
        Rigidbody jellyClone = (Rigidbody)Instantiate(jellyPrefab, shootPoint.position, Quaternion.identity); //instantiates jelly
        jellyClone.AddForce(shootPoint.forward * bulletForce * shotMultiplier,ForceMode.Impulse);             //applies physics
        jellyScript = jellyClone.GetComponent<JellyScript>();                                                 //get component
        jellyScript.JellyEffect((int)currJellyType);                                                          //changes prefab jelly type
        //jellyScript.SendMessage("JellyEffect", (int)currJellyType, SendMessageOptions.DontRequireReceiver);
        //maybe add object pooling shenanigans later
       
        
        //  CheckJellyType(jellyClone);


    }


    #region Obsoleted functions
    //void SetJellyType(Rigidbody jellyToShoot)
    //{
    //    jellyScript = jellyToShoot.GetComponent<JellyScript>();
    //    switch (currJellyType)
    //    {
    //        case JellyBase.JellyType.RED:
    //            jellyScript.JellyEffect((int)currJellyType);
    //            break;

    //    }
    //}

    //void CheckJellyType(Rigidbody jellyToShoot)
    //{
    //    switch(currJellyType)
    //    {
    //        case JellyBase.JellyType.RED:
    //            jellyToShoot.gameObject.AddComponent<RedJelly>();
    //            break;
    //        case JellyBase.JellyType.BLUE:
    //            jellyToShoot.gameObject.AddComponent<BlueJelly>();
    //            break;
    //        case JellyBase.JellyType.PURPLE:
    //            jellyToShoot.gameObject.AddComponent<PurpleJelly>();
    //            break;
    //        case JellyBase.JellyType.YELLOW:
    //            jellyToShoot.gameObject.AddComponent<YellowJelly>();
    //            break;
    //        case JellyBase.JellyType.BLACK:
    //            jellyToShoot.gameObject.AddComponent<BlackJelly>();
    //            break;
    //        case JellyBase.JellyType.WHITE:
    //            jellyToShoot.gameObject.AddComponent<WhiteJelly>();
    //            break;


    //    }
    //}
    #endregion


}
