using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMan : MonoBehaviour
{
    #region SINGLETON PATTERN
    private static GameMan _instance;

    public static GameMan Instance { get { return _instance; } }
    
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    #endregion

    public PlatformsPool platforms;
    public PlatformMovementInfo movementInfo;

    public GameObject platformPoolPrefab;

    // Start is called before the first frame update
    void Start()
    {
        platforms = Instantiate(platformPoolPrefab).GetComponent<PlatformsPool>();
        movementInfo.level = -1;
        movementInfo.lowestY = -5;
    }

}
