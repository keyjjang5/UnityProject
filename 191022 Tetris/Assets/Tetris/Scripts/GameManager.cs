using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // x, y
    bool[, ] isThereArray = new bool[12, 21];

    // Start is called before the first frame update
    void Start()
    {
        // 모든공간 false 초기화
        for (int i = 0; i < 12; i++)
            for (int j = 0; j < 21; j++)
                isThereArray[i, j] = false;

        // 좌우벽과 바닥 true 로 초기화
        for (int j = 0; j < 21; j++)
        {
            isThereArray[0, j] = true;
            isThereArray[11, j] = true;
        }
        for (int i = 0; i < 12; i++)
            isThereArray[i, 20] = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void fillBoard(int x, int y)
    {
        isThereArray[x, y] = true;
    }

    public bool isThere(int x, int y)
    {
        if (x > 11 || x < 0 || y > 20 || y < 0)
            return false;

        if(isThereArray[x, y])
            return true;

        return false;
    }
}
