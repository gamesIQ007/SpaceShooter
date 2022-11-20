using UnityEngine;
using UnityEngine.SceneManagement;

namespace SpaceShooter
{
    /// <summary>
    /// ����������� ���� �����
    /// </summary>
    public class PauseMenuPanel : MonoBehaviour
    {
        private void Start()
        {
            gameObject.SetActive(false);
        }

        /// <summary>
        /// ������� �� ������ �����
        /// </summary>
        public void OnButtonShowPause()
        {
            Time.timeScale = 0;

            gameObject.SetActive(true);
        }

        /// <summary>
        /// ������� �� ������ "����������"
        /// </summary>
        public void OnButtonContinue()
        {
            gameObject.SetActive(false);

            Time.timeScale = 1;
        }

        /// <summary>
        /// ������� �� ������ "������� ����"
        /// </summary>
        public void OnButtonMainMenu()
        {
            Time.timeScale = 1;

            SceneManager.LoadScene(LevelSequenceController.MainMenuSceneNickname);
        }
    }
}