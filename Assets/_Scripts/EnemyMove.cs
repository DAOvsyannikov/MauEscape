using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public GameObject mau;
    private Rigidbody2D rb;
    private float speed, mauX;
    private bool lookLeft;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = 0f;
        lookLeft = true;
    }

    void Update(){
        if(transform.rotation.z != 0) // не даём врагу завалиться набок
            transform.eulerAngles = new Vector3(0,0,0);

        mauX = mau.transform.position.x;
        if(mauX - transform.position.x > -16f)
            speed = mau.GetComponent<MauController>().speed - 1f;
        if(mauX - transform.position.x > 14f)
            speed = 0f;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (mauX < transform.position.x){
            lookLeft = true;
            Flip();
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
        
        if (mauX > transform.position.x){
            lookLeft = false;
            Flip();
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
    }

    void Flip(){
        if(!lookLeft){
            transform.rotation = Quaternion.Euler(0, 180, 0);
        } else {
            transform.rotation = Quaternion.Euler(0, -180, 0);
        }
    }
}
