using System.Collections;
using System.Collections.Generic;
using Framework.Manager.PoolManager;
using UnityEngine;

public class Managers
{
    //添加管理器
    public static AudioManger m_Audio = AudioManger.Instance as AudioManger;
    public static ItemManager m_Item = ItemManager.Instance as ItemManager;
    public static InventoryManager m_Invent = InventoryManager.Instance as InventoryManager;
    public static SaveManager m_Save = SaveManager.Instance;
    public static CharacterManager m_Character = CharacterManager.Instance as CharacterManager;
    public static PoolManager m_PoolManager = PoolManager.Instance;
    public static UIManger1 m_UI = UIManger1.Instance as UIManger1;

}
