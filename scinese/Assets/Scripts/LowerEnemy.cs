using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowerEnemy : Collidable
{
    public Transform player;//para saber a posição do player
    private Vector2 movement;//dar movimento em x e em y
    public int numberOfLives = 2;
    public float pushRecoverySpeed = 0.2f;

    public bool mustPatrol;//controlar se o inimigo deve estar em idle
    public Rigidbody2D rb;//rigidbody do enemy para dar movimento
    public float speed;

    protected float immuneTimeCooldown = 1.0f; // time in which the enemy can't be attacked
    protected float lastImmune;

    protected Vector2 pushDirection;

    Vector2 directionIdle = new Vector2(0.1f, 0);

    public Animator animator;


    private void Start()
    {
        mustPatrol = true;//Inicia em idle
    }

    private void Update()
    {

    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        Vector3 direction = player.position - transform.position;//posição do inimgo em relação à do player
        float range = Mathf.Sqrt(Mathf.Pow(direction.x, 2) + Mathf.Pow(direction.y, 2));
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;//Calcular angulo onde se econtra o player
        

        direction.Normalize(); //manter entre -1 e 1
        movement = direction;

        if(range <= 4)
        {
            rb.rotation = angle; //rodar o inimigo para o player
            FollowPlayer(movement);
        }
        else
        {
            Patrol(directionIdle);
        }
        
    }

    public void FollowPlayer(Vector2 direction2)//mover o inimgo
    {

        //Vector3 direction = player.position - transform.position;//posição do inimgo em relação à do player

        //float range = Mathf.Sqrt(Mathf.Pow(direction.x, 2) + Mathf.Pow(direction.y, 2)); 

        //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;//Calcular angulo onde se econtra o player
        //rb.rotation = angle; //rodar o inimigo para o player

        //direction.Normalize(); //manter entre -1 e 1
        //movement = direction;
        //if(range <= 2)
        //{
        //    rb.MovePosition((Vector2)transform.position + (direction2 * speed * Time.deltaTime));
        //}

        mustPatrol = false;
        rb.MovePosition((Vector2)transform.position + (direction2 * speed * Time.deltaTime));

    }

    void Patrol(Vector2 direction)//Enemy em idle
    {

        rb.MovePosition((Vector2)transform.position + (direction *speed * Time.fixedDeltaTime));

        //Debug.Log(rb.transform.position);

        //direction.Normalize(); //manter entre -1 e 1
        //movement = direction;

        if (transform.position.x >= 10)
        {
            FlipLeft();
        }

        if (transform.position.x <= -10)
        {
            FlipRight();
        }
        
        //animator.SetBool("isRight", true); //começar animaçao para a direita
    }

    void FlipLeft()
    {
        animator.SetBool("isRight", false);
        animator.SetBool("isLeft", true);//ativar anim esq
        directionIdle = new Vector2(-0.1f, 0);   
    }

    void FlipRight()
    {
        animator.SetBool("isLeft", false);
        animator.SetBool("isRight", true);//ativar anim dir
        directionIdle = new Vector2(0.1f, 0);
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
        // Debug.Log(coll);
        if (coll.tag == "Player")
        {
            // create a new damage object, then we'll send it to the lower enemy
            Damage dmg = new Damage(transform.position, 1, 0.2f);

            // send message to the enemy
            coll.SendMessage("TakeDamage", dmg);
        }
    }
}
