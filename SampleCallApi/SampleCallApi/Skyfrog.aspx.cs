using Newtonsoft.Json;
using SampleCallApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SampleCallApi
{
    public partial class Skyfrog : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AreaError.Visible = false;
            AreaSuccess.Visible = false;
        }

        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            AreaError.Visible = false;
            AreaSuccess.Visible = false;

            var job1 = new CreateJobSimple
            {
                CompanyID = Config.CustomerCode,
                JobNo = "J" + DateTime.Now.ToString("yyMMddHHmmss"),
                JobStatus = "B",
                Ref1 = "",
                Ref2 = "",
                Ref3 = "",
                Ref4 = "",
                Remark = "",
                LoadID = "",
                HHID = "",
                Customer = new Customers
                {
                    CustomerCode = "",
                    CustomerName = "Sample Customer",
                    Address = "Sample address",
                    Tel = "",
                    Fax = "",
                    Latitude = "",
                    Longitude = "",
                    UpSert = true
                },
                Pickup = new Point
                {
                    PointCode = "",
                    PointName = "Sample Pickup",
                    Address = "",
                    Latitude = "",
                    Longitude = "",
                    ContactName = "",
                    ContactFullName = "",
                    Tel = "",
                    UpSert = true
                },
                Shipping = new Point
                {
                    PointCode = "",
                    PointName = "Sample Shipping",
                    Address = "",
                    Latitude = "",
                    Longitude = "",
                    ContactName = "",
                    ContactFullName = "",
                    Tel = "",
                    UpSert = true
                }
            };
            //var i = 0;
            //foreach (var l in line)
            //{
                //i++;
                job1.Items.Add(new Item
                {
                    ItemNo = 1,
                    ItemCode = "ITM001",
                    Description = "Sample Item",
                    Quantity = 1,
                    ReceiveQuantity = 0,
                    Unit = "Unit",
                    Width = "",
                    Length = "",
                    Height = "",
                    Weight = "",
                    Reference = ""
                });
            //}

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Config.ApiUrl);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(Config.Username + ":" + Config.Password));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);

                var stringJson = JsonConvert.SerializeObject(job1);

                Log.More(stringJson, "Skyfrog_" + DateTime.Now.ToString("yyyyMMdd"));//เก็บ json ไว้ดูเผื่อตรวจสอบ

                var response = client.PostAsJsonAsync("API/CreateJobSimple", job1).Result;
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsAsync<ResultWithModels>().Result;
                    if (!result.success)
                    {
                        var datas = JsonConvert.DeserializeObject<List<ValidateModel>>(result.datas.ToString());
                        var description = "";
                        foreach (var r in datas.AsQueryable())
                        {
                            description += r.Coulums + " -> " + r.Description + "<br />";
                        }
                       
                        AreaError.Visible = true;
                        TextError.InnerHtml = Server.HtmlDecode(description);
                        Log.More(description, "Warnning");
                    }
                    else
                    {
                        AreaSuccess.Visible = true;
                        TextSuccess.InnerText = result.message;
                        Log.More(result.message, "JobSuccess");
                    }
                }
                else
                {
                    AreaError.Visible = true;
                    TextError.InnerText = response.ToString();
                    Log.Error(response.ToString());
                }

            }
        }
    }
}