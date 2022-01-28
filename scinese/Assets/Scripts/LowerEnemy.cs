using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowerEnemy : Collidable
{
    public Transform playerpos;//para saber a posição do player
    private Vector2 movement;//dar movimento em x e em y
    public int numberOfLives = 2;
    public float pushRecoverySpeed = 0.2f;

    public bool mustPatrol;//controlar se o inimigo deve estar em idle
    public Rigidbody2D rb;//rigidbody do enemy para dar movimento
    public float speed;

    protected float immuneTimeCooldown = 1.0f; // time in which the enemy can't be attacked
    protected float lastImmune;

    protected Vector2 pushDirection;
    private Vector3 directionVector;

    Vector2 directionIdle = new Vector2(0.1f, 0);
    private Transform myTransform;
    public Collider2D bounds;

    //public Animator animator;
    private Animator anim;
    public GameObject dad;


    private void Start()
    {
        mustPatrol = true;//Inicia em idle
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

    public void Move()
    {
        Vector3 temp = myTransform.position + directionVector * speed * Time.deltaTime;
        if (bounds.bounds.Contains(temp))
        {
            rb.MovePosition(temp);
        }
        else
        {
            ChangeDirection();
        }
    }

    //protected override void FixedUpdate()
    //{
    //    base.FixedUpdate();

    //    Vector3 direction = playerpos.position - transform.position;//posição do inimgo em relação à do player
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
        Vector3 direction = playerpos.position - transform.position;//posição do inimgo em relação à do player
        float range = Mathf.Sqrt(Mathf.Pow(direction.x, 2) + Mathf.Pow(direction.y, 2));

        if (range <= 4)
        {
            direction.Normalize(); //manter entre -1 e 1
            directionVector = direction;
            //rb.rotation = angle; //rodar o inimigo para o player
            FollowPlayer(directionVector);
        }
        else
        {
            Move();
        }

        UpdateAnimation();
    }

    public void FollowPlayer(Vector3 direction2)//mover o inimgo
    {

        mustPatrol = false;
        //direction2 = direction2.normalized;
        rb.MovePosition(myTransform.position + (direction2 * speed * Time.deltaTime));
        dad.transform.position = this.gameObject.transform.position;
    }

    void ChangeDirection()
    {
        int direction = Random.Range(0, 4);
        switch (direction)
        {
            case 0:
                //walking right
                directionVector = Vector3.right;
                break;
            case 1:
                //walking up
                directionVector = Vector3.up;
                break;
            case 2:
                //walking left
                directionVector = Vector3.left;
                break;
            case 3:
                //walking down
                directionVector = Vector3.down;
                break;
            default:
                break;
        }
    }

    void UpdateAnimation()
    {
        anim.SetFloat("Horizontal", directionVector.x);
        anim.SetFloat("Vertical", directionVector.y);
        anim.SetFloat("Speed", directionVector.sqrMagnitude);
    }

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

    }

    public void ReceiveDamage(Damage damage)
    {
        if (Time.time - lastImmune >= immuneTimeCooldown)
        {
            lastImmune = Time.time;
            numberOfLives -= damage.damage;

            // push direction, the enemy should be pushed backwards, so, you first need the position of the enemy, then the origin position (in this case, the player's)
            pushDirection = (this.transform.position - damage.originOfAttack).normalized * damage.pushForce;
        
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
            //animator.SetTrigger("Attack");//ativar animação de ataque
            anim.SetTrigger("Attack");

            //// create a new damage object, then we'll send it to the lower enemy
            //Damage dmg = new Damage(transform.position, 1, 0.2f);

            ////// send message to the enemy
            //coll.SendMessage("TakeDamage", dmg);
        }
    }
}
