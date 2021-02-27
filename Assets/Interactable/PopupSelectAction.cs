using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupSelectAction : MonoBehaviour
{
    public List<GameObject> listButton = new List<GameObject>(8);

    public GameObject buttonAction;
    public GameObject panel;


    // Start is called before the first frame update
    void Start()
    {
        //listButton.Add(buttonAction);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showMenu(List<Item> listItem, Interactable interacibleItem)
    {
        while (listItem.Count != listButton.Count)
        {
            if (listItem.Count > listButton.Count)
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
        /*for (int i = 0; i < listItem.Count - 1; ++i)
        {
            GameObject button = (GameObject)Instantiate(buttonAction);
            button.transform.SetParent(panel.transform, false);
            listButton.Add(button);
        }*/

        for (int i = 0; i < listItem.Count && i < listButton.Count; ++i)
        {
            ButtonActionScript scriptBouton = listButton[i].GetComponent<ButtonActionScript>();
            scriptBouton.SetText(listItem[i].useText);
            buttonAction.GetComponent<ButtonActionScript>().SetAction(listItem[i], interacibleItem, this);
        }

        gameObject.SetActive(true);
    }

    public void hide()
    {
        gameObject.SetActive(false);
    }
}
