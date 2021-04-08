using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOrb : MonoBehaviour
{
    [SerializeField] private float Rotate; //��� �������� ������� ��� ����� �����

    public Material mat;//�������� �������

    [SerializeField] private Texture[] texture;//����������� �������

    private GameManagerScript game;//������� ��������

    private float y = 0;

    private void Start()
    {
        game = FindObjectOfType<GameManagerScript>();
    }
    void Update()
    {
        if(game.forward == true)
        {
            y += Rotate;
            transform.rotation = Quaternion.Euler(0, y, 0);
            mat.mainTexture = texture[0];

        }
        else
        {
            y -= Rotate;
            transform.rotation = Quaternion.Euler(0, y, 0);
            mat.mainTexture = texture[1];
        }
    }
}
