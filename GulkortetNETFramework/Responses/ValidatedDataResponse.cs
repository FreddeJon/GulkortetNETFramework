using GulkortetNETFramework.Models;

namespace GulkortetNETFramework.Responses
{
    // En response klass från IncomingDataValidator
    public class ValidatedDataResponse
    {
        // En ctor som säger att resonsen är false
        public ValidatedDataResponse()
        {
            IsValid = false;
        }

        // Några properties
        public bool IsValid { get; set; }
        public string Message { get; set; }
        public Kunder User { get; set; }
        public Kort Card { get; set; }


        // En overridead toString metod som returnar ett meddelande beroende på om det är giltigt eller inte
        public override string ToString()
        {
            if (IsValid)
            {
                return
                    $"Grattis {User.Namn}!\nDu har vunnit det exlusiva {Card.KortTyp}-Kortet!\nDu kan hämta det i din lokala butik i {User.Kommun}";
            }

            return Message;
        }
    }
}