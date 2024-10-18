using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractVehicleFactory
{
    public abstract IVehicle Create();
}