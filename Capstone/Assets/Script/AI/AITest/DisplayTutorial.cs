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
    [SerializeField] AdventurePlayer adventurePlayer;
    [SerializeField] Melee_Adventure melee_Adventure;

    void Start()
    {
        playerCache = GameObject.FindGameObjectWithTag("Player");
        adventurePlayer = playerCache.GetComponent<AdventurePlayer>();
        melee_Adventure = playerCache.GetComponent<Melee_Adventure>();
        controller = playerCache.GetComponent<PlayerController>();
        anim = playerCache.GetComponent<Animator>();
    }

    public void OnEnter()
    {
        controller.enabled = false;

        if (adventurePlayer != null)
        {
            adventurePlayer.enabled = false;
        }
        if (melee_Adventure != null)
        {
            melee_Adventure.enabled = false;
        }

        anim.SetBool("Walk", false);
    }
    public void OnExit()
    {
        controller.enabled = true;
        if (adventurePlayer != null)
        {
            adventurePlayer.enabled = true;
        }
        if (melee_Adventure != null)
        {
            melee_Adventure.enabled = true;
        }
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
