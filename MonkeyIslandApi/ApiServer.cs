using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MonkeyIslandApi
{
    public class ApiServer
    {
        #region Class, Delegates and Events

        public class PostReceivedEventArgs : EventArgs
        {
            public string BodyResult { get; private set; }

            public PostReceivedEventArgs(string bodyResult) { this.BodyResult = bodyResult; }

        };
        public delegate void PostReceivedEventHandler(object sender, PostReceivedEventArgs e);


        public event EventHandler EventListeningError;
        public event PostReceivedEventHandler EventPostReceived;

        #endregion


        #region Variables

        public HttpListener ApiListener = null;
        private bool isRunning;

        #endregion


        #region Methods

        public bool Start(string urlString)
        {
            try
            {
                ApiListener = new HttpListener();
                ApiListener.Prefixes.Add(urlString); // imposto l'endpoint su cui ascoltare
                ApiListener.Start(); //avvio il listener
                isRunning = true;
                Console.WriteLine($"Listener successfully created");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Listener failed to create, not possibile to continue: {ex}");
                return false;
            }

            try
            {
                Task.Run(() => HandleRequests()); //apro un task con cui rimango in ascolto sulle chiamate in arrivo
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in handling the request: {ex}");
                return false;
            }


            return true;
        }

        public void Stop()
        {
            //dispose delle risorse
            ApiListener?.Stop();
            //indico al garbage collector che l'area di memoria effettivamente non è più utilizzata
            ApiListener = null;
        }

        private async Task HandleRequests()
        {
            while (isRunning) //se il listener è in corso = è stato eseguito lo start
            {
                // aspetto una richiesta
                var context = await ApiListener.GetContextAsync();
                var request = context.Request;
                var response = context.Response;

                if (request.HttpMethod == "POST") //se la richiesta è una POST proseguo
                {
                    try
                    {
                        // leggo il contenuto del body della richiesta
                        using (var reader = new System.IO.StreamReader(request.InputStream, request.ContentEncoding))
                        {
                            string requestBody = await reader.ReadToEndAsync();
                            // elaboro il body della richiesta POST collegandomi all'evento dedicato
                            EventPostReceived?.Invoke(this, new PostReceivedEventArgs(requestBody));
                            Console.WriteLine(requestBody);
                        }
                    }
                    catch
                    {
                        // se l'elaborazione della richiesta non è andata a buon fine lancio un evento 
                        EventListeningError?.Invoke(this, new EventArgs());
                    }

                    // elaboro una risposta da mandare al client, in questo caso una stringa vuota
                    string responseString = "";
                    byte[] buffer = Encoding.UTF8.GetBytes(responseString); //converto la risposta in un array di byte per poterla inviare
                    response.ContentLength64 = buffer.Length; //imposto la lunghezza della risposta in byte
                    var output = response.OutputStream; //recupero lo stream output per inviare effettivamente i dati
                    await output.WriteAsync(buffer, 0, buffer.Length); //invio i dati/la risposta al client
                    output.Close(); //chiudo lo stream output

                }
            }
        }

        #endregion
    }
}
