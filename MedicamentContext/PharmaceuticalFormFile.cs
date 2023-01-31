using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MedicamentContext
{
    public class PharmaceuticalFormFile : TextFile
    {
        public List<DataPharmaceuticalForm>? Elements { get; set; }
        public PharmaceuticalFormFile (string path ) : base(path )
        {
            Elements = new List<DataPharmaceuticalForm>();
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
                        if (!line.Contains("|NOMBRE|"))
                        {

                            var dataLine = line?.Split('|');

                            if (dataLine is not null)
                            {
                                DataPharmaceuticalForm dataPharmaceuticalForm = new()
                                {
                                    Id = int.Parse(dataLine[0]),
                                    Nombre = dataLine[1],
                                    Habilitado = int.Parse(dataLine[2])
                                };

                                Elements?.Add(dataPharmaceuticalForm);
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
