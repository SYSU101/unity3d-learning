using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Materials
{
    private Material boatMat;
    private Material priestMat;
    private Material evilMat;
    private Material bankMat;
    private Material waterMat;
    private Material reslutPlane;

    public Material Boat => this.boatMat;
    public Material Priest => this.priestMat;
    public Material Evil => this.evilMat;
    public Material Bank => this.bankMat;
    public Material Water => this.waterMat;
    public Material ResultPlane => this.reslutPlane;

    public Materials(Configs configs)
    {
        this.InitializeBoat(configs.BoatMatPath);
        this.InitializeEvil(configs.EvilMatPath);
        this.InitializePriest(configs.PriestMatPath);
        this.InitializeBank(configs.BankMatPath);
        this.InitializeWater(configs.WaterMatPath);
        this.InitializeResultPlane(configs.ResultPlaneMatPath);
    }

    private void InitializeBoat(string matPath)
    {
        boatMat = Resources.Load<Material>(matPath);
    }

    private void InitializeEvil(string matPath)
    {
        evilMat = Resources.Load<Material>(matPath);
    }

    private void InitializePriest(string matPath)
    {
        priestMat = Resources.Load<Material>(matPath);
    }

    private void InitializeBank(string matPath)
    {
        bankMat = Resources.Load<Material>(matPath);
    }
    private void InitializeWater(string matPath)
    {
        waterMat = Resources.Load<Material>(matPath);
    }
    private void InitializeResultPlane(string matPath)
    {
        reslutPlane = Resources.Load<Material>(matPath);
    }
}
