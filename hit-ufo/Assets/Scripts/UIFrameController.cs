using System;
using System.Collections.Generic;
using UnityEngine;

public class UIFrameController : MonoBehaviour
{
    private Models models;
    private new UIFrameRenderer renderer;
    private bool finished = false;
    private Configs configs;
    private Queue<CheckTimer> workTimers;

    public void Start()
    {
        this.workTimers = new Queue<CheckTimer>();
    }

    public void OnGUI ()
    {
        if (this.finished)
        {
            switch (models.Status)
            {
                case (GameStatus.OnGameLoading):
                    this.renderer.ShowLoadingScreen();
                    break;
                case (GameStatus.OnRoundLoading):
                    this.renderer.ShowRoundLoading(this.models.Round);
                    break;
                case (GameStatus.OnTrialLoading):
                    this.renderer.ShowTrialLoading(this.models.Trial);
                    break;
                case (GameStatus.OnTrial):
                    this.renderer.ShowScore(this.models.Score);
                    break;
            }
        }
        if (this.workTimers.Count > 0)
        {
            if (!this.workTimers.Peek().Check())
            {
                this.workTimers.Dequeue();
            }
        }
	}

    public void Inject(UIFrameRenderer renderer, Configs configs, Models models)
    {
        this.models = models;
        this.renderer = renderer;
        this.finished = true;
        this.configs = configs;
    }

    public void LoadRound()
    {
        this.models.Status = GameStatus.OnRoundLoading;
        this.workTimers.Enqueue(CheckTimer.SetTimeout(1000, this.LoadTrial));
    }

    public void LoadTrial()
    {
        this.models.Status = GameStatus.OnTrialLoading;
        this.workTimers.Enqueue(CheckTimer.SetTimeout(1000, this.StartTrial));
    }

    public void StartTrial()
    {
        this.models.Status = GameStatus.OnTrial;
        this.workTimers.Enqueue(CheckTimer.SetTimeout(6000, this.NextTrial));
    }

    public void NextTrial()
    {
        this.models.Trial++;
        if (this.models.Trial > 10)
        {
            this.models.Trial = 1;
            this.models.Round++;
            this.LoadRound();
        } else if(this.models.Round > this.configs.MaxRound)
        {
            this.models.Status = GameStatus.OnFinished;
        } else
        {
            this.LoadTrial();
        }
        
    }
}
