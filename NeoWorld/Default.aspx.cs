using NeoWorld.Control;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



namespace NeoWorld
{
    public partial class Default : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void logintest_Click(object sender, EventArgs e)
        {
            try
            {
                string sId = id.Text.Trim();
                string sPwd = password.Text;
                string sLoginResult = string.Empty;

                string desPw = AESEncrypt128(sPwd, "abcdefgh");

                string result = LoginCheck(sId, desPw);
                if (result != "FALSE")
                {
                    //  쿠키에 사용자 정보 담기
                    string[] userInfo = result.Split(new string[] { "/" }, StringSplitOptions.None);
                    for (int i = 0; i < userInfo.Length; i++)
                    {
                        userInfo[i] = userInfo[i].Trim();
                    }
                    string loginUserId = userInfo[0].Trim();
                    string loginUserName = userInfo[1].Trim();

                    ///*쿠키 설정 관련 url https://dotweb.tistory.com/207*/
                    Response.Cookies["loginUserId"].Value = loginUserId;
                    Response.Cookies["loginUserName"].Value = loginUserName;
                    Response.Cookies["loginUserId"].Expires = DateTime.Now.AddDays(1);
                    Response.Cookies["loginUserName"].Expires = DateTime.Now.AddDays(1);
                    Session["UserId"] = loginUserId;
                    Session["UserName"] = loginUserName;

                    string test = (string)Session["UserId"];



                    Response.Redirect(string.Format("shop/shoppingList.aspx"));
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Check your ID or Password')", true);
                }

            }

            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Fuck that shit')", true);
            }
        }

        ///  회원가입 로직
        //protected void btnRegister_Click(object sender, EventArgs e)
        //{
        //    string userId = testId.Text;
        //    string userPassword = testPw.Text;
        //    string userName = testName.Text;

        //    string testAesPw = AESEncrypt128(userPassword, "abcdefgh");

        //    string connectionString = ConfigurationManager.ConnectionStrings["UserDB"].ConnectionString;

        //    SqlConnection con;
        //    con = new SqlConnection(connectionString);
        //    con.Open();

        //    SqlCommand cmd = new SqlCommand();
        //    cmd.Connection = con;

        //    cmd.CommandText = string.Format("insert into TestTable(userId,userPassword,userName) values(@id,@pw,@name)");
        //    cmd.Parameters.AddWithValue("@id", userId);
        //    cmd.Parameters.AddWithValue("@pw", testAesPw);
        //    cmd.Parameters.AddWithValue("@name", userName);
        //    cmd.CommandType = CommandType.Text;
        //    cmd.ExecuteNonQuery();
        //    con.Close();

        //    testId.Text = "";
        //    testPw.Text = "";
        //}

    }
}