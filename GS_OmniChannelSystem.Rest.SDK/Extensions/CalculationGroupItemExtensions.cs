using GS.OmniChannelSystem.Rest.SDK.Models;
using System.Collections.Generic;
using System.Linq;

namespace GS.OmniChannelSystem.Rest.SDK.Extensions
{
    public static class CalculationGroupItemExtensions
    {
        // Transportpauschale
        public static void Set(this ICollection<CalculationGroupItem> conditions, string name, double deliverCost, EntityReference currency, EntityReference[] articleGroups, EntityReference calculationGroup)
        {
            var key = "delivercosts";
            var condition = conditions.SingleOrDefault(m => m.External_Key == key);
            if (condition == null)
                condition = new CalculationGroupItem();

            condition.Name = name;
            condition.External_Key = key;
            condition.Currency = currency;
            condition.Type = CalculationGroupItemType.Shipping;
            condition.TransactionType = TransactionType.Shipping;
            condition.ArticleGroups = articleGroups.ToList();
            condition.ValueType = CalulationPrincipleValueType.Value;
            condition.Value = deliverCost;
            condition.CalculationGroup = calculationGroup;

            if (!conditions.Contains(condition))
                conditions.Add(condition);
        }

        // Mindermengenzuschlag mit Limit
        public static void Set(this ICollection<CalculationGroupItem> conditions, string name, double deliverCost, double limit, EntityReference currency, EntityReference[] articleGroups, EntityReference calculationGroup)
        {
            var key = "delivercostsWithLimit";
            var condition = conditions.SingleOrDefault(m => m.External_Key == key);
            if (condition == null)
                condition = new CalculationGroupItem();

            condition.Name = name;
            condition.External_Key = key;
            condition.Type = CalculationGroupItemType.Shipping;
            condition.Currency = currency;
            condition.TransactionType = TransactionType.Shipping;
            condition.ArticleGroups = articleGroups.ToList();
            condition.ValueType = CalulationPrincipleValueType.Value;
            condition.Value = deliverCost;
            condition.TurnoverTo = limit;
            condition.TurnoverFrom = 0;
            condition.CalculationGroup = calculationGroup;

            if (!conditions.Contains(condition))
                conditions.Add(condition);
        }


    }
}
