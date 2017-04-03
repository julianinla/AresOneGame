using UnityEngine;
using System.Collections;

public class Player : MovingObject {

    Animator animator;
    private float speed = 4f;
    private float vertSpeed = 5f;

    void Update () {

        animator = GetComponent<Animator>();

        /* int xAxis = 0;
        int yAxis = 0;

        xAxis = (int) Input.GetAxisRaw("Horizontal");
        Debug.Log("xAxis" + xAxis);
        yAxis = (int) Input.GetAxisRaw("Vertical");
        Debug.Log("yAxis" + yAxis);

        if (xAxis != 0 || yAxis != 0)
        {
            CanObjectMove(xAxis, yAxis);
        }*/
        animator.SetBool("isRunning", false);

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-Vector2.right * speed * Time.deltaTime);
            animator.SetBool("isRunning", true);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            animator.SetBool("isRunning", true);
        }

        if(Input.GetKey(KeyCode.UpArrow)) {
            transform.Translate(Vector2.up * vertSpeed * Time.deltaTime);
        }
    }
}
