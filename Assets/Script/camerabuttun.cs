using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class camerabuttun : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler {
    public bool moved = false;
    public void OnPointerEnter(PointerEventData eventData){
        moved = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        moved = false;
    }

}
