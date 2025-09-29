using Exiled.API.Features;

namespace RpNames.Constructor
{
    public class NameConstructor
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
                RpNames = Plugin.config.MainRpNames;
        }

        public void Apply(Player player)
        {
            int random = Plugin.random.Next(1000, 9999);

            string NewName = NameStructure
                .Replace("%id%", player.Id.ToString())
                .Replace("%nick%", player.Nickname)
                .Replace("%random%", random.ToString())
                .Replace("%role%", player.Role.Name)
                .Replace("%rpname%", RpNames.RandomItem());

            player.DisplayNickname = NewName;
        }
    }
}
