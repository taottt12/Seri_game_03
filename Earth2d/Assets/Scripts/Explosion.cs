using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float damegeExplosion = 30f;

    private void OnTriggerEnter2D(Collider2D collision){
        Player player = collision.GetComponent<Player>();
        Enemy enemy = collision.GetComponent<Enemy>();
        if(collision.CompareTag("Player")){
            player.TakeDamege(damegeExplosion);
        }
        if(collision.CompareTag("Enemy")){
            enemy.TakeDamege(damegeExplosion);
        }
        
    }

    public void DestroyExplosion(){
        Destroy(gameObject);
    }
}
