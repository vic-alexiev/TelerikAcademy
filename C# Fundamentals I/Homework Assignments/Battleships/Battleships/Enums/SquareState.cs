// ********************************
// <copyright file="SquareState.cs" company="Anonymous Solutions Inc.">
// Copyright (c) 2013 Anonymous Solutions Inc. All rights reserved.
// </copyright>
//
// ********************************
namespace Battleships.Enums
{
    /// <summary>
    /// Specifies constants that define the square states.
    /// </summary>
    public enum SquareState
    {
        Hit = 0,
        Miss = 1,
        EmptyNoShot = 2,
        OccupiedNoShot = 3
    }
}
