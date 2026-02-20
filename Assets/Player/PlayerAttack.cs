using System.Reflection;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    
    public Animator anim;
    public float cooldown = 0.3f;
    private float timer;
    private InputAction attackButton;
    private RaycastHit2D[] hits;

    [SerializeField] private Transform attackTransform;
    [SerializeField] private float attackRange = 1.5f;
    [SerializeField] private LayerMask attackLayer;
    [SerializeField] private float attackDamage = 1f;

    private void Start()
    {
        anim = GetComponent<Animator>();
        attackButton = InputSystem.actions.FindAction("attack");
    }

    private void Update()
    {
        //Checks to see if player wants to attack
        if (attackButton.WasPressedThisFrame() && timer <= 0)
        {
            Attack();
        }
        
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
    }


    private void Attack(){
        //Plays attack animation
            anim.SetBool("IsAttacking", true);
            
            //Acts almost like a net and catches all GameObjects that align based on given arguments
            hits = Physics2D.CircleCastAll(attackTransform.position, 
                                                    attackRange, 
                                            transform.right,
                                                    0f,
                                                    attackLayer);
            
            //This is basically us sifting through the net of items we caught to see if there is anything valuable
            for (int i = 0; i < hits.Length; i++)
            {
                IDamageable damageable = hits[i].collider.GetComponent<IDamageable>();
                
                //We then iterate and apply damage operations to items caught of interest
                if (damageable != null)
                {
                    damageable.TakeDamage(attackDamage);
                }
            }
            //Sets attack on cooldown timer.
            timer = cooldown;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackTransform.position, attackRange);
    }


    //To be called by the Player movement script when attack button is pressed
    public void attack()
    {
        if (timer <= 0)
        {
          anim.SetBool("IsAttacking", true);
          timer = cooldown;
        }
        
    }

    //This is triggered by the animation ending
    public void finishattack()
    {
        anim.SetBool("IsAttacking", false);
    }

}