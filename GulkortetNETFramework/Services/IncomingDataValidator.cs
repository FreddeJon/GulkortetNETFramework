using System.Collections.Generic;
using System.Threading.Tasks;
using GulkortetNETFramework.Repositories.Interfaces;
using GulkortetNETFramework.Responses;
using GulkortetNETFramework.Services.Interfaces;

namespace GulkortetNETFramework.Services
{
    public class IncomingDataValidator : IIncomingDataValidator
    {

        // Propeties
        private readonly ICardRepository _cardRepository;
        private readonly IUserRepository _userRepository;


        // CTOR med DI, tar in IUserRepository och IUserManager
        public IncomingDataValidator(IUserRepository userRepository, ICardRepository cardRepository)
        {
            _userRepository = userRepository;
            _cardRepository = cardRepository;
        }


        // Metod som används för att validera inkommande meddelande
        public async Task<ValidatedDataResponse> Validate(string incomingMessage)
        {

            // Skapar upp en response
            var response = new ValidatedDataResponse();

            // Returnar responsen med fail om incomingmessage är null
            if (string.IsNullOrEmpty(incomingMessage))
            {
                response.Message = "Ogiltigt inkommande meddelande";
                return response;
            }

            // En try catch för att fånga fails
            try
            {
                // Splitar meddelandet på "-"
                var array = incomingMessage.Split('-');


                // Kollar om formatet är valid via en metod, annars returnar den fail response
                if (!IsValidFormat(array))
                {
                    response.Message = "Ogiltigt format";
                    return response;
                }

                // Tar ut userNumber och cardNumber från arrayen
                var userNumber = array[0];
                var cardNumber = array[1];


                // Kollar om användaren finns returnar fail om det inte finns
                if (!await _userRepository.CheckValidity(x => x.AnvändarNr == userNumber))
                {
                    response.Message = "Ogiltigt användarnummer eller kortnummer";
                    return response;
                }

                // Kollar om kortet finns returnar fail om det inte finns
                if (!await _cardRepository.CheckValidity(x => x.KortNr == cardNumber))
                {
                    response.Message = "Ogiltigt användarnummer eller kortnummer";
                    return response;
                }

                // Hämtar ut användaren och kortet returnar true
                response.User = await _userRepository.ReadEntity(x => x.AnvändarNr == userNumber);
                response.Card = await _cardRepository.ReadEntity(x => x.KortNr == cardNumber);
                response.IsValid = true;
            }
            catch
            {
                // ignored
            }


            return response;
        }


        // Kollar arrayen och ser om den är valid
        private static bool IsValidFormat(IReadOnlyList<string> array)
        {

            // Kollar om arrayen är rätt längd
            if (array.Count != 2)
            {
                return false;
            }


            // Kollar om Användar strängen är valid
            if (!array[0].ToUpper().StartsWith("A") || array[0].Length != 8)
            {
                return false;
            }

            // Kollar om Kort strängen är valid
            if (!array[1].ToUpper().StartsWith("K") || array[1].Length != 10)
            {
                return false;
            }

            return true;
        }
    }
}