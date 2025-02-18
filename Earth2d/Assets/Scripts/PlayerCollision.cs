using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private AudioManager audioManager;
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("EnemyBullet")){
            Player player = GetComponent<Player>();
            player.TakeDamege(100f);
        }
        else if(collision.CompareTag("Usb")){
            gameManager.WinGameMenu();
            Destroy(collision.gameObject);
        }
        else if(collision.CompareTag("Energy")){
            gameManager.AddEnergy();
            Destroy(collision.gameObject);
            audioManager.PlayEnergySound();
        }
    }
}
