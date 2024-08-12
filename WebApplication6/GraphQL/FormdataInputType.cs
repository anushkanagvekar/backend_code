using GraphQL.Types;
using WebApplication6.Models;

namespace WebApplication6.GraphQL
{
    public class FormdataInputType : InputObjectGraphType<Formdata>
    {
        public FormdataInputType()
        {
            Name = "FormdataInput";
            Field(x => x.Name).Description("The name of the form data.");
            Field(x => x.Description).Description("The description of the form data.");
            Field(x => x.Monitor).Description("The monitor associated with the form data.");
            Field(x => x.TestUrl).Description("The test URL associated with the form data.");
            Field(x => x.RequestType).Description("The request type of the form data.");
            Field(x => x.IsActive).Description("Indicates if the form data is active.");
            Field(x => x.StartDate).Description("The start date of the form data.");
            Field(x => x.EndDate).Description("The end date of the form data.");
        }
    }
}
