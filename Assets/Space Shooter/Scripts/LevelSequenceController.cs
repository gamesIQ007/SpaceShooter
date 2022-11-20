using UnityEngine;
using UnityEngine.SceneManagement;

namespace SpaceShooter
{
    /// <summary>
    /// Контроллер последовательности уровней
    /// </summary>
    public class LevelSequenceController : SingletonBase<LevelSequenceController>
    {
        /// <summary>
        /// Имя сцены с главным меню
        /// </summary>
        public static string MainMenuSceneNickname = "main_menu";

        /// <summary>
        /// Текущий эпизод
        /// </summary>
        public Episode CurrentEpisode { get; private set; }

        /// <summary>
        /// Текущий уровень
        /// </summary>
        public int CurrentLevel { get; private set; }

        /// <summary>
        /// Запуск эпизода
        /// </summary>
        /// <param name="episode">Эпизод</param>
        public void StartEpisode(Episode episode)
        {
            CurrentEpisode = episode;
            CurrentLevel = 0;

            // туть сбросить игрповую статистику перед началом

            SceneManager.LoadScene(episode.Levels[CurrentLevel]);
        }

        /// <summary>
        /// Перезапуск уровня
        /// </summary>
        public void RestartLevel()
        {
            SceneManager.LoadScene(CurrentEpisode.Levels[CurrentLevel]);
        }

        /// <summary>
        /// Завершение текущего уровня
        /// </summary>
        /// <param name="success"></param>
        public void FinishCurrentLevel(bool success)
        {

        }

        /// <summary>
        /// Переход к следующему уровню
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