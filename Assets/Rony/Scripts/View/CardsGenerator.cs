using UnityEngine;
using UnityEngine.UI;

public class CardsGenerator : MonoBehaviour
{
    [SerializeField] private Button generate;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        generate.onClick.AddListener(() =>
        {

        });
    }

    void RandomCardGenerator()
    {
        int cardID = Random.Range(1, 10);

    }
}
