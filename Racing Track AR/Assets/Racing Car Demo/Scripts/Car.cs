using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

namespace Spatialminds.RacingCarsAR
{
    public class Car : MonoBehaviour
    {
        [SerializeField] MeshRenderer m_Renderer;
        [SerializeField] TrailRenderer m_TrailRenderer;
        [SerializeField] Transform m_Car;

        [Header("Path")]
        [SerializeField] private PathCreator path;
        [SerializeField] private bool isDebug;
        [Range(0f, 1f)][SerializeField] private float pathPosition;
        [SerializeField] private Vector3 pathOffset;
        [SerializeField] private float carStartPosition;

        PathDataConverter pathData;

        private void Start()
        {
            pathData = FindObjectOfType<PathDataConverter>();
        }

        public void SetCar(Color col)
        {
            if(m_Renderer != null && m_Renderer.materials[0] != null) m_Renderer.materials[0].color= col;
        }

        private void Update()
        {
            if(isDebug)
            {
                UpdateCarPosition(pathPosition, pathOffset);
            }
        }

        public void UpdateCarPosition(float pathPosition, Vector3 offset)
        {
            if (pathData == null) return;

            if(m_Car!=null) m_Car.localPosition = offset;

            var pathPos = pathData.GetPathPosition(pathPosition, carStartPosition);

            if(path!=null)
            {
                transform.position = path.path.GetPointAtDistance(pathPos);
                transform.rotation = path.path.GetRotationAtDistance(pathPos);
            }
        }
    }
}
