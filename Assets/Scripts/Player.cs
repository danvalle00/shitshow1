using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 10f;
    [SerializeField]
    private float jumpForce = 11f;
    private float movimentX;

    private bool isGrounded;
    private string GROUND_TAG = "Ground";
 
    private Rigidbody2D myBody;
    private SpriteRenderer sr;
    private Animator anim;
    private string WALK_ANIMATION = "Walk";


    private void Awake() {
        myBody = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();     
    }
    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyboard();  
        AnimatePlayer();
        PlayerJump();
    }

    void PlayerMoveKeyboard(){
        movimentX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movimentX, 0f, 0f) * Time.deltaTime * moveForce;

    }

    void AnimatePlayer(){
        if (movimentX > 0){
            // facing right
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = false;

        }
        else if (movimentX < 0){
            // facing left
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = true;
        }
        else {
            anim.SetBool(WALK_ANIMATION, false);
        }
    }

    void PlayerJump(){
        if (Input.GetButtonDown("Jump") && isGrounded){
            isGrounded = false; 
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag(GROUND_TAG)){
            isGrounded = true;
        }
    }
} // class 
