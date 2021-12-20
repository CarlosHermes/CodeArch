using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.OnScreen;
using UnityEngine.Serialization;

public class OnScreenReplacer : OnScreenControl, IPointerDownHandler, IPointerUpHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData == null)
            throw new System.ArgumentNullException(nameof(eventData));

        RectTransformUtility.ScreenPointToLocalPointInRectangle(transform.GetComponentInParent<RectTransform>(), eventData.position, eventData.pressEventCamera, out m_PointerDownPos);

        m_StickBase.anchoredPosition = m_PointerDownPos;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (eventData == null)
            throw new System.ArgumentNullException(nameof(eventData));

        m_StickBase.anchoredPosition = m_StartPos;
    }
    

    private void Start()
    {
        m_StartPos = m_StickBase.anchoredPosition;
        if (!m_StickBase) m_StickBase = (RectTransform) transform.parent;
    }
    
    public float movementRange { get; set; }
    


    [InputControl(layout = "Vector2")]
    [SerializeField]
    private string m_ControlPath;
        
    private Vector3 m_StartPos;
    private Vector2 m_PointerDownPos;

    [SerializeField] private RectTransform m_StickBase;

    protected override string controlPathInternal
    {
        get => m_ControlPath;
        set => m_ControlPath = value;
    }
}
