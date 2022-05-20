using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace GentilCareBack
{
    public class Utils
    {

        public static void SendMailPINGmail(string PIN, string emailUser) {
            try
            {
                GestorCorreo gestor = new GestorCorreo();

                //Correo con archivos adjuntos
                //MailMessage correo = new MailMessage("tucuenta@gmail.com",
                //                                     "benjamin@aspnetcoremaster.com",
                //                                     "Archivo de configuracíon",
                //                                     "Por favor verificar adjunto.");

                //string ruta = "Configuracion.xml";
                //Attachment adjunto = new Attachment(ruta, MediaTypeNames.Application.Xml);
                //correo.Attachments.Add(adjunto);
                //gestor.EnviarCorreo(correo);

                // Correo con HTML
                //gestor.EnviarCorreo("jesus.hernandez@nayeeri.com.mx",
                //                    "Prueba",
                //                    "Mensaje en texto plano");
                // Correo de texto  

                string body = "Este es el pin para verificar tu cuenta:" + Environment.NewLine;
                body += "<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\">";
                body += "<tbody><tr>";
                body += "<td align=\"center\" bgcolor=\"#ffffff\" style=\"padding:12px\"> ";
                body += "<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\">";
                body += "<tbody><tr>";
                body += "<td align=\"center\" bgcolor=\"#1a82e2\" style=\"border-radius:6px\"> ";
                body += "<a style=\"display: inline - block; padding: 16px 36px; font - family:'Source Sans Pro',Helvetica,Arial,sans - serif; font - size:16px; color:#ffffff;text-decoration:none;border-radius:6px\"></a>";
                body += "</td>";
                body += "<td align=\"center\" bgcolor=\"#1a82e2\" style = \"border-radius:6px\" >";
                body += "<a style = \"display: inline - block; padding: 16px 36px; font - family:'Source Sans Pro',Helvetica,Arial,sans - serif; font - size:16px; color:#ffffff;text-decoration:none;border-radius:6px\"> " + PIN + " </a>";
                body += "</td>";
                body += "</tr>";
                body += "</tbody></table>";
                body += "</td>";
                body += "</tr>";
                body += "</tbody></table>';";
                body += Environment.NewLine + "NO RESPONDAS A ESTE CORREO";
                body += Environment.NewLine + Environment.NewLine + "Gentil Care";
                gestor.EnviarCorreo(emailUser,
                                    "VERIFICACIÓN DE CUENTA",
                                    body,
                                    true);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void SendMailUserAndPasswordGmail(string usuario, string password, string emailUser)
        {
            try
            {
                GestorCorreo gestor = new GestorCorreo();
                string body =  "Ingresa a nuestra pagina con las siguiente credenciales:" + Environment.NewLine;
                body += "<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\">";
                body += "<tbody><tr>";
                body += "<td align=\"center\" bgcolor=\"#ffffff\" style=\"padding:12px\"> ";
                body += "<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\">";
                body += "<tbody><tr>";
                body += "<td align=\"center\" bgcolor=\"#1a82e2\" style=\"border-radius:6px\"> ";
                body += "<a style=\"display: inline - block; padding: 16px 36px; font - family:'Source Sans Pro',Helvetica,Arial,sans - serif; font - size:16px; color:#ffffff;text-decoration:none;border-radius:6px\">NOMBRE DE USUARIO</a>";
                body += "</td>";
                body += "<td align=\"center\" bgcolor=\"#1a82e2\" style = \"border-radius:6px\" >";
                body += "<a style = \"display: inline - block; padding: 16px 36px; font - family:'Source Sans Pro',Helvetica,Arial,sans - serif; font - size:16px; color:#ffffff;text-decoration:none;border-radius:6px\"> " + usuario + " </a>";
                body += "</td>";
                body += "</tr>";
                body += "<tr>";
                body += "<td align=\"center\" bgcolor=\"#1a82e2\" style = \"border-radius:6px\" >";
                body += " <a style = \"display: inline - block; padding: 16px 36px; font - family:'Source Sans Pro',Helvetica,Arial,sans - serif; font - size:16px; color:#ffffff;text-decoration:none;border-radius:6px\" > CONTRASE&Ntilde;A </a>";
                body += "</td>";
                body += "<td align=\"center\" bgcolor=\"#1a82e2\" style=\"border-radius:6px\">";
                body += "<a style=\"display: inline - block; padding: 16px 36px; font - family:'Source Sans Pro',Helvetica,Arial,sans - serif; font - size:16px; color:#ffffff;text-decoration:none;border-radius:6px\" > " + password + " </a>";
                body += "</td>";
                body += "</tr>";
                body += "</tbody></table>";
                body += "</td>";
                body += "</tr>";
                body += "</tbody></table>';";
                body += Environment.NewLine + "NO RESPONDAS A ESTE CORREO";
                body += Environment.NewLine + Environment.NewLine + "Gentil Care";

                gestor.EnviarCorreo(emailUser,
                                    "BIENVENIDO A GENTIL CARE",
                                    body,
                                    true);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void SendMainAddressAndPassword(string usuario, string password, string emailUser) {
            
            MailMessage correo = new MailMessage();
            correo.From = new MailAddress("Gentil Care <contacto.gentil.care@gmail.com>", "Gentil Care", System.Text.Encoding.UTF8);//Correo de salida
            correo.To.Add(emailUser); //Correo destino?
            correo.Subject = "BIENVENIDO A GENTIL CARE"; //Asunto
            correo.Body = "Ingresa a nuestra pagina con las siguiente credenciales:" + Environment.NewLine;
            correo.Body += "<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\">";
            correo.Body += "<tbody><tr>";
            correo.Body += "<td align=\"center\" bgcolor=\"#ffffff\" style=\"padding:12px\"> ";
            correo.Body += "<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\">";
            correo.Body += "<tbody><tr>";
            correo.Body += "<td align=\"center\" bgcolor=\"#1a82e2\" style=\"border-radius:6px\"> ";
            correo.Body += "<a style=\"display: inline - block; padding: 16px 36px; font - family:'Source Sans Pro',Helvetica,Arial,sans - serif; font - size:16px; color:#ffffff;text-decoration:none;border-radius:6px\">NOMBRE DE USUARIO</a>";
            correo.Body += "</td>";
            correo.Body += "<td align=\"center\" bgcolor=\"#1a82e2\" style = \"border-radius:6px\" >";
            correo.Body += "<a style = \"display: inline - block; padding: 16px 36px; font - family:'Source Sans Pro',Helvetica,Arial,sans - serif; font - size:16px; color:#ffffff;text-decoration:none;border-radius:6px\"> " + usuario + " </a>";
            correo.Body += "</td>";
            correo.Body += "</tr>";
            correo.Body += "<tr>";
            correo.Body += "<td align=\"center\" bgcolor=\"#1a82e2\" style = \"border-radius:6px\" >";
            correo.Body += " <a style = \"display: inline - block; padding: 16px 36px; font - family:'Source Sans Pro',Helvetica,Arial,sans - serif; font - size:16px; color:#ffffff;text-decoration:none;border-radius:6px\" > CONTRASE&Ntilde;A </a>";
            correo.Body += "</td>";
            correo.Body += "<td align=\"center\" bgcolor=\"#1a82e2\" style=\"border-radius:6px\">";
            correo.Body += "<a style=\"display: inline - block; padding: 16px 36px; font - family:'Source Sans Pro',Helvetica,Arial,sans - serif; font - size:16px; color:#ffffff;text-decoration:none;border-radius:6px\" > " + password + " </a>";
            correo.Body += "</td>";
            correo.Body += "</tr>";
            correo.Body += "</tbody></table>";
            correo.Body += "</td>";
            correo.Body += "</tr>";
            correo.Body += "</tbody></table>';";
            correo.Body += Environment.NewLine + "NO RESPONDAS A ESTE CORREO";
            correo.Body += Environment.NewLine + Environment.NewLine + "Gentil Care";
            correo.IsBodyHtml = true;
            correo.Priority = MailPriority.Normal;
            SmtpClient smtp = new SmtpClient();
            smtp.UseDefaultCredentials = false;
            smtp.Host = "smtp.gmail.com"; //Host del servidor de correo
            smtp.Port = 25; //Puerto de salida
            smtp.Credentials = new System.Net.NetworkCredential("contacto.gentil.care@gmail.com", "Gentil2022");//Cuenta de correo
            ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
            smtp.EnableSsl = true;//True si el servidor de correo permite ssl
            smtp.Send(correo);
            

            /*
            MailMessage correo = new MailMessage();
            correo.From = new MailAddress("Gentil Care <contacto@gentil.care>", "Gentil Care", System.Text.Encoding.UTF8);//Correo de salida
            correo.To.Add(emailUser); //Correo destino?
            correo.Subject = "BIENVENIDO A GENTIL CARE"; //Asunto
            correo.Body = "Ingresa a nuestra pagina con las siguiente credenciales:" + Environment.NewLine;
            correo.Body += "<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\">";
            correo.Body += "<tbody><tr>";
            correo.Body += "<td align=\"center\" bgcolor=\"#ffffff\" style=\"padding:12px\"> ";
            correo.Body += "<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\">";
            correo.Body += "<tbody><tr>";
            correo.Body += "<td align=\"center\" bgcolor=\"#1a82e2\" style=\"border-radius:6px\"> ";
            correo.Body += "<a style=\"display: inline - block; padding: 16px 36px; font - family:'Source Sans Pro',Helvetica,Arial,sans - serif; font - size:16px; color:#ffffff;text-decoration:none;border-radius:6px\">NOMBRE DE USUARIO</a>";
            correo.Body += "</td>";
            correo.Body += "<td align=\"center\" bgcolor=\"#1a82e2\" style = \"border-radius:6px\" >";
            correo.Body += "<a style = \"display: inline - block; padding: 16px 36px; font - family:'Source Sans Pro',Helvetica,Arial,sans - serif; font - size:16px; color:#ffffff;text-decoration:none;border-radius:6px\"> " + usuario + " </a>"; 
            correo.Body += "</td>";
            correo.Body += "</tr>"; 
            correo.Body += "<tr>";
            correo.Body += "<td align=\"center\" bgcolor=\"#1a82e2\" style = \"border-radius:6px\" >";
            correo.Body += " <a style = \"display: inline - block; padding: 16px 36px; font - family:'Source Sans Pro',Helvetica,Arial,sans - serif; font - size:16px; color:#ffffff;text-decoration:none;border-radius:6px\" > CONTRASE&Ntilde;A </a>";
            correo.Body += "</td>";
            correo.Body += "<td align=\"center\" bgcolor=\"#1a82e2\" style=\"border-radius:6px\">" ;
            correo.Body += "<a style=\"display: inline - block; padding: 16px 36px; font - family:'Source Sans Pro',Helvetica,Arial,sans - serif; font - size:16px; color:#ffffff;text-decoration:none;border-radius:6px\" > " + password + " </a>";
            correo.Body += "</td>";
            correo.Body += "</tr>";
            correo.Body += "</tbody></table>";
            correo.Body += "</td>";
            correo.Body += "</tr>";
            correo.Body += "</tbody></table>';";
            correo.Body += Environment.NewLine + "NO RESPONDAS A ESTE CORREO";
            correo.Body += Environment.NewLine + Environment.NewLine + "Gentil Care";

            correo.IsBodyHtml = true;
            correo.Priority = MailPriority.Normal;
            SmtpClient smtp = new SmtpClient();
            smtp.UseDefaultCredentials = false;
            smtp.Host = "mail.gentil.care"; //Host del servidor de correo
            smtp.Port = 587; //Puerto de salida
            smtp.Credentials = new System.Net.NetworkCredential("contacto@gentil.care", "Monterrey*sw8");//Cuenta de correo
            ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
            smtp.EnableSsl = true;//True si el servidor de correo permite ssl
            smtp.Send(correo);
            */
        }

        public static void SendMainPin(string PIN, string emailUser)
        {
            
            MailMessage correo = new MailMessage();
            correo.From = new MailAddress("Gentil Care <contacto.gentil.care@gmail.com>", "Gentil Care", System.Text.Encoding.UTF8);//Correo de salida
            correo.To.Add(emailUser); //Correo destino?
            correo.Subject = "VERIFICACIÓN DE CUENTA"; //Asunto
            correo.Body = "Este es el pin para verificar tu cuenta:" + Environment.NewLine;
            correo.Body += "<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\">";
            correo.Body += "<tbody><tr>";
            correo.Body += "<td align=\"center\" bgcolor=\"#ffffff\" style=\"padding:12px\"> ";
            correo.Body += "<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\">";
            correo.Body += "<tbody><tr>";
            correo.Body += "<td align=\"center\" bgcolor=\"#1a82e2\" style=\"border-radius:6px\"> ";
            correo.Body += "<a style=\"display: inline - block; padding: 16px 36px; font - family:'Source Sans Pro',Helvetica,Arial,sans - serif; font - size:16px; color:#ffffff;text-decoration:none;border-radius:6px\"></a>";
            correo.Body += "</td>";
            correo.Body += "<td align=\"center\" bgcolor=\"#1a82e2\" style = \"border-radius:6px\" >";
            correo.Body += "<a style = \"display: inline - block; padding: 16px 36px; font - family:'Source Sans Pro',Helvetica,Arial,sans - serif; font - size:16px; color:#ffffff;text-decoration:none;border-radius:6px\"> " + PIN + " </a>";
            correo.Body += "</td>";
            correo.Body += "</tr>";
            correo.Body += "</tbody></table>";
            correo.Body += "</td>";
            correo.Body += "</tr>";
            correo.Body += "</tbody></table>';";
            correo.Body += Environment.NewLine + "NO RESPONDAS A ESTE CORREO";
            correo.Body += Environment.NewLine + Environment.NewLine + "Gentil Care";
            correo.IsBodyHtml = true;
            correo.Priority = MailPriority.Normal;
            SmtpClient smtp = new SmtpClient();
            smtp.UseDefaultCredentials = false;
            smtp.Host = "smtp.gmail.com"; //Host del servidor de correo
            smtp.Port = 25; //Puerto de salida
            smtp.Credentials = new System.Net.NetworkCredential("contacto.gentil.care@gmail.com", "Gentil2022");//Cuenta de correo
            ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
            smtp.EnableSsl = true;//True si el servidor de correo permite ssl
            smtp.Send(correo);
            

            /*
            MailMessage correo = new MailMessage();
            correo.From = new MailAddress("Gentil Care <contacto@gentil.care>", "Gentil Care", System.Text.Encoding.UTF8);//Correo de salida
            correo.To.Add(emailUser); //Correo destino?
            correo.Subject = "VERIFICACIÓN DE CUENTA"; //Asunto
            correo.Body = "Este es el pin para verificar tu cuenta:" + Environment.NewLine;
            correo.Body += "<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\">";
            correo.Body += "<tbody><tr>";
            correo.Body += "<td align=\"center\" bgcolor=\"#ffffff\" style=\"padding:12px\"> ";
            correo.Body += "<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\">";
            correo.Body += "<tbody><tr>";
            correo.Body += "<td align=\"center\" bgcolor=\"#1a82e2\" style=\"border-radius:6px\"> ";
            correo.Body += "<a style=\"display: inline - block; padding: 16px 36px; font - family:'Source Sans Pro',Helvetica,Arial,sans - serif; font - size:16px; color:#ffffff;text-decoration:none;border-radius:6px\"></a>";
            correo.Body += "</td>";
            correo.Body += "<td align=\"center\" bgcolor=\"#1a82e2\" style = \"border-radius:6px\" >";
            correo.Body += "<a style = \"display: inline - block; padding: 16px 36px; font - family:'Source Sans Pro',Helvetica,Arial,sans - serif; font - size:16px; color:#ffffff;text-decoration:none;border-radius:6px\"> " + PIN + " </a>";
            correo.Body += "</td>";
            correo.Body += "</tr>";
            correo.Body += "</tbody></table>";
            correo.Body += "</td>";
            correo.Body += "</tr>";
            correo.Body += "</tbody></table>';";
            correo.Body += Environment.NewLine + "NO RESPONDAS A ESTE CORREO";
            correo.Body += Environment.NewLine + Environment.NewLine + "Gentil Care";

            correo.IsBodyHtml = true;
            correo.Priority = MailPriority.Normal;
            SmtpClient smtp = new SmtpClient();
            smtp.UseDefaultCredentials = false;
            smtp.Host = "mail.gentil.care"; //Host del servidor de correo
            smtp.Port = 587; //Puerto de salida
            smtp.Credentials = new System.Net.NetworkCredential("contacto@gentil.care", "Monterrey*sw8");//Cuenta de correo
            ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
            smtp.EnableSsl = true;//True si el servidor de correo permite ssl
            smtp.Send(correo);
            */
        }
    }
}
