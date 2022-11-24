using UnityEngine;

namespace SpaceShooter
{
    /// <summary>
    /// Контроллер главного меню
    /// </summary>
    public class MainMenuController : SingletonBase<MainMenuController>
    {
        /// <summary>
        /// Корабль по умолчанию
        /// </summary>
        [SerializeField] private SpaceShip m_DefaultSpaceShip;

        /// <summary>
        /// Выбор эпизода
        /// </summary>
        [SerializeField] private GameObject m_EpisodeSelection;

        /// <summary>
        /// Выбор корабля
        /// </summary>
        [SerializeField] private GameObject m_ShipSelection;

        /// <summary>
        /// Общая статистика
        /// </summary>
        [SerializeField] private GameObject m_TotalStatistics;

        private void Start()
        {
            LevelSequenceController.PlayerShip = m_DefaultSpaceShip;
        }

        /// <summary>
        /// При нажатии на "Начать новую игру"
        /// </summary>
        public void OnButtonStartNew()
        {
            m_EpisodeSelection.SetActive(true);
            gameObject.SetActive(false);
        }

        /// <summary>
        /// При нажатии на "Выбор корабля"
        /// </summary>
        public void OnButtonSelectSpaceShip()
        {
            m_ShipSelection.SetActive(true);
            gameObject.SetActive(false);
        }

        /// <summary>
        /// При нажатии на "Общая статистика"
        /// </summary>
        public void OnButtonTotalStatistics()
        {
            m_TotalStatistics.SetActive(true);
            gameObject.SetActive(false);
        }

        /// <summary>
        /// При нажатии на кнопку "Выход"
        /// </summary>
        public void OnButtonExit()
        {
            Application.Quit();
        }
    }
}