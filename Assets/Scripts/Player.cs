using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private BoxCollider2D BoxColider;
    private Vector3 moveDelta;
    private RaycastHit2D hit;

    private void Start()
    {
        BoxColider = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        // reset move delta
        moveDelta = new Vector3(x,y,0);

        // Swap directions between left and right
        if (moveDelta.x > 0) 
        {
            transform.localScale = Vector3.one;
        }
        else if (moveDelta.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        //chek if the way is free to go with boxcast if box returns null move is able 
        hit = Physics2D.BoxCast(transform.position, BoxColider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("actor", "blocking"));      
        if(hit.collider == null)
        { 

            //movment for the player
            transform.Translate(0 ,moveDelta.y * Time.deltaTime ,0);

        }

        hit = Physics2D.BoxCast(transform.position, BoxColider.size, 0, new Vector2(moveDelta.x ,0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("actor", "blocking"));
        if (hit.collider == null)
        {

            //movment for the player
            transform.Translate(moveDelta.x * Time.deltaTime, 0,0);

        }
    }

}
