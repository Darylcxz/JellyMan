using UnityEngine;
using System.Collections;

public class WinScript : MonoBehaviour {
    public static int levelUnlocked;
    public int currentlevel;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "Regularman")
        {
            currentlevel++;
            PlayerPrefs.SetInt("Level", currentlevel);

            switch(currentlevel)
            {
                case 1:
                    Application.LoadLevel("Level2");
                    break;

                case 2:
                    Application.LoadLevel("Level3");
                    break;

                case 3:
                    Application.LoadLevel("Level4");
                    break;

                case 4:
                    Application.LoadLevel("Level5");
                    break;

                case 5:
                    Application.LoadLevel("Level6");
                    break;
            }
        }
    }
}
