using System.Threading;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D player;
    private Animator playeranim;
    private SpriteRenderer playersprite;
    private BoxCollider2D playerCollider;
    public Boolean alive;
    private float jumpHeight;
    private float runSpeed;
    public Boolean boosted;
    private float boostTimer;

    [SerializeField] private LayerMask jumpAbleGround;
    [SerializeField] private AudioSource jumpSound;
    [SerializeField] private AudioSource trampolineSound;

    private enum PlayerMovementState {idle, running, jumping, falling}
    

    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        playeranim = GetComponent<Animator>();
        playersprite = GetComponent<SpriteRenderer>();
        playerCollider = GetComponent<BoxCollider2D>();
        alive = true;
        runSpeed = 7f;
        jumpHeight = 15f;
    }

    // Update is called once per frame
    void Update()
    {
        if(alive == true){
         // Player movement

        if(boosted == true){ // boosting player movement if energy drink is drank
            jumpHeight = 18f;
            runSpeed = 10f;
            boostTimer += Time.deltaTime;
            if(boostTimer >= 10f)
            {
                runSpeed = 7f;
                jumpHeight = 15f;
                boosted = false;
            }
        }

        float dirX = Input.GetAxis("Horizontal");
        player.velocity = new Vector2(dirX * runSpeed, player.velocity.y); // Player movement towards axis * 7f
        if(Input.GetButtonDown("Jump") == true && playerIsGrounded())
        {
            jumpSound.Play();
            player.velocity = new Vector3(player.velocity.x, jumpHeight);
        }
        updatePlayerAnimations();
        }
    }

    private void updatePlayerAnimations(){
        //Animation update functionality running
        float dirX = Input.GetAxis("Horizontal");
        PlayerMovementState State;

        if(dirX > 0f){
            State = PlayerMovementState.running;
            playersprite.flipX = false;
        }else if(dirX < 0f){
            State = PlayerMovementState.running;
            playersprite.flipX = true;
        }else{
            State = PlayerMovementState.idle;
        }

        //Animation update functionality jumping and falling
        if(player.velocity.y > 0.1f){
            State = PlayerMovementState.jumping;
        }else if(player.velocity.y < -0.1f){
            State = PlayerMovementState.falling;
        }

        playeranim.SetInteger("State", (int)State);
    }

    private bool playerIsGrounded(){
        return Physics2D.BoxCast(playerCollider.bounds.center, playerCollider.bounds.size, 0f, Vector2.down, .1f, jumpAbleGround);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("Test"))
        { // if powerup is drank get more speed and vertical jump
            UnityEngine.Debug.Log("Energydrink");
            
        }
        if(collision.gameObject.CompareTag("trampoline"))
        {
            trampolineSound.Play();
            player.velocity = new Vector3(player.velocity.x, 40f);
        }
        
    }

    public void setAliveFalse(){
        alive = false;
    }

    public void setBoosted(){
            boostTimer = 0;
            boosted = true;
    }

}
