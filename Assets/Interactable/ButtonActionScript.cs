using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonActionScript : MonoBehaviour
{
    public Button button;
    // Start is called before the first frame update
    public DoorInteractable dd;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetAction(Item item, Interactable interacibleItem, PopupSelectAction parent)
    {
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(()=> { item.use(interacibleItem); });
        button.onClick.AddListener(parent.hide);
    }

    public void SetText(string text)
    {

        button.GetComponentInChildren<Text>().text = text;
    }

    public void handleTest(int test)
    {
        Debug.Log("test");
    }
}
