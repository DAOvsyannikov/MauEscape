using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public GameObject ground, gameName, mau, lives, envirenments;
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
                //backImage.color = new Color(backImage.color.r, backImage.color.g, backImage.color.b, 0.15f);
                gameName.SetActive(false);
                ground.SetActive(true);
                envirenments.SetActive(true);
                mau.SetActive(true);
                lives.SetActive(true);
                break;
            case "Repeat" :
                SceneManager.LoadScene("Main");
                break;
        }
    }
}
