using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypeWritterEffect : MonoBehaviour
{
    [SerializeField] private float typewritterSpeed = 50f;
    public Coroutine Run(string textToType, TMP_Text textlabel)
    {
        return StartCoroutine(TypeText(textToType, textlabel));
    }

    private IEnumerator TypeText(string textToType, TMP_Text textlabel)
    {
        textlabel.text = string.Empty;

        float t = 0;
        int charIndex = 0;

        while(charIndex < textToType.Length)
        {
            t += Time.deltaTime * typewritterSpeed;
            charIndex = Mathf.FloorToInt(t);
            charIndex = Mathf.Clamp(charIndex, 0, textToType.Length);

            textlabel.text = textToType.Substring(0, charIndex);
            yield return null;
        }

        textlabel.text = textToType;
    }
}
