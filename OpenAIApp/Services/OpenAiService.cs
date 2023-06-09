using Microsoft.Extensions.Options;
using OpenAI_API;
using OpenAI_API.Completions;
using OpenAI_API.Models;
using OpenAIApp.Configurations;

namespace OpenAIApp.Services
{
    public class OpenAiService : IOpenAiServie
    {
        private readonly OpenAIConfig _openAiConfig;

        public OpenAiService()
        {
        }

        public OpenAiService(IOptionsMonitor<OpenAIConfig> optionsMonitor)
        {
            _openAiConfig = optionsMonitor.CurrentValue;
        }


        public async Task<string> CompleteSentence(string text)
        {
            var api = new OpenAIAPI(_openAiConfig.Key);
            var result = await api.Completions.GetCompletion(text);
            return result;
        }

    

        public async Task<string> CompleteSentenceAdvance(string text)
        {
            var api = new OpenAIAPI(_openAiConfig.Key);
            var result = await api.Completions.CreateCompletionAsync(new CompletionRequest(text, model: Model.CurieText, temperature: 0.1));

            Console.WriteLine(result.ToString());
            return result.Completions[0].Text;
        }
        public async Task<string> CheckProgramingLanguage(string language)
        {
            var api = new OpenAIAPI(_openAiConfig.Key);
            var chat = api.Chat.CreateConversation();

            chat.AppendSystemMessage("You are  a teacher who help new programmers understand if a term is a programming language or not. If the user tells you a programming language. If the user tells you something that isnt a programming language respond with no. You will only respond with yes or no. You do not say anything else");
            chat.AppendUserInput(language);
            var response = await chat.GetResponseFromChatbotAsync();
            return response;
        }
    }
}
