using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStartInstantiate : MonoBehaviour
{
    public delegate void Instantiate1Player();
    public delegate void Instantiate2Player();
    public delegate void OnlineInstantiate2Player();
    public static event Instantiate1Player spawn1Player;
    public static event Instantiate2Player spawn2Player;
    public static event OnlineInstantiate2Player spawn2PlayerOnline;
    public baseSurvivalVariant variant;

    public void Awake()
    {
        switch (variant.variantType)
        {
            case baseSurvivalVariant.VariantType.Online:
                // spawn2PlayerOnline?.Invoke();
                Debug.Log("Online Mode");
                break;
            case baseSurvivalVariant.VariantType.TwoPlayer:
                spawn2Player?.Invoke();
                break;
            case baseSurvivalVariant.VariantType.SinglePlayer:
                spawn1Player?.Invoke();
                break;
            default:
                Debug.LogError("Invalid variant type");
                break;
        }
    }




}
