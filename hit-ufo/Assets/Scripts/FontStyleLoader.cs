using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FontStyleLoader {
    protected int fontSize;
    protected TextAnchor anchor;
    protected Color color;

    public FontStyleLoader(int fontSize, Color color, TextAnchor anchor)
    {
        this.fontSize = fontSize;
        this.color = color;
        this.anchor = anchor;
    }
	
    public GUIStyle Load()
    {
        GUIStyle style = new GUIStyle();
        style.alignment = this.anchor;
        style.fontSize = this.fontSize;
        style.normal.textColor = this.color;
        return style;
    }
}
