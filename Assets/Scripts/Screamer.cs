using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Screamer : MonoBehaviour
{
    public RawImage rawImage;
    public AudioSource AudioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        rawImage.gameObject.SetActive(false);
    }

    public void show()
    {
        rawImage.gameObject.SetActive(true);
        AudioSource.PlayOneShot(AudioSource.clip);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
