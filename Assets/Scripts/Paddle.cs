using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    [SerializeField]
    float screenWidthInUnits = 16f;

    [SerializeField]
    float clampMinX = 1;

    [SerializeField]
    float clampMaxX = 15;

	// Update is called once per frame
	void Update () {
        float mousePos = Mathf.Clamp(Input.mousePosition.x / Screen.width * screenWidthInUnits,clampMinX,clampMaxX);
        Vector2 paddlePos = new Vector2(mousePos, transform.position.y);
        transform.position = paddlePos;
	}
}
