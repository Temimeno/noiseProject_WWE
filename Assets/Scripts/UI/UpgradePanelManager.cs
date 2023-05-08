using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradePanelManager : MonoBehaviour
{
    [SerializeField] GameObject panel;

    [SerializeField] List<UpgradeButton> upgradeButtons;

    public void OpenPanel(List<UpgradeData> upgradeDatas)
    {
        panel.SetActive(true);
        Time.timeScale = 0f;

        for(int i = 0; i < upgradeDatas.Count; i++)
        {
            upgradeButtons[i].Set(upgradeDatas[i]);
        }
    }

    public void Upgrade(int pressedButtonID)
    {
        GameManager.instance.playerTransform.GetComponent<Level>().Upgrades(pressedButtonID);
        ClosePanel();
    }

    public void ClosePanel()
    {
        panel.SetActive(false);
        Time.timeScale = 1f;
    }
}
