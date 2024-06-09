
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    public EnemyController enemyController;
    private void OnTriggerStay2D(Collider2D other)
    {
        enemyController.PlayerEnteredTrigger();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        enemyController.PlayerExitedTrigger();
    }
}
