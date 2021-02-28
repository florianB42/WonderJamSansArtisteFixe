using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupSelectAction : MonoBehaviour
{
    public List<GameObject> listButton = new List<GameObject>(8);

    public GameObject buttonAction;
    public GameObject panel;


    void Start()
    {
        //listButton.Add(buttonAction);

    }

    void Update()
    {
        
    }

    public void showMenu(List<Item> listItem, Interactable interacibleItem)
    {
        while (listItem.Count + 1 != listButton.Count)
        {
            if (listItem.Count + 1 > listButton.Count)
            {
                GameObject button = (GameObject)Instantiate(buttonAction);
                button.transform.SetParent(panel.transform, false);
                listButton.Add(button);
            }
            else
            {
                GameObject button = listButton[listButton.Count - 1];
                listButton.RemoveAt(listButton.Count - 1);
                Destroy(button);
            }
        }

        for (int i = 0; i < listItem.Count && i < listButton.Count - 1; ++i)
        {
            ButtonActionScript scriptBouton = listButton[i].GetComponent<ButtonActionScript>();
            scriptBouton.SetText(listItem[i].useText);
            scriptBouton.SetAction(listItem[i], interacibleItem, this);
        }
        ButtonActionScript CancelBouton  = listButton[listButton.Count - 1].GetComponent<ButtonActionScript>();
        CancelBouton.isCancelBouton(interacibleItem, this);
        gameObject.SetActive(true);
    }

    public void hide()
    {
        gameObject.SetActive(false);
    }
}
