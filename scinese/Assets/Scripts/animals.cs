using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Mathematics.math;

public class animals : Collidable
{
   public Transform playerpos;//para saber a posi��o do player
    private Vector2 movement;//dar movimento em x e em y
    public int numberOfLives = 2;
    public float pushRecoverySpeed = 0.2f;

    public bool mustPatrol;//controlar se o inimigo deve estar em idle
    public Rigidbody2D rb;//rigidbody do enemy para dar movimento
    public float speed;

    protected float immuneTimeCooldown = 1.0f; // time in which the enemy can't be attacked
    protected float lastImmune;

    
    private Vector3 directionVector;

    Vector2 directionIdle = new Vector2(0.1f, 0);
    private Transform myTransform;
    public Collider2D bounds;

    //public Animator animator;
    private Animator anim;
    public GameObject dad;

    private float time = 0;
    float timeStopper = 0;
    bool isMoving = false;
    float newSpeed=0;
    bool isFollowing = true;
    bool stayColision = false;
    bool animFinish = true;


    private void Start()
    {
        //mustPatrol = true;//Inicia em idle
        myTransform = GetComponent<Transform>();
        anim = GetComponent<Animator>();
       // parentTransform = GetComponentInParent<Transform>();

        ChangeDirection();
    }

    //private void Update()
    //{
    //    // input on update funct
    //    //movement.x = AxisRaw("Horizontal");
    //    //movement.y = Input.GetAxisRaw("Vertical");

    //    movement = movement.normalized;
    //    //Debug.Log(movement);
    //    directionIdle = directionIdle.normalized;

    //    animator.SetFloat("Horizontal", movement.x); 
    //    animator.SetFloat("Vertical", movement.y);
    //    animator.SetFloat("Speed", movement.sqrMagnitude);
    //}

   

    //protected override void FixedUpdate()
    //{
    //    base.FixedUpdate();

    //    Vector3 direction = playerpos.position - transform.position;//posi��o do inimgo em rela��o � do player
    //    float range = Mathf.Sqrt(Mathf.Pow(direction.x, 2) + Mathf.Pow(direction.y, 2));
    //    //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;//Calcular angulo onde se econtra o player


    //    direction.Normalize(); //manter entre -1 e 1
    //    movement = direction;

    //    directionIdle.Normalize();

    //    if(range <= 4)
    //    {
    //        //rb.rotation = angle; //rodar o inimigo para o player
    //        FollowPlayer(movement);
    //    }
    //    else
    //    {
    //        Patrol(directionIdle);
    //    }
    //}

    public void FixedUpdate()
    {
        base.FixedUpdate();
        Vector3 direction = playerpos.position - transform.position;//posi��o do inimgo em rela��o � do player
        
        float range = Mathf.Sqrt(Mathf.Pow(direction.x, 2) + Mathf.Pow(direction.y, 2));

        
        Move();
        

        UpdateAnimation();
        
    }

    public void Move()
    {
        time += Time.deltaTime; 
        
        if(time >= Random.Range(2, 5)) 
        {  
            isMoving = !isMoving;
            
            if(isMoving == true)
            {
                anim.SetBool("GoesToIdle", false);
                anim.SetBool("isMoving", true);
                ChangeDirection();
                
            }
            if(isMoving == false)
            {
                anim.SetBool("GoesToIdle", true);
                anim.SetBool("isMoving", false);
                rb.MovePosition(myTransform.position);
                
                
            }
            
            time = 0;
            
        }

        if(isMoving)
        {
            setNewSpeed(directionVector);
            
            Vector2 temp = myTransform.position + directionVector * newSpeed * Time.deltaTime;
            
            if (bounds.bounds.Contains(temp))
            {
                rb.MovePosition(temp);
                
            }
            else
            {
                ChangeDirection();
            }
            
        }
        

        
    }
   
    

    void ChangeDirection()
    {
        int direction = Random.Range(0, 8);
        switch (direction) 
        {
            case 0:
                //walking right
                directionVector = Vector2.right;
                break;
            case 1:
                //walking up
                directionVector = Vector2.up;
                break;
            case 2:
                //walking left
                directionVector = Vector2.left;
                break;
            case 3:
                //walking down
                directionVector = Vector2.down;
                break;
            case 4:
                //walking down
                directionVector.Set(1,1,0);
                break;
            case 5:
                //walking down
                directionVector.Set(1,-1,0);
                break;
            case 6:
                //walking down
                directionVector.Set(-1,1,0);
                break;
            case 7:
                //walking down
                directionVector.Set(-1,-1,0);
                break;
            default:
                break;
        }
    }

    void UpdateAnimation()
    {
        
        
        anim.SetFloat("Horizontal", directionVector.x);
        anim.SetFloat("Vertical", directionVector.y);
        
    }

/*
    void Patrol(Vector2 direction)//Enemy em idle
    {
        direction = direction.normalized;
        // direction = Random.insideUnitCircle.normalized;

        rb.MovePosition((Vector2)transform.position + (direction *speed * Time.deltaTime));
        //Debug.Log(rb.transform.position);

        //direction.Normalize(); //manter entre -1 e 1
        //movement = direction;

        if (transform.position.x >= 10)
        {
            directionIdle = new Vector2(-0.1f, 0);
        }

        if (transform.position.x <= -10)
        {
            directionIdle = new Vector2(0.1f, 0);
        }

    }*/

    

    

    




/*
    protected override void OnCollide(Collider2D coll)
    {
        Vector3 temp = directionVector;
        ChangeDirection();
        int loops = 0;
        while(temp == directionVector && loops < 100)
        {
            loops++;
            ChangeDirection();
            
        }

        // Debug.Log(coll);
        if (coll.tag == "Player")
        {
            rb.MovePosition(rb.position);
            rb.bodyType = RigidbodyType2D.Static;
            //animator.SetTrigger("Attack");//ativar anima��o de ataque
            anim.SetTrigger("Attack");


            //// create a new damage object, then we'll send it to the lower enemy
            //Damage dmg = new Damage(transform.position, 1, 0.2f);

            ////// send message to the enemy
            //coll.SendMessage("TakeDamage", dmg);
        }
        else
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
        }
    }
*/
    public void setNewSpeed(Vector3 direction) 
    {
        speed = 1f;
        newSpeed = speed;

        if(direction.y == 0 ) 
        {
            newSpeed = speed + speed /7;
        }

        if(direction.x == 0) 
        {
            newSpeed = speed - speed /3.5f;
        }
        
        
    }

   
}
