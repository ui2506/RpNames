using Exiled.API.Features;
using RpNames.EventHandlers;
using System;

namespace RpNames
{
    public class Plugin : Plugin<Config>
    {
        public override string Prefix => "RpNames";
        public override string Name => "RpNames";
        public override string Author => "ui_2506";

        internal static Config config { get; private set; }
        internal static Random random { get; private set; }

        private PlayerEvents playerEvents;

        public override void OnEnabled()
        {
            config = Config;
            random = new Random();
            playerEvents = new PlayerEvents();

            playerEvents.Register();

            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            playerEvents.Unregister();

            config = null;
            random = null;
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
