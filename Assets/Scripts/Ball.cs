using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    [SerializeField]
    Paddle paddle;
        
    public bool hasStarted = false;

    AudioSource audioSource;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!hasStarted)
        {
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
   }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 15f);
            hasStarted = true;
        }
    }

    private void LockBallToPaddle()
    {
        transform.position = new Vector2(paddle.transform.position.x, paddle.transform.position.y+.5f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasStarted)
        {
            audioSource.Play();
        }        
    }
}

