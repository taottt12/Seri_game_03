using UnityEngine;

public class BasicEnemy : Enemy
{
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Player")){
            if(player != null){
                player.TakeDamege(enterDamege);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision){
        if(collision.CompareTag("Player")){
            if(player != null){
                player.TakeDamege(stayDamege);
            }
        }
    }

}
