using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogTurnController : MonoBehaviour
{
    public Text textUI;

    void Start()
    {
        
    }

    public void StartDialogue(string s)
    {
        StopAllCoroutines();
        gameObject.SetActive(true);
        StartCoroutine(TypeSentence(s));
        Invoke("hide", 4);
    }

    IEnumerator TypeSentence(string sentence)
    {
        textUI.text = sentence;
        yield return null;
    }

    public void hide()
    {
        StopAllCoroutines();
        gameObject.SetActive(false);
    }
}
