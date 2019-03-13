using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// MH - the third button press should stop an ongoing motion
public class ObjectMover : MonoBehaviour
{
    public float movingDistance = 3;
    public float movingSpeed = 0.05f;
    private bool isMoving = false;

    // in this state, the object is moving all the time - a button press will stop it
    void Update() {
        if (isMoving) {
            float x = this.gameObject.transform.localPosition.x + movingSpeed;
            if (x > movingDistance || x < -movingDistance) movingSpeed *= -1;

            move();

            if (Input.GetKeyUp(KeyCode.Space)) maximize();
        }
        if (PlayerPrefs.GetInt("inputState") == 2) isMoving = true;
    }

    void move() => this.gameObject.transform.position += new Vector3(movingSpeed, 0);
    void maximize() {
        PlayerPrefs.SetInt("inputState", 3);
        Destroy(this);
    }
}
