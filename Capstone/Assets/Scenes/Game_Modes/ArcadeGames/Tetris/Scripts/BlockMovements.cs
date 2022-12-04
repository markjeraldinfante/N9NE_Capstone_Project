using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMovements : MonoBehaviour
{
    GameLogic gameLogic;
    float timer = 0f;
    bool movable = true;
    public GameObject rig;
    // Start is called before the first frame update
    void Start()
    {
        gameLogic = FindObjectOfType <GameLogic>();
    }
    bool CheckValid()
    {
        foreach (Transform subBlock in rig.transform)
        {
            if(subBlock.transform.position.x >= GameLogic.width || subBlock.transform.position.x <= -1 || subBlock.transform.position.y <= 0 )
            {
                return false;
            }
        } return true;
    }

    // Update is called once per frame
    void Update()
    {
        if(movable){
            //drop
            timer += 1 * Time.deltaTime;
            if(Input.GetKeyDown(KeyCode.DownArrow) && timer > GameLogic.quickDropTime)
            {
                gameObject.transform.position -= new Vector3(0,1,0);
                timer = 0;
                if(!CheckValid())
                {
                    movable = false;
                    gameObject.transform.position += new Vector3(0,1,0);
                    gameLogic.SpawnBlock();
                }
            }
            else if (timer > GameLogic.dropTime)
            {
                
                gameObject.transform.position -= new Vector3(0,1,0);
                timer = 0;
                 if(!CheckValid())
                {
                    movable = false;
                    gameObject.transform.position += new Vector3(0,1,0);
                    gameLogic.SpawnBlock();
                }
            }
            //sidewaysn
            if(Input.GetKeyDown(KeyCode.A))
            {
                gameObject.transform.position -= new Vector3(1,0,0);
                 if(!CheckValid())
                {
                    gameObject.transform.position += new Vector3(1,0,0);
                }
            }
            else if(Input.GetKeyDown(KeyCode.D))
            {
                gameObject.transform.position += new Vector3(1,0,0);
                 if(!CheckValid())
                {
                    gameObject.transform.position -= new Vector3(1,0,0);
                }
            }
            //rotation
            if(Input.GetKeyDown(KeyCode.UpArrow))
            {
                rig.transform.eulerAngles -= new Vector3(0,0,90);
                 if(!CheckValid())
                {
                    rig.transform.eulerAngles += new Vector3(0,0,90);
                }
            }
        }
    }
}
