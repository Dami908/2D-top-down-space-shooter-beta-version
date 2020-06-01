using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public KeyCode shootKey = KeyCode.F;
    public GameObject projectile;
    public float shootForce;
    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(shootKey))
        {
            GameObject shot = GameObject.Instantiate(projectile, transform.position, Quaternion.identity);
            shot.GetComponent<Rigidbody2D>().AddForce(transform.up * shootForce);
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Asteroid")
        {
            GameObject.Destroy(collision.gameObject);
            Debug.Log("Asteroid collision");

        }
    }
}
