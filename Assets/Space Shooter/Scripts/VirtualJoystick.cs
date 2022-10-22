using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace SpaceShooter
{
    /// <summary>
    /// Класс виртуального джойстика
    /// </summary>
    public class VirtualJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
    {
        /// <summary>
        /// Фон джойстика
        /// </summary>
        [SerializeField] private Image m_JoyBack;

        /// <summary>
        /// Стик джойстика
        /// </summary>
        [SerializeField] private Image m_Joystick;

        /// <summary>
        /// Значение джойстика
        /// </summary>
        public Vector3 Value { get; private set; }

        /// <summary>
        /// Реализация интерфейса IDragHandler. Обработка касания экрана
        /// </summary>
        /// <param name="eventData"></param>
        public void OnDrag(PointerEventData eventData)
        {
            Vector2 position = Vector2.zero;

            // Получаем позицию относительно фона джойстика, а не экрана
            RectTransformUtility.ScreenPointToLocalPointInRectangle(m_JoyBack.rectTransform, eventData.position, eventData.pressEventCamera, out position);

            // Нормализуем позицию, чтобы она была в пределах от 0 до 1
            position.x = position.x / m_JoyBack.rectTransform.sizeDelta.x;
            position.y = position.y / m_JoyBack.rectTransform.sizeDelta.y;

            // Правим позицию, чтобы она была от -1 до 1
            position.x = position.x * 2 - 1;
            position.y = position.y * 2 - 1;

            // Задаём вектор джойстика и нормализуем его
            Value = new Vector3(position.x, position.y, 0);
            if (Value.magnitude > 1)
            {
                Value = Value.normalized;
            }

            // Задаём максимальное отклонение стика от центра
            float offsetX = m_JoyBack.rectTransform.sizeDelta.x / 2 - m_Joystick.rectTransform.sizeDelta.x / 2;
            float offsetY = m_JoyBack.rectTransform.sizeDelta.y / 2 - m_Joystick.rectTransform.sizeDelta.y / 2;

            // присваиваем позицию стику
            m_Joystick.rectTransform.anchoredPosition = new Vector2(Value.x * offsetX, Value.y * offsetY);
        }

        /// <summary>
        /// Реализация интерфейса IPointerDownHandler. Обработка касания экрана
        /// </summary>
        /// <param name="eventData"></param>
        public void OnPointerDown(PointerEventData eventData)
        {
            OnDrag(eventData);
        }

        /// <summary>
        /// Реализация интерфейса IPointerUpHandler. Обработка нереставания касания экрана
        /// </summary>
        /// <param name="eventData"></param>
        public void OnPointerUp(PointerEventData eventData)
        {
            Value = Vector3.zero;
            m_Joystick.rectTransform.anchoredPosition = Vector3.zero;
        }
    }
}
