using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayTutorial : MonoBehaviour
{
    public GameObject playerCache;
    PlayerController controller;
    Animator anim;
    public Canvas canvas;
    public AbilityHolder holder;
    public GameObject lifebar, miniMap, Skills, tanso;

    void Start()
    {
        playerCache = GameObject.FindGameObjectWithTag("Player");
        controller = playerCache.GetComponent<PlayerController>();
        anim = playerCache.GetComponent<Animator>();
    }

    public void OnEnter()
    {
        controller.enabled = false;
        anim.SetBool("Walk", false);
    }
    public void OnExit()
    {
        controller.enabled = true;
    }
    public void ShowTanso()
    {
        canvas.enabled = true;
        lifebar.SetActive(false);
        miniMap.SetActive(false);
        tanso.SetActive(true);
    }

    public void ShowHealthBar()
    {
        lifebar.SetActive(true);
    }
    public void ShowSkill()
    {
        holder.enabled = true;
        Skills.SetActive(true);
    }
    public void ShowMinimap()
    {
        miniMap.SetActive(true);
    }
}
