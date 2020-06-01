using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUpController : MonoBehaviour
{
    //Assignment 1
    //Emmanuel Ajayi 301050676
    //Date last modified :October 5th,2019
    //This script controls all asteroid movements and randomization of the powerup. N.b
    //This script is not responsible for instantiating the powerup sprite
    [SerializeField]
    public Boundary boundary;

    public float verticalSpeed = 0.02f;
    // Start is called before the first frame update
    void Start()
    {

        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckBounds();

    }
    //Reset method to randomize and provide a speed  range for the powerup
    void Reset()
    {
        float randomXPosition = Random.Range(boundary.LeftBounds, boundary.RightBounds);

        transform.position = new Vector2(randomXPosition, boundary.TopBounds);

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Player":
                Destroy(gameObject);
                break;

        }
    }


    //Checks to make sure that if the powerups goes out of bounds it is instantiated and randomly 
    //called at the top of the string
    void CheckBounds()
    {
        if (transform.position.y <= boundary.BottomBounds)
        {
            Reset();
        }
    }

    //This method handles the powerups movements down along the screen
    void Move()
    {
        Vector2 currentPosition = transform.position;
        currentPosition -= new Vector2(0.0f, verticalSpeed);
        transform.position = currentPosition;
    }
}
