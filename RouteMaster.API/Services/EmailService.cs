using MailKit.Net.Smtp;
using MimeKit;

namespace RouteMaster.API;

public class EmailService
{
    public static async Task SendResetPasswordEmailAsync(string toEmail, string resetCode)
    {
        try
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("Soporte", "soporte.routemaster@gmail.com"));
            emailMessage.To.Add(new MailboxAddress("", toEmail));
            emailMessage.Subject = "Recuperación de contraseña";

            var emailBody = $"Estimado usuario,\n\n"
                  + "Hemos recibido una solicitud para restablecer la contraseña de su cuenta. Para completar este proceso, por favor ingrese este código en la aplicación:\n\n"
                  + $"{resetCode}\n\n"
                  + "Si no ha solicitado este cambio de contraseña, puede ignorar este mensaje de correo electrónico. Su contraseña actual seguirá siendo válida.\n\n"
                  + "Por favor, recuerde mantener sus credenciales de inicio de sesión seguras y no comparta su contraseña con nadie.\n\n"
                  + "Si necesita ayuda o tiene alguna pregunta, no dude en ponerse en contacto con nuestro equipo de soporte.\n\n"
                  + "Atentamente,\n\n"
                  + "Equipo de soporte técnico de RouteMaster\n";

            var body = new TextPart("plain")
            {
                Text = emailBody
            };

            emailMessage.Body = body;

            using var client = new SmtpClient();
            await client.ConnectAsync("smtp.gmail.com", 587, false);
            await client.AuthenticateAsync("soporte.routemaster@gmail.com", "zcbafcjgsbymozbo");
            await client.SendAsync(emailMessage);
            await client.DisconnectAsync(true);
        }
        catch (Exception ex)
        {
            // Handle exceptions here
            Console.WriteLine($"Error sending email: {ex}");
            throw;
        }
    }
}
