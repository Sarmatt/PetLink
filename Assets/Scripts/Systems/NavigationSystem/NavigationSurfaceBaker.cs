using System.Collections.Generic;
using Meta.XR.BuildingBlocks;
using Sirenix.OdinInspector;
using Unity.AI.Navigation;
using UnityEngine;

namespace Systems.NavigationSystem
{
    public class NavigationSurfaceBaker : MonoBehaviour
    {
        [Title("Attached Components")] [SerializeField]
        private RoomMeshEvent _roomMeshEvent;

        [Title("Main Values")] [SerializeField]
        private List<NavMeshSurface> _targetSurfaces;

        private void Start()
            => _roomMeshEvent.OnRoomMeshLoadCompleted.AddListener(Bake);

        private void Bake(MeshFilter mesh)
        {
            foreach (var surface in _targetSurfaces)
                surface.BuildNavMesh();
        }
    }
}