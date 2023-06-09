using Microsoft.AspNetCore.Mvc;
using OpenAIApp.Services;

namespace OpenAIApp.Controllers
{
    public class ApiController : Controller
    {
        public IOpenAiServie _openAiService;

        [ActivatorUtilitiesConstructor]
        public ApiController(IOpenAiServie openAiService)
        {
            _openAiService = openAiService;
        }

        public ApiController()
        {
        }

        [HttpPost()]
        [Route("CompleteSentence")]
        public async Task<IActionResult> CompleteSentence(string text)
        {
            var result = await _openAiService.CompleteSentenceAdvance(text);
            return Ok(result);
        }


        [HttpPost()]
        [Route("AskAQuestion")]
        public async Task<IActionResult> AskQuestion(string text)
        {
            if(IsValidInput(text))
            {
                var result = await _openAiService.CheckProgramingLanguage(text);
                return Ok(result);
            }

            return BadRequest();
           
        }

        public bool IsValidInput(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }

            if (input.Length > 4096) // OpenAI API limit
            {
                return false;
            }

            return true;
        }

    }
}
