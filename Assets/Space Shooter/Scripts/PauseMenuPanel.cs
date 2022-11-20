using UnityEngine;
using UnityEngine.SceneManagement;

namespace SpaceShooter
{
    /// <summary>
    /// Отображение меню паузы
    /// </summary>
    public class PauseMenuPanel : MonoBehaviour
    {
        private void Start()
        {
            gameObject.SetActive(false);
        }

        /// <summary>
        /// Нажатие на кнопку паузы
        /// </summary>
        public void OnButtonShowPause()
        {
            Time.timeScale = 0;

            gameObject.SetActive(true);
        }

        /// <summary>
        /// Нажатие на кнопку "Продолжить"
        /// </summary>
        public void OnButtonContinue()
        {
            gameObject.SetActive(false);

            Time.timeScale = 1;
        }

        /// <summary>
        /// Нажатие на кнопку "Главное меню"
        /// </summary>
        public void OnButtonMainMenu()
        {
            Time.timeScale = 1;

            SceneManager.LoadScene(LevelSequenceController.MainMenuSceneNickname);
        }
    }
}