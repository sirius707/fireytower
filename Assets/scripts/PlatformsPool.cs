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

        for(int i = 0; i < platforms.Length; i++)
        {
            platforms[i].gameObject.SetActive(true);
            platforms[i].initialize();
        }
    }

    // Attempt to free some platforms to create new ones
    public void free()
    {
        foreach (platform p in platforms){
            if (p.gameObject.activeSelf){
                if (p.isActiveAndEnabled) p.checkDestroy();
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
