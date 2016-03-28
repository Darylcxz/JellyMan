using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour {
    public Image[] levels;
    int unlocked;
	// Use this for initialization
	void Start () {
        unlocked = 1;
        if(PlayerPrefs.HasKey("Level"))
        {
            unlocked = PlayerPrefs.GetInt("Level");
        }
        for (int i = 0; i < levels.Length; i++)
        {
            if (i + 1 > unlocked)
            {
                levels[i].enabled = false;
                Debug.Log("hide");
            }

        }
        
	}

    public void Level1()
    {
        Application.LoadLevel("Level1");
    }

    public void Level2()
    {
        Application.LoadLevel("Level2");
    }

    public void Level3()
    {
        Application.LoadLevel("Level3");
    }

    public void Level4()
    {
        Application.LoadLevel("Level4");
    }

    public void Level5()
    {
        Application.LoadLevel("Level5");
    }

    public void Level6()
    {
        Application.LoadLevel("Level6");
    }
}
