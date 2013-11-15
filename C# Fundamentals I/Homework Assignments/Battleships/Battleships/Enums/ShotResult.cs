// ********************************
// <copyright file="ShotResult.cs" company="Anonymous Solutions Inc.">
// Copyright (c) 2013 Anonymous Solutions Inc. All rights reserved.
// </copyright>
//
// ********************************
namespace Battleships.Enums
{
    /// <summary>
    /// Specifies constants that define the possible outcomes of an attack.
    /// </summary>
    public enum ShotResult
    {
        Error = 0,
        Hit = 1,
        Miss = 2,
        ShipSunk = 3,
        AllShipsSunk = 4
    }
}
