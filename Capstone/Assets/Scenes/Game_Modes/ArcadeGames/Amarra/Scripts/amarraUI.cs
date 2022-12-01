using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class amarraUI : MonoBehaviour
{
    public GameObject UIgameobj;
    public float floatTO;
    public float floatTIME;
    // Start is called before the first frame update
    void Start()
    {
        LeanTween.alpha(UIgameobj, floatTO, floatTIME).setLoopPingPong();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
