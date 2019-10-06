using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Renderer {
    protected GameObject gameObj;
    protected IMoveStrategy moveStrategy;
    protected MainSceneController globalController;

    public Vector3 Position
    {
        get
        {
            return this.gameObj.GetComponent<Transform>().position;
        }
    }
    public IMoveStrategy MoveStrategy
    {
        set
        {
            this.moveStrategy = value;
        }
    }

    public void MoveTo(Vector3 dest)
    {
        this.moveStrategy.SetMove(this.gameObj.GetComponent<Transform>().position, dest);
        this.globalController.objectsOnAnimation++;
    }

    public void Render()
    {
        if (this.moveStrategy.OnAnimation)
        {
            this.gameObj.GetComponent<Transform>().position = this.moveStrategy.Position;
            // 如果在计算完成位置后移动动画中止
            if (!this.moveStrategy.OnAnimation)
            {
                this.globalController.objectsOnAnimation--;
            }
        }
    }
}
