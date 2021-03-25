using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MauController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector3 pos;
    private SpriteRenderer spriterenderer;
    private int livesCount, jumpCount;
    private float x;
    public GameObject lives, repeate;
    public Sprite lostLive, getLive, die;
    public float speed, jumpForce;
    public static bool lose, onPlatform;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        livesCount = 3;
        x = -1.3f;
        speed = 3f;
        jumpForce = 5.5f;
        lose = false;
        onPlatform = false;
    }

    void Update(){
        if (livesCount == 0 || transform.position.y < -4f)
            playerLose();
        if (transform.rotation.z > 32f || transform.rotation.z < -32f)
            transform.rotation = Quaternion.Euler(0, 0, 0);
    } 

    // Update is called once per frame
    void FixedUpdate()
    {
        if (speed != 0)
            rb.velocity = new Vector2(speed, rb.velocity.y);
            
    }

    public void jump(){
        if(jumpCount < 2){
            rb.velocity = Vector2.zero; // тормозим персонажа перед прыжком, чтобы прыжки были одинаковые
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            jumpCount += 1;
        }
    }

    void loseLive() {
        livesCount -=1;
        print(livesCount);
        changeSprite("Envirenments 1_16", lostLive);
    }

    void getLives() {
        livesCount +=1;
        changeSprite("Envirenments_17", getLive);
    }
    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Spike" || other.gameObject.tag == "Enemy") {
            loseLive();
        }
        
        if(other.gameObject.tag == "Live") {
            getLives();
            Destroy(other.gameObject);
        }

        if((other.gameObject.tag == "Ground" || other.gameObject.tag == "Platform"|| other.gameObject.tag == "Enemy") && livesCount > 0) {
            jumpCount = 0;
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "CheckPoint") {
            speed += 0.5f;
            PlayerPrefs.SetFloat("checkpoint", transform.position.x);
        }
    }

    void changeSprite(string from, Sprite to){
        for(int i = 0; i < lives.transform.childCount; i ++){
            spriterenderer = lives.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>();
            if (spriterenderer.sprite.name == from){
                spriterenderer.sprite = to;
                i += 3;
            }
        }
    }

    void playerLose(){
        lose = true;
        speed = 0f;
        rb.velocity = Vector2.zero;
        transform.rotation = Quaternion.identity;
        GetComponent<SpriteRenderer>().sprite = die;
        repeate.SetActive(true);
    }

}
