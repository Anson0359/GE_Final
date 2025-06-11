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
        // ���P�_��V�]�o�q����ʡ^
        if (moveInput.x > 0)
            anim.SetInteger("Direction", 2); // �k
        else if (moveInput.x < 0)
            anim.SetInteger("Direction", 1); // ��
        else if (moveInput.y > 0)
            anim.SetInteger("Direction", 3); // �W
        else if (moveInput.y < 0)
            anim.SetInteger("Direction", 0); // �U
        //}


        if (Input.GetKeyDown(KeyCode.Space))
        {

        }
        

        // �A�T��﨤�u
        if (moveInput.x != 0) moveInput.y = 0;

        // �ǻ��t��
        anim.SetFloat("Speed", moveInput.sqrMagnitude);
    }



    void FixedUpdate()
    {
        // ���ʨ���
        rb.MovePosition(rb.position + moveInput * moveSpeed * Time.fixedDeltaTime);
    }

    public void SetCanMove(bool canMove)
    {
        this.canMove = canMove;
    }
}
