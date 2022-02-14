using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnKey : MonoBehaviour
{
    public GameObject enemy;
    public GameObject key;
    public bool isDropped;

    // Update is called once per frame
    void Update()
    {
        if(enemy == null && !isDropped)
        {
            isDropped = true;
            key.SetActive(true);
        }
    }
}
