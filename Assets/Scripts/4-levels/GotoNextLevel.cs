using UnityEngine;
using UnityEngine.SceneManagement;

public class GotoNextLevel : MonoBehaviour {
    [SerializeField] string sceneName;
    [SerializeField] NumberField scoreField;

    private void OnTriggerEnter2D(Collider2D collision) {
        SceneManager.LoadScene(sceneName);    // Input can either be a serial number or a name; here we use name.
    }
}
