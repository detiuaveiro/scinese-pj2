using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotController : MonoBehaviour
{
    private Player player;
    public int i;
    private bool[] isSelected = new bool[4];
    public Animator animator;
    public GameObject slot1;
    public GameObject slot2;
    public GameObject slot3;
    public GameObject slot4;


    // Start is called before the first frame update
    void Start()
    {
        player = GameManager.instance.player; // remember we're using the Singleton pattern!!
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            slot2.GetComponent<Animator>().SetBool("isSelected", false);
            slot3.GetComponent<Animator>().SetBool("isSelected", false);
            slot4.GetComponent<Animator>().SetBool("isSelected", false);

            for(int j =0; j< isSelected.Length; j++) //Deixar todos os slots a false
            {
                isSelected[j] = false;
            }

            if(isSelected[0] == false) 
            {
                isSelected[0] = true; // Selected = true na posição 0 do array
                slot1.GetComponent<Animator>().SetBool("isSelected", true);
            } 
        }else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            slot1.GetComponent<Animator>().SetBool("isSelected", false);
            slot3.GetComponent<Animator>().SetBool("isSelected", false);
            slot4.GetComponent<Animator>().SetBool("isSelected", false);

            for (int j = 0; j < isSelected.Length; j++)
            {
                isSelected[j] = false;
            }

            if (isSelected[1] == false)
            {
                isSelected[1] = true;
                slot2.GetComponent<Animator>().SetBool("isSelected", true);
            }
        }else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            slot1.GetComponent<Animator>().SetBool("isSelected", false);
            slot2.GetComponent<Animator>().SetBool("isSelected", false);
            slot4.GetComponent<Animator>().SetBool("isSelected", false);

            for (int j = 0; j < isSelected.Length; j++)
            {
                isSelected[j] = false;
            }

            if (isSelected[2] == false)
            {
                isSelected[2] = true;
                slot3.GetComponent<Animator>().SetBool("isSelected", true);
            }
        }else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            slot1.GetComponent<Animator>().SetBool("isSelected", false);
            slot2.GetComponent<Animator>().SetBool("isSelected", false);
            slot3.GetComponent<Animator>().SetBool("isSelected", false);

            for (int j = 0; j < isSelected.Length; j++)
            {
                isSelected[j] = false;
            }

            if (isSelected[3] == false)
            {
                isSelected[3] = true;
                slot4.GetComponent<Animator>().SetBool("isSelected", true);
            }
        }

        if (isSelected[0] == true) //posição 0 pertence ao slot1 e assim sequencialmente
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                DropItem1();
            }
        }
        if (isSelected[1] == true)
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                DropItem2();
            }
        }
        if (isSelected[2] == true)
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                DropItem3();
            }
        }
        if (isSelected[3] == true)
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                DropItem4();
            }
        }



        if (slot1.transform.childCount <= 0) //Se o slot1 não tiver filhos, variavel isSlotFull = false
        {
            player.inventory.isSlotFull[0] = false;

        }else if (slot2.transform.childCount <= 0)
        {
            player.inventory.isSlotFull[1] = false;
        }
        else if (slot3.transform.childCount <= 0)
        {
            player.inventory.isSlotFull[2] = false;
        }
        else if (slot4.transform.childCount <= 0)
        {
            player.inventory.isSlotFull[3] = false;
        }
    }

   

    public void DropItem1()
    {
        foreach(Transform child in slot1.transform)
        {
            child.GetComponent<InteractInv>().SpawnDroppedItem(); //dropar item, que está como filho do slot1
            player.inventory.items.RemoveAt(0); //Remover item da posição 0 da lista, que coincide com o primeiro slot
            GameObject.Destroy(child.gameObject);
        }
    }
    public void DropItem2()
    {
        foreach (Transform child in slot2.transform)
        {
            child.GetComponent<InteractInv>().SpawnDroppedItem();
            player.inventory.items.RemoveAt(1);
            GameObject.Destroy(child.gameObject);
        }
    }
    public void DropItem3()
    {
        foreach (Transform child in slot3.transform)
        {
            child.GetComponent<InteractInv>().SpawnDroppedItem();
            player.inventory.items.RemoveAt(2);
            GameObject.Destroy(child.gameObject);
        }
    }
    public void DropItem4()
    {
        foreach (Transform child in slot4.transform)
        {
            child.GetComponent<InteractInv>().SpawnDroppedItem();
            player.inventory.items.RemoveAt(3);
            GameObject.Destroy(child.gameObject);
        }
    }

    public void UseItem()
    {
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }
}
