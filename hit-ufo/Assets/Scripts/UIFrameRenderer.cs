using UnityEngine;

public class UIFrameRenderer
{
    private UIFrameController localController;
    private ResourceMgr resources;
    private Configs configs;

    public UIFrameRenderer(Configs configs, Models models, ResourceMgr resources)
    {
        this.localController = Component.FindObjectOfType<UIFrameController>();
        this.localController.Inject(this, configs, models);
        this.resources = resources;
        this.configs = configs;
    }

    public void ShowLoadingScreen()
    {
        GUI.skin = this.resources.skin;
        GUI.DrawTexture(
            new Rect(0, 0, Screen.width, Screen.height),
            this.resources.LoadingBgTile
        );
        Rect labelRect = new Rect(
            this.configs.LoadingPadding,
            this.configs.LoadingPadding,
            Screen.width-2*this.configs.LoadingPadding,
            this.configs.MainTitleFontSize
        );
        GUI.Label(
            labelRect,
            this.configs.GameTitleString,
            this.resources.LoadingTitleStyle
        );
        Rect startButtonRect = new Rect(
            (Screen.width - this.configs.StartButtonWidth) / 2,
            labelRect.yMax + this.configs.LoadingMargin,
            this.configs.StartButtonWidth,
            this.configs.StartButtonHeight
        );
        if (GUI.Button(startButtonRect, this.configs.GameStartString))
        {
            this.localController.LoadRound();
        }
    }

    public void ShowRoundLoading(int round)
    {
        GUI.DrawTexture(
            new Rect(0, 0, Screen.width, Screen.height),
            this.resources.LoadingBgTile
        );
        Rect labelRect = new Rect(
            this.configs.LoadingPadding,
            this.configs.LoadingPadding,
            Screen.width - 2 * this.configs.LoadingPadding,
            this.configs.MainTitleFontSize
        );
        GUI.Label(
            labelRect,
            this.configs.RoundLoadingString + " " + round.ToString(),
            this.resources.LoadingTitleStyle
        );
    }
    public void ShowTrialLoading(int trial)
    {
        GUI.DrawTexture(
            new Rect(0, 0, Screen.width, Screen.height),
            this.resources.LoadingBgTile
        );
        Rect labelRect = new Rect(
            this.configs.LoadingPadding,
            this.configs.LoadingPadding,
            Screen.width - 2 * this.configs.LoadingPadding,
            this.configs.MainTitleFontSize
        );
        GUI.Label(
            labelRect,
            this.configs.TrialLoadingString + " " + trial.ToString(),
            this.resources.LoadingTitleStyle
        );
    }

    public void ShowScore(int score)
    {
        Rect labelRect = new Rect(
            this.configs.NormalUIPadding,
            this.configs.NormalUIPadding,
            Screen.width - 2 * this.configs.NormalUIPadding,
            this.configs.HelpFontSize
        );
        GUI.Label(
            labelRect,
            this.configs.ScoreString + " " + score.ToString(),
            this.resources.GUIHelpTextStyle
        );
    }
}
