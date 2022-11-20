using UnityEngine;
using UnityEngine.UI;

namespace SpaceShooter
{
    /// <summary>
    /// ���������� ���� ������ �������
    /// </summary>
    public class PlayerShipSelectionController : MonoBehaviour
    {
        /// <summary>
        /// ������ �������
        /// </summary>
        [SerializeField] private SpaceShip m_Prefab;

        /// <summary>
        /// ��� �������
        /// </summary>
        [SerializeField] private Text m_ShipName;

        /// <summary>
        /// �������� �������
        /// </summary>
        [SerializeField] private Text m_Hitpoints;

        /// <summary>
        /// �������� �������
        /// </summary>
        [SerializeField] private Text m_Speed;

        /// <summary>
        /// ������������ �������� �������
        /// </summary>
        [SerializeField] private Text m_Agility;

        /// <summary>
        /// ����������� �������
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
        /// ����� �������
        /// </summary>
        public void OnShipSelect()
        {
            LevelSequenceController.PlayerShip = m_Prefab;

            gameObject.transform.parent.gameObject.SetActive(false);

            MainMenuController.Instance.gameObject.SetActive(true);
        }
    }
}