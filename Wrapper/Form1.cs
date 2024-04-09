
using Association_Tests;
using DAL;

using System.Windows.Forms;
using Order;


namespace Wrapper
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();



         //     GetOrder();
           GetAssociationTest();

    
        }

    





        private MockDataLayer GetAssociationTest()
        {
            var dal = new MockDataLayer();
            dal.Connect();
            var sdg = dal.GetSdgByName("13-00167");
            var associationTest = new AssociationTestsForm(sdg, null, null);
            associationTest.Dock = DockStyle.Fill;
            associationTest.Show();
            return dal;
        }

        private void GetOrder()
        {
            var order = new Order_cls();
            order.Dock = DockStyle.Fill;
            this.Controls.Add(order);
         //   IDataLayer dal = new MockDataLayer();
            //   order.Initialize(dal);
        }















        public static string Zip(string value)
        {
            //Transform string into byte[]  
            byte[] byteArray = new byte[value.Length];
            int indexBA = 0;
            foreach (char item in value.ToCharArray())
            {
                byteArray[indexBA++] = (byte)item;
            }

            //Prepare for compress
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            System.IO.Compression.GZipStream sw = new System.IO.Compression.GZipStream(ms,
                System.IO.Compression.CompressionMode.Compress);

            //Compress
            sw.Write(byteArray, 0, byteArray.Length);
            //Close, DO NOT FLUSH cause bytes will go missing...
            sw.Close();

            //Transform byte[] zip data to string
            byteArray = ms.ToArray();
            System.Text.StringBuilder sB = new System.Text.StringBuilder(byteArray.Length);
            foreach (byte item in byteArray)
            {
                sB.Append((char)item);
            }
            ms.Close();
            sw.Dispose();
            ms.Dispose();
            return sB.ToString();
        }



        public static string UnZip(string value)
        {
            //Transform string into byte[]
            byte[] byteArray = new byte[value.Length];
            int indexBA = 0;
            foreach (char item in value.ToCharArray())
            {
                byteArray[indexBA++] = (byte)item;
            }

            //Prepare for decompress
            System.IO.MemoryStream ms = new System.IO.MemoryStream(byteArray);
            System.IO.Compression.GZipStream sr = new System.IO.Compression.GZipStream(ms,
                System.IO.Compression.CompressionMode.Decompress);

            //Reset variable to collect uncompressed result
            byteArray = new byte[byteArray.Length];

            //Decompress
            int rByte = sr.Read(byteArray, 0, byteArray.Length);

            //Transform byte[] unzip data to string
            System.Text.StringBuilder sB = new System.Text.StringBuilder(rByte);
            //Read the number of bytes GZipStream red and do not a for each bytes in
            //resultByteArray;
            for (int i = 0; i < rByte; i++)
            {
                sB.Append((char)byteArray[i]);
            }
            sr.Close();
            ms.Close();
            sr.Dispose();
            ms.Dispose();
            return sB.ToString();
        }
    }
}


//  StringBuilder output = new StringBuilder();
//using (XmlReader reader = XmlReader.Create(new StringReader(xml)))
//{
//    reader.ReadToFollowing("Columns");
//    reader.MoveToFirstAttribute();
//    string genre = reader.Value;
//    output.AppendLine("The genre value: " + genre);

//    reader.ReadToFollowing("title");
//    output.AppendLine("Content of the title element: " + reader.ReadElementContentAsString());
//}







