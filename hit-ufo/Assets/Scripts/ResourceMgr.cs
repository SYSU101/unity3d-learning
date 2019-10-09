using System.Collections.Generic;
using UnityEngine;

public class ResourceMgr
{
    public Texture2D LoadingBgTile { get; private set; }
    public GUIStyle LoadingTitleStyle { get; private set; }
    public GUIStyle GUIHelpTextStyle { get; private set; }
    public GUISkin skin { get; private set; }
    public GameObject frisbeePrefab { get; private set; }

    public ResourceMgr(Configs configs)
    {
        this.LoadingBgTile = Resources.Load<Texture2D>(configs.LoadingBgTilePath);
        this.frisbeePrefab = Resources.Load<GameObject>(configs.FrisbeePrefabPath);
        this.LoadingTitleStyle = new LoadingTitleStyleLoader(configs).Load();
        this.GUIHelpTextStyle = new HelpTextStyleLoader(configs).Load();
        this.LoadGUISkin(configs);
    }

    public void LoadGUISkin(Configs configs)
    {
        this.skin = ScriptableObject.CreateInstance<GUISkin>();
        this.skin.button.normal.background = Texture2D.blackTexture;
        this.skin.button.normal.textColor = configs.UIFrameFontColor;
        this.skin.button.hover.background = Texture2D.whiteTexture;
        this.skin.button.hover.textColor = configs.LoadingBgColor;
        this.skin.button.active = this.skin.button.hover;
        this.skin.button.border = new RectOffset();
        this.skin.button.padding = new RectOffset();
        this.skin.button.fontSize = configs.BodyFontSize;
        this.skin.button.alignment = TextAnchor.MiddleCenter;
    }
}
