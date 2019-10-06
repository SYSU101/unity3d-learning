using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatController : MonoBehaviour
{
    private BoatRenderer boatRenderer;
    private MainSceneController globalController;
	
	public void OnGUI()
    {
		if (this.boatRenderer != null)
        {
            this.boatRenderer.Render();
        }
	}

    public void OnMouseDown()
    {
        if (this.globalController.objectsOnAnimation == 0)
        {
            this.globalController.SetSail();
        }
    }

    public void Inject(BoatRenderer boatRenderer, MainSceneController globalController)
    {
        this.boatRenderer = boatRenderer;
        this.globalController = globalController;
    }
}
