using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    Rigidbody2D rb;
    public float movespeed;
    public float rotateamount;
     float rot;
    int score;
    public GameObject wintext;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if(Input.GetMouseButton(0))
        {
            Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if(mousepos.x < 0)
            {
                rot = rotateamount;

            }
            else
            {
                rot = -rotateamount;
            }
            transform.Rotate(0, 0, rot);
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = transform.up * movespeed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "food")
        {
            Destroy(collision.gameObject);
            score++;
            if(score>5)
            {
                print("level complete");
                wintext.SetActive(true);
            }
        }
        else  if(collision.gameObject.tag=="Enemy")
        {
            SceneManager.LoadScene("game");
        }
    }
}
