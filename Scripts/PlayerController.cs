using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 3f;

    private Rigidbody2D rb;
    private Animator anim;
    private Vector2 moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        

    }

    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        // 先判斷方向（這段不能動）
        if (moveInput.x > 0)
            anim.SetInteger("Direction", 2); // 右
        else if (moveInput.x < 0)
            anim.SetInteger("Direction", 1); // 左
        else if (moveInput.y > 0)
            anim.SetInteger("Direction", 3); // 上
        else if (moveInput.y < 0)
            anim.SetInteger("Direction", 0); // 下

        // 再禁止對角線
        if (moveInput.x != 0) moveInput.y = 0;

        // 傳遞速度
        anim.SetFloat("Speed", moveInput.sqrMagnitude);
    }



    void FixedUpdate()
    {
        // 移動角色
        rb.MovePosition(rb.position + moveInput * moveSpeed * Time.fixedDeltaTime);
    }
}
