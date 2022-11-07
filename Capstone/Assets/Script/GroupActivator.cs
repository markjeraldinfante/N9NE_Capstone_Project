using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupActivator : MonoBehaviour
{

    public List<GameObject> GameObjectsGroup;

    public void ShowObject(GameObject toShow)
    {
        foreach (GameObject go in GameObjectsGroup)
        {
            go.SetActive(false);
        }
        toShow.SetActive(true);
    }

}
