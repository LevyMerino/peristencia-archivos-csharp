

namespace MedicamentContext
{
    public class TextFile 
    {
        private string Path { get; set; }
        protected StreamReader? Sr;
        protected StreamWriter? Sw;
        
        public TextFile(string path)
        {
            Path = path;           
        }

        public string OpenReading()
        {
            try
            {
                Sr = new StreamReader(Path);
                return "Se abrio el archivo";
            }
            catch (Exception e)
            {
                return "Exception: " + e.Message;
            }

        }

        public void CloseReading()
        {
            Sr?.Close();
        }

        public string OpenWriting()
        {
            try
            {
                Sw = new StreamWriter(Path);
                return "Se abrio el archivo";
            }
            catch (Exception e)
            {
                return "Exception: " + e.Message;
            }

        }

        public void CloseWriting()
        {
            Sw?.Close();
        }
    }
}