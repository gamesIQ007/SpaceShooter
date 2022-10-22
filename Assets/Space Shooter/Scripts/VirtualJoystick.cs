using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace SpaceShooter
{
    /// <summary>
    /// ����� ������������ ���������
    /// </summary>
    public class VirtualJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
    {
        /// <summary>
        /// ��� ���������
        /// </summary>
        [SerializeField] private Image m_JoyBack;

        /// <summary>
        /// ���� ���������
        /// </summary>
        [SerializeField] private Image m_Joystick;

        /// <summary>
        /// �������� ���������
        /// </summary>
        public Vector3 Value { get; private set; }

        /// <summary>
        /// ���������� ���������� IDragHandler. ��������� ������� ������
        /// </summary>
        /// <param name="eventData"></param>
        public void OnDrag(PointerEventData eventData)
        {
            Vector2 position = Vector2.zero;

            // �������� ������� ������������ ���� ���������, � �� ������
            RectTransformUtility.ScreenPointToLocalPointInRectangle(m_JoyBack.rectTransform, eventData.position, eventData.pressEventCamera, out position);

            // ����������� �������, ����� ��� ���� � �������� �� 0 �� 1
            position.x = position.x / m_JoyBack.rectTransform.sizeDelta.x;
            position.y = position.y / m_JoyBack.rectTransform.sizeDelta.y;

            // ������ �������, ����� ��� ���� �� -1 �� 1
            position.x = position.x * 2 - 1;
            position.y = position.y * 2 - 1;

            // ����� ������ ��������� � ����������� ���
            Value = new Vector3(position.x, position.y, 0);
            if (Value.magnitude > 1)
            {
                Value = Value.normalized;
            }

            // ����� ������������ ���������� ����� �� ������
            float offsetX = m_JoyBack.rectTransform.sizeDelta.x / 2 - m_Joystick.rectTransform.sizeDelta.x / 2;
            float offsetY = m_JoyBack.rectTransform.sizeDelta.y / 2 - m_Joystick.rectTransform.sizeDelta.y / 2;

            // ����������� ������� �����
            m_Joystick.rectTransform.anchoredPosition = new Vector2(Value.x * offsetX, Value.y * offsetY);
        }

        /// <summary>
        /// ���������� ���������� IPointerDownHandler. ��������� ������� ������
        /// </summary>
        /// <param name="eventData"></param>
        public void OnPointerDown(PointerEventData eventData)
        {
            OnDrag(eventData);
        }

        /// <summary>
        /// ���������� ���������� IPointerUpHandler. ��������� ������������ ������� ������
        /// </summary>
        /// <param name="eventData"></param>
        public void OnPointerUp(PointerEventData eventData)
        {
            Value = Vector3.zero;
            m_Joystick.rectTransform.anchoredPosition = Vector3.zero;
        }
    }
}
