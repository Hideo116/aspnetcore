// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;

namespace Microsoft.AspNetCore.Components.WebAssembly.Services
{
    internal class WebAssemblyLoggerFactory : ILoggerFactory
    {
        private readonly IJSInProcessRuntime _jsRuntime;

        public WebAssemblyLoggerFactory(IServiceProvider services)
        {
            _jsRuntime = (IJSInProcessRuntime)services.GetRequiredService<IJSRuntime>();
        }

        public void AddProvider(ILoggerProvider provider)
        {
            // No-op
        }

        public ILogger CreateLogger(string categoryName)
            => new WebAssemblyConsoleLogger<object>(_jsRuntime);

        public void Dispose()
        {
            // No-op
        }
    }
}
