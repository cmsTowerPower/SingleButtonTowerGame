using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// MH - the second button press should stop an ongoing growth
public class ObjectGrower : MonoBehaviour
{
    public float growthFactor = 0.05f;
    public float minSize = 0.5f;
    public float maxSize = 5.5f;
    private bool isGrowing = false;

    // in this state, the object grows all the time - a button press will stop the growth
    void Update() {
        if (isGrowing) {
            float x = this.gameObject.transform.localScale.x + growthFactor;
            if (x > maxSize || x < minSize) growthFactor *= -1;

            grow();

            if (Input.GetKeyUp(KeyCode.Space)) greatify();
        }
        if (PlayerPrefs.GetInt("inputState") == 1) isGrowing = true;
    }

    void grow() => this.gameObject.transform.localScale += new Vector3(growthFactor, growthFactor);
    void greatify() {
        PlayerPrefs.SetInt("inputState", 2);
        Destroy(this);
    }
}
