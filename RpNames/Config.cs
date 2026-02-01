using System.Collections.Generic;
using System.ComponentModel;
using Exiled.API.Interfaces;
using PlayerRoles;
using RpNames.Constructor;

namespace RpNames
{
    public sealed class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;

        [Description("Basic RP names that are accepted if the constructor rpnames is empty")]
        public string[] MainRpNames { get; set; } = new string[] { "OtherRPNames" };

        [Description("RP name constructor, set rpnames to empty to use the main RP names")]
        public Dictionary<Team, NameConstructor> NameConstructor { get; set; } = new Dictionary<Team, NameConstructor>()
        {
            {Team.ChaosInsurgency, new NameConstructor("%id% | %rpname% | %nick%", new string[] {"Coolguy", "Coolguy" }) },
            {Team.ClassD, new NameConstructor("%id% | D-%random% | %nick%", new string[] { "CoolName" }) },
            {Team.FoundationForces, new NameConstructor("%id% | %rpname% | %nick%", new string[] { "CoolName" }) },
            {Team.Scientists, new NameConstructor("%id% | %rpname% | %nick%", new string[] { "CoolName" }) },
            {Team.SCPs, new NameConstructor("%id% | %role% | %nick%", new string[] { "CoolName" }) },
        };

        [Description("Translation of roles")]
        public Dictionary<RoleTypeId, string> RoleTranslation { get; set; } = new Dictionary<RoleTypeId, string>
        {
            { RoleTypeId.ClassD, "Class-D" },
            { RoleTypeId.Scp049, "SCP-049" },
        };
    }
}
