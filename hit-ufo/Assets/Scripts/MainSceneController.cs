using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneController {
    private FrisbeeFactory frisbeeFactory;
    private UIFrameRenderer uiFrame;
    private Models models;
    private Configs configs;
    private ResourceMgr resources;
    private FrisbeeRenderer[] frisbees;
    private System.Random randGen;

	public MainSceneController()
    {
        this.configs = new Configs();
        this.models = new Models();
        this.resources = new ResourceMgr(this.configs);
        this.uiFrame = new UIFrameRenderer(this.configs, this.models, this.resources);
        this.frisbeeFactory = new FrisbeeFactory(this.configs, this.models, this.resources);
        this.randGen = new System.Random();
    }

    public void OnGameFrame()
    {
        if (this.models.Status == GameStatus.OnTrial)
        {
            if (this.frisbees == null)
            {
                this.frisbees = new FrisbeeRenderer[this.models.Trial * models.Round];
                for (int i = 0; i < this.models.Trial * models.Round; i++)
                {
                    this.frisbees[i] = this.frisbeeFactory.Produce();
                    float fromZ = (float)(randGen.Next() % 100) / 10f + 3;
                    float fromX = (randGen.Next() % 3 - 1) * fromZ * 2;
                    float fromY = (randGen.Next() % 3 - 1) * fromZ;
                    float mag = Mathf.Sqrt(fromX * fromX + fromY * fromY + fromZ * fromZ);
                    this.frisbees[i].MoveTo(new Vector3(fromX, fromY, fromZ));
                    float vcoe = 3 + this.models.Round;
                    Vector3 velocity = new Vector3(-fromX/mag*vcoe, -fromY/mag*vcoe, 0);
                    this.frisbees[i].Move = new FrisbeeMove(velocity);
                }
            } else
            {
                for (int i = 0; i < this.frisbees.Length; i++)
                {
                    this.frisbees[i].Render();
                }
            }
        }
        if (this.models.Status != GameStatus.OnTrial && this.frisbees != null)
        {
            for (int i = 0; i < this.frisbees.Length; i++)
            {
                this.frisbeeFactory.Recycle(this.frisbees[i]);
            }
            this.frisbees = null;
        }
    }
}
