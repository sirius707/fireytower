using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformsPool : MonoBehaviour
{
    public platform[] platforms;
    public GameObject platformPrefab;
    public int poolSize;
    public float[] initialHeights;// initial y positions of initial platforms

    // Start is called before the first frame update
    void Start()
    {
        platforms = new platform[poolSize];

        for(int i = 0; i < poolSize; i++){
            GameObject gb = Instantiate(platformPrefab);
            platforms[i] = gb.GetComponent<platform>();
            platforms[i].parentPool = this;// xD
            platforms[i].gameObject.SetActive(false);
        }

        for(int i = 0; i < initialHeights.Length; i++)
        {
            platforms[i].gameObject.SetActive(true);
            platforms[i].initialize(); ;
            platforms[i].transform.position = new Vector2(platforms[i].transform.position.x, initialHeights[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (platform p in platforms){
            if (p.gameObject.activeSelf){
                //if(p.isActiveAndEnabled)p.moveDown();
            }
        }
    }

    public void spawn()
    {
        foreach (platform p in platforms)
        {
            if(p.gameObject.activeSelf == false)
            {
                p.gameObject.SetActive(true);
                p.initialize();
                break;
            }
        }
    }
}
