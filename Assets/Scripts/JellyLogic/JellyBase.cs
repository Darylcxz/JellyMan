using UnityEngine;
using System.Collections;

public class JellyBase : MonoBehaviour {

	public enum JellyType //6-7 total
    {
        RED,            //makes surfaces bouncy
        BLUE,           //makes them slippery, propels player
        PURPLE,         //Magnetic, pulls player towards
        YELLOW,         //Repulsion, pushes player away
        BLACK,          //Strong acid, deletes blocks
        WHITE,          //Cum, erases stuff

    }
    public JellyType JellyColor;
    [SerializeField] protected MeshRenderer matRenderer;

    protected virtual void Start()
    {
        matRenderer = matRenderer.GetComponent<MeshRenderer>();
    }
    protected virtual void OnCollisionEnter()
    {
        //Might wanna check if it hits on a surface? Or do we do that via physics layering lol
        JellyPower();           //Jelly power activates whenever it hits any surface whatsoever
    }
    protected virtual void JellyPower()
    {

    }
}


