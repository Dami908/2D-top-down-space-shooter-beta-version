using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//Assignment 1
//Emmanuel Ajayi 301050676
//Date last modified :October 5th,2019
//The Game controller script handles the instatiating of the powerup,asteroid and sound clips assets in our game 


public class GameController : MonoBehaviour
{
    //Declaration and initilization
    [Header("Scene Game Objects")]
    public GameObject asteroid;
    public GameObject Powerup;

    [Header("Asteroid Control")]
    public int NumberOfAsteroids;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public List<GameObject> asteroids;

    [Header("PowerupController")]
    public int NumberOfPowerups;
    public float powerSpawnWait;
    public float powerStartWait;
    public float powerWait;
    public List<GameObject> powerups;

    [Header("Audio Sources")]
    public SoundClip defaultSoundClip;
    public AudioSource[] audioSources;

    [Header("Scoreboard")]
    [SerializeField]
    private int _score;
    public Text scoreLabel;

    [SerializeField]
    private int _lives;
    public Text livesLabel;
    // PUBLIC Properties
    public int Score
    {
        //set and get accesor for the Score count
        get
        {
            return _score;
        }

        set
        {
            _score = value;
            if (_score == 2000)
            {
                SceneManager.LoadScene("Win");
            }
            scoreLabel.text = "Score: " + _score.ToString();
        }
    }

    public int Lives
    {
        //set and get accesor for the lives count
        get
        {
            return _lives;
        }

        set
        {
            _lives = value;
            if (_lives == 0)
            {
                SceneManager.LoadScene("End");
            }
            livesLabel.text = "Lives:" + _lives.ToString();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Lives = 3;
        Score = 0;

        if ((defaultSoundClip != SoundClip.NONE) && (defaultSoundClip != SoundClip.NUMBER_OF_CLIP))
        {
            AudioSource defaultClip = audioSources[(int)defaultSoundClip];
            defaultClip.playOnAwake = false;
            defaultClip.loop = false;
            defaultClip.Play();
        }

        StartCoroutine (SpawnWaves());
        StartCoroutine(SpawnPowerups());
       
       

    }

    IEnumerator SpawnPowerups()
    {
        yield return new WaitForSeconds(powerStartWait);
        while (true)
        {
            for (int poweruped = 0; poweruped < NumberOfPowerups; poweruped++)
            {
                powerups.Add(Instantiate(Powerup));
                yield return new WaitForSeconds(powerSpawnWait);
            }
            yield return new WaitForSeconds(powerWait);
        }
       
    }

   IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int asteroidNum = 0; asteroidNum < NumberOfAsteroids; asteroidNum++)
            {
                asteroids.Add(Instantiate(asteroid));

                //Easy way:Make your list of conditional spawning here
                 if (_score < 499)
                 {
                    yield return new WaitForSeconds(spawnWait);
                 }
                else if (_score > 500 && _score < 999)
                {
                    yield return new WaitForSeconds(spawnWait*0.8f); //normal spawnWait
                    yield return new WaitForSeconds(waveWait * 0.8f);
                }
                else if(_score>1000 && _score < 1499)
                {
                    yield return new WaitForSeconds(spawnWait * 0.7f);//Quicker SpawnRate
                    yield return new WaitForSeconds(waveWait * 0.8f);
                }
                 else if (_score > 1500)
                {
                    yield return new WaitForSeconds(spawnWait * 0.6f);
                    yield return new WaitForSeconds(waveWait * 0.8f);
                }
                else
                {
                    yield return new WaitForSeconds(spawnWait);
                }
                yield return new WaitForSeconds(waveWait);
                
            }
            

        }
       
    }

    // Update is called once per frame
    void Update()
    {
       
    }

}
