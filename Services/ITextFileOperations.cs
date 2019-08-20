using System.Collections.Generic;

namespace Visitor_Management_System2019student.Services
{
    public interface ITextFileOperations
    {
        IEnumerable<string> LoadConditionsForAcceptanceText();
    }
}