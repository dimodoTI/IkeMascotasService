using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;



namespace mails
{
    public interface IikeMailService
    {
        Task<responseMail> sendReservaMail(string body, string emailDestinatario);
    }
    public class responseMail
    {

        public bool procesado { get; set; }
        public responseError error { get; set; }


    }
    public class responseError
    {

        public int codigo { get; set; }
        public string descripcion { get; set; }
        public int origen_error { get; set; }

    }
    public class IkeMailService : IikeMailService
    {
        private const string BaseUrl = "https://www.ikeargentina.com.ar/ikeapirestful/api/sendemail";

        private readonly HttpClient _client;

        private readonly string _token;
        public IkeMailService(HttpClient client, string token)
        {
            _client = client;
            _token = token;
        }
        public class requestMail
        {

            public string token { get; set; }
            public string email_destinatario { get; set; }
            public string nombre_destinatario { get; set; }
            public string parametro_1 { get; set; }
            public string parametro_2 { get; set; }
            public string cuerpo { get; set; }
            public int id_tipo_comunicacion { get; set; }

        }





        public Task<responseMail> sendReservaMail(string body, string emailDestinatario)
        {

            var request = new requestMail
            {
                token = _token,
                id_tipo_comunicacion = 4,
                parametro_1 = body,
                email_destinatario = emailDestinatario,
                nombre_destinatario = "Veterinarios IKE",
                parametro_2 = "Aviso de Reserva de Turno",
                cuerpo = "",


            };

            return sendMailAsync(request);

        }

        private async Task<responseMail> sendMailAsync(requestMail request)
        {
            var content = JsonConvert.SerializeObject(request);

            var httpResponse = await _client.PostAsync(BaseUrl, new StringContent(content, Encoding.Default, "application/json"));

            if (!httpResponse.IsSuccessStatusCode)
            {
                // ver que pasa si no puede enviar el mail
                //throw new Exception("Cannot add a todo task");
            }

            var createdTask = JsonConvert.DeserializeObject<responseMail>(await httpResponse.Content.ReadAsStringAsync());

            return createdTask;
        }



    }
}