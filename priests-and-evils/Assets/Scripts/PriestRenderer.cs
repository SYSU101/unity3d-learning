using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriestRenderer: Renderer
{
    public PriestRenderer(int id, Vector3 pos, Materials mats, IMoveStrategy moveStrategy, MainSceneController globalController, Configs configs)
    {
        this.gameObj = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        MeshRenderer meshRenderer = this.gameObj.GetComponent<MeshRenderer>();
        meshRenderer.material = mats.Priest;
        Transform transform = this.gameObj.GetComponent<Transform>();
        transform.position = pos;
        transform.localScale = configs.CharScale;
        PriestController localController = this.gameObj.AddComponent<PriestController>();
        localController.Inject(id, this, globalController, configs);
        this.moveStrategy = moveStrategy;
        this.globalController = globalController;
    }
}
