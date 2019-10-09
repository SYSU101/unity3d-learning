using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrisbeeRenderer
{
    private GameObject GameObj;
    private IMoveStrategy move;
    private FrisbeeController localController;

    public bool recycled = false;

    public IMoveStrategy Move
    {
        get
        {
            return this.move;
        }
        set
        {
            this.move = value;
            if (this.GameObj != null)
            {
                this.move.BindTrans(this.GameObj.transform);
            }
        }
    }

    public FrisbeeRenderer(Configs configs, FrisbeeFactory factory, Models models, IMoveStrategy move, ResourceMgr resources)
    {
        this.GameObj = GameObject.Instantiate(
            resources.frisbeePrefab,
            configs.DefaultFrisbeePos,
            Quaternion.Euler(0, 0, 0)
        );
        this.localController = this.GameObj.AddComponent<FrisbeeController>();
        this.localController.Inject(this, factory, models);
        this.Move = move;
    }

    public void Render()
    {
        this.Move.Calculate();
    }

    public void MoveTo(Vector3 pos)
    {
        this.GameObj.transform.position = pos;
    }
}
