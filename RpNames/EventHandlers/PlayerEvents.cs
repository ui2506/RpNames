using Exiled.Events.EventArgs.Player;
using MEC;
using PlayerRoles;

namespace RpNames.EventHandlers
{
    internal class PlayerEvents
    {
        internal void Register() => Exiled.Events.Handlers.Player.ChangingRole += OnChangingRole;

        internal void Unregister() => Exiled.Events.Handlers.Player.ChangingRole -= OnChangingRole;

        private void OnChangingRole(ChangingRoleEventArgs ev)
        {
            if (!ev.IsAllowed)
                return;

            Team team = ev.NewRole.GetTeam();

            if (!Plugin.config.NameConstructor.TryGetValue(team, out var constructor))
            {
                if (team == Team.Dead)
                    ev.Player.DisplayNickname = null;

                return;
            }

            Timing.CallDelayed(0.1f, () => constructor.Apply(ev.Player));
        }
    }
}
