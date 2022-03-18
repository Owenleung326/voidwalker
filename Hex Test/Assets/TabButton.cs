using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Image))]
public class TabButton : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
    public TabController tabController;

    public Image background;

    public void OnPointerClick(PointerEventData eventData)
    {
        tabController.OnTabSelected(this);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        tabController.OnTabEnter(this);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tabController.OnTabExit(this);        
    }

    // Start is called before the first frame update
    void Start()
    {
        background = GetComponent<Image>();
        tabController.Subscibe(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
