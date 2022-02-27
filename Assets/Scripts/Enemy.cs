using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float maxSpeed;
    public LayerMask mask;

    private Rigidbody2D rb;
    private int direction;

    //direction for the raycasts
    private Vector3 downRight;
    private Vector3 downLeft;

    private RaycastHit2D hit;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        direction = -1;
        downRight = new Vector3(1f, -1f, 0f);
        downLeft = new Vector3(-1f, -1f, 0f);
        //right now the length of these is 1.414... need to normalize to 1
        downRight.Normalize();
        downLeft.Normalize();
    }

    // Update is called once per frame
    void Update()
    {


        //raycast stuff
        if(direction==1) {
            hit = Physics2D.Raycast(this.transform.position, downRight, 2f, mask);
        } else {
            hit = Physics2D.Raycast(this.transform.position, downLeft, 2f, mask);
        }

        if(hit.collider == null) { //we didn't hit any collider
            direction *= -1;
        }



        //debug drawing
        Color hitColor = Color.red;
        if (hit.collider != null) {
            hitColor = Color.green;
        }

        if (direction == 1) {
            Debug.DrawRay(this.transform.position, downRight*2f, hitColor, 0.1f);
        } else {
            //drawing a ray from the center of the object, downleft as greed for 0.1 seconds
            Debug.DrawRay(this.transform.position, downLeft*2f, hitColor, 0.1f);
        }



        //the actual movement
        Vector3 velocity = rb.velocity;
        velocity.x = maxSpeed * direction;
        rb.velocity = velocity;
    }
}
