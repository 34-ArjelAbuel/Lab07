using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


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
        if (transform.position.y <= -4.5)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("GameLose");
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "score")
        {
            GameManager.thisManager.UpdateScore(1);
        }
        if (other.gameObject.tag == "dead")
        {
            SceneManager.LoadScene("GameLose");
        }
    }
}
