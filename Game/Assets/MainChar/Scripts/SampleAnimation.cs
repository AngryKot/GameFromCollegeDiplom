using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleAnimation : MonoBehaviour
{

    // Animator 
    private Animator animator;

    
    private const string key_isRun = "IsRun";
    private const string key_isAttack01 = "IsAttack01";
    private const string key_isAttack02 = "IsAttack02";
    private const string key_isJump = "IsJump";
    private const string key_isDamage = "IsDamage";
    private const string key_isDead = "IsDead";
  
    void Start()
    {
        
        this.animator = GetComponent<Animator>();
    }

  
    void Update()
    {
        
        if (Input.GetKey("w")||(Input.GetKey("a")) || (Input.GetKey("s")) || (Input.GetKey("d")))
        {
            // Run
            this.animator.SetBool(key_isRun, true);
        }
        else
        { 
            
            this.animator.SetBool(key_isRun, false);
        }

      
        if (Input.GetMouseButtonDown(0))
        {
            //AttackHand
            this.animator.SetBool(key_isAttack01, true);
        }
        else
        {
            // Attack01
            this.animator.SetBool(key_isAttack01, false);
        }
		
		
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            //Attack02
            this.animator.SetBool(key_isAttack02, true);
        }
        else
        {
            // Attack02
            this.animator.SetBool(key_isAttack02, false);
        }
       
        // space
        if (Input.GetKeyUp("space"))
        {
            //Jump
            this.animator.SetBool(key_isJump, true);
        }
        else
        {
            // Jump
            this.animator.SetBool(key_isJump, false);
        }

        
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            //DamageTaken
            this.animator.SetBool(key_isDamage, true);
        }
        else
        {
            // Damage
            this.animator.SetBool(key_isDamage, false);
        }

        
        if (Input.GetKeyUp("f"))
        {
            //Dead
            this.animator.SetBool(key_isDead, true);
        }
    }
}