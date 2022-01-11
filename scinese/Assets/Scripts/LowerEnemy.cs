using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    protected Vector2 pushDirection;

    Vector2 directionIdle = new Vector2(0.1f, 0);

    public Animator animator;
    private BoxCollider2D boxcol;

    private EnemyDamage enemyDamage;


    private void Start()
    {
        mustPatrol = true;//Inicia em idle
        boxcol = GetComponentInChildren<BoxCollider2D>();
    }

    private void Update()
    {
        // input on update funct
        //movement.x = AxisRaw("Horizontal");
        //movement.y = Input.GetAxisRaw("Vertical");

        movement = movement.normalized;
        //Debug.Log(movement);

        animator.SetFloat("Horizontal", movement.x); //Realizar anima��es quando as tivermos
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        Vector3 direction = playerpos.position - transform.position;//posi��o do inimgo em rela��o � do player
        float range = Mathf.Sqrt(Mathf.Pow(direction.x, 2) + Mathf.Pow(direction.y, 2));
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;//Calcular angulo onde se econtra o player
        

        direction.Normalize(); //manter entre -1 e 1
        movement = direction;

        if(range <= 4)
        {
            //rb.rotation = angle; //rodar o inimigo para o player
            FollowPlayer(movement);
        }
        else
        {
            Patrol(directionIdle);
        }
    }

    public void FollowPlayer(Vector2 direction2)//mover o inimgo
    {

        mustPatrol = false;
        direction2 = direction2.normalized;
        rb.MovePosition((Vector2)transform.position + (direction2 * speed * Time.deltaTime));

    }

    void Patrol(Vector2 direction)//Enemy em idle
    {
       direction = direction.normalized;
       // direction = Random.insideUnitCircle.normalized;

        rb.MovePosition((Vector2)transform.position + (direction *speed * Time.fixedDeltaTime));

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
        // Debug.Log(coll);
        if (coll.tag == "Player")
        {
            
            animator.SetTrigger("Attack");//ativar anima��o de ataque

            //// create a new damage object, then we'll send it to the lower enemy
            Damage dmg = new Damage(transform.position, 1, 0.2f);

            //// send message to the enemy
            coll.SendMessage("TakeDamage", dmg);
        }
    }
}
