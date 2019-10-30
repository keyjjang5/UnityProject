using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // x, y
    private bool[,] isThereArray = new bool[12, 21];
    private GameObject[,] blocks = new GameObject[12, 21];
    private int comboCount;
    private int score;
    private Text comboText;
    private Text scoreText;

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

        comboCount = 0;
        score = 0;
        comboText = GameObject.Find("Combo").transform.GetChild(0).GetComponent<Text>();
        scoreText = GameObject.Find("Score").transform.GetChild(0).GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void fillBoard(int x, int y, GameObject gameObj)
    {
        if (x > 11 || x < 0 || y > 20 || y < 0)
            return;
        isThereArray[x, y] = true;
        blocks[x, y] = gameObj;
    }

    public bool isThere(int x, int y)
    {
        if (x > 11 || x < 0 || y > 20 || y < 0)
            return false;

        if(isThereArray[x, y])
            return true;

        return false;
    }

    public void checkLineClear()
    {
        int cnt = 0;
        bool mainTainCombo = false;
        for(int j = 1; j < 20; j++)
        {
            for (int i = 1; i < 11; i++)
            {
                if (isThereArray[i, j])
                    cnt++;
            }

            if (cnt == 10)
            {
                lineClear(j);
                mainTainCombo = true;
            }

            cnt = 0;
        }

        if (!mainTainCombo)
            clearCombo();
    }

    void lineClear(int j)
    {
        for (int i = 1; i < 11; i++)
        {
            isThereArray[i, j] = false;
            Destroy(blocks[i, j]);
            blocks[i, j] = null;
        }

        for (int y = j - 1; y > 1; y--)
        {
            for (int k = 1; k < 11; k++)
            {
                isThereArray[k, y + 1] = isThereArray[k, y];

                if (!isThereArray[k, y])
                    continue;

                BlockController.MoveDown(blocks[k, y].transform);
                blocks[k, y + 1] = blocks[k, y];
            }
        }

        increaseCombo();
    }

    void increaseCombo()
    {
        comboCount++;
        increaseScore(1000 * comboCount);
        drawText();
    }

    void clearCombo()
    {
        comboCount = 0;
        drawText();
    }

    public void increaseScore(int value)
    {
        score += value;
        drawText();
    }

    void drawText()
    {
        comboText.text = comboCount.ToString();
        scoreText.text = score.ToString();
    }
}
