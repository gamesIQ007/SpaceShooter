using UnityEngine;
using UnityEngine.SceneManagement;

namespace SpaceShooter
{
    /// <summary>
    /// ���������� ������������������ �������
    /// </summary>
    public class LevelSequenceController : SingletonBase<LevelSequenceController>
    {
        /// <summary>
        /// ��� ����� � ������� ����
        /// </summary>
        public static string MainMenuSceneNickname = "main_menu";

        /// <summary>
        /// ������� ������
        /// </summary>
        public Episode CurrentEpisode { get; private set; }

        /// <summary>
        /// ������� �������
        /// </summary>
        public int CurrentLevel { get; private set; }

        /// <summary>
        /// ������ �������
        /// </summary>
        /// <param name="episode">������</param>
        public void StartEpisode(Episode episode)
        {
            CurrentEpisode = episode;
            CurrentLevel = 0;

            // ���� �������� �������� ���������� ����� �������

            SceneManager.LoadScene(episode.Levels[CurrentLevel]);
        }

        /// <summary>
        /// ���������� ������
        /// </summary>
        public void RestartLevel()
        {
            SceneManager.LoadScene(CurrentEpisode.Levels[CurrentLevel]);
        }

        /// <summary>
        /// ���������� �������� ������
        /// </summary>
        /// <param name="success"></param>
        public void FinishCurrentLevel(bool success)
        {

        }

        /// <summary>
        /// ������� � ���������� ������
        /// </summary>
        public void AdvanceLevel()
        {
            CurrentLevel++;

            if (CurrentEpisode.Levels.Length <= CurrentLevel)
            {
                SceneManager.LoadScene(MainMenuSceneNickname);
            }
            else
            {
                SceneManager.LoadScene(CurrentEpisode.Levels[CurrentLevel]);
            }
        }
    }
}