using UnityEngine;

public class RedJelly : JellyBase
{
    public RedJelly()
    {
        JellyColor = JellyType.RED;
    }
    protected override void JellyPower()
    {
        //Makes surface bouncy
        Debug.Log("RED");
    }
}

public class BlueJelly : JellyBase
{
    public BlueJelly()
    {
        JellyColor = JellyType.BLUE;
    }
    protected override void JellyPower()
    {
        //Makes surface slippery
        Debug.Log("BlueJelly");
    }
}
public class PurpleJelly : JellyBase
{
    public PurpleJelly()
    {
        JellyColor = JellyType.PURPLE;
    }
    protected override void JellyPower()
    {
        //Makes surface magnetic (pull)
        Debug.Log("Purple");
    }
}
public class YellowJelly : JellyBase
{
    public YellowJelly()
    {
        JellyColor = JellyType.YELLOW;
    }
    protected override void JellyPower()
    {
        //Makes surface repel
        Debug.Log("Yellow");
    }
}
public class BlackJelly : JellyBase
{
    public BlackJelly()
    {
        JellyColor = JellyType.BLACK;
    }
    protected override void JellyPower()
    {
        //Destroy surface 
        Debug.Log("Black");
    }
}
public class WhiteJelly : JellyBase
{
    public WhiteJelly()
    {
        JellyColor = JellyType.WHITE;
    }
    protected override void JellyPower()
    {
        //Erase jelly on surface 
        Debug.Log("White");
    }
}
