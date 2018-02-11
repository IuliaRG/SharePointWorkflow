using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Accesa.ServiceDeskWeb.InternalDtos
{
    public class AllStatus
    {
        public static readonly string Undefined = "Undefined";
        public static readonly string New ="New";
        public static readonly string InProgress ="In progress";
        public static readonly string Solved ="Solved";
        public static readonly string RespondedToOriginator = "Responded to originator";
        public static readonly string NoResponse = "No response";
        public static readonly string KnownIssue = "Known issue";
    }
}