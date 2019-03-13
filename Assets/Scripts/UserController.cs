using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//User input
public class UserController : MonoBehaviour
{

    public GameObject cube;
    public GameObject cylinder;

    private GameObject current;
    private Controller scriptOfPrefab;
    private bool init, resize, move, drop;
    // Start is called before the first frame update
    void Start()
    {
        init = true;
        resize = move = drop = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (init)
            {
                randomGameObject();
                init = false;
                resize = true;
                if (drop) drop = false;
            }
            if (resize)
            {
                scriptOfPrefab.resize = false;
                scriptOfPrefab.move = true;
                resize = false;
                move = true;
            }
        }
    }

    void randomGameObject()
    {
        int random = Random.Range(0, 100);
        if (random >= 50)
        {
            current = cube;
        } else
        {
            current = cylinder;
        }
        Instantiate(current, new Vector3(0, 3, 0), Quaternion.identity);
        scriptOfPrefab = current.GetComponent<Controller>();
    }
}
