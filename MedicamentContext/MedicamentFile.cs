using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MedicamentContext
{
    public class MedicamentFile : TextFile
    {
        public List<DataMedicament>? Elements { get; set; }
        public MedicamentFile(string path) : base(path)
        {
            Elements = new List<DataMedicament>();
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
                                DataMedicament dataMedicament = new()
                                {
                                    Id = int.Parse(dataLine[0]),
                                    Nombre = dataLine[1],
                                    Concentracion = dataLine[2],
                                    IdFormaFamamaceutica = int.Parse(dataLine[3]),
                                    Precio = float.Parse(dataLine[4]),
                                    Stock = int.Parse(dataLine[5]),
                                    Presentacion = dataLine[6],
                                    Habilitado = int.Parse(dataLine[7])
                                };

                                Elements?.Add(dataMedicament);
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

        public string White()
        {

            if (Elements is not null)
            {
                OpenWriting();
                foreach (var item in Elements)
                {
                    Sw?.WriteLine($"{item.Id}|{item.Nombre}|{item.Concentracion}|{item.IdFormaFamamaceutica}" +
                        $"|{item.Precio}|{item.Stock}|{item.Presentacion}|{item.Habilitado}");
                }
                CloseWriting();
            }

            return "Se escribio en el archivo";
        }


        public void Agregar(DataMedicament item)
        {
            Read();

            if (Elements is not null)
            {
                var lastItem = Elements.Last();
                item.Id = lastItem.Id + 1;
                Elements.Add(item);
            }

            White();
        }

        public void Delete(int id)
        {
            Read();

            if (Elements is not null)
            {
                Elements.RemoveAt(id - 1);
            }

            White();
        }

        public void Editar(int id, DataMedicament dataMedicament)
        {
            Read();

            if (Elements is not null)
            {

                foreach (var item in Elements)
                {
                    if (item.Id == id)
                    {
                        item.Nombre = dataMedicament.Nombre;
                        item.Concentracion = dataMedicament.Concentracion;
                        item.IdFormaFamamaceutica = dataMedicament.IdFormaFamamaceutica;
                        item.Precio = dataMedicament.Precio;
                        item.Stock = dataMedicament.Stock;
                        item.Presentacion = dataMedicament.Presentacion;
                        item.Habilitado = dataMedicament.Habilitado;
                    }
                }
            }

            White();
        }

    }
}
