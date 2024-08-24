using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; 
    public Rigidbody2D rb; 
    private Vector2 movement; 
    private Vector2 lastMovement; 
    public Animator anim;
    public Transform spriteTransform;
    public AudioSource stepSFX;

    private bool isPlayingStepSound = false;
    public float stepSoundInterval = 0.4f;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        if (stepSFX == null)
        {
            stepSFX = GetComponent<AudioSource>();
        }
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        

        if (movement != Vector2.zero)
        {
            lastMovement = movement;

            if (!isPlayingStepSound)
            {
                StartCoroutine(PlayStepSound());
            }
        }
        else
        {
            StopStepSound();
        }

        anim.SetFloat("Horizontal", lastMovement.x);
        anim.SetFloat("Vertical", lastMovement.y);

        anim.SetFloat("Speed", movement.sqrMagnitude);
        FlipSprite();

        if (movement != Vector2.zero)
        {
            PlayerHealth.Instance.SetLastMovement(movement);
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

    void FlipSprite()
    {
        if (lastMovement.x < 0)
        {
            spriteTransform.localScale = new Vector3(-1, 1, 1);
        }
        else if (lastMovement.x > 0)
        {
            spriteTransform.localScale = new Vector3(1, 1, 1);
        }

        if (lastMovement.y != 0)
        {
            if (lastMovement.y > 0)
            {
                spriteTransform.localScale = new Vector3(1, 1, 1); 
            }
            else if (lastMovement.y < 0)
            {
                spriteTransform.localScale = new Vector3(-1, 1, 1); 
            }
        }
    }

    private IEnumerator PlayStepSound()
    {
        isPlayingStepSound = true;

        if (stepSFX != null)
        {
            stepSFX.Play();
        }

        yield return new WaitForSeconds(stepSoundInterval);

        if (movement == Vector2.zero)
        {
            isPlayingStepSound = false;
        }
        else
        {
            StartCoroutine(PlayStepSound());
        }
    }

    private void StopStepSound()
    {
        if (isPlayingStepSound)
        {
            if (stepSFX != null)
            {
                stepSFX.Stop();
            }
            isPlayingStepSound = false;
        }
    }

}
