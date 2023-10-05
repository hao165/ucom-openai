ChatGPT(OpenAI API)與對談機器人開發實戰(2 day) - UUU - 2023/10/4, 5
doc url: https://wwjd.tw/608k615

挑戰賽: (Google sheet)
https://docs.google.com/spreadsheets/d/1L7bQX55mKutJFrOp9aE0gkItowMlCmtJyaNlogzrUsc/edit?usp=sharing

貼上圖片換URL:
https://hackmd.io/usaHN0xhR5ur2MxBXCobFw?both

上傳圖片取得網址:
http://imgur.com or https://zh-tw.imgbb.com/ or https://upload.cc/

📚學員上課環境：
建議使用 Windows 10/11(中文版)
建議使用 Edge 瀏覽器
Postman
https://www.getpostman.com/downloads/
Visual Studio Code
https://code.visualstudio.com/
.net core SDK 5.0+
https://dotnet.microsoft.com/download
Visual Studio community (optional, windows only)
https://visualstudio.microsoft.com/zh-hant/vs/community/
📡網路與硬體環境需求
由於大量實作均需要連上雲端，建議網路速度不低於100M的上課環境較佳
網路需要可以連線上網(80, 443)，請勿阻擋 3389, 1433等port.
⛳課前預備與帳號申請
申請個人 Microsoft Account 帳號(若您已有一般 hotmail.com 或 outlook.com 信箱，該信箱即是 Microsoft Account)，不建議採用公司帳號
若您不確定是否已擁有 Microsoft Account，可於底下網址申請一個全新的:
https://account.microsoft.com/account?lang=zh-tw

請用剛才申請的『個人 Microsoft Account』帳號申請免費 Azure 訂閱(subscription) 以便於進入Azure Portal (需綁信用卡，但無須付費)
(請務必於上課前申請，上課中申請失敗率非常高，同一個對外IP短時間內無法多次申請)
https://azure.microsoft.com/zh-tw/free/
🔥🔥🔥(重要) 建立好 Azure 訂閱(subscription)之後，填寫下列表格申請 Azure Open AI服務(建議於上課前15天完成)
https://aka.ms/oai/access
🔥🔥🔥(重要) 建立好 Azure 訂閱(subscription)之後，填寫下列表格申請 Azure Cognitive Services服務(建議於上課前15天完成)
https://learn.microsoft.com/zh-tw/azure/cognitive-services/cognitive-services-limited-access
開發工具
VS Code:
https://code.visualstudio.com/

VS 2019/2022 community(good enough):
https://visualstudio.microsoft.com/zh-hant/downloads/

Postman:
https://www.postman.com/
https://www.postman.com/downloads/

相關SDK與工具(先安裝VS2019/2022):
Bot Framework v4 SDK Templates for Visual Studio:
https://marketplace.visualstudio.com/items?itemName=BotBuilder.botbuilderv4

BotFramework-Emulator:
https://github.com/microsoft/BotFramework-Emulator/releases/download/v4.11.0/BotFramework-Emulator-4.11.0-windows-setup.exe

ChatGPT
👉取得 OpenAI API key(需信用卡、會有小額費用):
https://platform.openai.com/account/api-keys

👉Sample OpenAI API Key:
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

Lab 1 : 使用 postman 呼叫 OpenAI completion API


步驟:

查詢文件, 找到completion API
https://platform.openai.com/docs/api-reference/completions
使用 postman 呼叫API
endpoint : https://api.openai.com/v1/completions
Authorization: Bearer OPENAI_API_KEY
輸入API key, 組出request
{
  "model": "text-davinci-003",
  "prompt": "什麼是人工智慧? 這是",
  "max_tokens": 1000,
  "temperature": 0.8
}
取得response, 檢視結果 <== 截圖
Lab 2 : 使用 postman 呼叫 image generations API
步驟:

查詢文件, 找到image generations API
https://platform.openai.com/docs/api-reference/images/create
使用postman, 組出request, 輸入API key
POST /v1/images/generations HTTP/1.1
Host: api.openai.com
Authorization: Bearer [replace key]
Content-Type: application/json
Content-Length: 65

{
  "prompt": "夕陽下孤獨的身影" , 
  "n": 1,
  "size": "1024x1024"
}
取得response, 檢視結果
Lab 3 : 使用 OpenAI API 呼叫ChatGPT進行對談
POST /v1/chat/completions HTTP/1.1
Host: api.openai.com
Authorization: Bearer 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
Content-Type: application/json
Content-Length: 138

{
  "model": "gpt-3.5-turbo",
  "max_tokens" : 300, 
  "temperature" : 0.1, 
  "messages": [{"role": "user", "content": "我今天心情很好"}]
}
LINE BOT
建立 line bot
https://developers.line.biz/en/

NGROK:
👉申請帳號:
https://dashboard.ngrok.com/signup
👉download ngrok:
https://ngrok.com/download
or
https://bin.equinox.io/c/bNyj1mQVY4c/ngrok-v3-stable-windows-amd64.zip

Lab 4: create a ChatGPT bot
create a line bot (messaging api)
https://developers.line.biz/en/
get Channel access token and Your UserID
create a new webapi project
md testbot
cd testbot
dotnet new webapi
dotnet new --install isRock.Template.LineWebHook::1.0.17 
# https://arock.blob.core.windows.net/blogdata202310/LineBotChatGPTWebHookController.cs
dotnet add package linebotsdk
dotnet new linewebhook
code .
#編輯程式碼
dotnet run    
final version:
git clone https://github.com/isdaviddong/test20231002bot.git

run ngrok command:

ngrok authtoken 2eeb482nM____your____token____V3Ar4
ngrok http 5000 --host-header="localhost:5000" 
sample code:
https://gist.github.com/isdaviddong/5c630c9a97720962fc52ef766dbb7530#file-openailinebot-cs

//基本的 OpenAI ChatGPT WebHook
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;

namespace isRock.Template
{
    public class LineBotChatGPTWebHookController : isRock.LineBot.LineWebHookControllerBase
    {
        [Route("api/LineBotChatGPTWebHook")]
        [HttpPost]
        public IActionResult POST()
        {
            const string AdminUserId = "_____Admin_User_ID_________"; //👉repleace it with your Admin User Id

            try
            {
                //設定ChannelAccessToken
                this.ChannelAccessToken = "____LINE_Channel_Access_Token____"; //👉repleace it with your Channel Access Token
                //配合Line Verify
                if (ReceivedMessage.events == null || ReceivedMessage.events.Count() <= 0 ||
                    ReceivedMessage.events.FirstOrDefault().replyToken == "00000000000000000000000000000000") return Ok();
                //取得Line Event
                var LineEvent = this.ReceivedMessage.events.FirstOrDefault();
                var responseMsg = "";
                //準備回覆訊息
                if (LineEvent.type.ToLower() == "message" && LineEvent.message.type == "text")
                {
                    responseMsg = ChatGPT.getResponseFromGPT(LineEvent.message.text);
                }
                else if (LineEvent.type.ToLower() == "message")
                    responseMsg = $"收到 event : {LineEvent.type} type: {LineEvent.message.type} ";
                else
                    responseMsg = $"收到 event : {LineEvent.type} ";
                //回覆訊息
                this.ReplyMessage(LineEvent.replyToken, responseMsg);
                //response OK
                return Ok();
            }
            catch (Exception ex)
            {
                //回覆訊息
                this.PushMessage(AdminUserId, "發生錯誤:\n" + ex.Message);
                //response OK
                return Ok();
            }
        }
    }

    public class ChatGPT
    {
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public enum role
        {
            assistant, user, system
        }

        public static string CallOpenAIChatAPI(object requestData)
        {
            var client = new HttpClient();

            // 設定 API 網址
            var apiUrl = $"https://api.openai.com/v1/chat/completions";

            // 設定 HTTP request headers
            client.DefaultRequestHeaders.Add("Authorization", "Bearer sk-sEoH______open_ai_api_key_____qQTZU");
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


        public static string getResponseFromGPT(string Message)
        {
            return ChatGPT.CallOpenAIChatAPI(
                new
                {
                    model = "gpt-3.5-turbo",
                    messages = new[]
                    {
                        new {
                            role = ChatGPT.role.system ,
                            content = @"
                                假設你是一個專業客戶服務人員，對於客戶非常有禮貌、也能夠安撫客戶的抱怨情緒。
                                請檢視底下的客戶訊息，以最親切有禮的方式回應。

                                但回應時，請注意以下幾點:
                                * 不要說 '感謝你的來信' 之類的話，因為客戶是從對談視窗輸入訊息的，不是寫信來的
                                * 不能過度承諾
                                * 要同理客戶的情緒
                                * 要能夠盡量解決客戶的問題
                                * 不要以回覆信件的格式書寫，請直接提供對談機器人可以直接給客戶的回覆
                                ----------------------
"
                        },
                        new {
                             role = ChatGPT.role.user,
                              content = Message
                             },
                    }
                });
        }
    }
}
如果出現 307 error, 請在程式碼中槓掉
//app.UseHttpsRedirection();

如果 build error , 請在程式碼中補上
using System.Net.Http;

Lab 5 : 加入企業資料(包含菜單的點餐機器人)
使用上一個lab做出的 chat bot
修改prompt
你是餐飲店的客服機器人，會回答客戶詢問的餐點問題，並且推薦讓店裡獲利最高的產品。你也能處裡客戶的抱怨和申訴，安撫客戶情緒。
目前店裡面所販賣的產品有底下這些:
大亨堡，45元
麥香雞，36元
蛋餅，27元
可麗餅，50元
飯糰，45元
而飲料有底下這些:
可樂，55元
紅茶，35元
奶茶，45元
店裡沒有套餐，只能把餐點和飲料搭配銷售，這樣搭配沒有折扣。此外，跟客人推薦餐點時，必須是上述的清單中的餐點。
目前唯一的優惠是周日早上買一送一，只限單點大亨堡才有這個優惠。
----------------------
加入history
user: 請告訴我最便宜的餐點價格。
assistant: 你可以點選蛋餅，只需要27元
user: 有什麼好吃的餐點嗎?
assistant: 這個問題很主觀，不同的人有不同的口味喜好，以下是我個人的推薦:
1. 大亨堡：這是我們餐廳的招牌餐點，肉質鮮美，搭配特製的醬料非常美味
2. 麥香雞：這是一個很受歡迎的餐點，雞肉鮮嫩，外皮酥脆，非常適合當作午餐或晚餐 
3. 可麗餅：這是一個很受歡迎的早餐餐點，口感軟嫩，搭配楓糖漿和奶油非常美味
user: 我想要吃飽一點，你可以推薦我豐盛的套餐嗎?
assistant: 很抱歉，我們店裡沒有套餐，只能把餐點和飲料搭配銷售。
但是，如果你想吃得飽一點，我建議你可以考慮以下搭配：
1. 大亨堡 + 可樂：肉質鮮美，搭配可樂口感更佳。
2. 麥香雞 + 紅茶：雞肉鮮嫩，搭配紅茶口感更清爽。
3. 飯糰 + 奶茶：飯糰營養豐富，搭配奶茶口感更香濃。
希望這些搭配可以滿足你的食慾需求！
user: 這些搭配套餐分別是多少錢?
assistant: 很抱歉，我剛才的回答有點不清楚，我重新提供給你更詳細的價格資訊:
1. 大亨堡 + 可樂 = 100元 (大亨堡 45元 + 可樂 55元)
2. 麥香雞 + 紅茶 = 71元 (麥香雞 36元 + 紅茶 35元)
3. 飯糰 + 奶茶 = 90元 (飯糰 45元 + 奶茶 45元)
希望這些資訊可以幫助到你！
ref code:
https://gist.githubusercontent.com/isdaviddong/5c630c9a97720962fc52ef766dbb7530/raw/bae22e66b3b8a85ade70d9eba7be7f7488eab95c/LineBotChatGPTWebHookFor%25E6%2597%25A9%25E9%25A4%2590%25E5%25BA%2597Controller.cs

Lab 6 : 使用 Azure OpenAI API 呼叫ChatGPT進行對談
POST /openai/deployments/gpt35/chat/completions?api-version=2023-03-15-preview HTTP/1.1
Host: testopenai202303.openai.azure.com
api-key: b60c24fad0f2c3c88bffe
Content-Type: application/json
Content-Length: 98

{
  "model": "gpt-3.5-turbo",
  "messages": [{"role": "user", "content": "DevOps對軟體開發很重要嗎?"}]
}
Lab 7: 點餐機器人
承上例，修改原本的line bot
參考底下程式碼建立點餐機器人
https://gist.githubusercontent.com/isdaviddong/0226973d7170d87628909517b0bcb326/raw/993e1750e0f4b7ed4d444b902bac252ecf08be2b/SampleAzureOpenAILINEWebHook.cs
嘗試詢問優惠餐點 <= 截圖
Lab 8: Azure OpenAI SDK
參考資訊 :
endpoint: https://testopenai202303.openai.azure.com/
key: 52078a9a56e54931b182c259ef222381
deployment model: gpt35

步驟:

新增 dotnet core console app
dotnet new console -f net5.0
install .net core SDK
dotnet add package azure.ai.openai  --prerelease
撰寫 console 程式碼 (streaming)
using System;
using System.Threading.Tasks;
using Azure;
using Azure.AI.OpenAI;

namespace testt
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            // See https://aka.ms/new-console-template for more information
            Console.WriteLine("Ready...");

            OpenAIClient client = new OpenAIClient(
                    new Uri("https://____Endpoint_____.openai.azure.com/"),
                    new Azure.AzureKeyCredential("______key______"));

            //string nonAzureOpenAIApiKey = "your-api-key-from-platform.openai.com";
            //var client = new OpenAIClient(nonAzureOpenAIApiKey, new OpenAIClientOptions());
            var chatCompletionsOptions = new ChatCompletionsOptions()
            {
                Messages =
    {
        new ChatMessage(ChatRole.System, "你是一個智能助理，你會回答任何問題，像是一個聰明的智者。"),
        new ChatMessage(ChatRole.User, "你能幫助我嗎?"),
        new ChatMessage(ChatRole.Assistant, "好的，沒有問題。您請發問，我會盡力回答~"),
        new ChatMessage(ChatRole.User, "我該如何才獲得好的成績呢?"),
    }
            };

            Response<StreamingChatCompletions> response =
                await client.GetChatCompletionsStreamingAsync(
                deploymentOrModelName: "___deployment___", chatCompletionsOptions);
            using StreamingChatCompletions streamingChatCompletions = response.Value;

            await foreach (StreamingChatChoice choice in streamingChatCompletions.GetChoicesStreaming())
            {
                await foreach (ChatMessage message in choice.GetMessageStreaming())
                {
                    Console.Write(message.Content);
                }
                Console.WriteLine();
            }
        }
    }
}

抓取結果
demo: 語音助理
https://github.com/isdaviddong/SpeechChatGPT.git

Lab 9 : 建立LINE Bot，加上歷史對談紀錄
參考token資訊
endpoint : https://testopenai202303.openai.azure.com/
dployment name: gpt35
api-key: b878253b12344f709b8d26df1c36a092

步驟:

申請並建立LINE Bot
取得 Channel access token
建立 .net core web api project
md testhistory
cd testhistory
dotnet new webapi
dotnet add package linebotsdk
dotnet new linewebhook
使用 LINE WebHook template
串接 OpenAI API
測試
測試連續問題:

你好，我可以問問題嗎?
台灣最大的都市是哪一個?
這個城市有多少人口呢?
最南端的城市是哪一個呢?
狀況如何? 請利用底下程式碼修改…

sample code:
主程式碼片段
//如果是文字訊息
if (LineEvent.type.ToLower() == "message" && LineEvent.message.type == "text")
{
    if (LineEvent.message.text.Contains("/reset"))
    {
        ChatHistoryManager.DeleteIsolatedStorageFile();
        responseMsg = "我已經把之前的對談都給忘了!";
    }
    else
    {
        var chatHistory = ChatHistoryManager.GetMessagesFromIsolatedStorage(LineEvent.source.userId);
        responseMsg = ChatGPT.getResponseFromGPT(LineEvent.message.text, chatHistory);
        //儲存聊天紀錄
        ChatHistoryManager.SaveMessageToIsolatedStorage(
            System.DateTime.Now, LineEvent.source.userId, LineEvent.message.text, responseMsg);
    }
}
else if (LineEvent.type.ToLower() == "message")
    responseMsg = $"收到 event : {LineEvent.type} type: {LineEvent.message.type} ";
else
    responseMsg = $"收到 event : {LineEvent.type} ";
//回覆訊息

//準備回覆訊息
ChatGPT.cs
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
                            content = @"
                                假設你是一個專業的導遊人員，對於客戶非常有禮貌、也能夠安撫客戶的抱怨情緒。
                                請檢視底下的客戶訊息，以最親切有禮的方式回應。

                                但回應時，請注意以下幾點:
                                * 不要說 '感謝你的來信' 之類的話，因為客戶是從對談視窗輸入訊息的，不是寫信來的
                                * 不能過度承諾
                                * 要同理客戶的情緒
                                * 要能夠盡量解決客戶的問題
                                * 不要以回覆信件的格式書寫，請直接提供對談機器人可以直接給客戶的回覆
                                ----------------------
"
                        }
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
ChatHistoryManager.cs
 using isRock.LineBot;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;

namespace isRock.Template
{
    //一組對談訊息
    public class Message
    {
        public DateTime Time { get; set; }
        public string UserID { get; set; }
        public string UserMessage { get; set; }
        public string ResponseMessage { get; set; }
    }

    //對話紀錄處理
    public class ChatHistoryManager
    {
        const string fileName = "messages.json"; //儲存到 IsolatedStorage 的檔案名稱

        /// <summary>
        /// 將所有對話紀錄刪除
        /// </summary>
        public static void DeleteIsolatedStorageFile()
        {
            using (var isolatedStorage = IsolatedStorageFile.GetUserStoreForAssembly())
            {
                if (isolatedStorage.FileExists(fileName))
                {
                    isolatedStorage.DeleteFile(fileName);
                }
            }
        }

        /// <summary>
        /// 取得對談紀錄(依照 UserID)
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public static List<Message> GetMessagesFromIsolatedStorage(string UserID)
        {
            var messages = new List<Message>();
            using (var isolatedStorage = IsolatedStorageFile.GetUserStoreForAssembly())
            {
                if (isolatedStorage.FileExists(fileName))
                {
                    using (var fileStream = new IsolatedStorageFileStream(fileName, FileMode.Open, isolatedStorage))
                    {
                        using (var reader = new StreamReader(fileStream))
                        {
                            string line;
                            while ((line = reader.ReadLine()) != null)
                            {
                                var message = Newtonsoft.Json.JsonConvert.DeserializeObject<Message>(line);
                                messages.Add(message);
                            }
                        }
                    }
                }
            }

            return messages.Where(c => c.UserID == UserID).OrderBy(c => c.Time).ToList();
        }

        /// <summary>
        /// 儲存對談紀錄到IsolatedStorage
        /// </summary>
        /// <param name="time"></param>
        /// <param name="userID"></param>
        /// <param name="userMessage"></param>
        /// <param name="responseMessage"></param>
        public static void SaveMessageToIsolatedStorage(
            DateTime time, string userID, string userMessage, string responseMessage)
        {
            // 建立 JSON 物件
            var messageObject = new
            {
                Time = time,
                UserID = userID,
                UserMessage = userMessage,
                ResponseMessage = responseMessage
            };
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(messageObject);

            // 讀取 Isolated Storage 中的資料
            List<string> messages = new List<string>();
            var fileName = "messages.json";

            using (var isolatedStorage = IsolatedStorageFile.GetUserStoreForAssembly())
            {
                if (isolatedStorage.FileExists(fileName))
                {
                    using (var fileStream = new IsolatedStorageFileStream(fileName, FileMode.Open, isolatedStorage))
                    {
                        using (var reader = new StreamReader(fileStream))
                        {
                            string line;
                            while ((line = reader.ReadLine()) != null)
                            {
                                messages.Add(line);
                            }
                        }
                    }
                }
            }

            // 加上新的 JSON 物件
            messages.Add(json);

            // 寫回 Isolated Storage 中
            using (var isolatedStorage = IsolatedStorageFile.GetUserStoreForAssembly())
            {
                using (var fileStream = new IsolatedStorageFileStream(fileName, FileMode.Create, isolatedStorage))
                {
                    using (var writer = new StreamWriter(fileStream))
                    {
                        foreach (var message in messages)
                        {
                            writer.WriteLine(message);
                        }
                    }
                }
            }
        }
    }
}
完成具有歷史對談訊息的chatbot <==截圖


final version:
https://github.com/isdaviddong/ChatGPTLineBotWithChatHistory_net5.git

使用 Language Understanding
Lab 10: 建立Text Analysis帳號與服務，建立可區分訂餐 vs 客訴的LU App
在Azure Portal建立 Text Analytics 服務
可選擇S1 pricing tier
建議建立新的resource group
完成後，進入 https://language.cognitive.azure.com/clu/ , 以相同的MSA登入
建立+New App (名稱可用 test[YourName)]
建立 intent [點餐行為]
建立 [飲料名稱]、[餐點名稱]等entities
填入[點餐行為]例句
ex.

點餐語料區
我要點一份燒餅油條
麻煩你我需要一份蛋餅
給我來個大亨堡
三明治帶走
今天請幫我來一個飯糰
今天我想要一份咔啦雞腿堡和可樂一杯
來一份炒泡麵加蛋不要辣
排骨飯加竹筍湯一份帶走
給我來一份黃金開口笑
我要一杯大珍奶微糖
今晚，我想來點…金鋒的滷肉飯加蛋。
來一份5號限定香蕉
來一碗貢丸湯加大不要貢丸
給紐妞來一份銅鑼燒早餐，我要經典紐約客早午餐
我想吃米糕便當
老闆給我來個今日特餐
給開司一罐啤酒

Step 2: 建立可區分訂餐 vs 客訴的LU App
步驟:

建立intent [客訴]
填入[客訴]例句、訓練
客訴語料區
叫你老闆出來
我不喜歡你們可樂的味道
店員服務態度不好
老闆我要的炒麵不要加辣，粥不要蔥啦
湯裡有小強
今天肉沒熟，湯很酸
服務有夠差，老板臉真臭
地很髒
空調是有沒有開拉
漢堡很難吃
牛排裡面有頭髮
地板黏黏濕濕的

發佈model
透過endpoint確認model是否可順利辨識[客訴]或[點餐]
訓練並發佈為服務，並使用postman測試 <== 截圖
POST /language/:analyze-conversations?api-version=2022-10-01-preview HTTP/1.1
Host: ___________.cognitiveservices.azure.com
Ocp-Apim-Subscription-Key: ______________
Content-Type: application/json
Content-Length: 433

{
    "kind": "Conversation",
    "analysisInput": {
        "conversationItem": {
            "id": "1",
            "text": "冰奶茶是好喝的",
            "modality": "text",
            "language": "zh-tw",
            "participantId": "1"
        }
    },
    "parameters": {
        "projectName": "testdavid",
        "verbose": true,
        "deploymentName": "S1",
        "stringIndexType": "TextElement_V8"
    }
}
response

{
    "kind": "Conversation",
    "analysisInput": {
        "conversationItem": {
            "id": "1",
            "text": "冰奶茶是好喝的",
            "modality": "text",
            "language": "zh-tw",
            "participantId": "1"
        }
    },
    "parameters": {
        "projectName": "testdavid",
        "verbose": true,
        "deploymentName": "S1",
        "stringIndexType": "TextElement_V8"
    }
}


Lab 11 : 使用AOAI, 建立可以產出購票 intent, entity 的 prompt
當用戶說: 我要2張從台北到新竹的自由座，另外還要買一杯咖啡
OpenAI API將會判斷 intent 與 entities, 最終需要輸出的結果如下，

{
  "intent": "購票",
  "entities": {
    "起站": "台北",
    "迄站": "新竹",
    "車票票種": "自由座",
    "數量": "2"
  },
  "text": "我要2張從台北到新竹的自由座，另外還要買一杯咖啡"
}
sample system prompt:

你是一個能夠判斷 Intent 並且擷取 Entities 的AI，
會讀取用戶傳入的文字敘述，判斷出該敘述的意圖(Intent)，並且抓取文字敘述中關鍵的entities。
意圖只有 購票/客訴/閒聊 三種，請判斷出最接近的意圖，並將結果以JSON回傳，屬性名稱為 intent。
entities 分別有 起站(start)/迄站(arrive)/時間(date)/車票票種(type)/數量(amount)，請判斷出文字敘述中的entities，並將結果以JSON回傳，屬性名稱為entities。

請直接組一個JSON給我，不需要任何文字解釋，只要回傳JSON即可 
同時請注意以下規則:
* JSON中的 entities 屬性是陣列格式，如果發現有多種entities，請在JSON中以陣列方式回傳，屬性名稱為 entities 
* JSON中的 intent 屬性的值，只能是 購票/客訴/閒聊 三種之一 
* 原始語句用 text 屬性回傳 
* 不需要任何文字解釋，只要回傳JSON即可 
--- 
ref: https://gist.githubusercontent.com/isdaviddong/a896084082664958c28ac30b71c66b08/raw/7a9836601bbdbb4f22a2109ecb125ec01b1b8ac9/prompt.txt

Lab 12: 建立購票機器人
承上題
建立一個 LINE Bot 對談機器人
md folder
cd folder
dotnet new webapi
dotnet add package linebotsdk
dotnet new linewebhook
dotnet build
code .
使用你剛才建立出的 prompt
public static string getResponseFromGPT(string Message)
{
    return ChatGPT.CallAzureOpenAIChatAPI(
       AzureOpenAIEndpoint, AzureOpenAIModelName, AzureOpenAIToken, AzureOpenAIVersion,
        //ref: https://learn.microsoft.com/en-us/azure/cognitive-services/openai/reference#chat-completions
        new
        {
            model = "gpt-3.5-turbo",
            messages = new[]
            {
                new {
                    role = ChatGPT.role.system ,
                    content = @"
                        你是一個能夠判斷 Intent 並且擷取 Entities 的AI，
                        會讀取用戶傳入的文字敘述，判斷出該敘述的意圖(Intent)，並且抓取文字敘述中關鍵的entities。
                        意圖只有 購票/客訴/閒聊 三種，請判斷出最接近的意圖，並將結果以JSON回傳，屬性名稱為 intent。
                        entities 分別有 起站(start)/迄站(arrive)/時間(date)/車票票種(type)/數量(amount)，請判斷出文字敘述中的entities，並將結果以JSON回傳，屬性名稱為entities。

                        請直接組一個JSON給我，不需要任何文字解釋，只要回傳JSON即可 
                        同時請注意以下規則:
                        * JSON中的 entities 屬性是陣列格式，如果發現有多種entities，請在JSON中以陣列方式回傳，屬性名稱為 entities 
                        * JSON中的 intent 屬性的值，只能是 購票/客訴/閒聊 三種之一 
                        * 原始語句用 text 屬性回傳 
                        * 不需要任何文字解釋，只要回傳JSON即可 
                        ----------------------
                        "
                },
                new {
                     role = ChatGPT.role.user,
                     content = Message
                },
            }
        });
}
可以接收用戶的購票要求，剖析用戶意圖
最終產生一組JSON直接回應給用戶即可 <== 截圖

Lab 13 : 購票機器人 - better version
參考底下影片，建立一個真正可以互動的購票(或請假)機器人

參考 prompt:

你是一個售票客服機器人，客戶會向你購票，你必須從客戶的購票敘述中找到底下這些購票資訊。
找到的資訊必須覆述一次，如果有缺少的資訊，必須提醒客戶缺少的部分，直到蒐集完所有資訊後，
要跟客戶做最後的確認，並且問客戶是否正確? 

如果客戶回答不正確，則要重新蒐集資訊。
如果客戶說正確，則將蒐集到的資料，整理成一個JSON字串，直接輸出，無須回覆其他文字。。

購票資訊包含:
* 乘車起始站
* 乘車目的站     
* 乘車預計出發時間
* 乘車張數
* 乘車票種

票種包含:
* 全票
* 學生票
* 愛心票
* 自由座

回應時，請注意以下幾點:
* 不要說 '感謝你的來信' 之類的話，因為客戶是從對談視窗輸入訊息的，不是寫信來的
* 不要一直說抱歉或對不起，但可以說不好意思。
* 不要幫客戶購票，也不要說跟金額有關的事情
* 要能夠盡量解決客戶的問題
* 不要以回覆信件的格式書寫，請直接提供對談機器人可以直接給客戶的回覆
----------------------
問卷位置
https://survey.uuu.com.tw/
22306201


講師介紹

https://www.studyhost.tw/NewCourses/講師簡介-David