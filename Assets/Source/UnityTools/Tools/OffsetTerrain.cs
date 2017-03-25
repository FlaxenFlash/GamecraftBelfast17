#if UNITY_EDITOR
using System;
using BitStrap;
using UnityEngine;

namespace Assets.Source.Tools
{
    public class OffsetTerrain : MonoBehaviour
    {
        public Terrain Terrain;
        public int Xoffset;
        public int Yoffset;

        [Button]
        public void ApplyOffset()
        {
            var terrainData = Terrain.terrainData;
            var heights = terrainData.GetHeights(0, 0, terrainData.heightmapWidth, terrainData.alphamapHeight);

            var width = heights.GetLength(0);
            var height = heights.GetLength(1);
            var newHeights = new Single[width, height];

            for (int widthIndex = 0; widthIndex < width; widthIndex++)
            {
                var newXIndex = Wrap(widthIndex + Xoffset, width);
                for (int heightIndex = 0; heightIndex < height; heightIndex++)
                {
                    var newYIndex = Wrap(heightIndex + Yoffset,height);
                    newHeights[widthIndex, heightIndex] = heights[newXIndex, newYIndex];
                }
            }

            terrainData.SetHeights(0,0,newHeights);
        }

        private int Wrap(int value, int max)
        {
            if (value >= 0) return value%max;
            return max + value;
        }
    }
}
#endif