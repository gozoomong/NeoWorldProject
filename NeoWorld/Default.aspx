<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="NeoWorld.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>NeoWorld</title>
    <link href="https://fonts.googleapis.com/css2?family=Do+Hyeon&display=swap" rel="stylesheet">
</head>
<style type="text/css">
    body {
        background-color: black;
        color: white;
    }

    .copyRight {
        position: fixed;
        bottom: 0;
        font-size: 10px;
        width: 95%;
        text-align: center;
    }

    * {
        font-family: "Do Hyeon";
        font-weight: lighter;
    }

    .clear {
        height: 5px;
    }

    .login_btn {
        background-color: black;
        color: white;
    }
</style>

<body>
    <form id="form1" runat="server">

<%--        <div style="display:none;"> 
            ID:<asp:TextBox runat="server" ID="testId"></asp:TextBox> <br />
            PW:<asp:TextBox runat="server" ID="testPw" TextMode="Password"></asp:TextBox> <br />
            NAME:<asp:TextBox runat="server" ID="testName"></asp:TextBox> <br />
            <asp:Button runat="server" ID="btnRegister" OnClick="btnRegister_Click" />
        </div>--%>


        <div class="loginDiv">
            <div style="text-align: center; margin-top: 150px;">
                <div class="mainImg">
                    <img src="Scripts/Images/spiderman.png" alt="mainImg" style="width: 100px;" />
                </div>

                <div class="clear"></div>

                <div class="loginIdBox">
                    <asp:TextBox ID="id" runat="server" ClientIDMode="Static" CssClass="id" placeholder="아이디"></asp:TextBox>
                </div>

                <div class="clear"></div>
                <div>
                    <asp:TextBox ID="password" runat="server" ClientIDMode="Static" TextMode="Password" CssClass="pw" placeholder="비밀번호"></asp:TextBox>
                </div>

                <div class="clear"></div>

                <asp:Button ID="logintest" runat="server" class="login_btn" Text="로그인" OnClick="logintest_Click" />

                <label for="auto_login" style="letter-spacing: -1.5px;">
                    <input type="checkbox" id="auto_login" />
                    자동 로그인</label>
            </div>
        </div>

        <div class="copyRight">
            Copyrightⓒ 2022 by Neo.Co, Technology Developer JYShim
        </div>

    </form>
</body>
</html>
