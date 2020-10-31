using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform : MonoBehaviour
{
    PlatformMovementInfo moveInfo;
    public PlatformsPool parentPool;
    // Start is called before the first frame update
    void Start()
    {
        moveInfo = GameMan.Instance.movementInfo;
    }

    [ContextMenu("foo")]
    public void initialize()
    {
        Vector3 tmpScale = transform.localScale;
        Vector3 tmpPos = new Vector2(0, 0);

        tmpScale.x = Random.Range(GameMan.Instance.movementInfo.minWidth, GameMan.Instance.movementInfo.maxWidth); 
        tmpPos.x = Random.Range(-2.5f, 2.5f);

        tmpPos.y = GameMan.Instance.movementInfo.spacing * GameMan.Instance.movementInfo.level;
        GameMan.Instance.movementInfo.level++;

        transform.localScale = tmpScale;
        transform.position = tmpPos;
    }


    [ContextMenu("move down")]
    public void checkDestroy()//if platform is below threshold destroy and create a new one
    {
        if(transform.position.y <= GameMan.Instance.movementInfo.lowestY)
        {
            gameObject.SetActive(false);
            parentPool.spawn();
        }
    }

}
