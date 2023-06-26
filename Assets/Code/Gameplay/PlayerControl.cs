using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerControl : MonoBehaviour
{
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private Animator animator;
    [SerializeField] private EnemyDetection enemyDetection;
    [SerializeField] private float referenceMovespeed;

    private WeaponData currentWeaponData;

    private bool isMoving;
    private bool isAttacking;

    private void Update()
    {
        UpdateBehaviour();
        UpdateAnimator();
    }

    private void UpdateBehaviour()
    {
        Vector2 movementInput = PlayerInput.MoveAxis;
        isMoving = movementInput.magnitude > 0;
        navMeshAgent.velocity = movementInput.ToVector3XZ() * currentWeaponData.MovementSpeed;

        if (isMoving)
        {
            isAttacking = false;
        }
        else if (enemyDetection.HasTargetsInRange)
        {
            isAttacking = true;
            transform.LookAt(enemyDetection.GetClosestTarget().transform);
        }
    }

    private void UpdateAnimator()
    {
        animator.SetBool("Run", isMoving);
        animator.SetBool("Attack", isAttacking);
        animator.SetFloat("RunAnimationSpeed", currentWeaponData.MovementSpeed / referenceMovespeed);
        animator.SetFloat("AttackAnimationSpeed", currentWeaponData.AttackSpeed);
    }

    public void UpdateWeapon(WeaponData newWeaponData)
    {
        currentWeaponData = newWeaponData;
    }
}