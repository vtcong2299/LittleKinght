using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class AnimationPlayer : MonoBehaviour
{
    public static AnimationPlayer instance;
    public Animator animator;
    private void OnEnable()
    {
        instance = this;
    }
    private void OnDisable()
    {
        instance = null;
    }
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void SetIsRunTrue()
    {
        animator.SetBool("isRun", true);
    }
    public void SetIsRunFalse()
    {
        animator.SetBool("isRun", false);
    }
    public void SetPressZ()
    {
        animator.SetTrigger("baseAttack");
    }
    public void SetDefend()
    {
        animator.SetBool("defend", true );
    }
    public void SetNotDefend()
    {
        animator.SetBool("defend",false);
    }
    public void SetSkill1()
    {
        animator.SetBool("skill1",true);
        StartCoroutine(DelayEndSkill1());
    }
    IEnumerator DelayEndSkill1()
    {
        yield return new WaitForSeconds(3f);
        animator.SetBool("endSkill1",true);
        yield return new WaitForSeconds(1f);
        animator.SetBool("skill1",false);
        animator.SetBool("endSkill1", false) ;
    }
}
