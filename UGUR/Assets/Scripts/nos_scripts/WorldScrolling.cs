    using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldScrolling : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    private Vector3Int currentTilePosition = new Vector3Int(0, 0,0);
    [SerializeField] private Vector3Int playerTilePosition;
    private Vector3Int onTileGridPlayerPosition;
    [SerializeField] private float tileSize = 20f;
    private GameObject[,] terrainTiles;

    [SerializeField] private int terrainTileHorizontalCount =3;
    [SerializeField] private int terrainTileVerticalCount=3;

    [SerializeField] private int fieldOfVisionHeight = 3;
    [SerializeField] private int fieldOfVisonWidth = 3;

    private void Awake()
    {
        terrainTiles = new GameObject[terrainTileHorizontalCount,terrainTileVerticalCount];
    }
    

    private void Update()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
        UpdateTilesOnScreen();
        playerTilePosition.x = (int)(playerTransform.position.x / tileSize);
        playerTilePosition.z = (int)(playerTransform.position.z / tileSize);

        playerTilePosition.x -= playerTransform.position.x < 0 ? 1 : 0;
        playerTilePosition.z -= playerTransform.position.z < 0 ? 1 : 0;
        
        if (currentTilePosition != playerTilePosition)
        {
            currentTilePosition = playerTilePosition;

            onTileGridPlayerPosition.x -= CalculatePositionOnAxis(onTileGridPlayerPosition.x, true);
            onTileGridPlayerPosition.z -= CalculatePositionOnAxis(onTileGridPlayerPosition.z, false);
            UpdateTilesOnScreen();
        }
    }

    private void UpdateTilesOnScreen()
    {
        for (int povx = -(fieldOfVisonWidth / 2); povx <= fieldOfVisonWidth / 2; povx++)
        {
            for (int povz = -(fieldOfVisionHeight / 2); povz <= fieldOfVisionHeight / 2; povz++)
            {
                int tileToUpdate_x = CalculatePositionOnAxis(playerTilePosition.x + povx, true);
                int tileToUpdate_z = CalculatePositionOnAxis(playerTilePosition.z + povz, false);
                GameObject tile = terrainTiles[tileToUpdate_x, tileToUpdate_z];
                tile.transform.position =
                    CalculatePosition(playerTilePosition.x + povx, playerTilePosition.z + povz);
            }
        }
    }

    private Vector3 CalculatePosition(int x, int z)
    {
        return new Vector3(x * tileSize, 0, z * tileSize);
    }

    private int CalculatePositionOnAxis(float currentValue, bool horizontal)
    {
        if (horizontal)
        {
            if (currentValue >= 0)
            {
                currentValue = currentValue % terrainTileHorizontalCount;
            }
            else
            {
                currentValue += 1;
                currentValue = terrainTileHorizontalCount - 1 + currentValue % terrainTileHorizontalCount;
            }
        }
        else
        {
            if (currentValue >= 0)
            {
                currentValue = currentValue % terrainTileVerticalCount;
            }
            else
            {
                currentValue += 1;
                currentValue = terrainTileVerticalCount - 1 + currentValue % terrainTileVerticalCount;
            }
        }

        return (int)currentValue;
    }

    public void Add(GameObject tileGameObject, Vector2Int tilePosition)
    {
        terrainTiles[tilePosition.x, tilePosition.y] = tileGameObject;
    }
}

