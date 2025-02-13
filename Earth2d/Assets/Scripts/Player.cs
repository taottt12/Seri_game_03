using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
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
        
    }

    void Update()
    {
        Movement();
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
}
