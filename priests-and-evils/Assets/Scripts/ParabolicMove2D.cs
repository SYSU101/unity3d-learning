using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParabolicMove2D : IMoveStrategy
{
    private float summit; // 最高点纵坐标
    private float midx;  // 最高点横坐标
    private float speed; // x轴方向的速度分量
    private DateTime? startTime;
    private Vector3 src, dest;
    private bool isPaused;

    public Vector3 Position
    {
        get
        {
            if (this.startTime == null)
            {
                return new Vector3();
            }
            if (this.isPaused)
            {
                return this.src;
            }
            float sign = 1.0f;
            if (src.x > dest.x)
            {
                sign = -1.0f;
            }
            float x = (DateTime.Now.Ticks - startTime?.Ticks ?? 0) / 1e7f * this.speed * sign + src.x;
            if (sign * (x - dest.x) > 0)
            {
                x = dest.x;
                this.startTime = null;
                return dest;
            }
            // 拉格朗日插值公式
            float p0 = src.y * ((x - midx) * (x - dest.x)) / ((src.x - midx) * (src.x - dest.x));
            float p1 = summit * ((x - src.x) * (x - dest.x)) / ((midx - src.x) * (midx - dest.x));
            float p2 = dest.y * ((x - src.x) * (x - midx)) / ((dest.x - src.x) * (dest.x - midx));
            return new Vector3(x, p0 + p1 + p2, src.z);
        }
    }
    public bool OnAnimation => this.startTime != null;

    public ParabolicMove2D(float summit, float speed)
    {
        this.summit = summit;
        this.speed = speed;
    }

    public void SetMove(Vector3 from, Vector3 to)
    {
        this.startTime = DateTime.Now;
        this.src = from;
        this.dest = to;
        this.midx = (this.src.x + this.dest.x) / 2.0f;
    }

    public void OnStopMove()
    {
        this.startTime = null;
        this.src = dest;
    }

    public void OnPauseMove()
    {
        this.src = this.Position;
        this.isPaused = true;
    }

    public void OnResumeMove()
    {
        this.startTime = DateTime.Now;
        this.isPaused = false;
    }

    public IMoveStrategy Clone()
    {
        return new ParabolicMove2D(this.summit, this.speed);
    }
}
