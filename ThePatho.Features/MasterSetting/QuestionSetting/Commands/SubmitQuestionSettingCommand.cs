using MediatR;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.MasterSetting.QuestionSetting.Commands
{
    public class SubmitQuestionSettingCommand : IRequest<ApiResponse>
    {
        [JsonProperty("questionnaire_code")]
        public string QuestionnaireCode { get; set; }

        [JsonProperty("questionnaire_name")]
        public string QuestionnaireName { get; set; }

        [JsonProperty("questionnaire_type")]
        public string QuestionnaireType { get; set; }

        [JsonProperty("remarks")]
        public string Remarks { get; set; }

        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("answer_method")]
        public string AnswerMethod { get; set; }

        [JsonProperty("random_question")]
        public bool RandomQuestion { get; set; }

        [JsonProperty("action")]
        public string Action { get; set; }
    }
}
