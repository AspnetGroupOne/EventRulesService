using Core.Domain.Models;

namespace Presentation.Factory;

public class FormFactory
{
    public static AddRulesForm Create(AddRulesRequest rulesRequest)
    {
        if (rulesRequest == null) return null!;

        var addRulesForm = new AddRulesForm() 
        {
            EventId = rulesRequest.EventId,
            RuleItems = rulesRequest.RuleItems
        };
        return addRulesForm;
    }

    public static AddRulesForm Create(UpdateRulesRequest updateRulesRequest)
    {
        if (updateRulesRequest == null) return null!;

        var updateRulesForm = new AddRulesForm()
        {
            EventId = updateRulesRequest.EventId,
            RuleItems = updateRulesRequest.RuleItems
        };
        return updateRulesForm;
    }

}
