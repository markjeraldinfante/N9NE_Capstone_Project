using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swapCharacter : MonoBehaviour
{
    [SerializeField] private GameObject[] characters;
    private int currentIndex = 0;

    public void SwapCharacter()
    {
        characters[currentIndex].SetActive(false);

        currentIndex = (currentIndex + 1) % characters.Length;

        characters[currentIndex].SetActive(true);
    }

}
