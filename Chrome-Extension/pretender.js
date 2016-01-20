var codeArray = [
  // C# code
  "public static class PointFunctions\n{\n    public static double DistanceTo(this Point point1, Point point2)\n    {\n        var a = (double)(point2.X - point1.X);\n        var b = (double)(point2.Y - point1.Y);\n\n        return Math.Sqrt(a * a + b * b);\n    }\n}",
  "(Example 1)\nprivate Point getPointBaryCenter(Point p1, Point p2, Point p3)\n{\n	return new Point((p1.X + p2.X + p3.X) / 3, \n					(p1.Y + p2.Y + p3.Y) / 3);\n}\n\n(Example 2)\nprivate Point getInterpPt(Point p1, Point p2, Point p3)\n{\n	return new Point((p1.X >> 1) + ((p2.X + p3.X) >> 2),\n					(p1.Y >> 1) + ((p2.Y + p3.Y) >> 2));\n}",
  "public static T As<T>(this string input)\n{\n    return (T)TypeDescriptor.GetConverter(typeof(T)).ConvertFromString(input);\n}",
  "public void Jiggle()\n{\n     int X = this.Location.X;\n     int Y = this.Location.Y;\n     Random r = new Random();\n     int JiggleCount = 0;\n     int Z = 15;\n\n     while (JiggleCount < 1000)\n     {\n         this.Location = new Point(r.Next(X - Z, X + Z), r.Next(Y - Z, Y + Z));\n         JiggleCount++;\n     }\n\n     JiggleCount = 0;\n     this.Location = new Point(X, Y);\n}",
  "/// <summary>\n/// Calculates a point that is at an angle from the origin (0 is to the right)\n/// </summary>\nprivate PointF DegreesToXY(float degrees, float radius, Point origin)\n{\n    PointF xy = new PointF();\n    double radians = degrees * Math.PI / 180.0;\n\n    xy.X = (float)Math.Cos(radians) * radius + origin.X;\n    xy.Y = (float)Math.Sin(-radians) * radius + origin.Y;\n\n    return xy;\n}\n\n/// <summary>\n/// Calculates the angle a point is to the origin (0 is to the right)\n/// </summary>\nprivate float XYToDegrees(Point xy, Point origin)\n{\n    int deltaX = origin.X - xy.X;\n    int deltaY = origin.Y - xy.Y;\n\n    double radAngle = Math.Atan2(deltaY, deltaX);\n    double degreeAngle = radAngle * 180.0 / Math.PI;\n\n    return (float)(180.0 - degreeAngle);\n}",
  "private Point Project(Point line1, Point line2, Point toProject)\n{\n    double m = (double)(line2.Y - line1.Y) / (line2.X - line1.X);\n    double b = (double)line1.Y - (m * line1.X);\n\n    double x = (m * toProject.Y + toProject.X - m * b) / (m * m + 1);\n    double y = (m * m * toProject.Y + m * toProject.X + b) / (m * m + 1);\n\n    return new Point((int)x, (int)y);\n}",
  "public long Factorial(long x, long lowerBound)\n{\n    long fact = 1;\n    while (x >= 1 && x > lowerBound)\n    {\n        fact *= x;\n        x--;\n    }\n    return fact;\n}\n\npublic long Choose(long n, long r)\n{\n    return (long)((double)Factorial(n, Math.Max(n - r, r)) / (Factorial(Math.Min(n - r, r))));\n}",
  "List initialization:\nList<Book> ListOfBooks = new List<Book>()\n{\n    new Book {name = \"DaVinci Code\"    , owner = \"Alex\" , date = 2002},\n    new Book {name = \"Angels and Demons\", owner = \"Jeff\" , date = 2005},\n    new Book {name = \"The Last Mughal\", owner = \"Danny\", date = 2001},\n};\n\nLINQ query:\nIEnumerable<Book> QueryResult = from Book in ListOfBooks\n                                select Book;",
  "private IList<string> SortStringLength(IList<string> stringList)\n{\n    string[] strs = stringList.ToArray<string>();\n    Array.Sort(strs, new Comparison<string>(delegate(string str1, string str2) \n    {\n        if (str1 == null && str2 == null)\n            return 0; //both empty\n        else if (str1 == null)\n            return -1; //empty string before non-empty string\n        else if (str2 == null)\n            return 1; //non-empty string after empty string\n        else\n        {\n            if (str1.Length < str2.Length)\n                return -1; //shorter string before longer string\n            else if (str1.Length > str2.Length)\n                return 1; //longer string after shorter string\n            else\n                return str1.CompareTo(str2); //alphabetical order\n        }\n    }));\n\n    return strs;\n}\n\n//Example call\nstring[] test = { \"333\", null, \"1\", \"22\", \"12\", \"4444\" };\ntest = (string[])SortStringLength(test);\n\nforeach (string s in test)\n{\n    Console.WriteLine(s);\n}",
  "using System;\nusing System.Security.Cryptography;\n\nprivate static int NextInt(int min, int max)\n{\n    RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();\n    byte[] buffer = new byte[4];\n    \n    rng.GetBytes(buffer);\n    int result = BitConverter.ToInt32(buffer, 0);\n\n    return new Random(result).Next(min, max);\n}",
  "private long time()\n{\n    return time(DateTime.UtcNow);\n}\n\nprivate long time(DateTime time)\n{\n    DateTime unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0);\n    TimeSpan span = time.Subtract(unixEpoch);\n\n    return (long)span.TotalSeconds;\n}\n\nprivate DateTime fromPHPTime(long ticks)\n{\n    DateTime unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0);\n    return unixEpoch.Add(new TimeSpan(0, 0, (int)ticks));\n}",
  "public long Factorial(long x)\n{\n    long fact = 1;\n    long i = 1;\n    while (i <= x)\n    {\n        fact = fact * i;\n        i++;\n    }\n    return fact;\n}\n\npublic long Factorial(long x, long lowerBound)\n{\n    long fact = 1;\n    while (x >= 1 && x > lowerBound)\n    {\n        fact *= x;\n        x--;\n    }\n\n    return fact;\n}",
  "OperatingSystem os = System.Environment.OSVersion;\nConsole.WriteLine(\"Platform: {0}\", os.Platform);\nConsole.WriteLine(\"Service Pack: {0}\", os.ServicePack);\nConsole.WriteLine(\"Version: {0}\", os.Version);\nConsole.WriteLine(\"VersionString: {0}\", os.VersionString);\nConsole.WriteLine(\"CLR Version: {0}\", System.Environment.Version);",
  "private static UInt32 CountPhysicalProcessors()\n{\n     ManagementObjectSearcher objects = new ManagementObjectSearcher(\n        \"SELECT * FROM Win32_ComputerSystem\");\n     ManagementObjectCollection coll = objects.Get();\n     foreach(ManagementObject obj in coll)\n    {\n        return (UInt32)obj[\"NumberOfProcessors\"];\n    } \n    return 0;\n}\nprivate static UInt64 CountPhysicalMemory()\n{\n   ManagementObjectSearcher objects =new ManagementObjectSearcher(\n      \"SELECT * FROM Win32_PhysicalMemory\");\n   ManagementObjectCollection coll = objects.Get();\n   UInt64 total = 0;\n   foreach (ManagementObject obj in coll)\n   {\n       total += (UInt64)obj[\"Capacity\"];\n    }\n    return total;\n}",
  "ServiceController controller = new ServiceController(\"e-M-POWER\");      \ncontroller.Start();      \nif (controller.CanPauseAndContinue)      \n{      \n    controller.Pause();      \n    controller.Continue();      \n}      \ncontroller.Stop();",
  "[DllImport(\"mscoree.dll\", CharSet=CharSet.Unicode)]\nstatic extern bool StrongNameSignatureVerificationEx(string wszFilePath, bool fForceVerification, ref bool pfWasVerified);\n\nbool notForced = false;\nbool verified = StrongNameSignatureVerificationEx(assembly, false, ref notForced);\nConsole.WriteLine(\"Verified: {0}\nForced: {1}\", verified, !notForced);",
  "System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();\ntimer.Start();\nDecimal total = 0;\nint limit = 1000000;\nfor (int i = 0; i < limit; ++i)\n{\n      total = total + (Decimal)Math.Sqrt(i);\n}\ntimer.Stop();\nConsole.WriteLine(\"Sum of sqrts: {0}\",total);\nConsole.WriteLine(\"Elapsed milliseconds: {0}\",\ntimer.ElapsedMilliseconds);\nConsole.WriteLine(\"Elapsed time: {0}\", timer.Elapsed);",
  // PHP code
  "function getRealIpAddr()  \n{  \n    if (!emptyempty($_SERVER['HTTP_CLIENT_IP']))  \n    {  \n        $ip=$_SERVER['HTTP_CLIENT_IP'];  \n    }  \n    elseif (!emptyempty($_SERVER['HTTP_X_FORWARDED_FOR']))  \n    //to check ip is pass from proxy  \n    {  \n        $ip=$_SERVER['HTTP_X_FORWARDED_FOR'];  \n    }  \n    else  \n    {  \n        $ip=$_SERVER['REMOTE_ADDR'];  \n    }  \n    return $ip;  \n}",
  "function force_download($file) \n{ \n    $dir = \"../log/exports/\"; \n    if ((isset($file))&&(file_exists($dir.$file))) { \n       header(\"Content-type: application/force-download\"); \n       header('Content-Disposition: inline; filename=\"' . $dir.$file . '\"'); \n       header(\"Content-Transfer-Encoding: Binary\"); \n       header(\"Content-length: \".filesize($dir.$file)); \n       header('Content-Type: application/octet-stream'); \n       header('Content-Disposition: attachment; filename=\"' . $file . '\"'); \n       readfile(\"$dir$file\"); \n    } else { \n       echo \"No file selected\"; \n    } \n\n}",
  "function create_zip($files = array(),$destination = '',$overwrite = false) {  \n    //if the zip file already exists and overwrite is false, return false  \n    if(file_exists($destination) && !$overwrite) { return false; }  \n    //vars  \n    $valid_files = array();  \n    //if files were passed in...  \n    if(is_array($files)) {  \n        //cycle through each file  \n        foreach($files as $file) {  \n            //make sure the file exists  \n            if(file_exists($file)) {  \n                $valid_files[] = $file;  \n            }  \n        }  \n    }  \n    //if we have good files...  \n    if(count($valid_files)) {  \n        //create the archive  \n        $zip = new ZipArchive();  \n        if($zip->open($destination,$overwrite ? ZIPARCHIVE::OVERWRITE : ZIPARCHIVE::CREATE) !== true) {  \n            return false;  \n        }  \n        //add the files  \n        foreach($valid_files as $file) {  \n            $zip->addFile($file,$file);  \n        }  \n        //debug  \n        //echo 'The zip archive contains ',$zip->numFiles,' files with a status of ',$zip->status;  \n          \n        //close the zip -- done!  \n        $zip->close();  \n          \n        //check to make sure the file exists  \n        return file_exists($destination);  \n    }  \n    else  \n    {  \n        return false;  \n    }  \n}",
  "function unzip($location,$newLocation)\n{\n        if(exec(\"unzip $location\",$arr)){\n            mkdir($newLocation);\n            for($i = 1;$i< count($arr);$i++){\n                $file = trim(preg_replace(\"~inflating: ~\",\"\",$arr[$i]));\n                copy($location.'/'.$file,$newLocation.'/'.$file);\n                unlink($location.'/'.$file);\n            }\n            return TRUE;\n        }else{\n            return FALSE;\n        }\n}",
  "function send_mail($to,$subject,$body)\n{\n	$headers = \"From: KOONK\\r\\n\";\n	$headers .= \"Reply-To: blog@koonk.com\\r\\n\";\n	$headers .= \"Return-Path: blog@koonk.com\\r\\n\";\n	$headers .= \"X-Mailer: PHP5\\n\";\n	$headers .= 'MIME-Version: 1.0' . \"\\n\";\n	$headers .= 'Content-type: text/html; charset=iso-8859-1' . \"\\r\\n\";\n	mail($to,$subject,$body,$headers);\n}",
  "function get_client_language($availableLanguages, $default='en'){\n	if (isset($_SERVER['HTTP_ACCEPT_LANGUAGE'])) {\n		$langs=explode(',',$_SERVER['HTTP_ACCEPT_LANGUAGE']);\n\n		foreach ($langs as $value){\n			$choice=substr($value,0,2);\n			if(in_array($choice, $availableLanguages)){\n				return $choice;\n			}\n		}\n	} \n	return $default;\n}",
  "function generateCsv($data, $delimiter = ',', $enclosure = '\"') {\n   $handle = fopen('php://temp', 'r+');\n   foreach ($data as $line) {\n		   fputcsv($handle, $line, $delimiter, $enclosure);\n   }\n   rewind($handle);\n   while (!feof($handle)) {\n		   $contents .= fread($handle, 8192);\n   }\n   fclose($handle);\n   return $contents;\n}",
  "function tweetCount($url) {\n    $content = file_get_contents(\"http://api.tweetmeme.com/url_info?url=\".$url);\n    $element = new SimpleXmlElement($content);\n    $retweets = $element->story->url_count;\n    if($retweets){\n        return $retweets;\n    } else {\n        return 0;\n    }\n}",
  // jQuery code
  "// Close all panels\n$('#accordion').find('.content').hide();\n\n// Accordion\n$('#accordion').find('.accordion-header').click(function () {\n	var next = $(this).next();\n	next.slideToggle('fast');\n	$('.content').not(next).slideUp('fast');\n	return false;\n});",
  "// Fade\n$('.btn').click(function () {\n	$('.element').fadeToggle('slow');\n});\n\n// Toggle\n$('.btn').click(function () {\n	$('.element').slideToggle('slow');\n});",
  "$('.btn').hover(function () {\n  $(this).addClass('hover');\n}, function () {\n  $(this).removeClass('hover');\n});\n\n// You just need to add the necessary CSS. If you want an even simpler way use the toggleClass method:\n\n$('.btn').hover(function () {\n  $(this).toggleClass('hover');\n});",
  "$('#elem').show();\n$('#elem').html('bla');\n$('#elem').otherStuff();\n\n// This could be vastly improved by using chaining:\n\n$('#elem')\n  .show()\n  .html('bla')\n  .otherStuff();\n// An alternative is to cache the element in a variable (prefixed with $):\n\nvar $elem = $('#elem');\n$elem.hide();\n$elem.html('bla');\n$elem.otherStuff();\n\n// Both chaining and caching methods in jQuery are best practices that lead to shorter and faster code.",
  "// Trigger on visibility change\n$(document).on('visibilitychange', function (e) {\n	if (e.target.visibilityState === 'visible') {\n		console.log('Tab is now in view!');\n	} else if (e.target.visibilityState === 'hidden') {\n		console.log('Tab is now hidden!');\n	}\n});"
];

// Create HTML Header and load script
var head = document.getElementsByTagName('head')[0];
var script = document.createElement('script');
script.type = 'text/javascript';
script.src = 'https://cdn.rawgit.com/google/code-prettify/master/loader/run_prettify.js?autoload=true';
script.onload = function() {
  // Create CSS
  var sheet = window.document.styleSheets[0];
  sheet.insertRule('.prettyprint ol.linenums > li { list-style-type: decimal; }', 0);

  // Loading Options
  chrome.storage.sync.get({
    element: 'p',
    paragraph: 3
  }, function(items) {
    // Defined what element to catch as a paragraph
    var divs = document.getElementsByTagName(items.element);
    console.log('Load element options : ' + items.element);

    // Defined how many paragraphs to insert code
    var paragraph = items.paragraph;
    console.log('Load paragraph options : ' + items.paragraph);

    for (var i = 0; i < divs.length; i++) {
      // Insert codes every N paragraph
      if (i % paragraph === 0) {
        var newNode = document.createElement('pre');
        newNode.className = 'prettyprint linenums';
        newNode.style.cssText = 'width:auto; overflow:auto; max-height:600px; margin:20px auto;';
        content = document.createTextNode(codeArray[Math.floor((Math.random() * codeArray.length))]);
        newNode.appendChild(content);
        divs[i].parentNode.insertBefore(newNode, divs[i].nextSibling);
      }
    }
  });
};
head.appendChild(script);
