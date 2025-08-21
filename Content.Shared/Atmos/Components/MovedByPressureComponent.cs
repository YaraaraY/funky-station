// SPDX-FileCopyrightText: 2024 Nemanja <98561806+EmoGarbage404@users.noreply.github.com>
// SPDX-FileCopyrightText: 2025 taydeo <td12233a@gmail.com>
//
// SPDX-License-Identifier: MIT

using System.Numerics;
using Content.Shared.Atmos.EntitySystems;
using Robust.Shared.GameStates;

namespace Content.Shared.Atmos.Components;

[RegisterComponent, NetworkedComponent, AutoGenerateComponentState, Access(typeof(SharedAtmosphereSystem))]
public sealed partial class MovedByPressureComponent : Component
{
    public const float MoveForcePushRatio = 1f;
    public const float MoveForceForcePushRatio = 1f;
    public const float ProbabilityOffset = 25f;
    public const float ProbabilityBasePercent = 10f;
    public const float ThrowForce = 100f;

    /// <summary>
    /// Accumulates time when yeeted by high pressure deltas.
    /// </summary>
    [DataField]
    public float Accumulator;

    [DataField]
    public bool Enabled { get; set; } = true;

    [DataField]
    public float PressureResistance { get; set; } = 1f;

    [DataField]
    public float MoveResist { get; set; } = 100f;

    [ViewVariables(VVAccess.ReadWrite)]
    public int LastHighPressureMovementAirCycle { get; set; } = 0;
    public const float MinPushForce = 0.1f;
    public const float MinPushForceSquared = MinPushForce * MinPushForce;

    [DataField, AutoNetworkedField]
    public bool Enabled = true;

    [ViewVariables, AutoNetworkedField]
    public Vector2 CurrentWind;

    [DataField]
    public float? StunForceThreshold = 4f;

    [DataField]
    public TimeSpan StunTimePerNormalizedWind = TimeSpan.FromSeconds(0.2f);
}
