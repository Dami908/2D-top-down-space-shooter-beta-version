using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Assignment 1
//Emmanuel Ajayi 301050676
//Date last modified :October 5th,2019
//This script controls all asteroid movements and randomization of the asteroid. N.b
//This script is not responsible for instantiating the asteroid sprit


public class AsteroidController : MonoBehaviour
{
    [SerializeField]
    public Boundary boundary;
    public GameObject explosion;
    public float degreesPerSec = 360f;
    public GameController gamecontroller;






    [SerializeField]
    public Speed verticalSpeedRange;

    [SerializeField]
    public Speed horizontalSpeedRange;

    public float AsteroidStartOffset;

    public float verticalSpeed;
    public float horizontalSpeed;
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
        Rotate();
       
    }

    void Rotate()
    {
        float rotAmount = degreesPerSec * Time.deltaTime;
        float curRot = transform.localRotation.eulerAngles.z;
        transform.localRotation = Quaternion.Euler(new Vector3(0, 0, curRot + rotAmount));
    }

    //Reset method to randomize and provide a speed  range for the asteroid
    void Reset()
    {
        verticalSpeed = Random.Range(verticalSpeedRange.min, verticalSpeedRange.max);
        horizontalSpeed = Random.Range(horizontalSpeedRange.min, horizontalSpeedRange.max);

        float randomXPosition = Random.Range(boundary.LeftBounds, boundary.RightBounds);

        transform.position = new Vector2(randomXPosition, Random.Range(boundary.TopBounds, boundary.TopBounds + AsteroidStartOffset));

    }

    //Checks to make sure that if the asteroid goes out of bounds it is instantiated and randomly 
    //called at the top of the string
    void CheckBounds()
    {
        if (transform.position.y <= boundary.BottomBounds)
        {
            Reset();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            GameObject.Destroy(collision.gameObject);
            Destroy(gameObject);
            Instantiate(explosion, transform.position, Quaternion.identity);
            
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Player":
                Destroy(gameObject);
                break;
        }
    }

    //This method handles the asteroids movements down along the screen
    void Move()
    {   
        Vector2 currentPosition = transform.position;
        currentPosition -= new Vector2(horizontalSpeed, verticalSpeed);
        transform.position = currentPosition;
    }
}
