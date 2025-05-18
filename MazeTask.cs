using UnityEngine;

public class MazeTask : MonoBehaviour
{
    public GameObject wallPrefab;
    public Vector2 cellSize = new Vector2(1, 1);
    public int rows = 15;
    public int cols = 15;
    private int[,] mazePattern;

    void Start()
    {
        mazePattern = new int[rows, cols];

        
        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                if (r == 0 || r == rows - 1 || c == 0 || c == cols - 1)
                    mazePattern[r, c] = 1; 
                else
                    mazePattern[r, c] = Random.value > 0.7f ? 1 : 0; 
            }
        }

        GenerateMaze();
    }

    void GenerateMaze()
    {
        for (int row = 0; row < mazePattern.GetLength(0); row++)
        {
            for (int col = 0; col < mazePattern.GetLength(1); col++)
            {
                if (mazePattern[row, col] == 1)
                {
                    Vector3 position = new Vector3(col * cellSize.x, 0, -row * cellSize.y);
                    Instantiate(wallPrefab, position, Quaternion.identity, transform);
                }
            }
        }
    }
}