using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MedicamentContext 
{
    public class UserFile : TextFile
    {

        public List<DataUser> Elements { get; set; }
        public UserFile(string path ) : base( path )
        {
            Elements= new List<DataUser>();    
        }

        public string Read()
        {
            OpenReading();

            String? line;
            try
            {

                while (!Sr.EndOfStream)
                {
                    line = Sr?.ReadLine();

                    if (line is not null)
                    {
                        if (!line.Contains("|nombre|"))
                        {

                            var dataLine = line?.Split('|');

                            if (dataLine is not null)
                            {
                                DataUser dataUser = new()
                                {
                                    Id = int.Parse(dataLine[0]),
                                    Nombre = dataLine[1],
                                    FechaCreacion = DateTime.Parse(dataLine[2]),
                                    Usuario = dataLine[3],
                                    Password = dataLine[4],
                                    IdPerfil = int.Parse(dataLine[5]),
                                    Estatus = int.Parse(dataLine[6])
                                };

                                Elements?.Add(dataUser);
                            }
                        }
                    }

                }


                return "Ok";
            }
            catch (Exception e)
            {
                return "Exception: " + e.Message;
            }
            finally
            {
                CloseReading();
            }


        }


    }
}
