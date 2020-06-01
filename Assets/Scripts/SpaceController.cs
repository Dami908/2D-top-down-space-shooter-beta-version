using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceController : MonoBehaviour
{
    //Assignment 1
    //Emmanuel Ajayi 301050676
    //Date last modified :October 5th,2019
    //This script controls all background movements and randomization of the backround picture. N.b
    //This script is not responsible for instantiating the powerup sprite
    public float verticalSpeed = 0.080f;
    public bool resetToBottomPosition = false;

    private float m_topResetPosition = 9.741f;
    private float m_bottomResetPosition = -4.09f;
    private bool m_isFirstRun = true;

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

    void Reset()
    {
        Vector2 resetPosition = new Vector2(0.0f, 0.0f);

        if (m_isFirstRun)
        {
            resetPosition.y = (resetToBottomPosition)
            ? m_bottomResetPosition : m_topResetPosition;
            transform.position = resetPosition;
            m_isFirstRun = false;
        }
        else
        {
            transform.position = new Vector2(0.0f, m_topResetPosition);
        }
    }

    void CheckBounds()
    {
        if (transform.position.y <= -13.7f)
        {
            Reset();
        }
    }

    void Move()
    {
        Vector2 currentPosition = transform.position;
        currentPosition -= new Vector2(0.0f, verticalSpeed);
        transform.position = currentPosition;
    }
}
