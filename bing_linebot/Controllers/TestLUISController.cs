using bingshopLibrary.Models;
using bingshopLibrary.Repositories;
using bingshopLibrary.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace bing_linebot.Controllers
{
    public class TestLUISController : isRock.LineBot.LineWebHookControllerBase
    {
        const string channelAccessToken = "URFvCEz4aEe+iNzWlRgtt9kityT16JV4HldSfeJMf2W+bmSQzONqsZzv3RM6cIY8HPCLUvqWL6xBNFie0lv8878xS0VB7Z5WdrOcOAcKM018IomItL920I4yKSakR/BcxP1zqJ78JJFWhzNn0HATuwdB04t89/1O/w1cDnyilFU=";
        const string AdminUserId = "Ud00be0f21dd317b5b00f62a287ebdaae";
        const string LuisAppId = " 4c6a2257-62bb-49ce-a780-979af84f3fca";
        const string LuisAppKey = "30ab20b52276438d92cff77a71b08d3a";
        const string Luisdomain = "westus";

        [Route("api/TestLUIS")]
        [HttpPost]
        public IHttpActionResult POST()
        {
            try
            {
                //設定ChannelAccessToken(或抓取Web.Config)
                this.ChannelAccessToken = channelAccessToken;
                //取得Line Event(範例，只取第一個)
                var LineEvent = this.ReceivedMessage.events.FirstOrDefault();
                //配合Line verify 
                if (LineEvent.replyToken == "00000000000000000000000000000000") return Ok();
                //回覆訊息
                if (LineEvent.type == "message")
                {
                    var repmsg = "";
                    if (LineEvent.message.type == "text") //收到文字
                    {
                        //建立LuisClient
                        Microsoft.Cognitive.LUIS.LuisClient lc =
                          new Microsoft.Cognitive.LUIS.LuisClient(LuisAppId, LuisAppKey, true, Luisdomain);

                        //Call Luis API 查詢
                        var ret = lc.Predict(LineEvent.message.text).Result;
                        if (ret.Intents.Count() <= 0)
                            repmsg = $"你說了 '{LineEvent.message.text}' ，但我看不懂喔!";
                        else if (ret.TopScoringIntent.Name == "None")
                            repmsg = $"你說了 '{LineEvent.message.text}' ，但不在我的服務範圍內喔!";
                        else
                        {
                          /*  var EntityList = new List<string>();

                            foreach (var item in ret.Entities) 
                            {
                                EntityList.Add(item.Value[0].Name);
                            }*/

                            /* if (ret.Entities.Count > 0)
                                 repmsg += $"'{ ret.Entities.FirstOrDefault().Value.FirstOrDefault().Value}' ";*/

                            
                             if (ret.TopScoringIntent.Name == "訂單查詢")
                             {
                                 var Service = new service();
                                 var Order = Service.OrderGetAll();                          
                                 var Total = Order.Count();

                                 repmsg = $"OK，{ret.TopScoringIntent.Name}: {Total.ToString()} 筆";
                             }
                             if (ret.TopScoringIntent.Name == "金額查詢")
                             {

                                var Service = new service();
                                 var Order_Details = Service.Order_DetailsGetAll();
                                 var Products = Service.ProductsGetAll();                                
                                 decimal Total = 0;
                                 foreach(var itemO in Order_Details)
                                 {
                                     foreach(var itemP in Products)
                                     {
                                         if(itemO.ProductID == itemP.ProductID)
                                         {
                                             Total += itemO.Quantity * itemP.UnitPrice;
                                         }
                                     }
                                 }

                                 repmsg = $"OK，{ret.TopScoringIntent.Name}: {Decimal.Round(Total).ToString()} 元";

                             }
                             if (ret.TopScoringIntent.Name == "商品查詢")
                             {
                                 var Service = new service();
                                 var Products = Service.ProductsGetAll();
                                 var Total = Products.Count();

                                 repmsg = $"OK，{ret.TopScoringIntent.Name}: {Total.ToString()} 筆";

                             }
                             if (ret.TopScoringIntent.Name == "庫存查詢")
                             {
                                 var Service = new service();
                                 var Products = Service.ProductsGetAll();
                                 var Total = 0;
                                 foreach (var item in Products)
                                 {
                                     Total += item.UnitsInStock;
                                 }

                                 repmsg = $"OK，{ret.TopScoringIntent.Name}: {Total.ToString()} 個";

                             }
                             if (ret.TopScoringIntent.Name == "客戶查詢")
                             {
                                 var Service = new service();
                                 var Customers = Service.CustomerGetAll();
                                 var Total = Customers.Count();

                                 repmsg = $"OK，{ret.TopScoringIntent.Name}: {Total.ToString()} 位";

                             }
                             
                        }
                        //回覆
                        this.ReplyMessage(LineEvent.replyToken, repmsg);
                    }
                    if (LineEvent.message.type == "sticker") //收到貼圖
                        this.ReplyMessage(LineEvent.replyToken, 1, 2);
                }
                //response OK
                return Ok();
            }
            catch (Exception ex)
            {
                //如果發生錯誤，傳訊息給Admin
                this.PushMessage(AdminUserId, "發生錯誤:\n" + ex.Message);
                //response OK
                return Ok();
            }
        }
    }
}
