namespace ref_2;
public class DefaultViolationDescriptionProvider : IViolationDescriptionProvider
{
    private readonly Dictionary<int, string> _violationDescriptions = new()
    {
        { 1, "Превышение скорости" },
        { 2, "Проезд на красный свет" }
    };

    public string GetViolationDescription(int violationCode)
    {
        if (_violationDescriptions.TryGetValue(violationCode, out string description))
        {
            return description;
        }

        return "Неизвестное нарушение";
    }
}
