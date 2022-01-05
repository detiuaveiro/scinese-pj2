using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CkeckpointController : MonoBehaviour
{
    public bool isSaved;
    public Animator animator;
    public GameObject infballon;

    public void SaveGame()
    {
        if (!isSaved)
        {
            isSaved = true;
            animator.SetBool("isSaved", true);
            GameManager.instance.SaveState();
            infballon.gameObject.SetActive(false);
        }
    }
}
