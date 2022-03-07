using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WBT.Common
{
    public enum TransactionType
    {
        DeliveryNoteTreeLoad,
        DateTimeValidation,
        Deletesuccess,
        DataDependency,
        CorrectionRequired,
        None,
        Save,
        Edit,
        Delete,
        Print,
        Find,
        Serach,
        Load,
        IsValidEnter,
        OK,
        Success,
        Failure,
        Error,
        SaveAndClose,
        Close,
        Configuration,
        IsRequiredData,
        MissMatchData,
        DataValidation,
        DataExists,
        SystemError,
        TallyUpdation,
        TallyError,
        AliasNameExists,
        SaveAndPrint,   //used in Direct SO
        BindAllData,
        WarehouseData
    }
    public enum ConvertStyle
    {
        Asian,
        English
    }

    public class ApplicationActivate : IDataErrorInfo
    {
        private string mGetErrormessages = string.Empty;
        private string mGetErrorSource = string.Empty;
        private string mGetErrorStackTrace = string.Empty;
        public string GetErrorStackTrace
        {
            get { return mGetErrorStackTrace; }
            set { mGetErrorStackTrace = value; }
        }

        public string GetErrorSource
        {
            get { return mGetErrorSource; }
            set { mGetErrorSource = value; }
        }

        public string GetErrormessages
        {
            get { return mGetErrormessages; }
            set { mGetErrormessages = value; }
        }

        private static TransactionType mDataState = TransactionType.None;
        private static string mDisplayMessage = string.Empty;
        public TransactionType DataState
        {
            get
            {
                return mDataState;
            }
            set
            {
                mDataState = value;
            }
        }

        public string DisplayMessage
        {
            get
            {
                return mDisplayMessage;
            }
            set
            {
                mDisplayMessage = value;
            }
        }

        string IDataErrorInfo.Error => throw new NotImplementedException();

        public string this[string columnName] => throw new NotImplementedException();

        public static TransactionType RequiredData(string Message)
        {
            if (string.IsNullOrEmpty(Message))
                return TransactionType.DataValidation;
            else
                return TransactionType.Success;
        }
    }

    public abstract class BLActivate
    {
        private ApplicationActivate mApplicationActivate = new ApplicationActivate();
        public ApplicationActivate GetApplicationActivate
        {
            get
            {
                return mApplicationActivate;
            }
            set
            { mApplicationActivate = value; }
        }
        public abstract object GetAction(object Context);
        public abstract object SetAction(object Context);
    }
    public abstract class DLActivate
    {
        private ApplicationActivate mApplicationActivate = new ApplicationActivate();
        public ApplicationActivate GetApplicationActivate
        {
            get
            {
                return mApplicationActivate;
            }
            set
            { mApplicationActivate = value; }
        }
        public abstract object DataActivate(object Context);

    }

    public class Helper
    {
        static System.Timers.Timer mSetTimer = new System.Timers.Timer();
        static AppSettingsReader mConfigReader = new AppSettingsReader();
        static string ErrorMailBody = string.Empty;

        public System.Timers.Timer SetTimer
        {
            get { return Helper.mSetTimer; }
            set { Helper.mSetTimer = value; }
        }
        public static System.Configuration.AppSettingsReader ConfigReader
        {
            get { return mConfigReader; }
            set { mConfigReader = value; }
        }

        public static string GetSystemFilePath()
        {
            return System.IO.Path.Combine(System.Reflection.Assembly.GetExecutingAssembly().Location, System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory));
        }
        public static void LogError(string Message, string Source, Exception InnerException, string StackTrace, bool IsLog = false)
        {
            try
            {
                if (IsLog == false)
                {
                    CreateFolder(System.IO.Path.Combine(GetSystemFilePath() + @"ErrorLog"));
                    string excelFile = System.IO.Path.Combine(GetSystemFilePath() + @"ErrorLog" + @"\" + "ErrorLog" + "_" + DateTime.Now.ToString("dd_MM_yyyy") + ".txt");

                    string fileName = excelFile;
                    StringBuilder sb = new StringBuilder();
                    if (System.IO.File.Exists(fileName))
                    {
                        sb.Append(System.IO.File.ReadAllText(fileName));
                    }
                    sb.AppendLine("*******************Start**************");
                    sb.AppendLine("Date & Time : " + DateTime.Now.ToString());
                    sb.AppendLine("Message : " + Message);
                    sb.AppendLine("Source : " + Source);
                    if (InnerException != null)
                        sb.AppendLine("InnerException : " + InnerException.Message);
                    sb.AppendLine("StackTrace : " + StackTrace);
                    sb.AppendLine("*******************End**************");
                    System.IO.File.WriteAllText(fileName, sb.ToString());
                    ErrorMailBody = ErrorMailBody + "/n" + sb.ToString();
                }
                else
                {
                    if (ConfigReader.GetValue("IsLogGenerate", typeof(string)).ToString().Trim().Equals("true"))
                    {
                        string logFile = System.IO.Path.Combine(GetSystemFilePath() + @"\" + "ErrorLog" + "_" + DateTime.Now.ToString("dd_MM_yyyy") + ".txt");

                        StringBuilder sb = new StringBuilder();
                        if (System.IO.File.Exists(logFile))
                        {
                            sb.Append(System.IO.File.ReadAllText(logFile));
                        }
                        sb.AppendLine("Date & Time : " + DateTime.Now.ToString() + " [ " + Message + "]");
                        System.IO.File.WriteAllText(logFile, sb.ToString());
                    }
                }
            }
            catch (OutOfMemoryException outofMemory)
            {
                string message = outofMemory.Message;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }

        public static void TransactionLog(string Message, bool IsTransactionLog = false)
        {
            if (IsTransactionLog)
            {
                string logFile = System.IO.Path.Combine(GetSystemFilePath() + @"log" + @"\" + "TransactionLog" + "_" + DateTime.Now.ToString("dd_MM_yyyy") + ".txt");
                StringBuilder sb = new StringBuilder();
                if (System.IO.File.Exists(logFile))
                {
                    sb.Append(System.IO.File.ReadAllText(logFile));
                }

                sb.AppendLine("Date & Time : " + DateTime.Now.ToString() + " [ " + Message + "]");
                //System.IO.File.WriteAllText(logFile, sb.ToString());
            }
        }
        public static void TransactionLog(string Message, int TransactionType, bool IsTransactionLog = true)
        {
            if (IsTransactionLog)
            {
                try
                {
                    CreateFolder(System.IO.Path.Combine(GetSystemFilePath() + @"TransactionLog"));
                    string logFile = System.IO.Path.Combine(GetSystemFilePath() + @"TransactionLog" + @"\" + "TransactionLog" + "_" + DateTime.Now.ToString("dd_MM_yyyy") + ".txt");
                    StringBuilder sb = new StringBuilder();

                    using (FileStream fs = new FileStream(logFile, FileMode.OpenOrCreate, FileAccess.Read, FileShare.Read))
                    {
                        StreamReader sr = new StreamReader(fs);
                        sb.Append(sr.ReadToEnd());
                        sr.Close();
                        //BinaryWriter br = new BinaryWriter(fs);
                        //br.Write(sb.ToString());
                    }

                    if (TransactionType == 1)
                        sb.AppendLine("Date & Time : " + DateTime.Now.ToString() + "[Request]" + " [ " + Message + "]");
                    else
                        sb.AppendLine("Date & Time : " + DateTime.Now.ToString() + "[Response]" + " [ " + Message + "]");

                    //if (System.IO.File.Exists(logFile))
                    //{
                    //    sb.Append(System.IO.File.ReadAllText(logFile));
                    //}

                    FileWriter fileWriter = new FileWriter();
                    fileWriter.WriteData(sb.ToString(), logFile);
                }
                catch (Exception ex)
                {
                    LogError(ex.Message, null, ex.InnerException, null);
                }


                //System.IO.File.WriteAllText(logFile, sb.ToString());
            }
        }
        public class FileWriter
        {
            private static ReaderWriterLockSlim lock_ = new ReaderWriterLockSlim();
            public void WriteData(string dataWh, string filePath)
            {
                lock_.EnterWriteLock();
                try
                {
                    using (var fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                    {
                        byte[] dataAsByteArray = new UTF8Encoding(true).GetBytes(dataWh);
                        fs.Write(dataAsByteArray, 0, dataWh.Length);
                    }
                }
                finally
                {
                    lock_.ExitWriteLock();
                }
            }
        }
        public static void CreateFolder(string DirPath)
        {
            if (!System.IO.Directory.Exists(DirPath))
            {
                System.IO.Directory.CreateDirectory(DirPath);
            }
        }
        public static DateTime GetCurrentDate
        {
            get
            {
                //DateTime dateTime;
                //bool testbool = DateTime.TryParseExact(DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt"), "MM/dd/yyyy hh:mm:ss tt", CultureInfo.GetCultureInfo("en-US"), DateTimeStyles.None, out dateTime);
                //return dateTime;
                System.Globalization.CultureInfo cultureinfo = new System.Globalization.CultureInfo("en-US");
                cultureinfo.DateTimeFormat.LongDatePattern = "yyyy/MM/dd hh:mm:ss tt";
                //System.Threading.Thread.CurrentThread.CurrentCulture = cultureinfo;
                //System.Threading.Thread.CurrentThread.CurrentUICulture = cultureinfo;
                return DateTime.Parse(DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss tt"), cultureinfo);
            }
        }
        public static string Encrypt(string input, string key)
        {
            byte[] inputArray = UTF8Encoding.UTF8.GetBytes(input);
            TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
            tripleDES.Key = UTF8Encoding.UTF8.GetBytes(key);
            tripleDES.Mode = CipherMode.ECB;
            tripleDES.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tripleDES.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
            tripleDES.Clear();
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }


        /// <summary>
        /// Decrypts the given string using TripleDES algorithm
        /// </summary>
        /// <param name="input"></param>
        /// <param name="key"></param>
        /// <returns>returns the the Decrypted text</returns>
        public static string Decrypt(string input, string key)
        {
            //input = "hrYETT0+6PxhiiQ6wsj64A==";
            byte[] inputArray = Convert.FromBase64String(input);
            TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
            tripleDES.Key = UTF8Encoding.UTF8.GetBytes(key);
            tripleDES.Mode = CipherMode.ECB;
            tripleDES.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tripleDES.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
            tripleDES.Clear();
            return UTF8Encoding.UTF8.GetString(resultArray);
        }
        public static void SendMail(string ToEmailID, string FromMailID, string BodyMessage, string MailSubject, string MailServerHOST, string MailPassword, string SendingPort, IEnumerable<string> bccList = null, List<Attachment> MailAttachment = null, bool EnableSSL = false)
        {
            try
            {
                System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
                System.Net.Mail.SmtpClient SmtpServer = new System.Net.Mail.SmtpClient(MailServerHOST);

                if (bccList != null)
                {
                    foreach (var emailId in bccList)
                    {
                        mail.Bcc.Add(emailId);
                    }
                }

                if (MailAttachment != null)
                {
                    if (MailAttachment.Count > 0)
                    {
                        if (MailAttachment != null)
                        {
                            foreach (Attachment attachment in MailAttachment)
                            {
                                mail.Attachments.Add(attachment);
                            }
                        }
                    }
                }

                mail.From = new System.Net.Mail.MailAddress(FromMailID, "MWB Groups");
                mail.To.Add(ToEmailID);
                mail.Subject = MailSubject;
                mail.Body = BodyMessage;
                mail.IsBodyHtml = true;

                SmtpServer.Port = Convert.ToInt16(SendingPort);
                SmtpServer.Credentials = new System.Net.NetworkCredential(FromMailID, MailPassword);
                SmtpServer.EnableSsl = EnableSSL;
                SmtpServer.Send(mail);
                SmtpServer.Dispose();
                mail.Dispose();

            }
            catch (System.Exception ex)
            {
                throw ex;
                //LogError(ex.Message, ex.Source, ex.StackTrace);
            }
        }

        public static string SendSMS(string User, string password, string Mobile_Number, string Message,
            [System.Runtime.InteropServices.OptionalAttribute, System.Runtime.InteropServices.DefaultParameterValueAttribute("N")]  // ERROR: Optional parameters aren't supported in C#
            string MType)
        {
            string stringpost = "User=" + User + "&passwd=" + password + "&mobilenumber=" + Mobile_Number + "&message=" + Message + "&MTYPE=" + MType;
            // LogError(stringpost, "", "");
            System.Net.HttpWebRequest objWebRequest = null;
            System.Net.HttpWebResponse objWebResponse = null;
            System.IO.StreamWriter objStreamWriter = null;
            System.IO.StreamReader objStreamReader = null;
            try
            {
                string stringResult = null;
                objWebRequest = (System.Net.HttpWebRequest)System.Net.WebRequest.Create("http://info.bulksms-service.com/WebserviceSMS.aspx");

                objWebRequest.Method = "POST";
                objWebRequest.ContentType = "application/x-www-form-urlencoded";
                objStreamWriter = new System.IO.StreamWriter(objWebRequest.GetRequestStream());
                objStreamWriter.Write(stringpost);
                objStreamWriter.Flush();
                objStreamWriter.Close();
                objWebResponse = (System.Net.HttpWebResponse)objWebRequest.GetResponse();
                objWebResponse = (System.Net.HttpWebResponse)objWebRequest.GetResponse();
                objStreamReader = new System.IO.StreamReader(objWebResponse.GetResponseStream());
                stringResult = objStreamReader.ReadToEnd();
                objStreamReader.Close();
                return (stringResult);
            }
            catch (Exception ex)
            {
                LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                //logger(ex.Message);
                return (ex.ToString());
            }
            finally
            {

                if ((objStreamWriter != null))
                {
                    objStreamWriter.Close();
                }
                if ((objStreamReader != null))
                {
                    objStreamReader.Close();
                }
                objWebRequest = null;
                objWebResponse = null;
            }
        }
        public static string SendMessage(string BaseURL, string APIKey, string Mobile_Number, string Message, string SenderID)
        {
            //string stringpost = "User=" + User + "&passwd=" + password + "&mobilenumber=" + Mobile_Number + "&message=" + Message + "&MTYPE=" + MType;
            // LogError(stringpost, "", "");
            System.Net.HttpWebRequest objWebRequest = null;
            System.Net.HttpWebResponse objWebResponse = null;
            System.IO.StreamWriter objStreamWriter = null;
            System.IO.StreamReader objStreamReader = null;
            string URL = BaseURL + APIKey + "&method=sms&message=" + Message + "&to=" + Mobile_Number + "&sender=" + SenderID + "";
            try
            {
                string stringResult = null;
                objWebRequest = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(URL);

                objWebRequest.Method = "POST";
                objWebRequest.ContentType = "application/x-www-form-urlencoded";
                objStreamWriter = new System.IO.StreamWriter(objWebRequest.GetRequestStream());
                objStreamWriter.Write(Message);
                objStreamWriter.Flush();
                objStreamWriter.Close();
                objWebResponse = (System.Net.HttpWebResponse)objWebRequest.GetResponse();
                objWebResponse = (System.Net.HttpWebResponse)objWebRequest.GetResponse();
                objStreamReader = new System.IO.StreamReader(objWebResponse.GetResponseStream());
                stringResult = objStreamReader.ReadToEnd();
                objStreamReader.Close();
                return (stringResult);
            }
            catch (Exception ex)
            {
                LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                //logger(ex.Message);
                return (ex.ToString());
            }
            finally
            {

                if ((objStreamWriter != null))
                {
                    objStreamWriter.Close();
                }
                if ((objStreamReader != null))
                {
                    objStreamReader.Close();
                }
                objWebRequest = null;
                objWebResponse = null;
            }
        }
        public static string Encrypt(string encryptString)
        {
            return GetEncrypt(encryptString, string.Empty);
        }
        public static string Decrypt(string cipherText)
        {
            return SetDecrypt(cipherText, string.Empty);
        }
        private static string GetEncrypt(string encryptString, string EncryptionKey)
        {
            if (EncryptionKey == string.Empty)
                EncryptionKey = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            byte[] clearBytes = Encoding.Unicode.GetBytes(encryptString);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] {
            0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76
        });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    encryptString = Convert.ToBase64String(ms.ToArray());
                }
            }
            return encryptString;
        }
        private static string SetDecrypt(string cipherText, string EncryptionKey)
        {
            if (EncryptionKey == string.Empty)
                EncryptionKey = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            cipherText = cipherText.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] {
            0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76
        });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }
        public static string Get12hrtimeFormate(DateTime dateTime)
        {
            var cultureSource = new CultureInfo("en-US", false);
            var cultureDest = new CultureInfo("de-DE", false);

            var source = dateTime.ToString("hh:mm tt");

            var dt = DateTime.Parse(source, cultureSource);
            string tempTime = source;// (dt.ToString("t", cultureDest)); // Convert.ToDateTime
            return tempTime;
        }

        public static DateTime GetDateAsDateTimeFormat(DateTime dateTime)
        {
            System.Globalization.CultureInfo cultureinfo = new System.Globalization.CultureInfo("en-IN");
            cultureinfo.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
            System.Threading.Thread.CurrentThread.CurrentCulture = cultureinfo;
            System.Threading.Thread.CurrentThread.CurrentUICulture = cultureinfo;
            return DateTime.Parse(dateTime.ToString("dd/MM/yyyy hh:mm tt"), cultureinfo);
        }
        public static int GetUniqueNumber
        {
            get
            {
                return DateTime.Now.Millisecond * (DateTime.Now.Millisecond.ToString().Length);
            }
        }

        public static void TallyServiceLog(string LogType, string OrderNumber, string Customer, DateTime OrderDate, DateTime TallySyncDate, string DBStatus)
        {
            try
            {
                CreateFolder(System.IO.Path.Combine(GetSystemFilePath() + @"SOReceipts"));
                string logFile = System.IO.Path.Combine(GetSystemFilePath() + @"SOReceipts" + @"\" + "SOReceiptslog" + "_" + DateTime.Now.ToString("dd_MM_yyyy") + ".txt");
                StringBuilder sb = new StringBuilder();

                using (FileStream fs = new FileStream(logFile, FileMode.OpenOrCreate, FileAccess.Read, FileShare.Read))
                {
                    StreamReader sr = new StreamReader(fs);
                    sb.Append(sr.ReadToEnd());
                    sr.Close();
                    //BinaryWriter br = new BinaryWriter(fs);
                    //br.Write(sb.ToString());
                }

                sb.AppendLine("Type : " + LogType);
                sb.AppendLine("Sales Order / Receipt Number : " + OrderNumber);
                sb.AppendLine("Customer : " + Customer);
                sb.AppendLine("Order / Receipt Date : " + OrderDate);
                sb.AppendLine("Tally Sync Date : " + TallySyncDate);
                sb.AppendLine("Database Status : " + DBStatus);
                sb.AppendLine("************");

                //if (System.IO.File.Exists(logFile))
                //{
                //    sb.Append(System.IO.File.ReadAllText(logFile));
                //}

                FileWriter fileWriter = new FileWriter();
                fileWriter.WriteData(sb.ToString(), logFile);
            }
            catch (Exception ex)
            {
                LogError(ex.Message, null, ex.InnerException, null);
            }
        }

        public static string ConvertNumbertoText(long number)
        {
            if (number != 0)
                return new AmountConverter(number, AmountConverter.ConvertStyle.Asian).Convert();
            else
                return string.Empty;
        }
    }
}
