using UnityEngine;
using System.Collections;

public class Player : MovingObject {

    Animator animator;

	void Update () {

        animator = GetComponent<Animator>();

        int xAxis = 0;
        int yAxis = 0;
        bool attack = false;

        xAxis = (int) Input.GetAxisRaw("Horizontal");
        yAxis = (int) Input.GetAxisRaw("Vertical");
        attack = Input.GetKeyDown("z");

        animator.SetBool("playerAttack", attack);

        if (xAxis != 0)
        {
            yAxis = 0;
        }

        if (xAxis != 0 || yAxis != 0)
        {
            CanObjectMove(xAxis, yAxis);
        }

        if (yAxis > 0)
        {
            animator.SetBool("moveNorth", true);
        }
        else if (yAxis < 0)
        {
            animator.SetBool("moveSouth", true);
        }
        else if (xAxis < 0)
        {
            animator.SetBool("moveWest", true);
        }
        else if (xAxis > 0)
        {
            animator.SetBool("moveEast", true);
        }
    }
}
