using MediatR;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.MasterSetting.QuestionSettingDetail.Commands
{
    public class SubmitQuestionSettingDetailCommand : IRequest<ApiResponse>
    {
        [JsonProperty("quest_detail_id")]
        public int? QuestDetailId { get; set; }

        [JsonProperty("questionnaire_code")]
        public string QuestionnaireCode { get; set; }

        [JsonProperty("is_category")]
        public bool IsCategory { get; set; }

        [JsonProperty("question")]
        public string Question { get; set; }

        [JsonProperty("quest_parent")]
        public int? QuestParent { get; set; }

        [JsonProperty("scoring_code")]
        public string ScoringCode { get; set; }

        [JsonProperty("order")]
        public int Order { get; set; }

        [JsonProperty("attachment")]
        public string Attachment { get; set; }

        [JsonProperty("multi_choice_option")]
        public string MultiChoiceOption { get; set; }

        [JsonProperty("correct_answer")]
        public string CorrectAnswer { get; set; }

        [JsonProperty("weight_point")]
        public int? WeightPoint { get; set; }

        [JsonProperty("action")]
        public string Action { get; set; }
    }
}
