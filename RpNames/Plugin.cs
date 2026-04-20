using Exiled.API.Features;
using RpNames.EventHandlers;
using System;

namespace RpNames
{
    public sealed class Plugin : Plugin<Config>
    {
        public override string Prefix { get; } = "RpNames";
        public override string Name { get; } = "RpNames";
        public override string Author { get; } = "ui_2506";
        public override Version Version { get; } = new Version(1, 3, 2);

        internal static Config PluginConfig { get; private set; }

        private PlayerEvents playerEvents;

        public override void OnEnabled()
        {
            PluginConfig = Config;
            playerEvents = new PlayerEvents();

            playerEvents.Register();

            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            playerEvents.Unregister();

            PluginConfig = null;
            playerEvents = null;

            base.OnDisabled();
        }

        public override void OnReloaded()
        {
            OnDisabled();
            OnEnabled();

            base.OnReloaded();
        }
    }
}
