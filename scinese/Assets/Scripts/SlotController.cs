using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotController : MonoBehaviour
{
    private Player player;
    public int i;
    private bool[] isSelected = new bool[4];
    public Animator animator;
    //public GameObject slot1;
    //public GameObject slot2;
    //public GameObject slot3;
    //public GameObject slot4;
    public GameObject[] slots = new GameObject[4];


    // Start is called before the first frame update
    void Start()
    {
        player = GameManager.instance.player; // remember we're using the Singleton pattern!!
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            slots[1].GetComponent<Animator>().SetBool("isSelected", false);
            slots[2].GetComponent<Animator>().SetBool("isSelected", false);
            slots[3].GetComponent<Animator>().SetBool("isSelected", false);

            for (int j = 0; j < isSelected.Length; j++) //Deixar todos os slots a false
            {
                isSelected[j] = false;
            }

            if (isSelected[0] == false)
            {
                isSelected[0] = true; // Selected = true na posição 0 do array
                slots[0].GetComponent<Animator>().SetBool("isSelected", true);
            }
        } else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            slots[0].GetComponent<Animator>().SetBool("isSelected", false);
            slots[2].GetComponent<Animator>().SetBool("isSelected", false);
            slots[3].GetComponent<Animator>().SetBool("isSelected", false);

            for (int j = 0; j < isSelected.Length; j++)
            {
                isSelected[j] = false;
            }

            if (isSelected[1] == false)
            {
                isSelected[1] = true;
                slots[1].GetComponent<Animator>().SetBool("isSelected", true);
            }
        } else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            slots[0].GetComponent<Animator>().SetBool("isSelected", false);
            slots[1].GetComponent<Animator>().SetBool("isSelected", false);
            slots[3].GetComponent<Animator>().SetBool("isSelected", false);

            for (int j = 0; j < isSelected.Length; j++)
            {
                isSelected[j] = false;
            }

            if (isSelected[2] == false)
            {
                isSelected[2] = true;
                slots[2].GetComponent<Animator>().SetBool("isSelected", true);
            }
        } else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            slots[0].GetComponent<Animator>().SetBool("isSelected", false);
            slots[1].GetComponent<Animator>().SetBool("isSelected", false);
            slots[2].GetComponent<Animator>().SetBool("isSelected", false);

            for (int j = 0; j < isSelected.Length; j++)
            {
                isSelected[j] = false;
            }

            if (isSelected[3] == false)
            {
                isSelected[3] = true;
                slots[3].GetComponent<Animator>().SetBool("isSelected", true);
            }
        }

        if (isSelected[0] == true) //posição 0 pertence ao slot1 e assim sequencialmente
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                //  DropItem1();
                DropItem(slots[0], 0);
            }
        }
        if (isSelected[1] == true)
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                //  DropItem2();
                DropItem(slots[1], 1);
            }
        }
        if (isSelected[2] == true)
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                // DropItem3();
                DropItem(slots[2], 2);
            }
        }
        if (isSelected[3] == true)
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                //  DropItem4();
                DropItem(slots[3], 3);
            }
        }

        if (slots[0].transform.childCount <= 0) //Se o slot1 não tiver filhos, variavel isSlotFull = false
        {
            player.inventory.isSlotFull[0] = false;

        }
        else if (slots[1].transform.childCount <= 0)
        {
            player.inventory.isSlotFull[1] = false;
        }
        else if (slots[2].transform.childCount <= 0)
        {
            player.inventory.isSlotFull[2] = false;
        }
        else if (slots[3].transform.childCount <= 0)
        {
            player.inventory.isSlotFull[3] = false;
        }

        //if (slot1.transform.childCount <= 0) //Se o slot1 não tiver filhos, variavel isSlotFull = false
        //{
        //    player.inventory.isSlotFull[0] = false;

        //}else if (slot2.transform.childCount <= 0)
        //{
        //    player.inventory.isSlotFull[1] = false;
        //}
        //else if (slot3.transform.childCount <= 0)
        //{
        //    player.inventory.isSlotFull[2] = false;
        //}
        //else if (slot4.transform.childCount <= 0)
        //{
        //    player.inventory.isSlotFull[3] = false;
        //}
    }


    public void DropItem(GameObject slot, int i)
    {
        foreach (Transform child in slot.transform)
        {
            child.GetComponent<InteractInv>().SpawnDroppedItem(); //dropar item, que está como filho do slot1
                                                                  //  player.inventory.items.RemoveAt(0); //Remover item da posição 0 da lista, que coincide com o primeiro slot
            player.inventory.items[i] = null;
            player.inventory.itemIn[i] = false;
            GameObject.Destroy(child.gameObject);
        }
    }
    //public void DropItem2()
    //{
    //    foreach (Transform child in slots[1].transform)
    //    {
    //        child.GetComponent<InteractInv>().SpawnDroppedItem();
    //        player.inventory.items[1] = null;
    //        player.inventory.itemIn[1] = false;
    //        GameObject.Destroy(child.gameObject);
    //    }
    //}
    //public void DropItem3()
    //{
    //    foreach (Transform child in slots[2].transform)
    //    {
    //        child.GetComponent<InteractInv>().SpawnDroppedItem();
    //        //   player.inventory.items.RemoveAt(2);
    //        player.inventory.items[2] = null;
    //        player.inventory.itemIn[2] = false;
    //        GameObject.Destroy(child.gameObject);
    //    }
    //}
    //public void DropItem4()
    //{
    //    foreach (Transform child in slots[3].transform)
    //    {
    //        child.GetComponent<InteractInv>().SpawnDroppedItem();
    //        player.inventory.items[3] = null;
    //        player.inventory.itemIn[3] = false;
    //        //    player.inventory.items.RemoveAt(3);
    //        GameObject.Destroy(child.gameObject);
    //    }
    //}

    //public void DropItem1()
    //{
    //    foreach(Transform child in slot1.transform)
    //    {
    //        child.GetComponent<InteractInv>().SpawnDroppedItem(); //dropar item, que está como filho do slot1
    //      //  player.inventory.items.RemoveAt(0); //Remover item da posição 0 da lista, que coincide com o primeiro slot
    //        player.inventory.items[0] = null;
    //        player.inventory.itemIn[0] = false;
    //        GameObject.Destroy(child.gameObject);
    //    }
    //}
    //public void DropItem2()
    //{
    //    foreach (Transform child in slot2.transform)
    //    {
    //        child.GetComponent<InteractInv>().SpawnDroppedItem();
    //        player.inventory.items[1] = null;
    //        player.inventory.itemIn[1] = false;
    //        GameObject.Destroy(child.gameObject);
    //    }
    //}
    //public void DropItem3()
    //{
    //    foreach (Transform child in slot3.transform)
    //    {
    //        child.GetComponent<InteractInv>().SpawnDroppedItem();
    //        //   player.inventory.items.RemoveAt(2);
    //        player.inventory.items[2] = null;
    //        player.inventory.itemIn[2] = false;
    //        GameObject.Destroy(child.gameObject);
    //    }
    //}
    //public void DropItem4()
    //{
    //    foreach (Transform child in slot4.transform)
    //    {
    //        child.GetComponent<InteractInv>().SpawnDroppedItem();
    //        player.inventory.items[3] = null;
    //        player.inventory.itemIn[3] = false;
    //        //    player.inventory.items.RemoveAt(3);
    //        GameObject.Destroy(child.gameObject);
    //    }
    //}

    public void UseItem(GameObject slot)
    {
        foreach (Transform child in slot.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }
}
