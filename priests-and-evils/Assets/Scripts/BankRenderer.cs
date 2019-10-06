using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BankRenderer
{
    private GameObject gameObj;

    public BankRenderer(Vector3 pos, Materials mats, Configs configs)
    {
        this.gameObj = GameObject.CreatePrimitive(PrimitiveType.Cube);
        MeshRenderer meshRenderer = this.gameObj.GetComponent<MeshRenderer>();
        meshRenderer.materials = new Material[1] { mats.Bank };
        Transform transform = this.gameObj.GetComponent<Transform>();
        transform.position = pos;
        transform.localScale = configs.BankScale;
    }
}
