using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Senparc.Weixin.MP.AdvancedAPIs;
using Ad = Senparc.Weixin.MP.AdvancedAPIs;
using Weixin;
using Senparc.Weixin.MP.Entities;

namespace NavShare
{
    public partial class sendnews : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string text = Request.Form["idtxt"];
                string accessToken = Wx.accessToken;
                //实验回复新闻消息
                var l = Ad.User.List(accessToken, "");
                string opid=l.data.openid.ToString();
                if (text == opid)
                {
                    List<Article> News = new List<Article>();
                    News.Add(new Article
                    {
                        PicUrl = "http://wjh.apphb.com/img/a3.jpg",
                        Url = "http://wjh.apphb.com/index.aspx",
                        Title = "文俊豪 男 20150301123"
                    });
                    News.Add(new Article
                    {
                        PicUrl = "http://wjh.apphb.com/img/a1.jpg",
                        Description = "访问ViewNav页面",
                        Url = "http://wjh.apphb.com/ViewNav.aspx",
                        Title = "访问记录统计"
                    });
                    News.Add(new Article
                        {
                            PicUrl = "http://wjh.apphb.com/img/a2.jpg",
                            Description = "访问ViewNav页面",
                            Url = "http://wjh.apphb.com/ViewShare.aspx",
                            Title = "访问记录统计"
                        });
                    
                }
                int n = 0;
                foreach (var i in l.data.openid)
                {
                    try
                    {
                        CustomerService.SendText(accessToken, i, text);
                        n++;
                    }
                    catch { }
                }
                ClientScript.RegisterStartupScript(GetType(), "k", string.Format("alert('成功向{0}个用户发送消息');", n), true);
            }
        }
    }
}