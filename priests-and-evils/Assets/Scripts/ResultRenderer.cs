using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultRenderer {
    private GameObject textObj;
    private GameObject planeObj;

    public ResultRenderer(Vector3 pos, Quaternion rotation, Vector3 scale, Materials mats)
    {
        this.planeObj = GameObject.CreatePrimitive(PrimitiveType.Plane);
        Transform planeTrans = this.planeObj.GetComponent<Transform>();
        planeTrans.position = pos;
        planeTrans.rotation = rotation;
        planeTrans.localScale = scale;
        MeshRenderer meshRenderer = this.planeObj.GetComponent<MeshRenderer>();
        meshRenderer.material = mats.ResultPlane;
        this.planeObj.SetActive(false);
    }

    public void Show(string text, Vector3 pos)
    {
        this.textObj = new GameObject();
        Transform textTrans = this.textObj.GetComponent<Transform>();
        textTrans.position = pos;
        TextMesh textMesh = this.textObj.AddComponent<TextMesh>();
        textMesh.text = text;
        textMesh.anchor = TextAnchor.MiddleCenter;
        this.planeObj.SetActive(true);
    }
}
