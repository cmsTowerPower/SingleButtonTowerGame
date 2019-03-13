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
    }
}
