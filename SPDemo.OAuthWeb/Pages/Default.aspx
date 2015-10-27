<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SPDemo.OAuthWeb.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>OAuth Demo</title>
    <style type="text/css">
        .h1 {font-size:24pt;}
        .contentHeader {
            font-size:18pt;
            padding: 5px;
            color: blue;
        }
        .contentContainer {
            padding-left:10px;
        }
        .contentBody {font-size:14pt;padding:5px;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div id="request">
            <h1>Request</h1>
            <div class="contentContainer">
                <div class="contentHeader">Request Token</div>
                <div runat="server" id="requestTokenValue" class="contentBody"></div>
                <div class="contentHeader">Request Token Contents</div>
                <div runat="server" id="requestTokenContents" class="contentBody"></div>
            </div>
        </div>
        <div id="response">
            <h2>Response</h2>
            <div class="contentContainer">
                <div class="contentHeader">Access Token</div>
                <div runat="server" id="accessTokenValue" class="contentBody"></div>
                <div class="contentHeader">Access Token Content</div>
                <div runat="server" id="accessTokenContents" class="contentBody"></div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
