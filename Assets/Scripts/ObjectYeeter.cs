using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// MH - drop the object with physics and reignite the cycle
public class ObjectYeeter : MonoBehaviour
{
    private bool isYeeting = false;

    // this state should serve as a gateway - movement stops, the object drops and a new one may spawn if it landed nicely
    void Update() {
        if (isYeeting) {
            yeet();
            yolo();
        }
        if (PlayerPrefs.GetInt("inputState") == 3) isYeeting = true;
    }

    void yeet() => this.gameObject.AddComponent<Rigidbody2D>();
    void yolo() {
        PlayerPrefs.SetInt("inputState", 0);
        Destroy(this);
    }
}
