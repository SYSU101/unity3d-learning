using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMoveStrategy
{
    void BindTrans(Transform binded);
    void Calculate();
}
