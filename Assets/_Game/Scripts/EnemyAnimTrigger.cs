using UnityEngine;

public class EnemyAnimTrigger : MonoBehaviour
{
    public EnemyController enemyController;

    public void TriggerShoot()
    {
        enemyController.Shoot();
    }
}
