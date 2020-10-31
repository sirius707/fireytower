using UnityEngine;

[CreateAssetMenu(fileName = "PlatformMovementInfo", menuName = "ScriptableObjects/platform Movement Info", order = 1)]
public class PlatformMovementInfo : ScriptableObject
{
    public float maxWidth = 5.3f;
    public float minWidth = 3.2f;
    
    public float spacing = 2;// 2 units between each platform
    public float level = -2;// which level the to begin platforming

    public float platformSpd = 0.6f;
    public float lowestY = -5;//the height the platform gets destroyed at

}