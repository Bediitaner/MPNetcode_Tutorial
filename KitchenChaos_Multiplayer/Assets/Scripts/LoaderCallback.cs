using UnityEngine;

public class LoaderCallback : MonoBehaviour
{
    #region Fields

    private bool isFirstUpdate = true;

    #endregion

    #region Unity: Update

    private void Update()
    {
        if (isFirstUpdate)
        {
            isFirstUpdate = false;

            Loader.LoaderCallback();
        }
    }

    #endregion
}