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

        // ���P�_��V�]�o�q����ʡ^
        if (moveInput.x > 0)
            anim.SetInteger("Direction", 2); // �k
        else if (moveInput.x < 0)
            anim.SetInteger("Direction", 1); // ��
        else if (moveInput.y > 0)
            anim.SetInteger("Direction", 3); // �W
        else if (moveInput.y < 0)
            anim.SetInteger("Direction", 0); // �U

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
}
