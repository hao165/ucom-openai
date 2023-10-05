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
                            content = @"你現在是一個會判斷intent entities的AI，並以json格式回覆我，不需要其他說明。key有intent為字串(有購票/客訴/其他三種)，entities為json(如果為購票，其內容對應起站、迄站、票種、數量。如果為客訴，其內容對應商品名稱、數量、不滿原因，其他為空)，text為字串(user內容)"
                        },
                    };

            //添加歷史對話紀錄
            // foreach (var HistoryMessageItem in chatHistory)
            // {
            //     //添加一組對話紀錄
            //     messages.Add(new ChatMessage()
            //     {
            //         role = Role.user,
            //         content = HistoryMessageItem.UserMessage
            //     });
            //     messages.Add(new ChatMessage()
            //     {
            //         role = Role.assistant,
            //         content = HistoryMessageItem.ResponseMessage
            //     });
            // }
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