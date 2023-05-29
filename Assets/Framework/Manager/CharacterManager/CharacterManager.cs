using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Character
{
    public string name = "66";
    public int Level =1;
    public int  CurrentExp = 0;
    public int Hp = 0;

    public int MaxHp
    {
        get
        {
            return Level * 10;
        }
    }

    public int GetNextlevelExp()
    {
        return Level*50;
    }
    public int WeaponID = -1;
    public int ClothesID = -1;
    public int ShoesID = -1;
    public List<int> SkillList = new List<int>();

}
public class CharacterManager : MangerBase
{
    public Character character = new Character();
    public int Money = 0;
    public bool canControl = true;

    #region 人物属性

    public void AddMoney(int money)
    {
        Money += money;
        if (Money < 0)
        {
            Money = 0;
        }
    }

    public void AddExp(int exp)
    {
        character.CurrentExp += exp;
        if (character.CurrentExp >= character.GetNextlevelExp())
        {
            character.Level++;
            character.CurrentExp = 0;
        }
    }

    public void AddHp(int Hp)
    {
        character.Hp+= Hp;
        character.Hp = Mathf.Clamp(character.Hp, 0, character.MaxHp);
    }
    #endregion

    #region 人物技能

    public bool AddSkill(int skillId)
    {
        if (character.SkillList.Contains(skillId))
        {
            return false;
        }
        character.SkillList.Add(skillId);
        return true;
    }

    public bool HasSkill(int skillId)
    {
        return character.SkillList.Contains(skillId);
    }

    public void RemoveSkill(int skillID)
    {
        if (character.SkillList.Contains(skillID))
        {
            character.SkillList.Remove(skillID);
        }
    }

    public int[] GetSkills()
    {
        return character.SkillList.ToArray();
    }
    

    #endregion

    #region 人物装备

    //背包有这个武器就装备
    public void EquipWeapon(int id)
    {
        if (Managers.m_Invent.GetItem(id)!=null)
        {
            Managers.m_Invent.RemoveItem(id,1);
        } 
        //当前装备有武器,把武器卸载下来放入背包
        if (character.WeaponID > -1)
        {
            Managers.m_Invent.Additem(character.WeaponID,1);
        }
    }

    public int GetWeapon()
    {
        return character.WeaponID;
    }

    //卸载武器
    public void RemoveWeapon()
    {
        //当前有武器,把武器卸载下来放入背包
        if (character.WeaponID > -1)
        {
            Managers.m_Invent.Additem(character.WeaponID,1);
        }
    }
    

    #endregion

    public override byte GetMessageType()
    {
        throw new System.NotImplementedException();
    }
}
