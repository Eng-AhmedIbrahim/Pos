﻿namespace POS.Core.Specifications.MenuSalesItemsSpecs;

public class MenuSalesItemsWithIncludeSpec : BaseSpecifications<MenuSalesItems>
{
    public MenuSalesItemsWithIncludeSpec()
    {
        AddInclude();
    }

    public MenuSalesItemsWithIncludeSpec(int id)
        : base(s => s.Id.Equals(id))
    {
        AddInclude();
    }

    private void AddInclude()
    {
        Includes.Add(s => s.Attribute!);
        IncludeStrings.Add($"{nameof(MenuSalesItems.Attribute)}.{nameof(Attributes.AttributeItems)}.{nameof(AttributeItem.RelatedMenuItem)}");
    }
}