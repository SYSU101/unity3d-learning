using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingTitleStyleLoader: FontStyleLoader
{
    public LoadingTitleStyleLoader(Configs configs)
        :base(configs.MainTitleFontSize, configs.UIFrameFontColor, TextAnchor.MiddleCenter) { }
}
