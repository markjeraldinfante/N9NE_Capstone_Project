using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityHolder : MonoBehaviour
{
    public Ability ability;
    float cooldownTime;
    float activeTime;
    private Animator animator;
    private IEnumerator coroutine;
    public Image cd;
    enum AbilityState
    {
        ready,
        active,
        cooldown
    }
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    AbilityState state = AbilityState.ready;
    public KeyCode key;

    void Update()
    {

        switch (state)
        {

            case AbilityState.ready:
                if (Input.GetKeyDown(key))
                {
                    cd.fillAmount = 1f;
                    animator.SetBool("Walk", false);
                    animator.SetBool("Dash", true);
                    coroutine = WaitAndPrint(.5f);
                    StartCoroutine(coroutine);

                    state = AbilityState.active;
                    activeTime = ability.activeTime;
                    //activate ability
                }
                break;
            case AbilityState.active:
                if (activeTime > 0)
                {
                    activeTime -= Time.deltaTime;
                    cd.fillAmount = 0f;
                }
                else
                {
                    ability.BeginCooldown(gameObject);
                    state = AbilityState.cooldown;
                    cooldownTime = ability.cooldownTime;

                }
                break;
            case AbilityState.cooldown:
                if (cooldownTime > 0)
                {
                    animator.SetBool("Dash", false);
                    cooldownTime -= Time.deltaTime;
                    cd.fillAmount = 1f - cooldownTime / ability.cooldownTime;
                }
                else
                {
                    state = AbilityState.ready;
                }
                break;

        }

    }
    private IEnumerator WaitAndPrint(float waitTime)
    {

        yield return new WaitForSeconds(waitTime);
        ability.Activate(gameObject);

    }
}
