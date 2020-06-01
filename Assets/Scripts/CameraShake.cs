using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    //Transform of the camera to shake. Grabs the gameobject's transform
    //if null
    public Transform camTransform;

    //How long the object should shake
    public float shakeDuration = 0f;

    //Amplitude of the shake. A larger value shakes the camera harder
    public float shakeAmount = 0.7f;
    public float decreaseFactor = 1.0f;

    public bool shakeTrue = false;

    Vector3 originalPos;
    float originalShakeDuration;

     void Awake()
     {
        if(camTransform == null)
        {
            camTransform = GetComponent(typeof(Transform)) as Transform;
        }
     }

     void OnEnable()
     {
        originalPos = camTransform.localPosition;
        originalShakeDuration = shakeDuration;
     }

    void Update()
    {
        if (shakeTrue)
        {
            if (shakeDuration > 0)
            {
                camTransform.localPosition = Vector3.Lerp(camTransform.localPosition, originalPos + Random.insideUnitSphere * shakeAmount, Time.deltaTime * 3);
            }
            else
            {
                shakeDuration = originalShakeDuration;
                camTransform.localPosition = originalPos;
                shakeTrue = false;
            }
        }
        
    }

    public void shakecamera()
    {
        shakeTrue = true;
    }
}
