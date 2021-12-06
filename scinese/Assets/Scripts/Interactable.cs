using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public bool isInRange; //Vari�vel para verificar se est� no range
    public KeyCode InteractKey; //Vari�vel para passar a tecla de intera��o
    public UnityEvent interactAction; //vari�vel para disparar a a��oi dentro do unity

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isInRange) //se o player estiver no range
        {
            if (Input.GetKeyDown(InteractKey)) //e pressionar a tecla "e"
            {
                interactAction.Invoke(); //Dispara o evento
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))//se o player estiver no range
        {
            isInRange = true;
            Debug.Log("Player is in Range");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))//se o player n�o estiver no range
        {
            isInRange = false;
            Debug.Log("Player is not Range");
        }
    }
}
