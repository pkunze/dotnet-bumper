﻿// Copyright (c) Martin Costello, 2024. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Spectre.Console;

namespace MartinCostello.DotNetBumper.Upgraders;

internal abstract class Upgrader(
    IAnsiConsole console,
    IOptions<UpgradeOptions> options,
    ILogger logger) : UpgradeTask(console, options, logger), IUpgrader
{
    public virtual async Task<UpgradeResult> UpgradeAsync(
        UpgradeInfo upgrade,
        CancellationToken cancellationToken)
    {
        Console.MarkupLineInterpolated($"[{ActionColor}]{Action}...[/]");

        return await Console
            .Status()
            .Spinner(Spinner)
            .SpinnerStyle(SpinnerStyle)
            .StartAsync($"[{StatusColor}]{InitialStatus}...[/]", async (context) => await UpgradeCoreAsync(upgrade, context, cancellationToken));
    }

    protected abstract Task<UpgradeResult> UpgradeCoreAsync(
        UpgradeInfo upgrade,
        StatusContext context,
        CancellationToken cancellationToken);
}
