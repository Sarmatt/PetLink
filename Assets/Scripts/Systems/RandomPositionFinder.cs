using UnityEngine;
using UnityEngine.AI;

namespace Systems
{
    public static class RandomPositionFinder
    {
        public static bool TryGetNavMeshRandomPoint(Vector3 center, float sampleRadius, int maxAttempts,
            out Vector3 randomPoint)
        {
            randomPoint = Vector3.zero;
            for (int i = 0; i < maxAttempts; i++)
            {
                var randomPos = center + Random.insideUnitSphere * sampleRadius;
                randomPos.y = center.y;

                if (!NavMesh.SamplePosition(randomPos, out NavMeshHit hit, 2f,
                        NavMesh.AllAreas)) return false;
                randomPoint = hit.position;
                return true;
            }
            return false;
        }
    }
}