using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb = null;
    [SerializeField] private Animator anim = null;
    private bool canMove = false;


    private float moveSpeed = 3f;
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

        //if (canMove)
        //{
        // 先判斷方向（這段不能動）
        if (moveInput.x > 0)
            anim.SetInteger("Direction", 2); // 右
        else if (moveInput.x < 0)
            anim.SetInteger("Direction", 1); // 左
        else if (moveInput.y > 0)
            anim.SetInteger("Direction", 3); // 上
        else if (moveInput.y < 0)
            anim.SetInteger("Direction", 0); // 下
        //}


        if (Input.GetKeyDown(KeyCode.Space))
        {

        }
        

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

    public void SetCanMove(bool canMove)
    {
        this.canMove = canMove;
    }
}
