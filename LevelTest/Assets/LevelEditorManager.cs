using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEditorManager : MonoBehaviour
{
    public ItemController[] ItemButtons;
    public GameObject[] ItemPrefabs;
    public int CurrentButtonPressed;

    // Update is called once per frame
    void Update()
    {
        Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);

        if (Input.GetMouseButtonDown(0) && ItemButtons[CurrentButtonPressed].Clicked) {
            ItemButtons[CurrentButtonPressed].Clicked = false;
            GameObject newObj = Instantiate(ItemPrefabs[CurrentButtonPressed], new Vector3(worldPosition.x, worldPosition.y, 0), Quaternion.identity);
            newObj.tag = "Node";

            Rigidbody rb = newObj.AddComponent<Rigidbody>();
            rb.isKinematic = true;
            rb.mass = 1e15f;
            rb.velocity = new Vector3(0f,0f,0f);
        }
    }
}
