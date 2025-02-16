using UnityEngine;

public class BossEnemy : Enemy
{
    [SerializeField] private GameObject bulletPrefabs;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float speedBulletShot = 15f;
    [SerializeField] private float speedCircularSpreadShot = 10f;
    [SerializeField] private float hpValue = 50f;
    [SerializeField] GameObject miniEnemyPrefabs;
    [SerializeField] private float skilCoolDown = 3f;
    private float nextSkillTime = 3f;

    protected override void Update(){
        base.Update();
        if(Time.time >= nextSkillTime){
            UseSkill();
        }
    }

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

    private void ShotBullet(){
        if(player != null){
            Vector3 directionToPlayer = player.transform.position - firePoint.position;
            directionToPlayer.Normalize();
            GameObject bullet = Instantiate(bulletPrefabs, firePoint.position, Quaternion.identity);
            EnemyBullet enemyBullet = bullet.AddComponent<EnemyBullet>();
            enemyBullet.SetMovementDirection(directionToPlayer * speedBulletShot);
        }
    }
    private void CircularSpreadShot(){
        const int bulletCount = 12;
        float angleStep = 360f/ bulletCount;
        for(int i = 0; i < bulletCount; i++){
            float angle = i * angleStep;
            Vector3 bulletDirection = new Vector3(Mathf.Cos(Mathf.Deg2Rad * angle), Mathf.Sin(Mathf.Deg2Rad * angle), 0);
            GameObject bullet = Instantiate(bulletPrefabs, transform.position, Quaternion.identity);
            EnemyBullet enemyBullet = bullet.AddComponent<EnemyBullet>();
            enemyBullet.SetMovementDirection(bulletDirection * speedCircularSpreadShot);
        }
    }
    private void Heal(float hpAmount){
        currentHp = Mathf.Min(currentHp + hpAmount, maxHp);
        UpdateHpBar();
    }
    private void SpawnEnemyMini(){
        Instantiate(miniEnemyPrefabs, transform.position, Quaternion.identity);
    }
    private void Teleport(){
        if(player != null){
            transform.position = player.transform.position;
        }
    }

    private void ChoseRandomSkill(){
        int randomSkill = Random.Range(0, 5);
        switch (randomSkill){
            case 0: 
                ShotBullet();
                break;
            case 1: 
                CircularSpreadShot();
                break;
            case 2: 
                Heal(hpValue);
                break;
            case 3: 
                Teleport();
                break;
            case 4: 
                SpawnEnemyMini();
                break;
        }
    }

    private void UseSkill(){
        nextSkillTime = Time.time + skilCoolDown;
        ChoseRandomSkill();
    }
}
