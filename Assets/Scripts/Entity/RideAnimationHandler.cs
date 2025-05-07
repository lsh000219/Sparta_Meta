using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RideAnimationHandler : MonoBehaviour
{
    private Vector3 lastPosition;
    private static readonly int IsMoving = Animator.StringToHash("IsMove");

    [SerializeField] private Animator animator;

    private void Start() { lastPosition = transform.position; }

    private void Update()
    {
        Vector3 currentPosition = transform.position;
        animator.SetBool(IsMoving, (Vector3.Distance(currentPosition, lastPosition) > 0.01f));
        lastPosition = transform.position;
    }


}
