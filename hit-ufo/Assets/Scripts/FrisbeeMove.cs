using System;
using UnityEngine;

public class FrisbeeMove: IMoveStrategy
{
    private Transform bindedTrans;
    private Vector3 velocity;
    private long lastCalTick = -1;
    private System.Random randGen;

    public FrisbeeMove(Vector3 velocity)
    {
        this.velocity = velocity;
        this.randGen = new System.Random();
    }

    public void BindTrans(Transform binded)
    {
        this.bindedTrans = binded;
        this.lastCalTick = DateTime.Now.Ticks;
    }

    public void Calculate()
    {
        if (this.lastCalTick > 0)
        {
            this.bindedTrans.position += this.velocity * (DateTime.Now.Ticks - this.lastCalTick) / 10000000;
            Vector3 randRotate = this.bindedTrans.rotation.eulerAngles;
            randRotate.x += (float)(this.randGen.Next() % 200 - 200) / 100f;
            randRotate.y += (float)(this.randGen.Next() % 200 - 200) / 100f;
            randRotate.z += (float)(this.randGen.Next() % 200 - 200) / 100f;
            this.bindedTrans.rotation = Quaternion.Euler(randRotate);
            this.lastCalTick = DateTime.Now.Ticks;
        }
    }
}
