﻿using Domain.Enums;
using Domain.Interfaces;
using Domain.ValueObjects.Abstractions;

namespace Domain.ValueObjects;
public class BatteryPack(
    double capacity,
    double chargeDuration)
    : EnergyTank(
        fuelType: FuelType.Electricity, 
        capacity, 
        needsManualRefill: true), IPlugable
{
    public double ChargeDuration { get; } = chargeDuration;
}