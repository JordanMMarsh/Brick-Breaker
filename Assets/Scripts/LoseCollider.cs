using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour {

    [SerializeField]
    Ball ball;

    int collideTimes = 1;

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Collided " + collideTimes + " times with " + collision.name);

        if (collision.name == "Ball")
        {
            FindObjectOfType<GameStatus>().LoseLife();
            ball.hasStarted = false;
        }
    }            
    
}
