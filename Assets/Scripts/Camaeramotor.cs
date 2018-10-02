using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camaeramotor : MonoBehaviour
{

    public Transform lookAt;
    public float boundX = 0.15f;
    public float boundY = 0.05f;


    private void LateUpdate()
    {
        Vector3 delta = Vector3.zero;

        // tis is to check if the camrea have to move on the X
        float deltaX = lookAt.position.x - transform.position.x;
        if (deltaX > boundX || deltaX < -boundX)
        {
            if (transform.position.x < lookAt.position.x)
            {
                delta.x = deltaX - boundX;
            }
            else
            {
                delta.x = deltaX + boundX;
            }
        }
        // tis is to check if the camrea have to move on the Y 
        float delatY = lookAt.position.y - transform.position.y;
        if (delatY > boundY || delatY < -boundY)
        {
            if (transform.position.y < lookAt.position.y)
            {
                delta.y = delatY - boundY;
            }
            else
            {
                delta.y = delatY + boundY;
            }
        }

        transform.position += new Vector3(delta.x, delta.y, 0);


    }





}
