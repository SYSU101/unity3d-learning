using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Configs
{
    // Material Paths
    private string boatMatPath = "Vendors/Original Wood Textures/Wood Texture 07/Wood Texture 07";
    private string evilMatPath = "Materials/Evil";
    private string priestMatPath = "Materials/Priest";
    private string bankMatPath = "Vendors/Cobble textures pack/Cobble 01/Cobble pattern 01";
    private string waterMatPath = "Materials/Water";
    private string resultPlaneMatPath = "Materials/ResultPlane";
    // Object Scales
    private Vector3 bankScale = new Vector3(6, 6, 1);
    private Vector3 boatScale = new Vector3(2, 1, 1);
    private Vector3 charScale = new Vector3(1, 1, 1);
    private Vector3 resultPlaneScale = new Vector3(3, 1, 1);
    // Move Speeds
    private float boatMoveSpeed = 20f;
    private float charMoveSpeed = 10f;
    // Object Positions
    private Vector3 rightBoatPos = new Vector3(2f, 1.5f, 10);
    private Vector3 leftBoatPos = new Vector3(-2f, 1.5f, 10);
    private Vector3 rightBankPos = new Vector3(6, -1, 10);
    private Vector3 leftBankPos = new Vector3(-6, -1, 10);
    private Vector3[] rightCharPos = new Vector3[8]
    {
        new Vector3(1.5f, 2.5f, 10), new Vector3(2.5f, 2.5f, 10),
        new Vector3(3.5f, 2.5f, 10), new Vector3(4.5f, 2.5f, 10), new Vector3(5.5f, 2.5f, 10),
        new Vector3(6.5f, 2.5f, 10), new Vector3(7.5f, 2.5f, 10), new Vector3(8.5f, 2.5f, 10)
    };
    private Vector3[] leftCharPos = new Vector3[8]
    {
        new Vector3(-1.5f, 2.5f, 10), new Vector3(-2.5f, 2.5f, 10),
        new Vector3(-3.5f, 2.5f, 10), new Vector3(-4.5f, 2.5f, 10), new Vector3(-5.5f, 2.5f, 10),
        new Vector3(-6.5f, 2.5f, 10), new Vector3(-7.5f, 2.5f, 10), new Vector3(-8.5f, 2.5f, 10)
    };
    private Vector3 resultPlanePos = new Vector3(0, 1, 5);
    private Vector3 waterPos = new Vector3(0, -1.5f, 10);
    private Vector3 resultTextPos = new Vector3(0, 4, 5);
    // Result Message
    private string winMsg = "Win";
    private string lostMsg = "Lost";
    // Others
    private Characters.CharacterState defaultState = Characters.CharacterState.OnRight;
    private float charMoveSummit = 5f;
    private int peopleNum = 3;
    private Quaternion resultPlaneRotation = Quaternion.Euler(-90, 0, 0);

    public string BoatMatPath => this.boatMatPath;
    public string EvilMatPath => this.evilMatPath;
    public string PriestMatPath => this.priestMatPath;
    public string BankMatPath => this.bankMatPath;
    public string WaterMatPath => this.waterMatPath;
    public string ResultPlaneMatPath => this.resultPlaneMatPath;
    public Vector3 BankScale => this.bankScale;
    public Vector3 BoatScale => this.boatScale;
    public Vector3 CharScale => this.charScale;
    public Vector3 ResultPlaneScale => this.resultPlaneScale;
    public float BoatMoveSpeed => this.boatMoveSpeed;
    public float CharMoveSpeed => this.charMoveSpeed;
    public Vector3 RightBoatPos => this.rightBoatPos;
    public Vector3 LeftBoatPos => this.leftBoatPos;
    public Vector3 RightBankPos => this.rightBankPos;
    public Vector3 LeftBankPos => this.leftBankPos;
    public Vector3[] RightCharPos => this.rightCharPos;
    public Vector3[] LeftCharPos => this.leftCharPos;
    public Vector3 ResultPlanePos => this.resultPlanePos;
    public Vector3 WaterPos => this.waterPos;
    public Vector3 ResultTextPos => this.resultTextPos;
    public string WinMsg => this.winMsg;
    public string LostMsg => this.lostMsg;
    public Characters.CharacterState DefaultState => this.defaultState;
    public float CharMoveSummit => this.charMoveSummit;
    public int PeopleNum => this.peopleNum;
    public Quaternion ResultPlaneRotation => this.resultPlaneRotation;

    public Configs() { }
}
