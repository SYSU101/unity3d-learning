using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    int[,] state;
    int turn;
    Texture2D horizontalLine;
    Texture2D verticalLine;
    Texture2D circle;
    Texture2D cross;
    Texture2D chessButton;
    Rect header;
    Rect content;
    Rect footer;
    GUIStyle titleStyle;

    Color foreground = Color.white;
    Color background = Color.black;
    const int gridSize = 60;
    const int lineWidth = 3;
    const int gameWidth = gridSize*3+lineWidth*2;
    const int headerHeight = 50;
    const int contentHeight = gameWidth;
    const int footerHeight = 100;
    const int margin = 20;
    const int gridPadding = 5;

    bool IsGameOver
    {
        get
        {
            for (int i = 0; i < 3; i++)
            {
                if (state[i, 0] != 0 && state[i, 0] == state[i, 1] && state[i, 1] == state[i, 2]) return true;
                if (state[0, i] != 0 && state[0, i] == state[1, i] && state[1, i] == state[2, i]) return true;
            }
            if (state[0, 0] != 0 && state[0, 0] == state[1, 1] && state[1, 1] == state[2, 2]) return true;
            if (state[0, 2] != 0 && state[0, 2] == state[1, 1] && state[1, 1] == state[2, 0]) return true;
            bool hasSpace = false;
            for (int i = 0; i < 3 && !hasSpace; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (state[i, j] == 0)
                    {
                        hasSpace = true;
                        break;
                    }
                }
            }
            return !hasSpace;
        }
    }

    void Start ()
    {
        ResetGame();
        InitializeTexture();
        InitializeGameRegion();
        InitializeTitleStyle();
    }

    void ResetGame()
    {
        ResetData();
    }

    void OnGUI()
    {
        RenderPanel();
        RenderTitle();
        RenderChesses();
        if (IsGameOver) RenderRestartButton();
    }

    void ResetData()
    {
        state = new int[3, 3]
        {
            { 0, 0, 0 },
            { 0, 0, 0 },
            { 0, 0, 0 }
        };
        turn = 1;
    }

    void InitializeTexture()
    {
        InitializeLine(gridSize*3+lineWidth, lineWidth);
        InitializeCircle((gridSize/2)-gridPadding);
        InitializeCross(gridSize - gridPadding*2);
        InitializeChessButton(gridSize);
    }

    void InitializeCircle(int radius)
    {
        circle = new Texture2D(radius * 2, radius * 2);
        for (int i = 0; i < radius*2; i++)
        {
            for (int j = 0; j < radius*2; j++)
            {
                double dis = Math.Sqrt((i - radius) * (i - radius) + (j - radius) * (j - radius));
                if (Math.Abs(dis-radius) < 1.0)
                {
                    circle.SetPixel(i, j, foreground);
                } else
                {
                    circle.SetPixel(i, j, background);
                }
            }
        }
        circle.Apply();
    }

    void InitializeLine(int length, int width)
    {
        horizontalLine = new Texture2D(length, width);
        verticalLine = new Texture2D(width, length);
        for (int i = 0; i < length; i++)
        {
            for (int j = 0; j < width; j++)
            {
                horizontalLine.SetPixel(i, j, foreground);
                verticalLine.SetPixel(j, i, foreground);
            }
        }
        horizontalLine.Apply();
        verticalLine.Apply();
    }

    void InitializeCross(int size)
    {
        cross = new Texture2D(size, size);
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                if (Math.Abs(i-j) < 2 || Math.Abs(i-size+j-1) < 2)
                {
                    cross.SetPixel(i, j, foreground);
                } else
                {
                    cross.SetPixel(i, j, background);
                }
             }
        }
        cross.Apply();
    }

    void InitializeChessButton(int size)
    {
        chessButton = new Texture2D(size, size);
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                chessButton.SetPixel(i, j, Color.black);
            }
        }
        chessButton.Apply();
    } 

    void InitializeGameRegion()
    {
        int centerX = Screen.width / 2;
        int centerY = Screen.height / 2;
        content = new Rect(centerX - gameWidth / 2, centerY - contentHeight / 2, gameWidth, contentHeight);
        header = new Rect(content.xMin, content.yMin - margin - headerHeight, gameWidth, headerHeight);
        footer = new Rect(content.xMin, content.yMax + margin, gameWidth, footerHeight);
    }

    void InitializeTitleStyle()
    {
        titleStyle = new GUIStyle();
        titleStyle.alignment = TextAnchor.MiddleCenter;
        titleStyle.fontSize = 40;
        titleStyle.normal.textColor = foreground;
    }

    void RenderTexture(Rect region, int x, int y, Texture texture)
    {
        Rect renderRect = new Rect(region.xMin+x, region.yMin+y, texture.width, texture.height);
        GUI.DrawTexture(renderRect, texture);
    }

    void RenderPanel()
    {
        RenderTexture(content, gridSize, 0, verticalLine);
        RenderTexture(content, gridSize * 2 + lineWidth, 0, verticalLine);
        RenderTexture(content, 0, gridSize, horizontalLine);
        RenderTexture(content, 0, gridSize * 2 + lineWidth, horizontalLine);
    }

    void RenderTitle()
    {
        GUI.Label(header, "<b>井字棋</b>", titleStyle);
    }

    void RenderChessButton(int i, int j)
    {
        Rect renderRect = new Rect(content.xMin + (gridSize + lineWidth) * i, content.yMin + (gridSize + lineWidth) * j, gridSize, gridSize);
        if (GUI.Button(renderRect, chessButton))
        {
            HandleButtonClick(i, j);
        }
    }

    void RenderChesses()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                switch (state[i, j])
                {
                    case -1:
                        RenderTexture(content, (gridSize + lineWidth) * i + gridPadding, (gridSize + lineWidth) * j + gridPadding, cross);
                        break;
                    case 1:
                        RenderTexture(content, (gridSize + lineWidth) * i + gridPadding, (gridSize + lineWidth) * j + gridPadding, circle);
                        break;
                    case 0:
                        RenderChessButton(i, j);
                        break;
                }
            }
        }
        GUI.skin.button.border = new RectOffset();
        GUI.skin.button.padding = new RectOffset();
    }
    
    void HandleButtonClick(int i, int j)
    {
        if (!IsGameOver)
        {
            state[i, j] = turn;
            turn = -turn;
        }
    }

    void RenderRestartButton()
    {
        const float buttonWidth = 100;
        const float buttonHeight = 50;
        float xMin = (footer.width - buttonWidth) / 2 + footer.xMin;
        float yMin = (footer.height - buttonHeight) / 2 + footer.yMin;
        if (GUI.Button(new Rect(xMin, yMin, buttonWidth, buttonHeight), "重新开始"))
        {
            ResetData();
        }
    }
}
