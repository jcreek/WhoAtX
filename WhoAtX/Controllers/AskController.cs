using Microsoft.AspNetCore.Mvc;
using Microsoft.SemanticKernel;

namespace WhoAtX.Controllers;

public class AskController : Controller
{
    private readonly IConfiguration _config;
    private readonly IKernel _kernel;
    private readonly ILogger<AskController> _logger;

    public AskController(ILogger<AskController> logger, IConfiguration config)
    {
        _logger = logger;
        _config = config;

        // N.B. Swap this if not using Using Azure 
        _kernel = new KernelBuilder()
            .WithAzureChatCompletionService(
                _config["OpenAi:DeploymentName"] ?? throw new Exception("DeploymentName is null"),
                _config["OpenAi:Endpoint"] ?? throw new Exception("Endpoint is null"),
                _config["OpenAi:ApiKey"] ?? throw new Exception("ApiKey is null")
            )
            // .WithOpenAIChatCompletionService()
            .Build();
    }

    public async Task<JsonResult> WhoCanHelpWithX(string queryText)
    {
        // Define the semantic function
        const string promptTemplate = """
                                      Who at my organisation can help me with my query?

                                      ===== QUERY =====
                                      {{$input}}
                                      ===== END QUERY =====

                                      Please ensure that you respond in a professional and courteous manner, making full use of the information about relevant employees. This includes:
                                      - Name
                                      - Team
                                      - Link to their user profile (using the Id)
                                      - Areas of knowledge
                                      - Projects
                                      
                                      If the query is not about finding someone within my organisation to then please only respond to tell me that you can only help with queries about finding someone within my organisation.

                                      Engage.
                                      """;
        var whoCanHelpWithXFunction = _kernel.CreateSemanticFunction(promptTemplate);

        // Perform the ask
        var result = (await whoCanHelpWithXFunction.InvokeAsync(queryText, _kernel))
            .GetValue<string>();
        
        // TODO(#15) - add the NL2SQL plugin to retrieve data from the SQL database, enabling this query to access the relevant data. It must be run using a read-only user to ensure that it cannot change data.
        return Json(result);
    }
}