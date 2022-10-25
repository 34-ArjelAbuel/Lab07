using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animation thisAnimation;
    public float velocity;
    private Rigidbody rb;

    void Start()
    {
        thisAnimation = GetComponent<Animation>();
        thisAnimation["Flap_Legacy"].speed = 3;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            thisAnimation.Play();
            rb.velocity = Vector2.up * velocity;
        }
        if (transform.position.x <= -9)
        {
            Destroy(gameObject);
            GameManager.thisManager.GameOver();
        }
        if (transform.position.x >= 9)
        {
            Destroy(gameObject);
            GameManager.thisManager.GameOver();
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "score")
        {
            GameManager.thisManager.UpdateScore(1);
        }
    }
}
