using UnityEngine;
using UnityEngine.SceneManagement;

// MH - Init to win it
public class Init : MonoBehaviour
{
    void Awake() {
        setPlayerPrefs();
        SceneManager.LoadScene("Game");
    }

    void setPlayerPrefs() {

        /* 
            The input state indicates the current state of the random object lifecycle
            0 = About to spawn
            1 = Growing
            2 = Moving
            3 = Dropping
        */ 
        PlayerPrefs.SetInt("inputState", 0);

        /*
            isCamMoving indicates whether the camera is moving up or standing still
            0 = no movement
            1 = movement
        */
        PlayerPrefs.SetInt("isCamMoving", 0);
    }
}
