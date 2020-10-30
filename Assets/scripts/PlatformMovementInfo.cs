using UnityEngine;

[CreateAssetMenu(fileName = "PlatformMovementInfo", menuName = "ScriptableObjects/platform Movement Info", order = 1)]
public class PlatformMovementInfo : ScriptableObject
{
    public float maxWidth = 5f;
    public float minWidth = 2f;
    public Vector3 initialPosition = new Vector3(-6, 0, 0);
    public float platformSpd = 0.6f;
    public float lowestY = -5;//the height the platform gets destroyed at

}