using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeChartScript : MonoBehaviour
{

    public static Dictionary<string, List<string>> strengthDict = new Dictionary<string, List<string>>();
    public static Dictionary<string, List<string>> weaknessDict = new Dictionary<string, List<string>>();

    public List<string> DarkStrengths,
        EarthStrengths,
        EnergyStrengths,
        FireStrengths,
        LightStrengths,
        MechanicalStrengths,
        NatureStrengths,
        UndeadStrengths,
        WaterStrengths,
        WindStrengths,
        DarkWeakness,
        EarthWeakness,
        EnergyWeakness,
        FireWeakness,
        LightWeakness,
        MechanicalWeakness,
        NatureWeakness,
        UndeadWeakness,
        WaterWeakness,
        WindWeakness;

    void Start()
    {

        DarkStrengths.Add("Energy");
        DarkStrengths.Add("Nature");
        EarthStrengths.Add("Dark");
        EarthStrengths.Add("Fire");
        EarthStrengths.Add("Mechanical");
        EnergyStrengths.Add("Dark");
        EnergyStrengths.Add("Light");
        EnergyStrengths.Add("Water");
        EnergyStrengths.Add("Wind");
        FireStrengths.Add("Mechanical");
        FireStrengths.Add("Nature");
        FireStrengths.Add("Undead");
        LightStrengths.Add("Dark");
        LightStrengths.Add("Undead");
        MechanicalStrengths.Add("Energy");
        MechanicalStrengths.Add("Undead");
        NatureStrengths.Add("Earth");
        NatureStrengths.Add("Mechanical");
        NatureStrengths.Add("Water");
        UndeadStrengths.Add("Earth");
        UndeadStrengths.Add("Nature");
        WaterStrengths.Add("Fire");
        WaterStrengths.Add("Mechanical");
        WindStrengths.Add("Light");
        WindStrengths.Add("Nature");
        WindStrengths.Add("Wind");

        DarkWeakness.Add("Dark");
        DarkWeakness.Add("Light");
        EarthWeakness.Add("Nature");
        EarthWeakness.Add("Undead");
        EarthWeakness.Add("Water");
        EarthWeakness.Add("Wind");
        EnergyWeakness.Add("Earth");
        EnergyWeakness.Add("Energy");
        EnergyWeakness.Add("Mechanical");
        EnergyWeakness.Add("Undead");
        FireWeakness.Add("Earth");
        FireWeakness.Add("Water");
        FireWeakness.Add("Wind");
        LightWeakness.Add("Earth");
        LightWeakness.Add("Nature");
        MechanicalWeakness.Add("Earth");
        MechanicalWeakness.Add("Mechanical");
        NatureWeakness.Add("Dark");
        NatureWeakness.Add("Fire");
        UndeadWeakness.Add("Light");
        UndeadWeakness.Add("Mechanical");
        WaterWeakness.Add("Energy");
        WaterWeakness.Add("Nature");
        WindWeakness.Add("Earth");
        WindWeakness.Add("Energy");

        strengthDict.Add("Dark", DarkStrengths);
        strengthDict.Add("Earth", EarthStrengths);
        strengthDict.Add("Energy", EnergyStrengths);
        strengthDict.Add("Fire", FireStrengths);
        strengthDict.Add("Light", LightStrengths);
        strengthDict.Add("Mechanical", MechanicalStrengths);
        strengthDict.Add("Nature", NatureStrengths);
        strengthDict.Add("Undead", UndeadStrengths);
        strengthDict.Add("Water", WaterStrengths);
        strengthDict.Add("Wind", WindStrengths);

        weaknessDict.Add("Dark", DarkWeakness);
        weaknessDict.Add("Earth", EarthWeakness);
        weaknessDict.Add("Energy", EnergyWeakness);
        weaknessDict.Add("Fire", FireWeakness);
        weaknessDict.Add("Light", LightWeakness);
        weaknessDict.Add("Mechanical", MechanicalWeakness);
        weaknessDict.Add("Nature", NatureWeakness);
        weaknessDict.Add("Undead", UndeadWeakness);
        weaknessDict.Add("Water", WaterWeakness);
        weaknessDict.Add("Wind", WindWeakness);

    }

}
