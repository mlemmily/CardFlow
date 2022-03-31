using UnityEngine;
using UnityEngine.InputSystem;

public class ResetAllBindings : MonoBehaviour
{
    [SerializeField]
    private InputActionAsset inputActions;

    //A button which resets the bindings for any changed inputs back to default.
    public void ResetBindings()
    {
        foreach(InputActionMap map in inputActions.actionMaps)
        {
            map.RemoveAllBindingOverrides();
        }
        PlayerPrefs.DeleteKey("rebinds");
    }
}
