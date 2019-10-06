using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneController
{
    private Configs configs;
    private Materials materials;
    private Characters characters;
    private BoatRenderer boat;
    private PriestRenderer[] priests;
    private EvilRenderer[] evils;
    private IMoveStrategy charMove;
    private IMoveStrategy boatMove;
    private ResultRenderer result;
    public int objectsOnAnimation = 0;

    public MainSceneController()
    {
        this.configs = new Configs();
        this.materials = new Materials(configs);
        this.characters = new Characters(configs);
        new BankRenderer(this.configs.LeftBankPos, this.materials, this.configs);
        new BankRenderer(this.configs.RightBankPos, this.materials, this.configs);
        this.boatMove = new LinearMove2D(this.configs.BoatMoveSpeed);
        this.boat = new BoatRenderer(this.configs.RightBoatPos, this.materials, this.boatMove.Clone(), this, this.configs);
        this.priests = new PriestRenderer[this.configs.PeopleNum];
        this.evils = new EvilRenderer[this.configs.PeopleNum];
        this.charMove = new ParabolicMove2D(this.configs.CharMoveSummit, this.configs.CharMoveSpeed);
        for (int i = 0; i < this.configs.PeopleNum; i++)
        {
            this.priests[i] = new PriestRenderer(i, this.configs.RightCharPos[i + 2], materials, this.charMove.Clone(), this, this.configs);
        }
        for (int i = 0; i < this.configs.PeopleNum; i++)
        {
            this.evils[i] = new EvilRenderer(i, this.configs.RightCharPos[i + 2 + this.configs.PeopleNum], materials, this.charMove.Clone(), this, this.configs);
        }
        this.result = new ResultRenderer(this.configs.ResultPlanePos, this.configs.ResultPlaneRotation, this.configs.ResultPlaneScale, this.materials);
    }

    public void SetSail()
    {
        if (this.characters.SetSail())
        {
            Vector3 tgtPos; 
            if (this.characters.BoatState == Characters.CharacterState.OnLeft)
            {
                tgtPos = this.configs.LeftBoatPos;
            } else
            {
                tgtPos = this.configs.RightBoatPos;
            }
            for (int i = 0; i < this.configs.PeopleNum; i++)
            {
                if (this.characters.priestStates[i] == Characters.CharacterState.OnBoat)
                {
                    this.priests[i].MoveStrategy = this.boatMove.Clone();
                    this.priests[i].MoveTo(this.priests[i].Position - this.boat.Position + tgtPos);
                }
                if (this.characters.evilStates[i] == Characters.CharacterState.OnBoat)
                {
                    this.evils[i].MoveStrategy = this.boatMove.Clone();
                    this.evils[i].MoveTo(this.evils[i].Position - this.boat.Position + tgtPos);
                }
            }
            this.boat.MoveTo(tgtPos);
            if (!this.characters.IsRunning)
            {
                this.ShowResult();
                this.objectsOnAnimation++;
            }
        }
    }

    public void Embark(Characters.CharacterType charType, int id)
    {
        if (this.characters.Embark(charType, id))
        {
            bool isCharOnPos0 = false;
            Vector3[] posGroup;
            if (this.characters.BoatState == Characters.CharacterState.OnLeft)
            {
                posGroup = this.configs.LeftCharPos;
            } else
            {
                posGroup = this.configs.RightCharPos;
            }
            for (int i = 0; i < 3; i++)
            {
                if (this.priests[i].Position == posGroup[0] || this.evils[i].Position == posGroup[0])
                {
                    isCharOnPos0 = true;
                    break;
                }
            }
            Vector3 tgtPos;
            if (isCharOnPos0)
            {
                tgtPos = posGroup[1];
            } else
            {
                tgtPos = posGroup[0];
            }
            switch(charType)
            {
                case Characters.CharacterType.Priest:
                    this.priests[id].MoveTo(tgtPos);
                    break;
                case Characters.CharacterType.Evil:
                    this.evils[id].MoveTo(tgtPos);
                    break;
            }
        }
    }

    public void Disembark(Characters.CharacterType charType, int id)
    {
        if (this.characters.Disembark(charType, id))
        {
            switch (this.characters.BoatState)
            {
                case Characters.CharacterState.OnLeft:
                    switch (charType)
                    {
                        case Characters.CharacterType.Priest:
                            this.priests[id].MoveStrategy = this.charMove.Clone();
                            this.priests[id].MoveTo(this.configs.LeftCharPos[id + 2]);
                            break;
                        case Characters.CharacterType.Evil:
                            this.evils[id].MoveStrategy = this.charMove.Clone();
                            this.evils[id].MoveTo(this.configs.LeftCharPos[id + this.configs.PeopleNum + 2]);
                            break;
                    }
                    break;
                case Characters.CharacterState.OnRight:
                    switch (charType)
                    {
                        case Characters.CharacterType.Priest:
                            this.priests[id].MoveStrategy = this.charMove.Clone();
                            this.priests[id].MoveTo(this.configs.RightCharPos[id + 2]);
                            break;
                        case Characters.CharacterType.Evil:
                            this.evils[id].MoveStrategy = this.charMove.Clone();
                            this.evils[id].MoveTo(this.configs.RightCharPos[id + this.configs.PeopleNum + 2]);
                            break;
                    }
                    break;
            }
            if (this.characters.CharsOnBoat == 0 && !this.characters.IsRunning)
            {
                this.ShowResult();
                this.objectsOnAnimation++;
            }
        }
    }

    public Characters.CharacterState GetState(Characters.CharacterType charType, int id)
    {
        switch(charType)
        {
            case Characters.CharacterType.Priest:
                return this.characters.priestStates[id];
            case Characters.CharacterType.Evil:
                return this.characters.evilStates[id];
            default:
                return this.configs.DefaultState;
        }
    }

    private void ShowResult()
    {
        if (this.characters.IsWin)
        {
            this.result.Show(this.configs.WinMsg, this.configs.ResultTextPos);
        }
        if (this.characters.IsLost)
        {
            this.result.Show(this.configs.LostMsg, this.configs.ResultTextPos);
        }
    }
}
