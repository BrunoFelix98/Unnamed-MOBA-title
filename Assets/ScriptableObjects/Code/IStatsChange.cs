using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStatsChange
{
    public void AddEffect(PlayerData player);
    public void RemoveEffect(PlayerData player);
}