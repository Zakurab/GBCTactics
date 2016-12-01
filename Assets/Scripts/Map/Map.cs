using UnityEngine;
using System.Collections;

public class Map : singleton<Map>
{
    public int Rows;
    public int Columns;

    public MapPiece[,] m_map;
    //Private LATER
    public Vector2 m_currentSelection;


    public MapPiece[,] MAP { get { return m_map; } }
    public Vector2 SelectedTile { get { return m_currentSelection; } set { m_currentSelection = value; } }

    
    //MonoBehaviors
    private void OnEnable()
    {
        m_map = new MapPiece[Rows, Columns];

        for(int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Columns; j++)
            {
                m_map[i, j] = GameObject.Find("MapPieceOutline (" + (i * Columns + j) + ")").GetComponent<MapPiece>();
                //print("Map (" + i + ", " + j + ") Set to:" + m_map[i, j].name);
            }
        }
    }

    private void Update()
    {
        GetPlayerInput();
    }

    //Public functions
    public void DeselectTile()
    {
        m_map[(int)m_currentSelection.x, (int)m_currentSelection.y].m_isSelected = false;
    }

    public Vector2 GetPosition(float Xindex, float Yindex)
    {
        print("(" + Xindex + ", " + Yindex + ")");
        return m_map[(int)Xindex, (int)Yindex].gameObject.transform.position;
    }

    void GetPlayerInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            //Set Current Cell to deselected;
            //set x-- cell to selected; above
            m_map[(int)m_currentSelection.x, (int)m_currentSelection.y].m_isSelected = false;
            if (m_currentSelection.x - 1 >= 0)
            {
                m_currentSelection.x--;
            }
        }

        else if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            //Deselect
            //Select x++ below
            m_map[(int)m_currentSelection.x, (int)m_currentSelection.y].m_isSelected = false;
            if (m_currentSelection.x + 1 < Rows)
            {
                m_currentSelection.x++;
            }
        }

        else if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            //y++ right
            m_map[(int)m_currentSelection.x, (int)m_currentSelection.y].m_isSelected = false;
            if (m_currentSelection.y + 1 < Columns)
            {
                m_currentSelection.y++;
            }
        }

        else if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //y-- left
            m_map[(int)m_currentSelection.x, (int)m_currentSelection.y].m_isSelected = false;
            if (m_currentSelection.y - 1 >= 0)
            {
                m_currentSelection.y--;
            }
        }

        m_map[(int)m_currentSelection.x, (int)m_currentSelection.y].m_isSelected = true;
    }

}
