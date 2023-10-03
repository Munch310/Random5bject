using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    private Transform targetEnemy;
    private Vector3 direction;

    private const string EnemyTag = "Enemy";

    public Tower tower;

    public float damage;

    public void SetTarget(Transform enemy)
    {
        targetEnemy = enemy;
        direction = (targetEnemy.position - transform.position).normalized;

        StartCoroutine(MoveTowardsTarget());
    }

    IEnumerator MoveTowardsTarget()
    {
        while (true)
        {
            if (targetEnemy == null || targetEnemy.gameObject.activeInHierarchy == false)
            {
                Destroy(gameObject);
                yield break;
            }

            direction = (targetEnemy.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;

            yield return null;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(EnemyTag))
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage((int)tower.CurrentAtkDamage);
                AudioManager.instance.PlaySfx(AudioManager.Sfx.Hit);
                Destroy(gameObject);
            }
            Destroy(gameObject);
        }
    }
}
