using UnityEngine;

namespace SpaceShooter
{

    /// <summary>
    /// ����� ��� ���������� �����������
    /// </summary>
    [RequireComponent(typeof(MeshRenderer))]
    public class BackgroundElement : MonoBehaviour
    {
        /// <summary>
        /// ���� ��������� �������
        /// </summary>
        [Range(0.0f, 4.0f)]
        [SerializeField] private float m_ParallaxPower;

        /// <summary>
        /// ��������� ������� ��������
        /// </summary>
        [SerializeField] private float m_TextureScale;

        /// <summary>
        /// ������ �� ��������
        /// </summary>
        private Material m_QuadMaterial;

        /// <summary>
        /// ����������� ��������
        /// </summary>
        private Vector2 m_InitialOffset;

        #region Unity Events

        private void Start()
        {
            m_QuadMaterial = GetComponent<MeshRenderer>().material;
            m_InitialOffset = Random.insideUnitCircle;

            m_QuadMaterial.mainTextureScale = Vector2.one * m_TextureScale;
        }

        private void Update()
        {
            Vector2 offset = m_InitialOffset;

            offset.x += transform.position.x / transform.localScale.x / m_ParallaxPower;
            offset.y += transform.position.y / transform.localScale.y / m_ParallaxPower;

            m_QuadMaterial.mainTextureOffset = offset;
        }

        #endregion
    }
}