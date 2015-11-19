using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace NovelPretender
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonGetFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Text files | *.txt";
            dialog.Multiselect = false;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                String path = dialog.FileName;
                String pathWithoutFile = Path.GetDirectoryName(path);
                String fileName = Path.GetFileNameWithoutExtension(path);
                String newFilePath = pathWithoutFile + "\\" + fileName + ".html";
                String line;
                int counter = 0, codeNum = 0;

                // Random code array
                String[] code = {
                                    "public static class PointFunctions" + Environment.NewLine + "{" + Environment.NewLine + "    public static double DistanceTo(this Point point1, Point point2)" + Environment.NewLine + "    {" + Environment.NewLine + "        var a = (double)(point2.X - point1.X);" + Environment.NewLine + "        var b = (double)(point2.Y - point1.Y);" + Environment.NewLine + "" + Environment.NewLine + "        return Math.Sqrt(a * a + b * b);" + Environment.NewLine + "    }" + Environment.NewLine + "}",
                                    "(Example 1)" + Environment.NewLine + "private Point getPointBaryCenter(Point p1, Point p2, Point p3)" + Environment.NewLine + "{" + Environment.NewLine + "	return new Point((p1.X + p2.X + p3.X) / 3, " + Environment.NewLine + "					(p1.Y + p2.Y + p3.Y) / 3);" + Environment.NewLine + "}" + Environment.NewLine + "" + Environment.NewLine + "(Example 2)" + Environment.NewLine + "private Point getInterpPt(Point p1, Point p2, Point p3)" + Environment.NewLine + "{" + Environment.NewLine + "	return new Point((p1.X >> 1) + ((p2.X + p3.X) >> 2)," + Environment.NewLine + "					(p1.Y >> 1) + ((p2.Y + p3.Y) >> 2));" + Environment.NewLine + "}",
                                    "public static T As<T>(this string input)" + Environment.NewLine + "{" + Environment.NewLine + "    return (T)TypeDescriptor.GetConverter(typeof(T)).ConvertFromString(input);" + Environment.NewLine + "}",
                                    "public void Jiggle()" + Environment.NewLine + "{" + Environment.NewLine + "     int X = this.Location.X;" + Environment.NewLine + "     int Y = this.Location.Y;" + Environment.NewLine + "     Random r = new Random();" + Environment.NewLine + "     int JiggleCount = 0;" + Environment.NewLine + "     int Z = 15;" + Environment.NewLine + "" + Environment.NewLine + "     while (JiggleCount < 1000)" + Environment.NewLine + "     {" + Environment.NewLine + "         this.Location = new Point(r.Next(X - Z, X + Z), r.Next(Y - Z, Y + Z));" + Environment.NewLine + "         JiggleCount++;" + Environment.NewLine + "     }" + Environment.NewLine + "" + Environment.NewLine + "     JiggleCount = 0;" + Environment.NewLine + "     this.Location = new Point(X, Y);" + Environment.NewLine + "}",
                                    "/// <summary>" + Environment.NewLine + "/// Calculates a point that is at an angle from the origin (0 is to the right)" + Environment.NewLine + "/// </summary>" + Environment.NewLine + "private PointF DegreesToXY(float degrees, float radius, Point origin)" + Environment.NewLine + "{" + Environment.NewLine + "    PointF xy = new PointF();" + Environment.NewLine + "    double radians = degrees * Math.PI / 180.0;" + Environment.NewLine + "" + Environment.NewLine + "    xy.X = (float)Math.Cos(radians) * radius + origin.X;" + Environment.NewLine + "    xy.Y = (float)Math.Sin(-radians) * radius + origin.Y;" + Environment.NewLine + "" + Environment.NewLine + "    return xy;" + Environment.NewLine + "}" + Environment.NewLine + "" + Environment.NewLine + "/// <summary>" + Environment.NewLine + "/// Calculates the angle a point is to the origin (0 is to the right)" + Environment.NewLine + "/// </summary>" + Environment.NewLine + "private float XYToDegrees(Point xy, Point origin)" + Environment.NewLine + "{" + Environment.NewLine + "    int deltaX = origin.X - xy.X;" + Environment.NewLine + "    int deltaY = origin.Y - xy.Y;" + Environment.NewLine + "" + Environment.NewLine + "    double radAngle = Math.Atan2(deltaY, deltaX);" + Environment.NewLine + "    double degreeAngle = radAngle * 180.0 / Math.PI;" + Environment.NewLine + "" + Environment.NewLine + "    return (float)(180.0 - degreeAngle);" + Environment.NewLine + "}",
                                    "private Point Project(Point line1, Point line2, Point toProject)" + Environment.NewLine + "{" + Environment.NewLine + "    double m = (double)(line2.Y - line1.Y) / (line2.X - line1.X);" + Environment.NewLine + "    double b = (double)line1.Y - (m * line1.X);" + Environment.NewLine + "" + Environment.NewLine + "    double x = (m * toProject.Y + toProject.X - m * b) / (m * m + 1);" + Environment.NewLine + "    double y = (m * m * toProject.Y + m * toProject.X + b) / (m * m + 1);" + Environment.NewLine + "" + Environment.NewLine + "    return new Point((int)x, (int)y);" + Environment.NewLine + "}",
                                    "public long Factorial(long x, long lowerBound)" + Environment.NewLine + "{" + Environment.NewLine + "    long fact = 1;" + Environment.NewLine + "    while (x >= 1 && x > lowerBound)" + Environment.NewLine + "    {" + Environment.NewLine + "        fact *= x;" + Environment.NewLine + "        x--;" + Environment.NewLine + "    }" + Environment.NewLine + "    return fact;" + Environment.NewLine + "}" + Environment.NewLine + "" + Environment.NewLine + "public long Choose(long n, long r)" + Environment.NewLine + "{" + Environment.NewLine + "    return (long)((double)Factorial(n, Math.Max(n - r, r)) / (Factorial(Math.Min(n - r, r))));" + Environment.NewLine + "}",
                                    "List initialization:" + Environment.NewLine + "List<Book> ListOfBooks = new List<Book>()" + Environment.NewLine + "{" + Environment.NewLine + "    new Book {name = \"DaVinci Code\"    , owner = \"Alex\" , date = 2002}," + Environment.NewLine + "    new Book {name = \"Angels and Demons\", owner = \"Jeff\" , date = 2005}," + Environment.NewLine + "    new Book {name = \"The Last Mughal\", owner = \"Danny\", date = 2001}," + Environment.NewLine + "};" + Environment.NewLine + "" + Environment.NewLine + "LINQ query:" + Environment.NewLine + "IEnumerable<Book> QueryResult = from Book in ListOfBooks" + Environment.NewLine + "                                select Book;",
                                    "private IList<string> SortStringLength(IList<string> stringList)" + Environment.NewLine + "{" + Environment.NewLine + "    string[] strs = stringList.ToArray<string>();" + Environment.NewLine + "    Array.Sort(strs, new Comparison<string>(delegate(string str1, string str2) " + Environment.NewLine + "    {" + Environment.NewLine + "        if (str1 == null && str2 == null)" + Environment.NewLine + "            return 0; //both empty" + Environment.NewLine + "        else if (str1 == null)" + Environment.NewLine + "            return -1; //empty string before non-empty string" + Environment.NewLine + "        else if (str2 == null)" + Environment.NewLine + "            return 1; //non-empty string after empty string" + Environment.NewLine + "        else" + Environment.NewLine + "        {" + Environment.NewLine + "            if (str1.Length < str2.Length)" + Environment.NewLine + "                return -1; //shorter string before longer string" + Environment.NewLine + "            else if (str1.Length > str2.Length)" + Environment.NewLine + "                return 1; //longer string after shorter string" + Environment.NewLine + "            else" + Environment.NewLine + "                return str1.CompareTo(str2); //alphabetical order" + Environment.NewLine + "        }" + Environment.NewLine + "    }));" + Environment.NewLine + "" + Environment.NewLine + "    return strs;" + Environment.NewLine + "}" + Environment.NewLine + "" + Environment.NewLine + "//Example call" + Environment.NewLine + "string[] test = { \"333\", null, \"1\", \"22\", \"12\", \"4444\" };" + Environment.NewLine + "test = (string[])SortStringLength(test);" + Environment.NewLine + "" + Environment.NewLine + "foreach (string s in test)" + Environment.NewLine + "{" + Environment.NewLine + "    Console.WriteLine(s);" + Environment.NewLine + "}",
                                    "using System;" + Environment.NewLine + "using System.Security.Cryptography;" + Environment.NewLine + "" + Environment.NewLine + "private static int NextInt(int min, int max)" + Environment.NewLine + "{" + Environment.NewLine + "    RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();" + Environment.NewLine + "    byte[] buffer = new byte[4];" + Environment.NewLine + "    " + Environment.NewLine + "    rng.GetBytes(buffer);" + Environment.NewLine + "    int result = BitConverter.ToInt32(buffer, 0);" + Environment.NewLine + "" + Environment.NewLine + "    return new Random(result).Next(min, max);" + Environment.NewLine + "}",
                                    "private long time()" + Environment.NewLine + "{" + Environment.NewLine + "    return time(DateTime.UtcNow);" + Environment.NewLine + "}" + Environment.NewLine + "" + Environment.NewLine + "private long time(DateTime time)" + Environment.NewLine + "{" + Environment.NewLine + "    DateTime unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0);" + Environment.NewLine + "    TimeSpan span = time.Subtract(unixEpoch);" + Environment.NewLine + "" + Environment.NewLine + "    return (long)span.TotalSeconds;" + Environment.NewLine + "}" + Environment.NewLine + "" + Environment.NewLine + "private DateTime fromPHPTime(long ticks)" + Environment.NewLine + "{" + Environment.NewLine + "    DateTime unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0);" + Environment.NewLine + "    return unixEpoch.Add(new TimeSpan(0, 0, (int)ticks));" + Environment.NewLine + "}",
                                    "public long Factorial(long x)" + Environment.NewLine + "{" + Environment.NewLine + "    long fact = 1;" + Environment.NewLine + "    long i = 1;" + Environment.NewLine + "    while (i <= x)" + Environment.NewLine + "    {" + Environment.NewLine + "        fact = fact * i;" + Environment.NewLine + "        i++;" + Environment.NewLine + "    }" + Environment.NewLine + "    return fact;" + Environment.NewLine + "}" + Environment.NewLine + "" + Environment.NewLine + "public long Factorial(long x, long lowerBound)" + Environment.NewLine + "{" + Environment.NewLine + "    long fact = 1;" + Environment.NewLine + "    while (x >= 1 && x > lowerBound)" + Environment.NewLine + "    {" + Environment.NewLine + "        fact *= x;" + Environment.NewLine + "        x--;" + Environment.NewLine + "    }" + Environment.NewLine + "" + Environment.NewLine + "    return fact;" + Environment.NewLine + "}",
                                    "function getRealIpAddr()  " + Environment.NewLine + "{  " + Environment.NewLine + "    if (!emptyempty($_SERVER['HTTP_CLIENT_IP']))  " + Environment.NewLine + "    {  " + Environment.NewLine + "        $ip=$_SERVER['HTTP_CLIENT_IP'];  " + Environment.NewLine + "    }  " + Environment.NewLine + "    elseif (!emptyempty($_SERVER['HTTP_X_FORWARDED_FOR']))  " + Environment.NewLine + "    //to check ip is pass from proxy  " + Environment.NewLine + "    {  " + Environment.NewLine + "        $ip=$_SERVER['HTTP_X_FORWARDED_FOR'];  " + Environment.NewLine + "    }  " + Environment.NewLine + "    else  " + Environment.NewLine + "    {  " + Environment.NewLine + "        $ip=$_SERVER['REMOTE_ADDR'];  " + Environment.NewLine + "    }  " + Environment.NewLine + "    return $ip;  " + Environment.NewLine + "}",
                                    "function force_download($file) " + Environment.NewLine + "{ " + Environment.NewLine + "    $dir = \"../log/exports/\"; " + Environment.NewLine + "    if ((isset($file))&&(file_exists($dir.$file))) { " + Environment.NewLine + "       header(\"Content-type: application/force-download\"); " + Environment.NewLine + "       header('Content-Disposition: inline; filename=\"' . $dir.$file . '\"'); " + Environment.NewLine + "       header(\"Content-Transfer-Encoding: Binary\"); " + Environment.NewLine + "       header(\"Content-length: \".filesize($dir.$file)); " + Environment.NewLine + "       header('Content-Type: application/octet-stream'); " + Environment.NewLine + "       header('Content-Disposition: attachment; filename=\"' . $file . '\"'); " + Environment.NewLine + "       readfile(\"$dir$file\"); " + Environment.NewLine + "    } else { " + Environment.NewLine + "       echo \"No file selected\"; " + Environment.NewLine + "    } " + Environment.NewLine + "" + Environment.NewLine + "}",
                                    "function create_zip($files = array(),$destination = '',$overwrite = false) {  " + Environment.NewLine + "    //if the zip file already exists and overwrite is false, return false  " + Environment.NewLine + "    if(file_exists($destination) && !$overwrite) { return false; }  " + Environment.NewLine + "    //vars  " + Environment.NewLine + "    $valid_files = array();  " + Environment.NewLine + "    //if files were passed in...  " + Environment.NewLine + "    if(is_array($files)) {  " + Environment.NewLine + "        //cycle through each file  " + Environment.NewLine + "        foreach($files as $file) {  " + Environment.NewLine + "            //make sure the file exists  " + Environment.NewLine + "            if(file_exists($file)) {  " + Environment.NewLine + "                $valid_files[] = $file;  " + Environment.NewLine + "            }  " + Environment.NewLine + "        }  " + Environment.NewLine + "    }  " + Environment.NewLine + "    //if we have good files...  " + Environment.NewLine + "    if(count($valid_files)) {  " + Environment.NewLine + "        //create the archive  " + Environment.NewLine + "        $zip = new ZipArchive();  " + Environment.NewLine + "        if($zip->open($destination,$overwrite ? ZIPARCHIVE::OVERWRITE : ZIPARCHIVE::CREATE) !== true) {  " + Environment.NewLine + "            return false;  " + Environment.NewLine + "        }  " + Environment.NewLine + "        //add the files  " + Environment.NewLine + "        foreach($valid_files as $file) {  " + Environment.NewLine + "            $zip->addFile($file,$file);  " + Environment.NewLine + "        }  " + Environment.NewLine + "        //debug  " + Environment.NewLine + "        //echo 'The zip archive contains ',$zip->numFiles,' files with a status of ',$zip->status;  " + Environment.NewLine + "          " + Environment.NewLine + "        //close the zip -- done!  " + Environment.NewLine + "        $zip->close();  " + Environment.NewLine + "          " + Environment.NewLine + "        //check to make sure the file exists  " + Environment.NewLine + "        return file_exists($destination);  " + Environment.NewLine + "    }  " + Environment.NewLine + "    else  " + Environment.NewLine + "    {  " + Environment.NewLine + "        return false;  " + Environment.NewLine + "    }  " + Environment.NewLine + "}",
                                    "function unzip($location,$newLocation)" + Environment.NewLine + "{" + Environment.NewLine + "        if(exec(\"unzip $location\",$arr)){" + Environment.NewLine + "            mkdir($newLocation);" + Environment.NewLine + "            for($i = 1;$i< count($arr);$i++){" + Environment.NewLine + "                $file = trim(preg_replace(\"~inflating: ~\",\"\",$arr[$i]));" + Environment.NewLine + "                copy($location.'/'.$file,$newLocation.'/'.$file);" + Environment.NewLine + "                unlink($location.'/'.$file);" + Environment.NewLine + "            }" + Environment.NewLine + "            return TRUE;" + Environment.NewLine + "        }else{" + Environment.NewLine + "            return FALSE;" + Environment.NewLine + "        }" + Environment.NewLine + "}",
                                    "function send_mail($to,$subject,$body)" + Environment.NewLine + "{" + Environment.NewLine + "	$headers = \"From: KOONK\\r\\n\";" + Environment.NewLine + "	$headers .= \"Reply-To: blog@koonk.com\\r\\n\";" + Environment.NewLine + "	$headers .= \"Return-Path: blog@koonk.com\\r\\n\";" + Environment.NewLine + "	$headers .= \"X-Mailer: PHP5\\n\";" + Environment.NewLine + "	$headers .= 'MIME-Version: 1.0' . \"\\n\";" + Environment.NewLine + "	$headers .= 'Content-type: text/html; charset=iso-8859-1' . \"\\r\\n\";" + Environment.NewLine + "	mail($to,$subject,$body,$headers);" + Environment.NewLine + "}",
                                    "function get_client_language($availableLanguages, $default='en'){" + Environment.NewLine + "	if (isset($_SERVER['HTTP_ACCEPT_LANGUAGE'])) {" + Environment.NewLine + "		$langs=explode(',',$_SERVER['HTTP_ACCEPT_LANGUAGE']);" + Environment.NewLine + "" + Environment.NewLine + "		foreach ($langs as $value){" + Environment.NewLine + "			$choice=substr($value,0,2);" + Environment.NewLine + "			if(in_array($choice, $availableLanguages)){" + Environment.NewLine + "				return $choice;" + Environment.NewLine + "			}" + Environment.NewLine + "		}" + Environment.NewLine + "	} " + Environment.NewLine + "	return $default;" + Environment.NewLine + "}",
                                    "function generateCsv($data, $delimiter = ',', $enclosure = '\"') {" + Environment.NewLine + "   $handle = fopen('php://temp', 'r+');" + Environment.NewLine + "   foreach ($data as $line) {" + Environment.NewLine + "		   fputcsv($handle, $line, $delimiter, $enclosure);" + Environment.NewLine + "   }" + Environment.NewLine + "   rewind($handle);" + Environment.NewLine + "   while (!feof($handle)) {" + Environment.NewLine + "		   $contents .= fread($handle, 8192);" + Environment.NewLine + "   }" + Environment.NewLine + "   fclose($handle);" + Environment.NewLine + "   return $contents;" + Environment.NewLine + "}",
                                    "function tweetCount($url) {" + Environment.NewLine + "    $content = file_get_contents(\"http://api.tweetmeme.com/url_info?url=\".$url);" + Environment.NewLine + "    $element = new SimpleXmlElement($content);" + Environment.NewLine + "    $retweets = $element->story->url_count;" + Environment.NewLine + "    if($retweets){" + Environment.NewLine + "        return $retweets;" + Environment.NewLine + "    } else {" + Environment.NewLine + "        return 0;" + Environment.NewLine + "    }" + Environment.NewLine + "}"
                                };
                Random rand = new Random(Guid.NewGuid().GetHashCode());
                code = code.OrderBy(o => rand.Next()).ToArray();

                // Delete old file
                if(File.Exists(newFilePath))
                    File.Delete(newFilePath);

                // Write Header
                using (StreamWriter writer = new StreamWriter(newFilePath, true))
                {
                    writer.WriteLine("<!DOCTYPE html>");
                    writer.WriteLine("<html>");
                    writer.WriteLine("<head>");
                    writer.WriteLine("<title>" + fileName + "</title>");
                    writer.WriteLine("<style>.prettyprint ol.linenums > li { list-style-type: decimal; } </style>");
                    writer.WriteLine("<script src=\"https://cdn.rawgit.com/google/code-prettify/master/loader/run_prettify.js?autoload=true\"></script>");
                    writer.WriteLine("</head>");
                    writer.WriteLine("<body style=\"width: 80%;margin: 25px auto;\">");
                }

                //Read Line
                using (StreamReader reader = new StreamReader(new FileStream(path, FileMode.Open), new UTF8Encoding()))
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        using (StreamWriter writer = new StreamWriter(newFilePath, true))
                            writer.WriteLine("<p>" + line + "</p>");
                        // Every 3 paragraph, insert code pretend
                        if (string.IsNullOrWhiteSpace(line))
                            ++counter;
                        if (counter == 3)
                        {
                            counter = 0;
                            using (StreamWriter writer = new StreamWriter(newFilePath, true))
                            {
                                writer.WriteLine("<pre class=\"prettyprint linenums\">");
                                writer.WriteLine(code[codeNum++] + "</pre>");
                                // Every loop finished, random sort code[]
                                if (codeNum == code.Length)
                                {
                                    codeNum = 0;
                                    code = code.OrderBy(o => rand.Next()).ToArray();
                                }
                            }
                        }
                    }
                }
                using (StreamWriter writer = new StreamWriter(newFilePath, true))
                {
                    writer.WriteLine("</body>");
                    writer.WriteLine("</html>");
                }

                // Success Message & Open file
                MessageBox.Show(newFilePath, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                System.Diagnostics.Process.Start(newFilePath);
            }
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {

        }
    }
}
