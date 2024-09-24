using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace MonkeyIslandApi
{
    public class ApiCaller
    {
        #region Variables

        public HttpClient ApiClient = null;

        #endregion


        #region Methods

        public bool Open(string urlString)
        {

            Uri baseUri;
            if (Uri.TryCreate(urlString, UriKind.Absolute, out baseUri))
            {
                ApiClient = new HttpClient(); //creo un'istanza per comunica con un client API
                ApiClient.BaseAddress = baseUri; //assegno l'indirizzo base a tale istanza 
                ApiClient.Timeout = new TimeSpan(0, 1, 0); //imposto l'intervallo entro il quale deve scattare il timeout se non ricevo risposte dalla chiamata 
                ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")); //tipo di dati utilizzato per la comunicazione 
                //se tutto va a buon fine restituisco true
                return true;
            }

            //altrimenti restituisco false
            return false;

        }

        public void Close()
        {
            //dispose delle risorse
            ApiClient?.Dispose();
            //indico al garbage collector che l'area di memoria effettivamente non è più utilizzata
            ApiClient = null; 
        }

        #endregion
    }
}
