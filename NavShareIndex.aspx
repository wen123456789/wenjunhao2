<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NavShareIndex.aspx.cs" Inherits="NavShare.NavShareIndex" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta name="viewport" content="width:device-width, initial-scale=1, minimum-scale=1, maximum-scale=1, user-scalable=no" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<title></title>
<script src="Scripts/jquery-1.9.1.min.js" type="text/javascript"></script>
<%-- 微信JS接口 --%>
<script src="http://res.wx.qq.com/open/js/jweixin-1.0.0.js"></script>
<style type="text/css">
body
{
font-family : 微软雅黑,宋体;
font-size : 15px;
color : #0ff;
}
</style>

</head>
<body>    
    <p>文俊豪</p>
    <form id="form1" runat="server">
    <div>    
        通过菜单直接打开的页面
    </div>
    </form>
</body>
</html>
<script>
    var url = location.href;
    url = 'Share.aspx?url=' + url + '&u=<%=ViewState["u"]%>' + '&s=<%=ViewState["s"]%>';
    //转发给朋友圈的回调函数，向后台传递转发记录
    function friendCirclecallback(res) {        
        //AJAX请求               
        $.ajax({
            type: "get",
            url: url + "&type=timeline",
            beforeSend: function () {
            },
            success: function () {                
            },
            complete: function () {
            },
            error: function () {                
            }
        });
    };
    //转发给朋友的回调函数，向后台传递转发记录
    function friendcallback(res) {
        //AJAX请求
        $.ajax({
            type: "get",
            url: url + "&type=friend",
            beforeSend: function () {
            },
            success: function () {                
            },
            complete: function () {
            },
            error: function () {                
            }
        });
    };
</script>
