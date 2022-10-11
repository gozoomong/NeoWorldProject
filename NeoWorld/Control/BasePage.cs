using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Configuration;

namespace NeoWorld.Control
{
    public class BasePage : System.Web.UI.Page
    {
        
        public string LoginCheck(string userID, string userPassword)
        {
            string result = "";
            string userId = "";
            string userName = "";

            string dbInfo2=  ConfigurationManager.ConnectionStrings["UserDB"].ConnectionString;
            SqlConnection conn;
            conn = new SqlConnection(dbInfo2);
            conn.Open();
            SqlCommand cmd = new SqlCommand("dbo.USP_User_Login", conn);  

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = userID;
            cmd.Parameters.Add("@pwd", SqlDbType.VarChar).Value = userPassword;

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                result = dr["Result"].ToString();
                userId = dr["UserId"].ToString();
                userName = dr["UserName"].ToString();
            }
            conn.Close();
            if (result.Equals("FALSE"))
            {
                return "FALSE";
            }
            else
            {
                return userId + "/" + userName;
            }
        }


        public string AESEncrypt128(string text, string password)
        {
            // 사전 설정
            UTF8Encoding ue = new UTF8Encoding();
            RijndaelManaged rijndael = new RijndaelManaged();
            rijndael.Padding = PaddingMode.PKCS7;
            rijndael.Mode = CipherMode.CBC;
            rijndael.KeySize = 128;

            // key 및 iv 설정
            byte[] pwdBytes = ue.GetBytes(password);
            byte[] keyBytes = new byte[16];
            byte[] IVBytes = new byte[16];
            int lenK = pwdBytes.Length;
            int lenIV = pwdBytes.Length;
            if (lenK > keyBytes.Length) { lenK = keyBytes.Length; }
            if (lenIV > IVBytes.Length) { lenIV = IVBytes.Length; }
            Array.Copy(pwdBytes, keyBytes, lenK);
            Array.Copy(pwdBytes, IVBytes, lenIV);
            rijndael.Key = keyBytes;
            rijndael.IV = IVBytes;

            byte[] message = ue.GetBytes(text);
            ICryptoTransform transform = rijndael.CreateEncryptor();
            // 암호화 수행 
            byte[] cipherBytes = transform.TransformFinalBlock(message, 0, message.Length);
            rijndael.Clear();

            // 16진수로 변환
            string hex = "";
            foreach (byte x in cipherBytes)
            {
                hex += x.ToString("x2");
            }
            return hex;
        }

        public static string DecryptByAES128(string text, string password)
        {
            // 사전 설정
            UTF8Encoding ue = new UTF8Encoding();
            RijndaelManaged rijndael = new RijndaelManaged();
            rijndael.Padding = PaddingMode.PKCS7;
            rijndael.Mode = CipherMode.CBC;
            rijndael.KeySize = 128;

            // 16진수 문자열을 바이트 배열로 변환
            byte[] cipherBytes = new byte[text.Length / 2];
            for (int i = 0; i < cipherBytes.Length; i++)
            {
                cipherBytes[i] = Convert.ToByte(text.Substring(i * 2, 2), 16);
            }

            // key 및 iv 설정
            byte[] pwdBytes = ue.GetBytes(password);
            byte[] keyBytes = new byte[16];
            byte[] IVBytes = new byte[16];
            int lenK = pwdBytes.Length;
            int lenIV = pwdBytes.Length;
            if (lenK > keyBytes.Length) { lenK = keyBytes.Length; }
            if (lenIV > IVBytes.Length) { lenIV = IVBytes.Length; }
            Array.Copy(pwdBytes, keyBytes, lenK);
            Array.Copy(pwdBytes, IVBytes, lenIV);
            rijndael.Key = keyBytes;
            rijndael.IV = IVBytes;

            ICryptoTransform transform = rijndael.CreateDecryptor();
            // 암호화 수행
            byte[] message = transform.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length);
            rijndael.Clear();

            return Encoding.UTF8.GetString(message);
        }




    }
}