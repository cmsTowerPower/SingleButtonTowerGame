using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    public float upDistance = 2;
    public float upSpeed = 0.05f;
    private float newY;
    private bool moving = false;

    void Update() {
        if (PlayerPrefs.GetInt("isCamMoving") == 1) {
            newY = this.gameObject.transform.position.y + upDistance;
            moving = true;
            PlayerPrefs.SetInt("isCamMoving", 0);
        }
        if (moving) {
            this.gameObject.transform.position += new Vector3(0, upSpeed);
            if (this.gameObject.transform.position.y > newY) {
                moving = false;
                FindObjectOfType<ObjectCreator>().spawnPoint += new Vector3(0, upDistance);
            }
        }
    }
}
