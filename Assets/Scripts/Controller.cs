using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Self control for prefab
public class Controller : MonoBehaviour
{
    public float speed;
    public float minSize, maxSize;
    public float leftSide, rightSide;

    //game logic states
    public bool physics;
    public bool resize;
    public bool move;

    //if object is falling apart
    public string collisionObject;

    // Start is called before the first frame update
    void Start()
    {
        resize = true;
        move = physics = false;
    }

    // Update is called once per frame
    void Update()
    {
        //1. button-push (set size of object)
        if (resize)
        {
            growAndShrink();
        }

        //2. button-push (set drop position of object)
        if (move)
        {
            Debug.Log("Object is moving!");
            moveLeftAndRight();
        }

        //3. button-push
        if (physics)
        {
            this.gameObject.AddComponent<Rigidbody2D>();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == collisionObject)
        {
            //Some UI interaction

            //Destroy self
            Destroy(this.gameObject);
            
        }
    }

    void growAndShrink()
    {
        transform.localScale += new Vector3(speed, speed, speed);
        if (transform.localScale.x >= maxSize || transform.localScale.x <= minSize)
        {
            speed = -speed;
        }
    }

    void moveLeftAndRight()
    {
        transform.position += new Vector3(speed, 0, 0);
        if (transform.position.x >= rightSide || transform.position.x <= leftSide)
        {
            speed = -speed;
        }
    }
}
