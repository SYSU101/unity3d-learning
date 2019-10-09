using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Models
{
    public GameStatus Status { get; set; } = GameStatus.OnGameLoading;
    public int Round { get; set; } = 1;
    public int Trial { get; set; } = 1;
    public int Score { get; set; } = 0;
}
