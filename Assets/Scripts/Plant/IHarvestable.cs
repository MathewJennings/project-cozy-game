using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHarvestable
{
    public bool IsHarvestable();

    public Crop getCrop();

    /**
     * Returns the harvested GameObject, or null
     */
    public GameObject Harvest();

}
