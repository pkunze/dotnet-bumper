﻿// Copyright (c) Martin Costello, 2024. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace MartinCostello.DotNetBumper.Upgrades;

/// <summary>
/// Defines a method to upgrade a project in one or more ways to use a newer version of .NET.
/// </summary>
public interface IUpgrader
{
    /// <summary>
    /// Attempts to apply an upgrade to the project.
    /// </summary>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/> to use.</param>
    /// <returns>
    /// A <see cref="Task"/> representing the asynchronous operation to upgrade the project.
    /// </returns>
    Task<bool> UpgradeAsync(CancellationToken cancellationToken);
}
