using UnityEngine;

namespace SpaceShooter
{
    /// <summary>
    /// Астероид, наследованный от дестрактибл
    /// </summary>
    public class Asteroid : Destructible
    {
        /// <summary>
        /// Перечень размеров
        /// </summary>
        public enum Size
        {
            Small,
            Normal,
            Big,
            Huge
        }

        /// <summary>
        /// Размер
        /// </summary>
        [SerializeField] private Size m_Size;

        /// <summary>
        /// Скорость движения
        /// </summary>
        [SerializeField] private float m_Speed;

        /// <summary>
        /// Масштаб разных размеров
        /// </summary>
        [Header("Scale")]
        [SerializeField] private float m_Huge;
        [SerializeField] private float m_Big;
        [SerializeField] private float m_Normal;
        [SerializeField] private float m_Small;

        #region Unity Events

        private void Awake()
        {
            SetSize(m_Size);

            m_EventOnDeath.AddListener(OnAsteroidDestroyed);
        }

        private void OnDestroy()
        {
            m_EventOnDeath.RemoveListener(OnAsteroidDestroyed);
        }

        #endregion

        #region Public API

        /// <summary>
        /// Установить размер
        /// </summary>
        /// <param name="size">Размер</param>
        public void SetSize(Size size)
        {
            if (size < 0) return;

            transform.localScale = GetVectorFromSize(size);
            m_Size = size;
        }

        #endregion

        /// <summary>
        /// Действие при уничтожении астероида
        /// </summary>
        private void OnAsteroidDestroyed()
        {
            if (m_Size != Size.Small)
            {
                SpawnAsteroids();
            }

            Destroy(gameObject);
        }

        private void SpawnAsteroids()
        {
            for (int i = 0; i < 2; i++)
            {
                Asteroid asteroid = Instantiate(this, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                asteroid.SetSize(m_Size - 1);
                asteroid.m_HitPoints = Mathf.Clamp(m_HitPoints / 2, 1, m_HitPoints); // половина от максимального хп, не меньше 1, не больше макс хп
                asteroid.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-m_Speed, m_Speed), Random.Range(-m_Speed, m_Speed)).normalized, ForceMode2D.Impulse);
                // костыль - после смерти почемут отключается
                asteroid.enabled = true;
                asteroid.GetComponentInChildren<CircleCollider2D>().enabled = true;
            }
        }

        /// <summary>
        /// Устанавливает масштабирование в соответствии с размером
        /// </summary>
        /// <param name="size">Размер</param>
        /// <returns>Масштаб</returns>
        private Vector3 GetVectorFromSize(Size size)
        {
            if (size == Size.Huge) return new Vector3(m_Huge, m_Huge, m_Huge);
            if (size == Size.Big) return new Vector3(m_Big, m_Big, m_Big);
            if (size == Size.Normal) return new Vector3(m_Normal, m_Normal, m_Normal);
            if (size == Size.Small) return new Vector3(m_Small, m_Small, m_Small);

            return new Vector3(m_Huge, m_Huge, m_Huge);
        }
    }
}