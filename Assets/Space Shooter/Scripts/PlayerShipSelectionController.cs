using UnityEngine;
using UnityEngine.UI;

namespace SpaceShooter
{
    /// <summary>
    /// Контроллер окна выбора корабля
    /// </summary>
    public class PlayerShipSelectionController : MonoBehaviour
    {
        /// <summary>
        /// Префаб корабля
        /// </summary>
        [SerializeField] private SpaceShip m_Prefab;

        /// <summary>
        /// Имя корабля
        /// </summary>
        [SerializeField] private Text m_ShipName;

        /// <summary>
        /// Здоровье корабля
        /// </summary>
        [SerializeField] private Text m_Hitpoints;

        /// <summary>
        /// Скорость корабля
        /// </summary>
        [SerializeField] private Text m_Speed;

        /// <summary>
        /// Вращательная скорость корабля
        /// </summary>
        [SerializeField] private Text m_Agility;

        /// <summary>
        /// Изображение корабля
        /// </summary>
        [SerializeField] private Image m_Preview;

        private void Start()
        {
            if (m_Prefab != null)
            {
                m_ShipName.text = m_Prefab.Nickname;
                m_Hitpoints.text = "Hitpoints: " + m_Prefab.MaxHitPoints.ToString();
                m_Speed.text = "Speed: " + m_Prefab.MaxLinearVelocity.ToString();
                m_Agility.text = "Agility: " + m_Prefab.MaxAngularVelocity.ToString();
                m_Preview.sprite = m_Prefab.PreviewImage;
            }
        }

        /// <summary>
        /// Выбор корабля
        /// </summary>
        public void OnShipSelect()
        {
            LevelSequenceController.PlayerShip = m_Prefab;

            gameObject.transform.parent.gameObject.SetActive(false);

            MainMenuController.Instance.gameObject.SetActive(true);
        }
    }
}