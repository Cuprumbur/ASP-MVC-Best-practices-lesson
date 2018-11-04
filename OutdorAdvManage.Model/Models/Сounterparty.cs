namespace OutdorAdvManage.Model.Models
{
    /// <summary>
    /// Контарагент. Описывает юридическое или физическое лицо
    /// </summary>
    public class Counterparty
    {
        public int CounterpartyId { get; set; }

        public string NameCompany { get; set; }
        public bool IsLegalEntity;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
    }
}