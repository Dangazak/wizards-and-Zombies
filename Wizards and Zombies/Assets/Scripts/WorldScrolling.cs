using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldScrolling : MonoBehaviour
{
    int playerPosX;
    int playerPosY;
    [SerializeField] float tileSize;
    [SerializeField] int gridW;
    [SerializeField] int gridH;
    [SerializeField] GameObject[] tiles = new GameObject[9];
    [SerializeField] GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        playerPosX = 0;
        playerPosY = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x > (tileSize / 2) + playerPosX * tileSize)
        {
            MoveTilesRight();
        }
        else if (player.transform.position.x < -(tileSize / 2) + playerPosX * tileSize)
        {
            MoveTilesLeft();
        }

        if (player.transform.position.y > (tileSize / 2) + playerPosY * tileSize)
        {
            MoveTilesDown();
        }
        else if (player.transform.position.y < -(tileSize / 2) + playerPosY * tileSize)
        {
            MoveTilesUp();
        }
    }
    void MoveTilesRight()
    {
        playerPosX++;

        Vector3 movementVector = new Vector3(tileSize * gridW, 0, 0);
        tiles[0].transform.Translate(movementVector);
        tiles[3].transform.Translate(movementVector);
        tiles[6].transform.Translate(movementVector);

        GameObject[] newTiles = new GameObject[tiles.Length];
        for (int i = 0; i < tiles.Length; i++)
        {
            if (i != 0)
            {
                newTiles[i - 1] = tiles[i];
            }
        }

        newTiles[2] = tiles[0];
        newTiles[5] = tiles[3];
        newTiles[8] = tiles[6];

        tiles = newTiles;
    }
    void MoveTilesLeft()
    {
        playerPosX--;
        Vector3 movementVector = new Vector3(-tileSize * gridW, 0, 0);
        tiles[2].transform.Translate(movementVector);
        tiles[5].transform.Translate(movementVector);
        tiles[8].transform.Translate(movementVector);

        GameObject[] newTiles = new GameObject[tiles.Length];
        for (int i = 0; i < tiles.Length; i++)
        {
            if (i != 0)
            {
                newTiles[i] = tiles[i - 1];
            }
        }

        newTiles[0] = tiles[2];
        newTiles[3] = tiles[5];
        newTiles[6] = tiles[8];

        tiles = newTiles;
    }
    void MoveTilesDown()
    {
        playerPosY++;
        Vector3 movementVector = new Vector3(0, tileSize * gridH, 0);
        tiles[0].transform.Translate(movementVector);
        tiles[1].transform.Translate(movementVector);
        tiles[2].transform.Translate(movementVector);

        GameObject[] newTiles = new GameObject[tiles.Length];
        for (int i = 0; i < tiles.Length; i++)
        {
            if (i >= gridH)
            {
                newTiles[i - gridH] = tiles[i];
            }
        }

        newTiles[6] = tiles[0];
        newTiles[7] = tiles[1];
        newTiles[8] = tiles[2];

        tiles = newTiles;
    }
    void MoveTilesUp()
    {
        playerPosY--;
        Vector3 movementVector = new Vector3(0, -tileSize * gridH, 0);
        tiles[6].transform.Translate(movementVector);
        tiles[7].transform.Translate(movementVector);
        tiles[8].transform.Translate(movementVector);

        GameObject[] newTiles = new GameObject[tiles.Length];
        for (int i = 0; i < tiles.Length; i++)
        {
            if (i >= gridH)
            {
                newTiles[i] = tiles[i - gridH];
            }
        }

        newTiles[0] = tiles[6];
        newTiles[1] = tiles[7];
        newTiles[2] = tiles[8];

        tiles = newTiles;
    }
}
