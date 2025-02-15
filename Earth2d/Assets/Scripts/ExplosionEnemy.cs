using UnityEngine;

public class ExplosionEnemy : Enemy
{
    [SerializeField] private GameObject explosionPrefabs;

    private void CrateExplosion(){
        if(explosionPrefabs != null){
            Instantiate(explosionPrefabs, transform.position, Quaternion.identity);
        }
    }

    protected override void Die(){
        CrateExplosion();
        base.Die();
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Player")){
            CrateExplosion();
            Die();
        }
    }
}
