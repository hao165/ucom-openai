using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;

namespace isRock.Template
{
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum Role
    {
        assistant, user, system
    }

    public class ChatGPT
    {
        const string AzureOpenAIEndpoint = "https://testopenai202303.openai.azure.com";  //👉replace it with your Azure OpenAI Endpoint
        const string AzureOpenAIModelName = "gpt35"; //👉repleace it with your Azure OpenAI Model Name
        const string AzureOpenAIToken = "b878253b12344f709b8d26df1c36a092"; //👉repleace it with your Azure OpenAI Token
        const string AzureOpenAIVersion = "2023-03-15-preview";  //👉replace  it with your Azure OpenAI Model Version

        public static string CallAzureOpenAIChatAPI(
            string endpoint, string modelName, string apiKey, string apiVersion, object requestData)
        {
            var client = new HttpClient();

            // 設定 API 網址
            var apiUrl = $"{endpoint}/openai/deployments/{modelName}/chat/completions?api-version={apiVersion}";

            // 設定 HTTP request headers
            client.DefaultRequestHeaders.Add("api-key", apiKey);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));//ACCEPT heade
            // 將 requestData 物件序列化成 JSON 字串
            string jsonRequestData = Newtonsoft.Json.JsonConvert.SerializeObject(requestData);
            // 建立 HTTP request 內容
            var content = new StringContent(jsonRequestData, Encoding.UTF8, "application/json");
            // 傳送 HTTP POST request
            var response = client.PostAsync(apiUrl, content).Result;
            // 取得 HTTP response 內容
            var responseContent = response.Content.ReadAsStringAsync().Result;
            var obj = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(responseContent);
            return obj.choices[0].message.content.Value;
        }


        public static string getResponseFromGPT(string Message, List<Message> chatHistory)
        {
            //建立對話紀錄
            var messages = new List<ChatMessage>
                    {
                        new ChatMessage {
                            role = Role.system ,
                            content = @"你現在是一個請假系統，你有兩個功能，1.大家可以向你請假，你需要索取員工編號、請假時間-起(西元年月日時分)、請假時間-日(西元年月日時分)，2.當有人索取『請假清單』時，將資料整理成表格輸出。"
                        },
                    };

            //添加歷史對話紀錄
            foreach (var HistoryMessageItem in chatHistory)
            {
                //添加一組對話紀錄
                messages.Add(new ChatMessage()
                {
                    role = Role.user,
                    content = HistoryMessageItem.UserMessage
                });
                messages.Add(new ChatMessage()
                {
                    role = Role.assistant,
                    content = HistoryMessageItem.ResponseMessage
                });
            }
            messages.Add(new ChatMessage()
            {
                role = Role.user,
                content = Message
            });
            //回傳呼叫結果
            return ChatGPT.CallAzureOpenAIChatAPI(
               AzureOpenAIEndpoint, AzureOpenAIModelName, AzureOpenAIToken, AzureOpenAIVersion,
                new
                {
                    model = "gpt-3.5-turbo",
                    messages = messages
                }
             );
        }
    }

    public class ChatMessage
    {
        public Role role { get; set; }
        public string content { get; set; }
    }

}