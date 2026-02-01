using Exiled.Events.EventArgs.Player;
using MEC;
using PlayerRoles;

namespace RpNames.EventHandlers
{
    internal sealed class PlayerEvents
    {
        internal void Register() => Exiled.Events.Handlers.Player.Spawned += OnSpawned;

        internal void Unregister() => Exiled.Events.Handlers.Player.Spawned -= OnSpawned;

        private void OnSpawned(SpawnedEventArgs ev)
        {
            Team team = ev.Player.Role.Team;

            if (!Plugin.PluginConfig.NameConstructor.TryGetValue(team, out var constructor))
            {
                if (team == Team.Dead)
                    ev.Player.DisplayNickname = null;

                return;
            }

            Timing.CallDelayed(0.1f, () => constructor.Apply(ev.Player));
        }
    }
}
