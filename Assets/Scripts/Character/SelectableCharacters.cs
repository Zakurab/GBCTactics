using UnityEngine;
using System.Collections;

public class SelectableCharacters : singleton<SelectableCharacters>
{
    public int TeamSize;

    public MoveableCharacter[] Team;
    public int SelectionIndex;

    private bool m_characterSelected;

    public bool CharacterSelected { set { m_characterSelected = value; } }

    void Start()
    {
        Team = new MoveableCharacter[TeamSize];

        for (int i = 0; i < TeamSize; i++)
        {
            Team[i] = GameObject.Find("PlayerMember" + i).GetComponent<MoveableCharacter>();
        }
    }

    void Update()
    {
        if (!m_characterSelected)
        {
            GetInput();
        }

        else
        {
            //Toggle Team[selectionIndex].isSelected;
            Team[SelectionIndex].m_isSelected = true;
            print("TeamMember Selected " + Team[SelectionIndex].name);
        }
    }

    void GetInput()
    {
        if (GameManager.Instance.GameState == (int)GameManager.GameStates.Selecting)
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                if (SelectionIndex < TeamSize - 1)
                {
                    SelectionIndex++;
                }

                else
                {
                    SelectionIndex = 0;
                }

                UpdateCursorLocation();
            }

            if (Input.GetKeyDown(KeyCode.Return))
            {
                CharacterSelected = true;
                //Set game state to moving;
                GameManager.Instance.GameState = (int)GameManager.GameStates.Moving;
            }
        }
    }

    void UpdateCursorLocation()
    {
        Map.Instance.DeselectTile();
        Map.Instance.SelectedTile = Team[SelectionIndex].m_CurrentLocation; 
    }



}
