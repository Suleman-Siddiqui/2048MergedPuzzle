using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InitializerScripts : MonoBehaviour
{
    #region Unity LifeCycle

    // Start is called before the first frame update
    void Start()
    {

        GridBaseTileInitFun();
        SpawnPlayerTile(3);
    }

    // Update is called once per frame
    void Update()
    {
    }

    #endregion
    public int[] GirdTileNumber;
    public Color[] TileColorNumberWise;
    [Header("Grid ITems")]
    public GameObject gridMainParent;
    public GameObject[] gridtilePrefabsObjArry;
    public float gridRowXOffset, gridColorumYOffset;

    [Header("Player Tile ITems")]
    public GameObject NewTileHolderParent;
    public GameObject playerTileObject;
    public Vector3[] playerTileSpawninglocalPosArr;
    public Vector3[] playerTileScaleArry;

    #region INITIALIZER AREA

    #region Grid Init

    void GridBaseTileInitFun()
    {
        //switch (gridIndex)
        //{
        //    case 3:
        //        GenerateGrid(gridtilePrefabsObjArry[0], 3, 3, 1.909f, 1.909f);
        //        break;
        //    case 4:
        //        GenerateGrid(gridtilePrefabsObjArry[1], 4, 4, 1.428f, 1.428f);
        //        break;
        //    case 5:
        //        GenerateGrid(gridtilePrefabsObjArry[2], 5, 5, 1.153f, 1.153f);
        //        break;
        //    case 6:
        //        GenerateGrid(gridtilePrefabsObjArry[3], 6, 6, 0.956f, 0.956f);
        //        break;
        //}

        GenerateGrid(gridtilePrefabsObjArry[0], 5, 5, gridRowXOffset, gridColorumYOffset);
    }

    void GenerateGrid(GameObject TilePlacer, int Pr_numOfRow, int Pr_numOfCol,
                      float xIncrementalValue, float yIncrementalValue)
    {
        int nameconuter = 0;
        float xOffset = 0;
        float YOffset = 0;
        for (int row = 0; row < Pr_numOfRow; row++)
        {
            xOffset = 0;
            for (int col = 0; col < Pr_numOfCol; col++)
            {
                GameObject currentTile = Instantiate(TilePlacer);
                currentTile.transform.SetParent(gridMainParent.transform);
                currentTile.transform.localPosition = new Vector3(currentTile.transform.position.x + xOffset, currentTile.transform.position.y + YOffset, 0);
                currentTile.transform.name = nameconuter.ToString();
                currentTile.GetComponent<SpriteRenderer>().enabled = true;
                xOffset += xIncrementalValue;
                currentTile.GetComponent<GridTileScripts>().FindNeihbourForMe(nameconuter, Pr_numOfRow, Pr_numOfCol);
                nameconuter++;

            }
            YOffset += yIncrementalValue;
        }
    }


    #endregion

    #region Init Player Tiles

     public  void SpawnPlayerTile(int numberOfTileInit)
    {
        for (int i = 0; i < numberOfTileInit; i++)
        {
            GameObject TileObj = Instantiate(playerTileObject) as GameObject;
            TileObj.transform.SetParent(NewTileHolderParent.transform);
            TileObj.transform.localPosition = playerTileSpawninglocalPosArr[TileObj.transform.GetSiblingIndex()];
            int r = Random.Range(0, 4);
            TileObj.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = GirdTileNumber[r].ToString();
            TileObj.GetComponent<SpriteRenderer>().color = TileColorNumberWise[r];
            TileObj.transform.localScale = playerTileScaleArry[TileObj.transform.GetSiblingIndex()];
            TileObj.GetComponent<TileScripts>().TileNumber = GirdTileNumber[r];
        }
    }

    #endregion


    #endregion


    public Color GetTileColorAtNumberWise(int tileNumber)
    {
        switch(tileNumber)
        {
            case 2:
                return TileColorNumberWise[0];
            case 4:
                return TileColorNumberWise[1];
            case 8:
                return TileColorNumberWise[2];
            case 16:
                return TileColorNumberWise[3];
            case 32:
                return TileColorNumberWise[4];
            case 64:
                return TileColorNumberWise[5];
            case 128:
                return TileColorNumberWise[6];
            case 256:
                return TileColorNumberWise[7];
            case 512:
                return TileColorNumberWise[8];
            case 1024:
                return TileColorNumberWise[9];
            case 2048:
                return TileColorNumberWise[10];
        }

        return new Color();
    }
}
