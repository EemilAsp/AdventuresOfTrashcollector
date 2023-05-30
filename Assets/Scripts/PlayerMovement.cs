using System.Threading;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Walter, F. 2021. Player Movement | Build a 2D Platformer Game in Unity #3 Youtube video
// used as assistance in order to create player movement in Unity
// link: https://www.youtube.com/watch?v=Uv5tfMSKlnU&list=RDCMUC_Fh8kvtkVPkeihBs42jGcA&index=6

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D player;
    private Animator playeranimator;
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
        playeranimator = GetComponent<Animator>();
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
            if(boostTimer >= 10f) // if boost timer ran out set to normal
            {
                runSpeed = 7f;
                jumpHeight = 15f;
                boosted = false;
            }
        }

        float Xdirection = Input.GetAxis("Horizontal"); // get the current direction for playeer
        player.velocity = new Vector2(Xdirection * runSpeed, player.velocity.y); // Player movement towards axis * 7f

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
        float Xdirection = Input.GetAxis("Horizontal");
        PlayerMovementState State;

        if(Xdirection > 0f){
            State = PlayerMovementState.running;
            playersprite.flipX = false;

        }else if(Xdirection < 0f){
            State = PlayerMovementState.running;
            playersprite.flipX = true;

        }else{
            State = PlayerMovementState.idle;
        }

        //Animation update functionality jumping and falling
        if(player.velocity.y > 0.1f){ // if higher than ground animation jump
            State = PlayerMovementState.jumping;
        }else if(player.velocity.y < -0.1f){ // if falling than animation fall
            State = PlayerMovementState.falling;
        }

        playeranimator.SetInteger("State", (int)State); //change player animator state based on whats happening
    }

    private bool playerIsGrounded(){
        return Physics2D.BoxCast(playerCollider.bounds.center, playerCollider.bounds.size, 0f, Vector2.down, .1f, jumpAbleGround);
    }

    private void OnCollisionEnter2D(Collision2D collision) { // collisions
        if(collision.gameObject.CompareTag("Test"))
        { // if powerup is drank get more speed and vertical jump
            UnityEngine.Debug.Log("Energydrink");
            
        }
        if(collision.gameObject.CompareTag("trampoline"))
        {// if trampoline jump higher to air
            trampolineSound.Play();
            player.velocity = new Vector3(player.velocity.x, 40f);
        }
        
    }

    public void setAliveFalse(){ // when dying set alive false
        alive = false;
    }

    public void setBoosted(){ // whend boosted set boosted true
            boostTimer = 0;
            boosted = true;
    }

}
