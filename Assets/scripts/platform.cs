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
        Vector3 tmpPos = GameMan.Instance.movementInfo.initialPosition;

        tmpScale.x = Random.Range(GameMan.Instance.movementInfo.minWidth, GameMan.Instance.movementInfo.maxWidth); 
        tmpPos.x += Random.Range(0.5f, 5f);

        transform.localScale = tmpScale;
        transform.position = tmpPos;
    }

    [ContextMenu("move down")]
    public void moveDown()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, -50), GameMan.Instance.movementInfo.platformSpd * Time.deltaTime);
        if(transform.position.y <= GameMan.Instance.movementInfo.lowestY)
        {
            gameObject.SetActive(false);
            parentPool.spawn();
        }
    }

}
