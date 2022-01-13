using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotController : MonoBehaviour
{

    private Player player;
    public int i;
    public bool isSelected;
    public Animator animator;
    public GameObject slot2;
    public GameObject slot3;
    public GameObject slot4;

    public Slot2 invslot2;


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
           
            isSelected = false;
            if(isSelected == false)
            {
                isSelected = true;
                animator.SetBool("isSelected", true);
            } 
        }else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            animator.SetBool("isSelected", false);
            slot3.GetComponent<Animator>().SetBool("isSelected", false);
            slot4.GetComponent<Animator>().SetBool("isSelected", false);
            
            isSelected = false;
            if (isSelected == false)
            {
                isSelected = true;
                slot2.GetComponent<Animator>().SetBool("isSelected", true);
            } else if(isSelected == true)
            {
                if (Input.GetKeyDown(KeyCode.G))
                {
                    invslot2.DropItem();
                }
            }
        }else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            animator.SetBool("isSelected", false);
            slot2.GetComponent<Animator>().SetBool("isSelected", false);
            slot4.GetComponent<Animator>().SetBool("isSelected", false);
           
            isSelected = false;
            if (isSelected == false)
            {
                isSelected = true;
                slot3.GetComponent<Animator>().SetBool("isSelected", true);
            }
        }else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            animator.SetBool("isSelected", false);
            slot2.GetComponent<Animator>().SetBool("isSelected", false);
            slot3.GetComponent<Animator>().SetBool("isSelected", false);
            
            isSelected = false;
            if (isSelected == false)
            {
                isSelected = true;
                slot4.GetComponent<Animator>().SetBool("isSelected", true);
            }
        }

        if (isSelected == true)
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                DropItem();
            }
        }

        if(transform.childCount <= 0)
        {
            player.inventory.isSlotFull[i] = false;
        }
    }

   

    public void DropItem()
    {
        foreach(Transform child in transform)
        {
            child.GetComponent<InteractInv>().SpawnDroppedItem();
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
