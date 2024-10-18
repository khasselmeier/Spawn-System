using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Client : MonoBehaviour
{
    public TMP_InputField NumberOfWheelsInput;
    public TMP_InputField PassengersInput;
    public Toggle EngineToggle;
    public Toggle CargoToggle;
    public TMP_Text VehicleText;

    public int NumberOfWheels;
    public bool Engine;
    public int Passengers;
    public bool Cargo;

    void Update()
    {
        int.TryParse(NumberOfWheelsInput.text, out NumberOfWheels);
        int.TryParse(PassengersInput.text, out Passengers);

        NumberOfWheels = Mathf.Max(NumberOfWheels, 1);
        Passengers = Mathf.Max(Passengers, 1);

        Engine = EngineToggle.isOn;
        Cargo = CargoToggle.isOn;

        VehicleRequirements requirements = new VehicleRequirements();
        requirements.NumberOfWheels = NumberOfWheels;
        requirements.Engine = Engine;
        requirements.Passengers = Passengers;

        IVehicle v = GetVehicle(requirements);
        //Debug.Log(v);
        DisplayVehicleOnUI(v);
    }

    private static IVehicle GetVehicle(VehicleRequirements requirements)
    {
        VehicleFactory factory = new VehicleFactory(requirements);
        return factory.Create();
    }

    private void DisplayVehicleOnUI(IVehicle vehicle)
    {
        if (vehicle is Unicycle)
        {
            VehicleText.text = "Vehicle Type: Unicycle";
        }
        else if (vehicle is Bicycle)
        {
            VehicleText.text = "Vehicle Type: Bicycle";
        }
        else if (vehicle is Tandem)
        {
            VehicleText.text = "Vehicle Type: Tandem";
        }
        else if (vehicle is Tricycle)
        {
            VehicleText.text = "Vehicle Type: Tricycle";
        }
        else if (vehicle is GoKart)
        {
            VehicleText.text = "Vehicle Type: GoKart";
        }
        else if (vehicle is FamilyBike)
        {
            VehicleText.text = "Vehicle Type: FamilyBike";
        }
        else if (vehicle is Motorbike)
        {
            VehicleText.text = "Vehicle Type: Motorbike";
        }
        else if (vehicle is Truck)
        {
            VehicleText.text = "Vehicle Type: Truck";
        }
        else
        {
            VehicleText.text = "Unknown Vehicle";
        }
    }
}