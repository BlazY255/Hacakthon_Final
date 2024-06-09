using UnityEngine;
using DG.Tweening;
using System.Collections;

public class EnemyController : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed;
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    
    public float shootingDelay = 2f; 
    private bool canShoot = true;

    private bool isPlayerInRange = false;
    private Sequence movementSequence;
    public Animator animator;

    void Start()
    { 

        movementSequence = DOTween.Sequence()
            .Append(transform.DOMove(pointB.position, speed).SetEase(Ease.Linear))
            .AppendCallback(() => FlipDirection())
            .Append(transform.DOMove(pointA.position, speed).SetEase(Ease.Linear))
            .AppendCallback(() => FlipDirection())
            .SetLoops(-1, LoopType.Restart)
            .Pause();
        movementSequence.Play();
    }
    
    private void FlipDirection()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    void Update()
    {
        if (!isPlayerInRange)
        {
            if (!movementSequence.IsActive() || movementSequence.IsComplete())
            {
                movementSequence.Restart();
                animator.SetBool(Constants.Move, true); 
            }
        }
        else
        {
            animator.SetBool(Constants.Move, false); 
        }
    }
    
    public void PlayerEnteredTrigger()
    {
        isPlayerInRange = true;
        movementSequence.Pause();
        animator.SetBool(Constants.Move, false);
        StartCoroutine(ShootWithDelay());
    }
    
    public void PlayerExitedTrigger()
    {
        isPlayerInRange = false;
        animator.SetBool(Constants.Move, true);
    }
    private IEnumerator ShootWithDelay()
    {
        while (isPlayerInRange && canShoot)
        {
            canShoot = false;
            animator.SetTrigger(Constants.Shoot);
            yield return new WaitForSeconds(shootingDelay);
            canShoot = true;
        }
    }

    public void Shoot()
    {
        if (bulletPrefab && bulletSpawnPoint)
        {
            GameObject Bullet =  Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);

            GameObject player = GameObject.FindGameObjectWithTag(Constants.Player);

            if (player)
            {
                Vector3 directionToPlayer = player.transform.position - transform.position;
                float angle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;

                if (player.transform.position.x < transform.position.x)
                {
                    // Player is on the left side of the enemy
                    Bullet.GetComponent<Bullet>().direction = Vector3.left;
                    FlipDirection();
                }
                else
                {
                    // Player is on the right side of the enemy
                    Bullet.GetComponent<Bullet>().direction = Vector3.right;
                    FlipDirection();
                }
            }
        }
    }
    
}