using UnityEngine;

public class Shop : MonoBehaviour
{
    private BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }
    
    public void PurchaseStandardTurret()
    {
        Debug.Log("Standard Turret Selected");
        buildManager.SetTurretToBuild(buildManager.standardTurretPrefab);
    }

    public void PurchaseMissileLauncher()
    {
        Debug.Log("Missile Launcher Selected");
        buildManager.SetTurretToBuild(buildManager.missileLauncherPrefab);
    }
}
