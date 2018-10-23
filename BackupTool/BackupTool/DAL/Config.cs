using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace BackupTool.DAL
{
    public class Config
    {
        public static void CarregarConfig()
        {
            try
            {
                string sPath = Directory.GetCurrentDirectory() + @"\config.xml";

                XmlDocument xml = new XmlDocument();
                xml.Load(sPath);

                XmlNodeList elemList = xml.GetElementsByTagName("config");

                foreach (XmlNode node in elemList)
                {
                    XmlNodeList elemList2 = node.ChildNodes;
                    foreach (XmlNode node2 in elemList2)
                    {
                        if (node2.Name      == "host")              BLL.Config_Sessao.host              = BLL.Crypt.Decrypt(node2.InnerText);
                        else if (node2.Name == "port")              BLL.Config_Sessao.port              = BLL.Crypt.Decrypt(node2.InnerText);
                        else if (node2.Name == "db")                BLL.Config_Sessao.db                = BLL.Crypt.Decrypt(node2.InnerText);
                        else if (node2.Name == "user")              BLL.Config_Sessao.user              = BLL.Crypt.Decrypt(node2.InnerText);
                        else if (node2.Name == "password")          BLL.Config_Sessao.password          = BLL.Crypt.Decrypt(node2.InnerText);
                        else if (node2.Name == "caminho_pg_dump")   BLL.Config_Sessao.caminho_pg_dump   = BLL.Crypt.Decrypt(node2.InnerText);
                    }
                }
            }
            catch (Exception excep)
            {
                throw new Exception(excep.Message);
            }

        }

        public static void SalvarConfig()
        {
            try
            {
                string sPath = Directory.GetCurrentDirectory() + @"\config.xml";

                if (File.Exists(sPath)) File.Delete(sPath);

                XmlTextWriter writer = new XmlTextWriter(sPath, Encoding.UTF8);

                //inicia o documento xml
                writer.WriteStartDocument();

                //define a indentação do arquivo
                writer.Formatting = Formatting.Indented;

                writer.WriteStartElement("config");

                writer.WriteElementString("host", BLL.Crypt.Encrypt(BLL.Config_Sessao.host));
                writer.WriteElementString("port", BLL.Crypt.Encrypt(BLL.Config_Sessao.port));
                writer.WriteElementString("db", BLL.Crypt.Encrypt(BLL.Config_Sessao.db));
                writer.WriteElementString("user", BLL.Crypt.Encrypt(BLL.Config_Sessao.user));
                writer.WriteElementString("password", BLL.Crypt.Encrypt(BLL.Config_Sessao.password));
                writer.WriteElementString("caminho_pg_dump", BLL.Crypt.Encrypt(BLL.Config_Sessao.caminho_pg_dump));

                writer.WriteEndElement();

                writer.WriteEndDocument();

                writer.Close();
            }
            catch (Exception excep)
            {
                throw new Exception(excep.Message);
            }

        }
    }
}
