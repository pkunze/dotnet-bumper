﻿// Copyright (c) Martin Costello, 2024. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Spectre.Console;

namespace MartinCostello.DotNetBumper.PostProcessors;

internal abstract class PostProcessor(
    IAnsiConsole console,
    IOptions<UpgradeOptions> options,
    ILogger logger) : UpgradeTask(console, options, logger), IPostProcessor
{
    public virtual async Task<ProcessingResult> PostProcessAsync(
        UpgradeInfo upgrade,
        CancellationToken cancellationToken)
    {
        Console.MarkupLineInterpolated($"[{ActionColor}]{Action}...[/]");

        return await Console
            .Status()
            .Spinner(Spinner)
            .SpinnerStyle(SpinnerStyle)
            .StartAsync($"[{StatusColor}]{InitialStatus}...[/]", async (context) => await PostProcessCoreAsync(upgrade, context, cancellationToken));
    }

    protected abstract Task<ProcessingResult> PostProcessCoreAsync(
        UpgradeInfo upgrade,
        StatusContext context,
        CancellationToken cancellationToken);
}
