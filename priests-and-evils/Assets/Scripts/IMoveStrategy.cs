using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMoveStrategy
{
    void SetMove(Vector3 from, Vector3 to);
    Vector3 Position { get; }
    bool OnAnimation { get; }
    void OnStopMove();
    void OnPauseMove();
    void OnResumeMove();
    IMoveStrategy Clone();
}
