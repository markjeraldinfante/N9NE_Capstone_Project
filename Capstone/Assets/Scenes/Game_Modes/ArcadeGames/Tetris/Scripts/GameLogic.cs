using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public static float dropTime = 0.9f;
    public static float quickDropTime = 0.05f;
    public static int width = 15, height = 30;
    public GameObject[] blocks;
    public Transform[,] grid = new Transform [width,height];
    // Start is called before the first frame update
    void Start()
    {
        SpawnBlock();
    }
public void ClearLines() {
	for (int y = height-1; y >= 0; y--) {
		if (IsLineComplete(y)) {
			DestroyLine(y);
			MoveLines(y);
		}
	}
}
    
    void MoveLines(int y)
    {
        for (int i = y; i < height; i++)
        {
            for (int x = 0; x < width; x++)
            {
                if(grid[x,y+1]!= null)
                {
                    grid[x,y]=grid[x,y+1];
                    grid[x,y].gameObject.transform.position -= new Vector3(0,1,0);
                    grid[x,y+1] = null;
                }
            }
        }
    }
  
    void DestroyLine(int y)
    {
        for (int x = 0; x < width; x++)
        {
            Destroy(grid[x,y].gameObject);
        }
    }
    bool IsLineComplete(int y)
    {
        for (int x = 0; x < width; x++)
        {
            if(grid[x,y]==null)
            {
                return false;
            }
        }
        return true;
    }
    // Update is called once per frame
    public void SpawnBlock()
    {
        float guess = Random.Range(0, 1f);
        guess *= blocks.Length;
        Instantiate(blocks[Mathf.FloorToInt(guess)]);

    }
}
