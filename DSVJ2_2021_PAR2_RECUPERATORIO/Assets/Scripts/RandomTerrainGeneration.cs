using UnityEngine;
using UnityEngine.U2D;
using System.Collections.Generic;

public class RandomTerrainGeneration : MonoBehaviour
{
    [Header("Shape Properties")]
    [SerializeField] GameObject spriteShape;
    [SerializeField] int stretchDistance;
    [SerializeField] int pointAmount;

    [Header("Random Properties")]
    [SerializeField] float minY;
    [SerializeField] float maxY;

    [Header("Landing Properties")]
    [SerializeField] int landingZones;

    private Spline terrainSpline;
    private List<int> landingPoints = new List<int>();

    void Start()
    {
        GameObject terrainSprite = Instantiate(spriteShape);
        terrainSprite.transform.SetParent(transform);

        terrainSpline = terrainSprite.GetComponent<SpriteShapeController>().spline;

        terrainSpline.SetPosition(0, terrainSpline.GetPosition(0) - Vector3.right * stretchDistance);
        terrainSpline.SetPosition(1, terrainSpline.GetPosition(1) - Vector3.right * stretchDistance);

        terrainSpline.SetPosition(2, terrainSpline.GetPosition(2) + Vector3.right * stretchDistance);
        terrainSpline.SetPosition(3, terrainSpline.GetPosition(3) + Vector3.right * stretchDistance);

        float distanceBetweenPoints = (Mathf.Abs(terrainSpline.GetPosition(2).x) + Mathf.Abs(terrainSpline.GetPosition(1).x)) / pointAmount;

        for(short i = 0; i < pointAmount - 1; i++)
        {
            float posX = terrainSpline.GetPosition(i + 1).x + distanceBetweenPoints;
            float posY = terrainSpline.GetPosition(1).y + Random.Range(minY, maxY);
            terrainSpline.InsertPointAt(2 + i, new Vector3(posX, posY));
        }

        SmoothTerrain();
        SelectLandingZones();
    }
    void SmoothTerrain()
    {
        for (int i = 2; i < pointAmount + 1; i++)
        {
            terrainSpline.SetTangentMode(i, ShapeTangentMode.Continuous);
            terrainSpline.SetLeftTangent(i, Vector3.left * 0.5f);
            terrainSpline.SetRightTangent(i, Vector3.right * 0.5f);
        }
    }
    void SelectLandingZones()
    {
        for(int i = 0; i < landingZones; i++)
        {
            int randomPos;
            do
            {
                randomPos = Random.Range(4, pointAmount - 2);
            } while (landingPoints.Contains(randomPos));            

            landingPoints.Add(randomPos);
            landingPoints.Add(randomPos + 1);
            landingPoints.Add(randomPos - 1);

            Vector3 auxMinus1 = terrainSpline.GetPosition(randomPos - 1);
            auxMinus1.y = terrainSpline.GetPosition(randomPos).y;

            Vector3 auxPlus1 = terrainSpline.GetPosition(randomPos + 1);
            auxPlus1.y = terrainSpline.GetPosition(randomPos).y;

            terrainSpline.SetPosition(randomPos - 1, auxMinus1);
            terrainSpline.SetPosition(randomPos + 1, auxPlus1);
        }
    }
}
