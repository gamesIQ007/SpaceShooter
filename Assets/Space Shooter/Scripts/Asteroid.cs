using UnityEngine;

namespace SpaceShooter
{
    /// <summary>
    /// ��������, ������������� �� �����������
    /// </summary>
    public class Asteroid : Destructible
    {
        /// <summary>
        /// �������� ��������
        /// </summary>
        public enum Size
        {
            Small,
            Normal,
            Big,
            Huge
        }

        /// <summary>
        /// ������
        /// </summary>
        [SerializeField] private Size m_Size;

        /// <summary>
        /// �������� ��������
        /// </summary>
        [SerializeField] private float m_Speed;

        /// <summary>
        /// ������� ������ ��������
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
        /// ���������� ������
        /// </summary>
        /// <param name="size">������</param>
        public void SetSize(Size size)
        {
            if (size < 0) return;

            transform.localScale = GetVectorFromSize(size);
            m_Size = size;
        }

        #endregion

        /// <summary>
        /// �������� ��� ����������� ���������
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
                asteroid.m_HitPoints = Mathf.Clamp(m_HitPoints / 2, 1, m_HitPoints); // �������� �� ������������� ��, �� ������ 1, �� ������ ���� ��
                asteroid.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-m_Speed, m_Speed), Random.Range(-m_Speed, m_Speed)).normalized, ForceMode2D.Impulse);
                // ������� - ����� ������ ������� �����������
                asteroid.enabled = true;
                asteroid.GetComponentInChildren<CircleCollider2D>().enabled = true;
            }
        }

        /// <summary>
        /// ������������� ��������������� � ������������ � ��������
        /// </summary>
        /// <param name="size">������</param>
        /// <returns>�������</returns>
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