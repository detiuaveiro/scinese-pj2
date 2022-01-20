using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackpackInteraction : MonoBehaviour
{
    public GameObject[] slots = new GameObject[4];
    private bool isActive;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            ShowInventory();
        }
    }

    public void ShowInventory()
    {
        if(isActive == false)
        {
            for (int i = 0; i < slots.Length; i++)
            {
                isActive = true;
                slots[i].gameObject.SetActive(false);
            }
        } else if(isActive == true)
        {
            for (int i = 0; i < slots.Length; i++)
            {
                isActive = false;
                slots[i].gameObject.SetActive(true);
            }
        }

    }
}
