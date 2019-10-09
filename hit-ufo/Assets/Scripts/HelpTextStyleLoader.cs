using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpTextStyleLoader: FontStyleLoader
{
    public HelpTextStyleLoader(Configs configs):
        base(configs.HelpFontSize, configs.UIFrameFontColor, TextAnchor.LowerLeft) { }
}
