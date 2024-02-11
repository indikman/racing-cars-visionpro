using UnityEngine;

namespace Spatialminds.RacingCarsAR
{
    public class PathDataConverter : MonoBehaviour
    {
        [SerializeField] private float startPosition;
        [SerializeField] private float pathSize;
        [SerializeField] private bool flipPathDirection = true;

        public float GetPathPosition(float value, float startOffset)
        {
            if(value <0 && value>1)
            {
                Debug.LogError("Invalid Input");
                return -1;
            }

            return flipPathDirection ? -1 : 1 * (pathSize - startPosition - startOffset) * value;

        }
    }
}
