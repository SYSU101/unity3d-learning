using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearMove2D : IMoveStrategy
{
    private float speed;
    private Vector3 src, dest;
    private DateTime? startTime;
    private bool isPaused = false;

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
            float dx = src.x - dest.x;
            float sign = 1.0f;
            if (src.x > dest.x)
            {
                sign = -1.0f;
            }
            float x = (DateTime.Now.Ticks - startTime?.Ticks ?? 0) / 1e7f * this.speed * sign + src.x;
            if (sign*(x-dest.x) > 0)
            {
                x = dest.x;
                this.startTime = null;
                return dest;
            }
            float y = (src.y - dest.y) / dx * x + (src.x * dest.y - dest.x * src.y) / dx;
            return new Vector3(x, y, src.z);
        }
    }
    public bool OnAnimation => this.startTime != null;

    public LinearMove2D(float speed)
    {
        this.speed = speed;
    }

    public void SetMove(Vector3 from, Vector3 to)
    {
        this.startTime = DateTime.Now;
        this.src = from;
        this.dest = to;
    }

    public void OnStopMove() {
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
        return new LinearMove2D(this.speed);
    }
}
