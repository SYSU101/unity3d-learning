using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Characters
{
    public enum CharacterState
    {
        OnLeft,
        OnBoat,
        OnRight,
    }
    public enum CharacterType
    {
        Priest,
        Evil,
    }

    public CharacterState[] priestStates;
    public CharacterState[] evilStates;
    private CharacterState boatState;
    private int peopleNum; // 牧师或恶魔的数量

    private int PriestsOnRight => this.CountState(this.priestStates, CharacterState.OnRight);
    private int PriestOnLeft => this.CountState(this.priestStates, CharacterState.OnLeft);
    private int PriestOnBoat => this.CountState(this.priestStates, CharacterState.OnBoat);
    private int EvilsOnRight => this.CountState(this.evilStates, CharacterState.OnRight);
    private int EvilsOnLeft => this.CountState(this.evilStates, CharacterState.OnLeft);
    private int EvilsOnBoat => this.CountState(this.evilStates, CharacterState.OnBoat);
    public bool IsWin => this.PriestOnLeft + this.EvilsOnLeft == this.peopleNum*2;
    public bool IsLost => (this.PriestOnLeft < this.EvilsOnLeft && this.PriestOnLeft > 0) || (this.PriestsOnRight < this.EvilsOnRight && this.PriestsOnRight > 0);
    public bool IsRunning => !this.IsWin && !this.IsLost;
    public CharacterState BoatState => this.boatState;
    public int CharsOnBoat => this.PriestOnBoat + this.EvilsOnBoat;

    public Characters(Configs configs)
    {
        ArrayList protoList = ArrayList.Repeat(configs.DefaultState, 3);
        this.priestStates = new CharacterState[3];
        this.evilStates = new CharacterState[3];
        protoList.CopyTo(this.priestStates);
        protoList.CopyTo(this.evilStates);
        boatState = configs.DefaultState;
        this.peopleNum = configs.PeopleNum;
    }

    private int CountState(CharacterState[] states, CharacterState tgtState)
    {
        int num = 0;
        foreach(CharacterState state in states)
        {
            if (state == tgtState)
            {
                num++;
            }
        }
        return num;
    }

    public bool Embark(CharacterType charType, int id)
    {
        if (this.PriestOnBoat + this.EvilsOnBoat < 2)
        {
            switch (charType)
            {
                case CharacterType.Evil:
                    if (this.evilStates[id] == this.boatState)
                    {
                        this.evilStates[id] = CharacterState.OnBoat;
                        return true;
                    }
                    return false;
                case CharacterType.Priest:
                    if (this.priestStates[id] == this.boatState)
                    {
                        this.priestStates[id] = CharacterState.OnBoat;
                        return true;
                    }
                    return false;
                default:
                    return false;
            }
        }
        return false;
    }
    
    public bool Disembark(CharacterType charType, int id)
    {
        switch (charType)
        {
            case CharacterType.Evil:
                if (this.evilStates[id] == CharacterState.OnBoat)
                {
                    this.evilStates[id] = this.boatState;
                    return true;
                }
                return false;
            case CharacterType.Priest:
                if (this.priestStates[id] == CharacterState.OnBoat)
                {
                    this.priestStates[id] = this.boatState;
                    return true;
                }
                return false;
            default:
                return false;
        }
    }

    public bool SetSail()
    {
        if (this.PriestOnBoat + this.EvilsOnBoat > 0)
        {
            if (this.boatState == CharacterState.OnLeft)
            {
                this.boatState = CharacterState.OnRight;
            } else
            {
                this.boatState = CharacterState.OnLeft;
            }
            return true;
        }
        return false;
    }
}
