using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Taafi.Application.Helpers
{
    public class EmailBody
    {

        public static string GetEmail(string Name, string Time, string QueueNumber)
        {
            string email = $@"
<!DOCTYPE html>
<html>
<head>
    <style>
       
        body {{ font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; }}
    </style>
</head>
<body style='margin: 0; padding: 0; background-color: #f4f4f4;'>
    
    <div style='max-width: 600px; margin: 20px auto; background-color: #ffffff; border-radius: 8px; overflow: hidden; box-shadow: 0 0 10px rgba(0,0,0,0.1); direction: rtl; text-align: right;'>
        
        <div style='background-color: #2c3e50; color: #ffffff; padding: 20px; text-align: center;'>
            <h2 style='margin: 0;'>نظام تعافي الطبي</h2>
        </div>

        <div style='padding: 30px;'>
            <h3 style='color: #2c3e50; margin-top: 0;'>مرحباً دكتور،</h3>
            <p style='font-size: 16px; color: #555555; line-height: 1.6;'>
                تم تسجيل حجز جديد في النظام. يرجى الاطلاع على التفاصيل أدناه:
            </p>

            <div style='background-color: #f9f9f9; border: 1px solid #e0e0e0; padding: 15px; border-radius: 5px; margin: 20px 0;'>
                <p style='margin: 5px 0;'><strong>اسم المريض:</strong> {Name}</p>
                <p style='margin: 5px 0;'><strong>رقم الحجز:</strong> <span style='font-family: monospace; font-size: 1.1em;'>{QueueNumber}</span></p>
                <p style='margin: 5px 0;'><strong>وقت الحجز:</strong> <span dir='ltr' style='display:inline-block;'>{Time}</span></p>
            </div>

        </div>

        <div style='background-color: #eeeeee; color: #888888; padding: 15px; text-align: center; font-size: 12px;'>
            &copy; 2025 Taafi Medical System. جميع الحقوق محفوظة.
        </div>

    </div>

</body>
</html>";
            return email;
        }
        
    }
}
