using JavaToNSD.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JavaToNSD
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.ThreadException += Application_ThreadException;
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            sendMail(convertException(e.Exception), e.Exception.HResult.ToString());
        }



        static private string convertException(Exception e)
        {
            string inhalt = DateTime.Now.ToLongTimeString();
            try
            {
                //inhalt += "Machine Name:\n";
                //inhalt += System.Environment.MachineName;
                inhalt += "\n";

                inhalt += "Version:\n";
                inhalt += Environment.Version.ToString();
                inhalt += "\n";

                inhalt += "OS-Version:\n";
                inhalt += System.Environment.OSVersion.VersionString;
                inhalt += "\n";

                inhalt += "Größe des Arbeitsspeichers für die Auslagerungsdatei:\n";
                inhalt += System.Environment.SystemPageSize.ToString();
                inhalt += "\n";

                //inhalt += "Anzahl an Millisekunden seit dem Systemstart:\n";
                //inhalt += System.Environment.TickCount.ToString();
                //inhalt += "\n";
                inhalt += "Physischer Speicher:\n";
                inhalt += System.Environment.WorkingSet.ToString();
                inhalt += "\n";
                inhalt += "\n";
                inhalt += "\n";
                inhalt += "--------DATA--------";
                foreach (String item in e.Data)
                {
                    inhalt += item;
                    inhalt += "\n";
                }
                inhalt += "\n";
                inhalt += "--------------------";
                inhalt += "\n";
                inhalt += "\n";
                inhalt += "*InnerException*";
                if (e.InnerException != null)
                {
                    inhalt += convertException(e.InnerException);
                    inhalt += "\n";
                }
                inhalt += "\n";
                inhalt += "--------------------";
                inhalt += "\n";

                inhalt += "Hilfelink:\n";
                inhalt += e.HelpLink;

                inhalt += "\n";
                inhalt += "Message:\n";
                inhalt += e.Message;
                inhalt += "\n";

                inhalt += "Quelle:\n";
                inhalt += e.Source;
                inhalt += "\n";

                inhalt += "\n";
                inhalt += "\n";

                inhalt += "Methode:\n";

                inhalt += "Attribute:\n";
                inhalt += e.TargetSite.Attributes;
                inhalt += "\n";

                inhalt += "Aufrufkonvention:\n";
                inhalt += e.TargetSite.CallingConvention.ToString();
                inhalt += "\n";

                inhalt += "Enthält nicht zugewiesene Typparameter:\n";
                inhalt += e.TargetSite.ContainsGenericParameters.ToString();
                inhalt += "\n";

                inhalt += "Abtrake Methode:\n";
                inhalt += e.TargetSite.IsAbstract.ToString();
                inhalt += "\n";

                inhalt += "Konstruktor:\n";
                inhalt += e.TargetSite.IsConstructor.ToString();
                inhalt += "\n";

                inhalt += "Privat:\n";
                inhalt += e.TargetSite.IsPrivate.ToString();
                inhalt += "\n";

                inhalt += "Public:\n";
                inhalt += e.TargetSite.IsPublic.ToString();
                inhalt += "\n";

                inhalt += "Name:\n";
                inhalt += e.TargetSite.Name;
                inhalt += "\n";
                inhalt += "\n";
                inhalt += "\n";

                inhalt += "Frame:\n";
                inhalt += e.StackTrace;
                inhalt += "\n";
            }
            catch (Exception)
            {
                inhalt = "Fehler bei Erstellen der Fehlermeldung";
            }
            return inhalt;
        }

        static private void sendMail(string inhalt, string betreff)
        {
            //Erzeugt eine neue Mail
            MailMessage mail = new MailMessage();
            //legt den Absender der Mail auf die gespeicherte E-Mailadresse
            mail.From = new MailAddress(Settings.Default.MailName);
            //fügt einen Empfänger hinzu
            mail.To.Add("javansd@outlook.de");
            //legt den Betreff fest
            mail.Subject = betreff;
            //legt den Inhalt fest
            mail.Body = inhalt;
            //neuer SMTP-Client mit dem gespeicherten Mail-Server und gespeicherten Port
            SmtpClient client = new SmtpClient(Settings.Default.MailServer, Settings.Default.MailPort);
            //versucht eine Mail zu senden
            try
            {
                //erstellt neue Anmeldeinformationen
                client.Credentials = new System.Net.NetworkCredential(Settings.Default.MailName, Settings.Default.MailPass);
                //aktiviert ssl
                client.EnableSsl = true;
                //sendet die Mail
                client.Send(mail);
                MessageBox.Show("Fehler gesendet");
            }
            catch (Exception ex)
            {
                //gibt den Fehler aus
                MessageBox.Show("Fehler beim Senden der Mail:\n" + ex.Message);
            }
        }
    }
}