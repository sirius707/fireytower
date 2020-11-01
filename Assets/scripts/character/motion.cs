using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;


public class motion : MonoBehaviour
{
    #region variables
    public float speed;
    public float sprint_speed;
    public float jump_speed;
    public Transform ground_detect;
    public Transform wall_detect; 
    public LayerMask gnd_layer;
    public LayerMask wall_layer;

    private float speed_modifier;
    private Vector3 jmp_velocity;
    private Rigidbody2D rigid_body;


    //axis
    float h_move;

    //controls
    bool sprint;
    bool jump;


    //states
    public bool is_grounded;
    public bool is_walled;
    bool is_jumping;
    bool is_sprinting;
    float direction = 1;

    //animation 
    Animator animator;

    //misc
    public int extra_jump_max;
    int extra_jump_counter;
    #endregion

    #region monobehaviour
    // Start is called before the first frame update
    void Start()
    {
        rigid_body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        //axis
        h_move = Input.GetAxisRaw("Horizontal");
        
        //controls
        sprint = Input.GetKey(KeyCode.LeftShift);
        jump = Input.GetKeyDown(KeyCode.Space);

        //states
        is_grounded = Physics2D.OverlapCircle(ground_detect.position, 0.1f, gnd_layer);
        //is_walled = Physics2D.OverlapCircle(wall_detect.position, 0.1f, gnd_layer);
        is_walled = false;
        is_jumping = jump && (is_grounded || extra_jump_counter > 0);
        is_sprinting = sprint && !is_jumping && is_grounded;
    
        //jumping 
        if (is_jumping)
        {
            if (is_walled && !is_grounded)
            {
                print("wall jump");
                wall_jump();
            }
            else
            {
                extra_jump_counter--;
                normal_jump();
            }
        }

        animator.SetFloat("h_speed", Mathf.Abs(h_move));
        animator.SetBool("is_jumping", is_jumping);
        animator.SetBool("grounded", is_grounded);
    }
    void FixedUpdate()
    {
        
        //movement
        if (is_grounded) extra_jump_counter = extra_jump_max;
        if (is_sprinting) { speed_modifier = sprint_speed; }
        else speed_modifier = speed;

        if (h_move != 0){
            if(h_move != direction)
            {
                flip();
            }
        }
        
        
        rigid_body.velocity = new Vector2(h_move * speed_modifier, rigid_body.velocity.y);

        
    }
    #endregion

    #region functions
    void normal_jump()
    {
        rigid_body.velocity = Vector2.up * jump_speed;
    }

    void wall_jump()
    {
        if (h_move != direction)
        {
            extra_jump_counter = extra_jump_max;
            rigid_body.velocity = Vector2.up * jump_speed;
        }
    }

    void flip()
    {
        direction *= -1;
        Vector2 scale;
        scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
    #endregion
}
