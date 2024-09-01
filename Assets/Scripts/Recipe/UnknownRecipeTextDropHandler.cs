using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UnknownRecipeTextDropHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private List<GameObject> selectedHighlightingObjects;

    private static GameObject hoverTarget;

    public static GameObject GetDropTarget() { return hoverTarget; }

    private void Start()
    {
        selectedHighlightingObjects.ForEach(gameObject => gameObject.SetActive(false));
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        hoverTarget = this.gameObject;
        selectedHighlightingObjects.ForEach(gameObject => gameObject.SetActive(true));
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (hoverTarget == this.gameObject)
        {
            hoverTarget = null;
            selectedHighlightingObjects.ForEach(gameObject => gameObject.SetActive(false));
        }
    }
}
