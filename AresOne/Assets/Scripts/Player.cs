using UnityEngine;
using System.Collections;

public class Player : MovingObject {

    Animator animator;
    private float speed = 4f;
    private float vertSpeed = 5f;
    private int secondUntilLevelLoads;

    public AudioClip deathSound;
    public AudioClip exitSound;

    void Update () {

        animator = GetComponent<Animator>();

        animator.SetBool("isRunning", false);

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            animator.SetBool("isRunning", true);
            FlipLeft();
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            animator.SetBool("isRunning", true);
            FlipRight();
        }

        if(Input.GetKey(KeyCode.UpArrow)) {
            transform.Translate(Vector2.up * vertSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D objectPlayerCollidedWith)
    {
        if (objectPlayerCollidedWith.tag == "Spike")
        {
            Debug.Log("Hit Spike");
            SoundController.Instance.PlaySingle(deathSound);
            Invoke("onDeath", secondUntilLevelLoads);
        }
        else if (objectPlayerCollidedWith.tag == "Exit")
        {
            Debug.Log("Hit Exit");
            SoundController.Instance.PlaySingle(exitSound);
            Invoke("LoadNewLevel", secondUntilLevelLoads);
        }
    }

    private void LoadNewLevel()
    {
        Application.LoadLevel(Application.loadedLevel + 1);
    }

    private void onDeath()
    {
        Application.LoadLevel(0);
    }

    void FlipLeft()
    {
        transform.localRotation = Quaternion.Euler(0, 180, 0); 
    }

    void FlipRight()
    {
        transform.localRotation = Quaternion.Euler(0, 0, 0);
    }
}
