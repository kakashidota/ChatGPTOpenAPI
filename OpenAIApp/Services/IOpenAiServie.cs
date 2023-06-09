namespace OpenAIApp.Services
{
    public interface IOpenAiServie
    {
        Task<string> CompleteSentence(string text);
        Task<string> CompleteSentenceAdvance(string text);
        Task<string> CheckProgramingLanguage(string language);
    }

}
