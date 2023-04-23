using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LandTitleHandler : MonoBehaviour
{
    public LandTitleBase[] landPieces;
    public Image[] landPiece;

    private void Start()
    {
        Refresher();
    }

    public void Refresher()
    {
        for (int i = 0; i < landPiece.Length; i++)
        {
            landPiece[i].enabled = landPieces[i].isUnlocked;
        }
    }
}


