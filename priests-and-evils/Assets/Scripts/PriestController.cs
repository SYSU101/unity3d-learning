using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriestController : MonoBehaviour {
    private PriestRenderer priestRenderer;
    private MainSceneController globalController;
    private int id;

    public void OnGUI()
    {
        if (this.priestRenderer != null)
        {
            this.priestRenderer.Render();
        }
    }

    public void OnMouseDown()
    {
        if (this.globalController.objectsOnAnimation == 0)
        {
            if (this.globalController.GetState(Characters.CharacterType.Priest, id) != Characters.CharacterState.OnBoat)
            {
                this.globalController.Embark(Characters.CharacterType.Priest, this.id);
            }
            else
            {
                this.globalController.Disembark(Characters.CharacterType.Priest, this.id);
            }
        }
        
    }

    public void Inject(int id, PriestRenderer priestRenderer, MainSceneController globalController, Configs configs)
    {
        this.id = id;
        this.globalController = globalController;
        this.priestRenderer = priestRenderer;
    }
 }
