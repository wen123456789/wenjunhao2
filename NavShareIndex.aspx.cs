using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.Serialization.Json;//需添加System.Runtime.Serialization引用
using Weixin.JSSDK;
using Weixin;
namespace NavShare
{
    public partial class NavShareIndex : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string shareOpenId = Request.QueryString["s"];
            string navOpenId = Data.GetNavOpenId();
            AddNav(navOpenId, shareOpenId);
            ViewState["s"] = shareOpenId;
            ViewState["u"] = navOpenId;
            ClientScript.RegisterStartupScript(GetType(), "2", RegShare(), true);
        }
        void AddNav(string navOpenId, string shareOpenId)
        {            
            var pageNav = new Nav()
            {
                NavFrom = Data.GetNavFromType(),
                NavOpenId = navOpenId ?? "noknow",
                ShareOpenId = shareOpenId ?? "None",
                Url = "http://" + Request.Url.Host + Request.FilePath
            };
            BLL.InsertNav(pageNav);
        }

        string RegShare()
        {
            string url = Request.Url.AbsoluteUri.Replace(":" + Request.Url.Port, "");
            string link = "http://" + Request.Url.Host + Request.FilePath;
            link += "?s=" + ViewState["u"];
            RegJssdk.ShareEnitiy shareentity = new RegJssdk.ShareEnitiy()
            {
                imgUrl = "http://image.baidu.com/search/detail?ct=503316480&z=0&ipn=d&word=%E5%9B%BE%E7%89%87&hs=0&pn=1&spn=0&di=112972528020&pi=0&rn=1&tn=baiduimagedetail&is=0%2C0&ie=utf-8&oe=utf-8&cl=2&lm=-1&cs=594559231%2C2167829292&os=2394225117%2C7942915&simid=3436308227%2C304878115&adpicid=0&lpn=0&ln=30&fr=ala&fm=&sme=&cg=&bdtype=0&oriquery=&objurl=http%3A%2F%2Fimg.taopic.com%2Fuploads%2Fallimg%2F120727%2F201995-120HG1030762.jpg&fromurl=ippr_z2C%24qAzdH3FAzdH3Fooo_z%26e3Bpw5rtv_z%26e3Bv54AzdH3Fejvp56AzdH3Fda8da0AzdH3Fdanll9_z%26e3Bip4s&gsm=0",
                Title = "图片",
                Desc = "图片",
                Link = link 
            };
            string jscode = RegJssdk.RegisterJssdk(Wx.appId, Wx.accessToken, url, shareentity);
            return jscode; 
        }        
    }
}