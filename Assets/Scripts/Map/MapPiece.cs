using UnityEngine;
using System.Collections;

public class MapPiece : MonoBehaviour
{
    public bool m_isSelected;
    public bool m_lightUp;

    public Vector4 m_deselectedColor;
    public Vector4 m_selectedColor;
    public Vector4 m_pathingColor;
    public Vector4 m_movableColor;
    public Vector4 m_unMovableColor;

    public SpriteRenderer m_spriteRenderer;

    //Monobehaviors
    private void Start()
    {
        m_spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        SetColor();
    }


    //Public Functions
    public void SetColor()
    {
        if(m_isSelected)
        {
            m_spriteRenderer.color = m_selectedColor;
        }

        else if(m_lightUp)
        {
            m_spriteRenderer.color = m_pathingColor;
        }

        else
        {
            m_spriteRenderer.color = m_deselectedColor;
        }
    }
}
