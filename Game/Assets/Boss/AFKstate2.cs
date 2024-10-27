using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AFK2behaviour : StateMachineBehaviour
{
    float timer;
    Transform player;
    float chaseRange = 13;
    BossScript enemyHealth; // Добавляем переменную для хранения компонента здоровья

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 5;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemyHealth = animator.GetComponent<BossScript>(); // Получаем компонент здоровья у объекта с аниматором
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (enemyHealth != null && enemyHealth.HP <= 100) // Проверяем здоровье противника
        {


            animator.SetTrigger("lowhealth");

        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
