using UnityEngine;

public class PlayerController : BaseController
{
    public static PlayerController instance;

    private GoblinManager goblinManager;
    private Camera camera;
    private int gold = 100, inventory = 0;

    public void Init(GoblinManager goblinManager)
    {
        instance = this;
        this.goblinManager = goblinManager;
    }

    public void PlusGold(int gold) { this.gold += gold; }

    public void BuyItem(int gold, int item) { MinusGold(gold); GetItem(item); }

    private void MinusGold(int gold) { this.gold -= gold; }

    private void GetItem(int item) { inventory += item; }

    public bool SearchItem(int item)
    {
        if ((inventory & item) == item) return true;
        else return false;
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