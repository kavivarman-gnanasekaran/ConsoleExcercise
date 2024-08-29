using System;
using System.Net.Mail;
using System.Net;
using System.IO;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SMTP
{
    public class smtp
    {
       
        private readonly IConfiguration configuration;

        public  smtp(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public string password;

        public string fromEmail { set; get; }
        string body = $"Hello! I am kavivarman this is main email @{DateTime.UtcNow:F}";
        

        public void JsonRead()
        {
            string read;
            read = null;
            try
            {
                
                StreamReader reader = new StreamReader("C:\\Users\\Anaiyaan\\source\\repos\\ConsoleExcercise\\ConsoleExcercise\\jsonread.json");
                string Json = reader.ReadToEnd();
                List<Forecast> Result = JsonConvert.DeserializeObject<List<Forecast>>(Json);

                foreach (var source in Result)
                {
                    body+= $"{source.date},{source.temperatureC},{source.temperatureF}"+
                        $"{source.summary} ";
                  
                    Console.WriteLine($"{source.date},{source.temperatureC},{source.temperatureF}" +
                        $"{source.summary} ");
                }
            }
            catch(Exception e)
            {
                body += e;
            }
        }
        public void FileLog()
        {
            string file = $"File_{DateTime.Now.ToString("yyyy-MM-dd")}.txt";
            JsonRead();
            send();
            try
            {
                
                StreamWriter sw = new StreamWriter($"C:\\New folder\\{file}", false);
                sw.WriteLine($"Succefully sent Mail in{DateTime.Now.ToString("yyyy-MM-dd")} ");
                sw.Close();

            }
            catch (Exception e)
            {
               // string directory = "C:\\New folder";
                StreamWriter sw1 = new StreamWriter($"C:\\New folder\\{file}", false);
                sw1.WriteLine(e.StackTrace);
                sw1.Close();
            }

        }


        public void send()
        {
            Console.WriteLine(GetUserName());
            Console.WriteLine("Hello World!");

            SendEmail(GetUserName(), GetPassword());
            
        }
        public  void SendEmail(string fromAddress, string password)
        {
            using SmtpClient email = new SmtpClient
            {
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                EnableSsl = true,
                Host = "smtp.gmail.com",
                Port = 587,
                Credentials = new NetworkCredential(fromAddress, password)

            };
            Console.WriteLine(fromAddress);
            string subject = "Good Morning";
           
            try
            {
                Console.WriteLine("sending email ");
                email.Send(fromAddress, toAddress(), subject, body);
                Console.WriteLine("email sent ");
            }
            catch (SmtpException e)
            {
                throw ;
            }

        }
        public  string GetUserName()
        {
            var dataFromJsonFile = configuration.GetSection("fromAdderss").Value;
           
            return dataFromJsonFile;
        }
        public string GetPassword()
        {
            var dataFromJsonFile1 = configuration.GetSection("password").Value;         
            return dataFromJsonFile1;
        }
        public  string toAddress()
        {
            var dataFromJsonFile1 = configuration.GetSection("toAddress").Value; 
            return dataFromJsonFile1;


        }
      }
    }


    


