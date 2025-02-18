using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] protected float maxHp = 150f;
    [SerializeField] protected Image hpBar;
    [SerializeField] private GameManager gameManager;
    protected float currentHp;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private void Awake(){
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        currentHp = maxHp;
        UpdateHpBar();
    }

    void Update()
    {
        Movement();
        if(Input.GetKeyDown(KeyCode.Escape)){
            gameManager.PauseGameMenu();
        }
    }

    void Movement(){
        Vector2 playerInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rb.linearVelocity = playerInput.normalized * moveSpeed;

        if(playerInput.x < 0){
            spriteRenderer.flipX = true;
        }else if(playerInput.x > 0) {
            spriteRenderer.flipX = false;
        }

        if(playerInput != Vector2.zero){
            animator.SetBool("isRun", true);
        }else{
            animator.SetBool("isRun",false);
        }
    }

    public void TakeDamege(float damege){
        currentHp-= damege;
        currentHp = Mathf.Max(currentHp, 0);
        UpdateHpBar();
        if(currentHp <= 0){
            Die();
        }
    }
    
    public void Heal(float healValue){
        if(currentHp < maxHp){
            currentHp += healValue;
            currentHp = Mathf.Min(currentHp, maxHp);
            UpdateHpBar();
        }
    }
    public void Die(){
        gameManager.GameOverMenu();
    }

    private void UpdateHpBar(){
        if(hpBar != null){
            hpBar.fillAmount = currentHp / maxHp;
        }
    }
}
