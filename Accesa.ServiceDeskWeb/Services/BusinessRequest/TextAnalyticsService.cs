
using Accesa.ServiceDeskWeb;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;


namespace Accesa.ServiceDeskWeb.Services
{
    public class TextAnalyticsService
    {
        private const string apiKey = "515cd658e14d42e0803bf4d5628cc921";
        private const string sentimentUri = "https://westus.api.cognitive.microsoft.com/text/analytics/v2.0/sentiment";
        private const string keyPhrasesUri = "https://westus.api.cognitive.microsoft.com/text/analytics/v2.0/keyPhrases";
        private const string languageUri = "https://westus.api.cognitive.microsoft.com/text/analytics/v2.0/languages";
        WebClient client;
        public TextAnalyticsService()
        {
            client = new WebClient();
            client.Headers.Add("Ocp-Apim-Subscription-Key", apiKey);
            client.Headers.Add("Content-Type", "application/json");
            client.Headers.Add("Accept", "application/json");
        }
        public IEnumerable<string> GetKeyPhrases(string text)
        {
            string textServiceDesk = SerializeText(text);
            var responseKeyPhrases = client.UploadString(keyPhrasesUri, textServiceDesk);
            var responseKeyPhrasesObj = JsonConvert.DeserializeObject<ResponseKeyPhrases>(responseKeyPhrases);
            IEnumerable<string> keyPhrases = responseKeyPhrasesObj.documents.SelectMany((s => s.keyPhrases));
            return keyPhrases;
        }
        public ResponseLanguage GetLanguage(string languageText)
        {
            var responseLanguage = client.UploadString(languageUri, languageText);
            var responseLanguageObj = JsonConvert.DeserializeObject<ResponseLanguage>(responseLanguage);
            return responseLanguageObj;
        }
        public ResponseSentiment GetSentiment(string sentimentText)
        {
            var responseSentiment = client.UploadString(sentimentUri, sentimentText);
            var responseSentimentObj = JsonConvert.DeserializeObject<ResponseSentiment>(responseSentiment);
            return responseSentimentObj;
        }
        private string SerializeText(string text)
        {
            PostData documentObj = new PostData();
            Document document = new Document();
            document.id = "1";
            document.text = text;
            documentObj.documents = new List<Document>();
            documentObj.documents.Add(document);
            string postDocument = JsonConvert.SerializeObject(documentObj);

            return postDocument;
        }
    }
}


