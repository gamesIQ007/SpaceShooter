using UnityEngine;

namespace SpaceShooter
{
    /// <summary>
    /// Контроллер главного меню
    /// </summary>
    public class MainMenuController : MonoBehaviour
    {
        /// <summary>
        /// Выбор эпизода
        /// </summary>
        [SerializeField] private GameObject m_EpisodeSelection;

        /// <summary>
        /// При нажатии на "Начать новую игру"
        /// </summary>
        public void OnButtonStartNew()
        {
            m_EpisodeSelection.SetActive(true);
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