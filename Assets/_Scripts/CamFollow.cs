using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform mau;
    private Vector3 position;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(mau.gameObject.activeSelf && !MauController.lose){
            position = mau.position;
            position.z = -5f;
            position.x += 1.5f;
            if(position.y < 0)
                position.y = 0f;
            else 
                position.y += 0.5f;
            transform.position = Vector3.Lerp(transform.position, position, 1f * Time.deltaTime);
        }
    }
}
