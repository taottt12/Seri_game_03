using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("EnemyBullet")){
            Player player = GetComponent<Player>();
            player.TakeDamege(100f);
        }
        else if(collision.CompareTag("Usb")){
            
        }else if(collision.CompareTag("Energy")){
            gameManager.AddEnergy();
            Destroy(collision.gameObject);
        }
    }
}
