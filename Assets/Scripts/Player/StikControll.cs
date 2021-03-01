using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class StikControll : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    private Image JoystikBg;
    private Image JoystikStik;
    private Vector2 VectorInput;

    private void Start()
    {
        JoystikBg = GetComponent<Image>();
        JoystikStik = transform.GetChild(0).GetComponent<Image>();
    }

    public virtual void OnPointerDown(PointerEventData ped)
    {
        OnDrag(ped);
    }

    public virtual void OnPointerUp(PointerEventData ped)
    {
        VectorInput = Vector2.zero;
        JoystikStik.rectTransform.anchoredPosition = Vector2.zero;
    }

    public virtual void OnDrag(PointerEventData ped)
    {
        Vector2 pos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(JoystikBg.rectTransform, ped.position, ped.pressEventCamera, out pos))
        {
            pos.x = (pos.x / JoystikBg.rectTransform.sizeDelta.x);
            pos.y = (pos.y / JoystikBg.rectTransform.sizeDelta.y);

            VectorInput = new Vector2(pos.x * 2, pos.y * 2);
            VectorInput = (VectorInput.magnitude > 1.0f) ? VectorInput.normalized : VectorInput;

            JoystikStik.rectTransform.anchoredPosition = new Vector2(VectorInput.x * (JoystikBg.rectTransform.sizeDelta.x / 2), VectorInput.y * (JoystikBg.rectTransform.sizeDelta.y / 2));
        }
    }

    public float Horizontal()
    {
        if (VectorInput.x != 0) { return VectorInput.x; }
        else return Input.GetAxis("Horizontal");
    }

    public float Vertical()
    {
        if (VectorInput.y != 0) return VectorInput.y;
        else return Input.GetAxis("Vertical");
    }
}
