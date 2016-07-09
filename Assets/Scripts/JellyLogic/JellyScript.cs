using UnityEngine;
using System.Collections;

public class JellyScript : JellyBase {



    // Use this for initialization
    protected override void Start()
    {
        //Stuff 
        base.Start();
    }
    // Update is called once per frame
    void Update () {
	
	}

    public void JellyEffect(int jellyType)
    {
        switch(jellyType)
        {
            case (int)JellyType.RED:
                matRenderer.material.SetColor("_Color", Color.red);
                break;
            case (int)JellyType.BLUE:
                matRenderer.material.SetColor("_Color", Color.blue);
                break;
            case (int)JellyType.PURPLE:
                Color purple = new Color(0.431f, 0, 1f);
                matRenderer.material.SetColor("_Color", purple);
                break;
            case (int)JellyType.YELLOW:
                matRenderer.material.SetColor("_Color", Color.yellow);
                break;
            case (int)JellyType.BLACK:
                matRenderer.material.SetColor("_Color", Color.black);
                break;
            case (int)JellyType.WHITE:
                matRenderer.material.SetColor("_Color", Color.white);
                break;
        }
    }

    //void JellyEffect()
    //{
    //    switch(JellyColor)
    //    {
    //        case JellyType.RED:
    //            break;
    //        case JellyType.BLUE:
    //            break;
    //        case JellyType.PURPLE:
    //            break;
    //        case JellyType.YELLOW:
    //            break;
    //        case JellyType.BLACK:
    //            break;
    //        case JellyType.WHITE:
    //            break;
    //    }
    //}
}
