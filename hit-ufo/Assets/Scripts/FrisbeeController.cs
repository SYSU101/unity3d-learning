using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrisbeeController: MonoBehaviour
{
    private Models models;
    private new FrisbeeRenderer renderer;
    private FrisbeeFactory factory;

    public void OnMouseDown()
    {
        this.models.Score++;
        factory.Recycle(renderer);
    }

    public void Inject(FrisbeeRenderer renderer, FrisbeeFactory factory, Models models)
    {
        this.renderer = renderer;
        this.factory = factory;
        this.models = models;
    }
}
