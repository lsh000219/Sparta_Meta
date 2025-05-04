using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    private static readonly int IsMoving = Animator.StringToHash("IsMove");
    private static readonly int IsDamage = Animator.StringToHash("IsDamage");
    private static readonly int IsExitTheDungeon = Animator.StringToHash("IsExitTheDungeon");

    [SerializeField] private Animator animator;

    protected virtual void Awake()
    {
        animator = transform.Find("MainSprite").GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("Animator not found in children of " + gameObject.name);
        }
    }

    public void Move(Vector2 obj)
    {
        animator.SetBool(IsMoving, obj.magnitude > .5f);
    }

    public void ExitTheDungeonOn()
    {
        animator.SetBool(IsExitTheDungeon, true);
    }

    public void ExitTheDungeonOff()
    {
        animator.SetBool(IsExitTheDungeon, false);
    }

    public void Damage()
    {
        animator.SetBool(IsDamage, true);
    }

    public void InvincibilityEnd()
    {
        animator.SetBool(IsDamage, false);
    }
}
