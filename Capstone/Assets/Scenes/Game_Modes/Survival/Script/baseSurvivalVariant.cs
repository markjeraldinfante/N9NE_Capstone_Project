using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class baseSurvivalVariant : ScriptableObject
{
    public enum VariantType
    {
        Online,
        TwoPlayer,
        SinglePlayer
    }

    public VariantType variantType;
}

