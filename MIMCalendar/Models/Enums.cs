using System;

namespace MIMCalendar.Models
{
    [Flags]
    public enum EmailTemplateType
    {
        ToAdmin = 1,
        ToTeamMemebers = 2,
        ToGameMemebers = 4,
        ConfirmEmail = 8,
        ConfirmEmailByAdminRequest = 16,
    }
}