using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinSystem : MonoBehaviour
{
    public GameObject[] animals = new GameObject[4];
    public GameObject[] enemys = new GameObject[5];
    public GameObject trophy;
    public int x = 0;
    private Player player;

    public void Start()
    {
        player = GameManager.instance.player;
    }

    public void Update()
    {
        //foreach (GameObject animal in animals)
        //{
        //    if (animal == null)
        //    {
        //        x++;
        //    }
        //}
        //for (int i = 0; i < animals.Length; i++)
        //{
        //    for (int j = 0; j < enemys.Length; j++)
        //    {
        //        if (animals[i] != null && enemys[i] != null /*&& animals[i] != null*/)
        //        {
        //            trophy.SetActive(false);
        //        }
        //        else if (animals[i] == null && enemys[i] == null)
        //        {
        //            trophy.SetActive(true);
        //        }
        //    }
        //}

        if(animals[0] == null && animals[1] == null && animals[2] == null && animals[3] == null && enemys[0] == null && enemys[1] == null && enemys[2] == null && enemys[3] == null && enemys[4] == null)
        {
            trophy.SetActive(true);
            player.hasWon = true;
            player.animalsinTemple = true;
        }
    }
}
