using UnityEngine;

public class TerrainManager : MonoBehaviour
{
    public Terrain terrain;          
    public GameObject cactusPrefab;   
    public int cantidad = 100;        
    public float alturaExtra = 1f; 

    void Start()
    {
        GenerarCactus();
    }

    void GenerarCactus()
    {
        TerrainData data = terrain.terrainData;

        for (int i = 0; i < cantidad; i++)
        {
            
            float x = Random.Range(0, data.size.x);
            float z = Random.Range(0, data.size.z);

            float y = terrain.SampleHeight(new Vector3(x, 0, z));
      
            Vector3 pos = new Vector3(
                x + terrain.transform.position.x,
                y + terrain.transform.position.y + alturaExtra,
                z + terrain.transform.position.z
            );

            GameObject cactus = Instantiate(cactusPrefab, pos, Quaternion.identity);
            cactus.transform.rotation = Quaternion.Euler(0, Random.Range(0f, 360f), 0);
        }
    }
}
