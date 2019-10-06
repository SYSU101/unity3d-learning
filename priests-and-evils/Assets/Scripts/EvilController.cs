using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilController : MonoBehaviour {
    private EvilRenderer evilRenderer;
    private MainSceneController globalController;
    private int id;

    public void OnGUI()
    {
        if (this.evilRenderer != null)
        {
            this.evilRenderer.Render();
        }
    }

    public void OnMouseDown()
    {
        if (this.globalController.objectsOnAnimation == 0)
        {
            if (this.globalController.GetState(Characters.CharacterType.Evil, id) != Characters.CharacterState.OnBoat)
            {
                this.globalController.Embark(Characters.CharacterType.Evil, this.id);
            }
            else
            {
                this.globalController.Disembark(Characters.CharacterType.Evil, this.id);
            }
        }

    }

    public void Inject(int id, EvilRenderer evilRenderer, MainSceneController globalController, Configs configs)
    {
        this.id = id;
        this.globalController = globalController;
        this.evilRenderer = evilRenderer;
    }
}
