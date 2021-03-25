using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public GameObject gameName, mau, lives, detectClicks;
    private Image backImage;
    // Start is called before the first frame update
    void Start()
    {
        //backImage = back.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseUpAsButton(){
        switch(gameObject.name){
            case "Play" :
                gameObject.SetActive(false);
                gameName.SetActive(false);
                mau.SetActive(true);
                lives.SetActive(true);
                detectClicks.SetActive(true);
                break;
            case "Repeat" :
                SceneManager.LoadScene("Main");
                break;
        }
    }
}
