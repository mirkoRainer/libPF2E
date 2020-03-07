using PF2E.Rules.Creature.PlayerCharacter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace PF2E
{
    public static class PF2eCoreUtils
    {
        public static List<string> GetListOfAncestries()
        {
            return GetListOfNamesOfClassesThatImplement(typeof(IAncestry));
        }

        public static List<string> GetListOfBackgrounds()
        {
            return GetListOfNamesOfClassesThatImplement(typeof(IBackground));
        }

        public static List<string> GetListOfClasses()
        {
            return GetListOfNamesOfClassesThatImplement(typeof(IPcClass));
        }

        private static List<string> GetListOfNamesOfClassesThatImplement(Type interfaceName)
        {
            var result = from t in Assembly.GetExecutingAssembly().GetTypes()
                         where t.GetInterfaces().Contains(interfaceName)
                         select t.Name as string;
            return result.ToList();
        }

        public static List<int> GetAbilityScoreRange()
        {
            return Enumerable.Range(1, 40).ToList();
        }
    }
}