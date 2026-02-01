using Exiled.API.Features;

namespace RpNames.Constructor
{
    public sealed class NameConstructor
    {
        public string NameStructure { get; set; }
        public string[] RpNames { get; set; }

        public NameConstructor() { }

        public NameConstructor(string nameStructure, string[] rpNames)
        {
            NameStructure = nameStructure;

            if (rpNames.Length > 0)
                RpNames = rpNames;
            else
                RpNames = Plugin.PluginConfig.MainRpNames;
        }

        internal void Apply(Player player)
        {
            int random = Plugin.Random.Next(1000, 9999);

            string roleName = Plugin.PluginConfig.RoleTranslation.TryGetValue(player.Role.Type, out string translation)
                ? translation
                : player.Role.Name;

            string NewName = NameStructure
                .Replace("%id%", player.Id.ToString())
                .Replace("%nick%", player.Nickname)
                .Replace("%random%", random.ToString())
                .Replace("%role%", roleName)
                .Replace("%rpname%", RpNames.RandomItem());

            player.DisplayNickname = NewName;
        }
    }
}
