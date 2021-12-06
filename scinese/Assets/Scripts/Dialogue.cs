using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue //Esta classe vai levar toda a informação de uma conversa
{
    public string name; //nome do npc 

    [TextArea(3, 10)]
    public string[] sentences; //frases para dar load no queue

}
