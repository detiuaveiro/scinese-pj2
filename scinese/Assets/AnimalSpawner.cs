using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalSpawner : MonoBehaviour
{
    public GameObject[] animals = new GameObject[4];
    private Player player;

    public void Start()
    {
        player = GameManager.instance.player;
    }

    // Update is called once per frame
    void Update()
    {
        if(player.animalsinTemple == true)
        {
            for(int i = 0; i < animals.Length; i++)
            {
                animals[i].SetActive(true);
            }
        }
    }
}
