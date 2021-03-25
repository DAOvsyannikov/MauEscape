using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    private GameObject mau;
    private bool move;
    private float playerSpeed, checkPos;
    public GameObject checkpoint;
    // Start is called before the first frame update
    void Start()
    {
        checkPos = -100f;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < checkPos)
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, checkPos), 2.5f * Time.deltaTime);
        if (transform.position.y >= checkPos && mau){
            mau.GetComponent<MauController>().speed = playerSpeed;
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Player") {
            mau = other.gameObject;
            playerSpeed = mau.GetComponent<MauController>().speed;
            mau.GetComponent<MauController>().speed = 0f;
            mau.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            checkPos = 16.8f;
            checkpoint.SetActive(true);
        }
    }
}
