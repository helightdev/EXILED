// -----------------------------------------------------------------------
// <copyright file="Permissions.cs" company="Exiled Team">
// Copyright (c) Exiled Team. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Exiled.Permissions
{
    using System;
    using Exiled.API.Features;

    /// <summary>
    /// Handles all plugin-related permissions, for executing commands, doing actions and so on.
    /// </summary>
    public sealed class Permissions : Plugin<Config>
    {
        private static readonly Lazy<Permissions> LazyInstance = new Lazy<Permissions>(() => new Permissions());

        private Permissions()
        {
        }

        /// <summary>
        /// Gets the permissions instance.
        /// </summary>
        public static Permissions Instance => LazyInstance.Value;

        /// <inheritdoc/>
        public override void OnEnabled()
        {
            base.OnEnabled();

            Extensions.Permissions.Create();
            Extensions.Permissions.Reload();
        }

        /// <inheritdoc/>
        public override void OnDisabled()
        {
            base.OnDisabled();

            Extensions.Permissions.Groups.Clear();
        }
    }
}
