using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Mathematics.math;

public class LowerEnemy : Collidable
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

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        Vector3 direction = playerpos.position - transform.position;//posi��o do inimgo em rela��o � do player
        
        float range = Mathf.Sqrt(Mathf.Pow(direction.x, 2) + Mathf.Pow(direction.y, 2));

        if (range <= 3)
        {
            FollowPlayer(direction);
        }
        else
        {
        if(animFinish) 
        {
            Move();
        }
           
        }

        UpdateAnimation();
        
    }

    public void Move()
    {
        time += Time.deltaTime; 
        
        if(time >= Random.Range(2, 5)) 
        {  
            isMoving = !isMoving;
            Debug.Log("wiiii");
            
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
    public void FollowPlayer(Vector3 direction2)//mover o inimgo
    {
        
        if(isFollowing) //se for verdade o inimigo segue o jogador, se for falso o inimigo para de andar. Bool deixa de ser verdade quando o enimigo colide com o jogador
        {
            anim.SetBool("isMoving", true);
            anim.SetBool("GoesToIdle", false);
            setFixedDirection(direction2);
            setNewSpeed(directionVector);
            rb.MovePosition(myTransform.position + directionVector * newSpeed * Time.deltaTime);
            dad.transform.position = this.gameObject.transform.position;
        }
        else
        {
            setFixedDirection(direction2);
            rb.MovePosition(rb.position);
            
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

    public void ReceiveDamage(Damage damage)
    {
        if (Time.time - lastImmune >= immuneTimeCooldown)
        {
            lastImmune = Time.time;
            numberOfLives -= damage.damage;

            // push direction, the enemy should be pushed backwards, so, you first need the position of the enemy, then the origin position (in this case, the player's)
            


            // se receber dano:
            anim.SetBool("isAttacking", false); // cancelar a sua animação de ataque


            // tirar isto e POR isto no final da animação de hit
            isFollowing = true;  // voltar a andar 
            anim.SetBool("isFollowing", true);
            Debug.Log("sdf");



        
        if (numberOfLives <= 0)
            {
                numberOfLives = 0;
                Death();
            }
        }
    }

    public void Death()
    {
        Debug.Log("A lower enemy was killed!");
        Destroy(this.gameObject);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            Debug.Log("colide");
            anim.SetBool("isAttacking", true); // iniciar a animação de ataque
            anim.SetBool("isMoving", false);
            isMoving = true;
            isFollowing = false;  // para o movimento do jogador
            stayColision = true;

            //// create a new damage object, then we'll send it to the lower enemy
            //Damage dmg = new Damage(transform.position, 1, 0.2f);

            ////// send message to the enemy
            //coll.SendMessage("TakeDamage", dmg);
        }
    }

     void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            stayColision = false;
            animFinish = false;

        }

    }


    public void AttackAnimEndded () 
    {
        if(stayColision == false)
        {
            anim.SetBool("isMoving", true);
            anim.SetBool("isAttacking", false);
            isFollowing = true;
            animFinish = true;
            
        }
       
        
    }



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

    public void setFixedDirection (Vector3 direction)
    {
        direction.Normalize();

        if(direction.x > 0.5f)
        {
            directionVector.x = 1f;
        }

         if(direction.x < -0.5f)
        {
            directionVector.x = -1f;
        }

        if(direction.x <= 0.5f && direction.x >= -0.5f)
        {
            directionVector.x =0;
        }

        //-------------

        if(direction.y > 0.5f)
        {
            directionVector.y = 1f;
        }

         if(direction.y < -0.5f)
        {
            directionVector.y = -1f;
        }

        if(direction.y <= 0.5f && direction.y >= -0.5f)
        {
            directionVector.y =0;
        }


    }
}
