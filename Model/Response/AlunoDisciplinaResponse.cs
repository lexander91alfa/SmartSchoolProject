using Newtonsoft.Json;

namespace SmartSchool.API.Model.Response
{
    public class AlunoDisciplinaResponse
    {
        [JsonProperty("aluno_id")]
        public int AlunoId { get; set; }
        [JsonProperty("disciplina_id")]
        public int DisciplinaId { get; set; }
    }
}