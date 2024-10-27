using UnityEngine;
using UnityEngine.EventSystems;

public class GazeDetection : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{


    void Start()
    {

    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        Destroy(this);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        
    }
}