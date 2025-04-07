using UnityEngine;

public class InventoryInput : MonoBehaviour
{
    [SerializeField] KeyCode[] toggleinventorykey;
    [SerializeField] GameObject inventoryGameObject;
    
    void Update()
    {
        for (int i = 0; i < toggleinventorykey.Length; i++)
        {
            if (Input.GetKeyDown(toggleinventorykey[i]))
            {
                inventoryGameObject.SetActive(!inventoryGameObject.activeSelf);

                if (inventoryGameObject.activeSelf)
                {
                    ShowMouseCursor();
                    
                }
                else
                {
                    HideMouseCursor();
                }

                break;
            }
        }
    }
    public void ShowMouseCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void HideMouseCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
