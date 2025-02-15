using UnityEngine;
using UnityEngine.UI;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected float enemyMoveSpeed = 1.5f;
    [SerializeField] protected float maxHp = 50f;
    [SerializeField] protected Image hpBar;
    [SerializeField] protected float enterDamege = 10f;
    [SerializeField] protected float stayDamege = 1f;
    protected float currentHp;
    protected Player player;

    protected virtual void Start(){
        player = FindAnyObjectByType<Player>();
        currentHp = maxHp;
        UpdateHpBar();
    }

    protected virtual void Update(){
        MoveToPlayer();
        UpdateHpBar();
    }

    protected void MoveToPlayer(){
        if(player != null){
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, enemyMoveSpeed * Time.deltaTime);
            FlipEnemy();
        }
    }

    protected void FlipEnemy(){
        if(player != null){
            transform.localScale = new Vector3(player.transform.position.x < transform.position.x ? -1 : 1, 1, 1);
        }
    }

    public virtual void TakeDamege(float damege){
        currentHp-= damege;
        currentHp = Mathf.Max(currentHp, 0);
        if(currentHp <= 0){
            Die();
        }
    }

    protected virtual void Die(){
        Destroy(gameObject);
    }

    protected void UpdateHpBar(){
        if(hpBar != null){
            hpBar.fillAmount = currentHp / maxHp;
        }
    }
}
