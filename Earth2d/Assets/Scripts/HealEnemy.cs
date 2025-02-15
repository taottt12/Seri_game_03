using UnityEngine;

public class HealEnemy : Enemy
{
    [SerializeField] private float healValue = 10f;
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

    protected override void Die(){
        HealPlayer();
        base.Die();
    }

    private void HealPlayer(){
        if(player != null){
            player.Heal(healValue);
        }
    }
}
