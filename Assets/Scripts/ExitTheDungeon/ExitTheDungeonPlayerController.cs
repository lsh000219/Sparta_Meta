using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitTheDungeonPlayerController : MonoBehaviour
{
    private Camera camera;
    public static ExitTheDungeonPlayerController instance;
    protected AnimationHandler animationHandler;
    private Rigidbody2D rb;
    bool jump = false, isDead = false;

    int speed = 3;
    public void IsDead(bool dead) { isDead = dead; }

    public void StartRun()
    {
        rb.velocity = new Vector2(speed, 0);
    }

    public void Init()
    {
        instance = this;
    }

    void Awake()
    {
        camera = Camera.main;
        animationHandler = GetComponent<AnimationHandler>();
        animationHandler.ExitTheDungeonOn();
        rb = GetComponent<Rigidbody2D>();

        StartRun();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) { jump = true; }
    }

    public void FixedUpdate()
    {
        if (transform.position.x < 63) { camera.transform.position = new Vector3(transform.position.x + 5, 0, -10f); }
        else { camera.transform.position = new Vector3(68, 0, -10f); }

        Vector2 currentVelocity = rb.velocity;
        currentVelocity.x = speed;
        rb.velocity = currentVelocity;

        if(!isDead&&rb.velocity.x == 0) { rb.velocity = new Vector2(speed, rb.velocity.y); }

        if (jump)
        {
            rb.velocity = new Vector2(rb.velocity.x, 6.5f);
            jump = false;
        }

        if (isDead) { rb.velocity = new Vector2(0, 0); transform.rotation = Quaternion.Euler(0, 0, 90); }
        else { transform.rotation = Quaternion.Euler(0, 0, 0); }
    }
}
