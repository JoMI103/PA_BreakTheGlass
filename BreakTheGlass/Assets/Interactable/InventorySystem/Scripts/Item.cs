using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Item")]
public class Item : ScriptableObject
{
    public string name;
    public string IdPuzzle;
    public GameObject prefab;
    public Sprite image;
    public bool interactableOnInspector;

    public GameObject placeableGameObject;
}
