using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitTheDungeonPlayerController : MonoBehaviour
{
    [SerializeField] private Transform RidingPivot;
    [SerializeField] private GameObject Zom;
    [SerializeField] private GameObject Imp;
    [SerializeField] private GameObject Pum;
    [SerializeField] private GameObject Gob;
    [SerializeField] private GameObject Liz;

    private Camera camera;
    public static ExitTheDungeonPlayerController instance;
    protected AnimationHandler animationHandler;
    private Rigidbody2D rb;
    bool jump = false, isDead = false;
    int speed = 3;
    private GameObject Riding;

    public void IsDead(bool dead) { isDead = dead; }

    public void StartRun()
    {
        speed += speed + PlayerController.instance.ItemStatSpeed();
        rb.velocity = new Vector2(speed, 0);
    }

    public void Init() { instance = this; }

    void Awake()
    {
        camera = Camera.main;
        animationHandler = GetComponent<AnimationHandler>();
        animationHandler.ExitTheDungeonOn();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        switch (PlayerPrefs.GetInt("Equip", 0))
        {
            case 0:
                Destroy(Riding);
                break;
            case 1:
                if (Riding != null) { Destroy(Riding); }
                Riding = Instantiate(Zom, RidingPivot);
                break;
            case 2:
                if (Riding != null) { Destroy(Riding); }
                Riding = Instantiate(Imp, RidingPivot);
                break;
            case 4:
                if (Riding != null) { Destroy(Riding); }
                Riding = Instantiate(Pum, RidingPivot);
                break;
            case 8:
                if (Riding != null) { Destroy(Riding); }
                Riding = Instantiate(Gob, RidingPivot);
                break;
            case 16:
                if (Riding != null) { Destroy(Riding); }
                Riding = Instantiate(Liz, RidingPivot);
                break;
        }

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
