using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Configs
{
    // Resouce paths
    public string LoadingBgTilePath { get; private set; } = "Images/LoadingBgTile";
    public string FrisbeePrefabPath { get; private set; } = "Prefabs/Frisbee";
    // Font sizes
    public int MainTitleFontSize { get; private set; } = 40;
    public int BodyFontSize { get; private set; } = 20;
    public int HelpFontSize { get; private set; } = 14;
    // Colors
    public Color UIFrameFontColor = new Color(1, 1, 1);
    public Color LoadingBgColor = new Color(0.1f, 0.1f, 0.1f);
    // Strings
    public string GameTitleString { get; private set; } = "<b>Hit UFOs</b>";
    public string GameStartString { get; private set; } = "<b>Let's Rock</b>";
    public string RoundLoadingString { get; private set; } = "<b>Round</b>";
    public string TrialLoadingString { get; private set; } = "<b>Trial</b>";
    public string ScoreString { get; private set; } = "<b>Score:</b>";
    // Paddings and margins
    public float LoadingPadding { get; private set; } = 120;
    public float LoadingMargin { get; private set; } = 60;
    public float NormalUIPadding { get; private set; } = 20;
    // Others
    public float StartButtonWidth { get; private set; } = 200;
    public float StartButtonHeight { get; private set; } = 50;
    public int MaxRound { get; private set; } = 5;
    public Vector3 DefaultFrisbeePos { get; private set; } = new Vector3(0, 0, -10);
}
