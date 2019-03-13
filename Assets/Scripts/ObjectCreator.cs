using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// MH - The first button press should create a new object
public class ObjectCreator : MonoBehaviour
{
    public Vector3 spawnPoint = new Vector3(0, 0, 0);
    private List<GameObject> objectPool = new List<GameObject>();
    private GameObject currentGameObject = null;

    // load all possible gameobjects into a list
    void Start() {
        var load = Resources.LoadAll("Objects");
        foreach (var obj in load) objectPool.Add(obj as GameObject);
    }

    // if the button is pressed in this state, create a random object and update the state
    void Update() {
        if (PlayerPrefs.GetInt("inputState") == 0 && Input.GetKeyUp(KeyCode.Space)) {
            choose(Random.Range(0, objectPool.Count));
            create();
            change();
        }
    }

    void choose(int r) => currentGameObject = objectPool[r];
    void create() {
        currentGameObject.gameObject.AddComponent<ObjectGrower>();
        currentGameObject.gameObject.AddComponent<ObjectMover>();
        currentGameObject.gameObject.AddComponent<ObjectYeeter>();
        Instantiate(currentGameObject, spawnPoint, Quaternion.identity);
    }
    void change() => PlayerPrefs.SetInt("inputState", 1);
}
