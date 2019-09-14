using System;
using System.Reflection;

namespace PhoenixService.Web.ScheduleApiOld.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}