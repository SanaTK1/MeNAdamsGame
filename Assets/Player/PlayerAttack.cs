using System.Reflection;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    
    public Animator anim;

    public float cooldown = 0.5f;
    private float timer;

    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
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