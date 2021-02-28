using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupItemFund : MonoBehaviour
{

    public Text textUI;
    public Image spriteLoot;

    public Sprite hammerSprite;
    public Sprite keySprite;
    public Sprite goldkeySprite;
    public Sprite crowbarSprite;
    public Sprite headSprite;
    public Sprite spiderSprite;
    public Sprite teddySprite;
    public Sprite matchSprite;

    void Start()
    {
    }

    public void StartDialogue(Item item)
    {
        StopAllCoroutines();

        gameObject.SetActive(true);
        switch (item.name)
        {
            case ItemType.HAMMER:
                spriteLoot.sprite = hammerSprite;
                break;
            case ItemType.KEY:
                spriteLoot.sprite = keySprite;
                break;
            case ItemType.GOLDKEY:
                spriteLoot.sprite = goldkeySprite;
                break;
            case ItemType.CROWBAR:
                spriteLoot.sprite = crowbarSprite;
                break;
            case ItemType.HEAD:
                spriteLoot.sprite = headSprite;
                break;
            case ItemType.SPIDER:
                spriteLoot.sprite = spiderSprite;
                break;
            case ItemType.MATCH:
                spriteLoot.sprite = matchSprite;
                break;
            case ItemType.TEDDY:
                spriteLoot.sprite = teddySprite;
                break;
        }
        StartCoroutine(TypeSentence("Vous avez trouvé "+item.nameString));
        Invoke("hide", 4);
    }

    IEnumerator TypeSentence(string sentence)
    {
        textUI.text = "";

        foreach(char letter in sentence.ToCharArray())
        {
            textUI.text += letter;
            yield return null;
        }
    }

    public void hide()
    {
        spriteLoot.sprite = null;
        StopAllCoroutines();
        gameObject.SetActive(false);
    }
}
