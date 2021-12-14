<%@ Page Language="VB" AutoEventWireup="false"  Debug="true" CodeFile="index.aspx.vb" Inherits="index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
       <title></title><link rel="stylesheet" href="css/bootstrap.min.css" /><script src="js/jquery.min.js"></script><script src="js/bootstrap.min.js"></script><script>$(function () { $("[data-toggle='tooltip']").tooltip(); });</script>
     <script language="VB" Runat="Server">
    function getCookie()
	Dim cookieValue
	CookieValue=""
	IF not ( Request.Cookies("iPlanetDirectoryPro") is nothing ) THEN
 		CookieValue = Request.Cookies("iPlanetDirectoryPro").value
	end if
	Return cookieValue 
	
End Function
</Script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
       <center>

<%
	Dim login,gotoURL,serverUrl,loginUrl,logout,logoutUrl
	Dim idstar
    idstar = Server.CreateObject("Idstar.IdentityManager")
 
    serverUrl = "Login.aspx"
 
	loginUrl = serverUrl
 

	Dim cookieValue
	Dim currentUser
    Dim pagenames 
    
	cookieValue = getCookie()
    currentUser = ""
    pagenames = "Default"
    Dim page3
    page3 = Request("pagenames")
    If (Len(page3) <> 0) Then
        pagenames = page3
    End If
    

    currentUser = idstar.GetCurrentUser("" & Server.UrlDecode(cookieValue))
    If (Len(currentUser) <> 0) Then
        Response.Write("cookies值是：" & Server.UrlDecode(cookieValue))
        Response.Write("<p>已登录")
		
		  
        Dim dateStr As String = New DateTime().ToString("yyyyMMddhi24miss")
        Response.Cookies(dateStr).Value = currentUser
        Dim dateStr2 As String = New DateTime().ToString("yyyyMMdd")
        Response.Cookies(dateStr2).Value = pagenames
        Response.Redirect("Login1.aspx?currentUserCookie=" + dateStr + "&pagenames=" + dateStr2)
		%>
		<p>当前用户: <%= currentUser %>
		<%
	Else
	
	    Response.Redirect(serverUrl)
		%>
		<p>您没有登录,请登录  <a href="<%= loginUrl %>">Login</a>
		<%
	End If
	
%>
</center>
    </div>
    </form>
</body>
</html>
