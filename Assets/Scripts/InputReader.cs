using UnityEngine;

public abstract class InputReader : MonoBehaviour
{
    private static InputReader _instance = null;
    public static InputReader Instance
    {
        get
        {
            if (_instance == null) _instance = (InputReader) FindObjectOfType(typeof(InputReader));

            if (_instance == null)
            {
#if PLATFORM_STANDALONE || UNITY_EDITOR
                _instance = new GameObject("StandaloneInputReader").AddComponent<StandaloneInputReader>();
#endif
            }

            return _instance;
        }
    }

    /// <summary>
    ///  get point in proportion of screen
    /// </summary>
    /// <returns> Vector2(0-1,0-1)  </returns>
    public abstract Vector2 GetScreenTouchPoint();

    /// <summary>
    ///  get touch move delta in proportion of screen
    /// </summary>
    /// <returns> Vector2(0-1,0-1)  </returns>
    public abstract Vector2 GetScreenTouchMoveDelta();

    public abstract bool IsTouching();
}