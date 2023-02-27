using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class MapContextHandler : ScriptableObject
{
    public MapContext map;

    public void SetMap(MapContext map)
    {
        this.map = map;
    }
}
