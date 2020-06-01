using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //Assignment 1
    //Emmanuel Ajayi 301050676
    //Date last modified :October 5th,2019
    //The Game controller script handles the instatiating of the powerup,asteroid and sound clips assets in our game 

    //Declaration and initilization

    public Speed speed;
    public Boundary boundary;
    public GameController gameController;
    public GameObject explosion;
    public AudioSource SoundEffect;
    // Start is called before the first frame update
    void Start()
    {
        // on start call  the sound script
        SoundEffect = gameController.audioSources[(int)SoundClip.SOUNDEFFECTR];
        SoundEffect.playOnAwake = false;

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckBounds();
        //CheckPlayercollisions();
    }

    //This method handles the player movement.
    //player movement is done using WASD format
    private void Move()
    {
        Vector2 currentPosition = transform.position;

        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            currentPosition += new Vector2(speed.max, 0.0f);
        }
        if (Input.GetAxisRaw("Vertical")> 0)
        {
            currentPosition += new Vector2(0.0f, speed.max);
        }
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            currentPosition += new Vector2(speed.min, 0.0f);
        }
        if (Input.GetAxisRaw("Vertical") < 0)
        {
            currentPosition += new Vector2(0.0f, speed.min);
        }
        transform.position = currentPosition;
    }
    //Ensures that the player movement is restricted to within the camera
    public void CheckBounds()
    {
        if (transform.position.x > boundary.RightBounds)
        {
            transform.position = new Vector2(boundary.RightBounds, transform.position.y);
        }

        if (transform.position.x < boundary.LeftBounds)
        {
            transform.position = new Vector2(boundary.LeftBounds, transform.position.y);
        }
        if (transform.position.y > boundary.TopBounds)
        {
            transform.position = new Vector2(transform.position.x,boundary.TopBounds );
        }
        if (transform.position.y < boundary.BottomBounds)
        {
            transform.position = new Vector2(transform.position.x,boundary.BottomBounds);
        }
       
    }
    //checks dor collisions with other game objects 
    //and take action depending on  what paremeters or rules is set
    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Asteroid":
                gameController.Lives -= 1;
                Instantiate(explosion, transform.position, Quaternion.identity);
               

                break;
            case "Orb":
                SoundEffect.Play();
                gameController.Score += 100;
                //if (gameController.Score > 1000)
                //{
                //    gameController.Lives += 1;
                //}
                break;

        }
    }
  
}
