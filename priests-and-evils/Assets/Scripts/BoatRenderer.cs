using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatRenderer: Renderer
{
    public BoatRenderer(Vector3 pos, Materials mats, IMoveStrategy moveStrategy, MainSceneController globalController, Configs configs)
    {
        this.gameObj = GameObject.CreatePrimitive(PrimitiveType.Cube);
        MeshRenderer meshRenderer = this.gameObj.GetComponent<MeshRenderer>();
        meshRenderer.material = mats.Boat;
        Transform transform = this.gameObj.GetComponent<Transform>();
        transform.position = pos;
        transform.localScale = configs.BoatScale;
        BoatController localController = this.gameObj.AddComponent<BoatController>();
        localController.Inject(this, globalController);
        this.moveStrategy = moveStrategy;
        this.globalController = globalController;
    }
}
