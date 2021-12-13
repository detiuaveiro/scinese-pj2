using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// tu es tao rei mano
/// </summary>
public class InteractScene0 : MonoBehaviour
{
    public bool isInRange; //Variável para verificar se está no range
    public UnityEvent interactAction; //variável para disparar a ação dentro do unity

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isInRange) //se o player estiver no range
        {
                interactAction.Invoke(); //Dispara o evento
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))//se o player estiver no range
        {
            isInRange = true;
        }
    }
}
