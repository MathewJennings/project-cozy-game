using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlantReceivable
{
    public bool HasPlant();
    public void ReceivePlant(GameObject plant);
}
