using UnityEngine;

public class PlayerController : BaseController
{
    public static PlayerController instance;

    private GoblinManager goblinManager;
    private Camera camera;

    public void Init(GoblinManager goblinManager)
    {
        instance = this;
        this.goblinManager = goblinManager;
    }


    protected override void HandleAction()
    {
        camera = Camera.main;
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        movementDirection = new Vector2(horizontal, vertical).normalized;

        Vector2 mousePosition = Input.mousePosition;
        Vector2 worldPos = camera.ScreenToWorldPoint(mousePosition);
        lookDirection = (worldPos - (Vector2)transform.position);

        if (lookDirection.magnitude < .9f)
        {
            lookDirection = Vector2.zero;
        }
        else
        {
            lookDirection = lookDirection.normalized;
        }

        isAttacking = Input.GetMouseButton(0);
    }

    public override void Death()
    {
        base.Death();
        goblinManager.GameOver();
    }

    public void ExitGoblin() { transform.position = new Vector2(0f, 8.18f); }
}