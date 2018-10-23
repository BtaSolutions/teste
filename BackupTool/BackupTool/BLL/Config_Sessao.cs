using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BackupTool.BLL
{
    public static class Config_Sessao
    {
        public static string host { get; set; } = "";
        public static string port { get; set; } = "";
        public static string db { get; set; } = "";
        public static string user { get; set; } = "";
        public static string password { get; set; } = "";
        public static string caminho_pg_dump { get; set; } = "";
    }
}
