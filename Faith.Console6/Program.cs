using Faith.Console6.Factory;
using Faith.EntityModel.Entity;
using Microsoft.Extensions.Configuration;
using NPOI.SS.UserModel;
using NPOI.Util;
using NPOI.XSSF.UserModel;
using System.Drawing;
using System.Text;
using System.Threading;

namespace Faith.Console6
{
    public class Program
    {
        private static string test01 = @"C:\Users\faith\Desktop\test01.xlsx";
        private static int test01row = 24;
        private static int test01col = 3;
        private static string test02 = @"C:\Users\faith\Desktop\test02.xlsx";
        private static int test02row = 24;
        private static int test02col = 3;
        private static string test = @"C:\Users\faith\Desktop\test03.xlsx";
        private static string test04 = @"C:\Users\faith\Desktop\test03.xlsx";
        delegate void D1();
        delegate int D2(int a,int b);
        public static void Main(string[] args)
        {
            #region MyRegion
            //获取当前时间戳
            //var date = DateTime.Now;
            //当前时间变换为时间戳
            //var timespan = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
            //数据库list
            /*            List<T_Users> list1 = new List<T_Users>();
                        //排除list
                        List<T_Users> list2 = new List<T_Users>();
                        var list3 = list2.Where(p=>!list1.Contains(p)).ToList();*/
            //except 如果两个集合中的元素的值相同，则会被排除。  //1,2
            // var list3 = list.Except(list1).ToList();
            //intersecy 获取两个集合的元素的值相同             //3，4
            //var list3 = list.Intersect(list1);
            //union   获取两个集合的合并集合去重的             //1，2，3，4，5，6
            //var list3 = list.Union(list1);
            //concat  获取两个集合的合并不会去重               //1，2，3，4，3，4，5，6
            //var list3 = list.Concat(list1);
            /*List<int> list = new List<int>() { 5, 6, 3, 4 };
            List<int> list1 = new List<int>() {  3, 4, 5, 6 };
            var list3 =list.Except(list1).ToList();
            foreach (var item in list3)
            {
                Console.WriteLine(item);
            }*/
            #endregion
            #region Attribute 特性
            /*            //Attribute 特性
            AnimalTypeTestClass testClass = new AnimalTypeTestClass();
            Type type = typeof(AnimalTypeTestClass);
            //遍历类的所有方法
            foreach (var item in type.GetMethods())
            {
                //遍历每个方法的属性
                foreach (var attr in Attribute.GetCustomAttributes(item))
                {
                    if (attr.GetType() == typeof(AnimalTypeAttribute))
                    {
                        Console.WriteLine($"method {item.Name} has a pet {((AnimalTypeAttribute)attr).Pet} attribute");
                    }
                }
            }*/
            #endregion
            #region sample factory
            /*            Operation operation = SampleFactory.CreateOperation("+");
                        operation.numberA = 1;
                        operation.numberB = 1;
                        Console.WriteLine(operation.GetResult());
                        Operation operation1 = SampleFactory.CreateOperation("-");
                        operation1.numberA = 1;
                        operation1.numberB = 1;
                        Console.WriteLine(operation1.GetResult());*/
            #endregion
            #region npoi获取图片
            /* List<string> listpath = new List<string> { };
             string savePath = Path.Combine("D:\\", "pic");
             if (!Directory.Exists(savePath))//判断是否存在保存文件夹，没有则新建
                 Directory.CreateDirectory(savePath);
             bool result = ExcelToImage(exclePath, savePath, ref listpath);
             if (result)
                 Console.WriteLine("导出成功");
             else
                 Console.WriteLine("导出成功");*/
            #endregion
            #region 合并单元格
            /*var fullWork = new XSSFWorkbook();
            List<string> workList = new List<string>();
            workList.Add(test01);
            workList.Add(test02);
            foreach (var item in workList)
            {
                using (FileStream fsReader = File.OpenRead(item))
                {
                    fsReader.Position = 0;
                    XSSFWorkbook wk = new XSSFWorkbook(fsReader);
                    XSSFSheet sheet = wk.GetSheetAt(0) as XSSFSheet;
                    sheet.CopyTo(fullWork, fsReader.Name, true, true);
                }
            }
            var stream = new MemoryStream();
            fullWork.Write(stream);
            byte[] bytes = stream.ToArray();
            string savePath = Path.Combine("D:\\", "pic");
            if (!Directory.Exists(savePath))//判断是否存在保存文件夹，没有则新建
                Directory.CreateDirectory(savePath);
            using (FileStream fs = new FileStream(savePath, FileMode.Create, FileAccess.Write))
            {
                fs.Write(bytes, 0, bytes.Length);
                fs.Close();
            }
            Console.WriteLine(true);*/
            #endregion
            #region MyRegion
            /*try
            {
                HttpClient httpClient = new HttpClient();
                var flag = true;
                
                List<Task> tList = new List<Task>();
                for (int i = 0; i < 50; i++)
                {
                    var t = Task.Run(() =>
                    {
                        string url = "https://cwmjc.suichang.gov.cn:8082/ossShow/inside/1614802471874596864.png";
                        httpClient.GetByteArrayAsync(url);
                    });
                    tList.Add(t);
                }
                Task.WaitAll(tList.ToArray());
                Console.WriteLine(flag);
            }
            catch (Exception ex)
            {
                throw;
            }*/
            #endregion
            #region 冒泡排序
            /*var arr = new int[] { 1, 12, 6, 2, 4 };
            int index = 0;
            for (int i = 0; i < arr.Length -1; i++)
            {
                for (int j = 0; j < arr.Length - 1 - i; j++)
                {
                    var a = arr[j];
                    var b = arr[j + 1];
                    if (arr[j] > arr[j + 1])
                    {
                        index = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = index;
                    }
                }
            }
            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }*/
            #endregion
            #region C# file IO
            //获取当前路径
            //DirectoryInfo currDir = new DirectoryInfo(".");
            //获取到你想要的目录
            /*DirectoryInfo dereksDir = new DirectoryInfo(@"C:\Users\faith\Desktop");
            Console.WriteLine(dereksDir.FullName);//文件路径全称
            Console.WriteLine(dereksDir.Name);//文件夹名称
            Console.WriteLine(dereksDir.Parent);//父类文件夹
            Console.WriteLine(dereksDir.Attributes);//类型
            Console.WriteLine(dereksDir.CreationTime);//文件夹创建时间
            Console.WriteLine(true);*/
            #endregion
            #region 将两个excel合并成1个excel
            /*List<Data> datas = new List<Data>();
            Data d1 = new Data()
            {
                name = test01,
                row = 1,
                col = 3
            };
            Data d2 = new Data()
            {
                name = test02,
                row = 1,
                col = 3
            };
            datas.Add(d1);
            datas.Add(d2);

            Stream ModelStream = GetDirToStream(test);
            //文件流转XSS
            IWorkbook ModelWk = new XSSFWorkbook(ModelStream);
            ISheet ModelSheet = ModelWk.GetSheetAt(0);
            #region 单元格样式
            ICellStyle cellStyle = ModelWk.CreateCellStyle();
            cellStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
            cellStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
            cellStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
            cellStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
            cellStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
            cellStyle.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.Center;
            #endregion
            ICell cell;
            StringBuilder sb = new StringBuilder();
            foreach (var item in datas)
            {
                Stream stream = GetDirToStream(item.name);
                IWorkbook wk = new XSSFWorkbook(stream);
                ISheet sheet = wk.GetSheetAt(0);
                IRow rows = null;
                for (int i = item.row; i <= sheet.LastRowNum; i++)
                {
                    rows = sheet.GetRow(i);
                    IRow modelRow = ModelSheet.CreateRow(ModelSheet.LastRowNum + 1);
                    for (int j = 0; j < rows.LastCellNum; j++)
                    {
                        sb.Append(rows.GetCell(j).ToString());
                        //插入到模板中
                        cell = modelRow.CreateCell(j);
                        cell.SetCellValue(sb.ToString());
                        sb.Clear();
                    }
                    
                }
            }
            ByteArrayOutputStream bos = new ByteArrayOutputStream();
            ModelWk.Write(bos,true);
            bos.Close();
            var dateArr = bos.ToByteArray();
            string localUrl = @"D:\tete\test03.xlsx";
            //写入
            using (FileStream fs = new FileStream(localUrl,FileMode.OpenOrCreate,FileAccess.Write))
            {
                fs.Write(dateArr,0,dateArr.Length);
                Console.WriteLine(true);
            }*/
            #endregion
            #region test
            /*            string str = "abc123中文汉字";
                        int i = Encoding.Default.GetBytes(str).Length;
                        int j = str.Length;
                        Console.WriteLine(i);//18
                        Console.WriteLine(j);//10*/
            //一列数的规则如下: 1、1、2、3、5、8、13、21、34...... 求第30 位数是多少
            /*int num = FOO(5);
            Console.WriteLine(num);*/
            #endregion
            #region 委托
            //int i = 0;
            //Console.WriteLine(i);
            //如上int i = 0;
            //真正意义上i是指向的一个内存地址 内存里放了个类型为int 的数据 0
            //那么委托可以理解为就是个函数指针，他指向的是方法
            //D1 d1 = FunA;
            //如上这个委托就指向了FunA这个方法 当你调用d1委托的时候等同于是指针指向了FunA的这个方法
            //D2 d2 = FunB;
            //d1();
            //Console.WriteLine(d2(1, 2)); 
            /*Action a = FunA;
            Action<string, string> b = FunC;
            Action aa = delegate
            {
                Console.WriteLine("nihao");
            };
            aa();
            Action<string, string> bb = delegate (string a, string b)
            {
                Console.WriteLine(a + b);
            };
            bb("hello", "world");
            Func<int, int, int> F1 = FunB;
            Console.WriteLine(F1(1,2));
            //匿名委托
            Func<int, int, string> F2 = delegate (int a, int b)
            {
                return (a + b).ToString();
            };
            //匿名lambda
            Func<int, int, string> F3 = (int i, int j) =>
            {
                return (i + j).ToString();
            };
            F3(3, 3);
            //匿名省略参数
            Func<int, int, int> F4 = (i, j) =>
            {
                return i + j;
            };
            F4(2, 2);
            Action<int,int> a1 =(i,j)=>{
                Console.WriteLine(i+j);
            };
            //没有返回值 只有一行可以省略大括号
            Action a2 = () => Console.WriteLine("heihi");
            Action a3 = () =>
            {
                Console.WriteLine(1);
                Console.WriteLine(2);
            };
            //如果只有一个参数 并且只有一行代码 那么参数的括号也可以省略掉
            Func<int, bool> f5 = i => i > 0;
            Console.WriteLine(F2(2,2));*/
            //手写where
            //int[] nums = { 1, 2, 3, 4, 5, 11, 11, 15 };
            /*var list = WhereFaith(nums, x => x > 10);
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }*/
            //single 满足条件且只有一条数据
            //Console.WriteLine(nums.Single(x => x == 12));
            // 如果没有返回默认值
            // Console.WriteLine(nums.SingleOrDefault(x=>x == 12));
            //first 满足条件取第一条
            //Console.WriteLine(nums.First(x => x == 12));
            //FirstOrDefault 满足条件取第一条 没有查到 返回默认值
            //Console.WriteLine(nums.FirstOrDefault(x => x == 12));
            //分页用到的两个linq方法 Skip Take
            //Skip=>可以说是跳过多少条数据 Take 可以说是取多少条数据
            /*int[] nums = { 1, 2, 3, 4, 5, 11, 11, 15 };
            int pageSize = 5;
            int pageIndex = 1;
            //第一页那么就是 不跳过取 5行 应该是Skip(0) take(5)
            //第二页那么就是 跳过5行 继续取5条
            var pageList = nums.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            foreach (var item in pageList)
            {
                Console.WriteLine(item);
            }*/
            /*int[] nums = { 2, 7, 11, 15 };
            int target = 9;
            var arr = TwoSum(nums, target);*/
            #endregion
            #region await
            //await 会开子线程执行 执行之后 继续用子线程跑 这样释放了主线程服务其他请求
            /*Console.WriteLine("主:" + Thread.CurrentThread.ManagedThreadId.ToString());
var str = await GetStrings();
Console.WriteLine("await:" + Thread.CurrentThread.ManagedThreadId.ToString());
for (int i = 0; i < str.Length; i++)
{
    Console.WriteLine(str[i]);
}*/
            #endregion
            #region 配置文件
            /*            var config = new ConfigurationBuilder()
                            .AddInMemoryCollection()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("faith.json", optional: true, reloadOnChange: true)
                            .Build();*/


            #endregion
            #region join groupjoin
            /*            List<int> numArr = new List<int>();
                        var a = numArr.Sum();*/
            // Console.WriteLine(a);
            /* List<Person> people = new List<Person>()
             {
                 new Person(){ Id = 1,Name = "faith",Age = 25},
                 new Person(){ Id = 2,Name = "evil",Age = 25},
                 new Person(){ Id = 3,Name = "won",Age = 23},
                 new Person(){ Id = 4,Name = "acid",Age = 24},
             };

             List<Animal> animals = new List<Animal>() {
             new Animal(){ Id = 9,Name = "A",Age = 23},
             new Animal(){ Id = 8,Name = "B",Age = 24},
             new Animal(){ Id = 7,Name = "C",Age = 24}
             };

             var res = people.GroupJoin(animals, p => p.Age, a => a.Age, (p, o) => new { p, o }).ToList();

             *//*List<int> idList = new List<int>() { 1, 3 };
             var res = people.Join(idList, p => p.Id, n => n, (p, n) => new { p, n }).Select(o => o.p);*//*
             foreach (var item in res)
             {
                 Console.WriteLine($"{item.p.Name}的年龄:{item.p.Age},Id:{item.p.Id}-----");
                 foreach (var c in item.o.ToList())
                 {
                     Console.WriteLine($"{c.Id},{c.Name},{c.Age}");
                 }
             }*/
            #endregion
            //nums = [2,7,11,15], target = 9
            //[0,1]
            int[] num = { 2, 7, 11, 15 };
            var target =  TwoSum(num, 9);
            Console.ReadLine();
        }
        public static int[] TwoSum(int[] nums, int target)
        {

            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j < nums.Length -1 - i; j++)
                {
                    if (nums[j] + nums[j+1] == target)
                    {
                        Console.WriteLine($"下标为{j},{j+1}");
                    }
                }
            }
            int[] num = { 1,2};
            return num;
        }

        #region MyRegion

        public static IEnumerable<int> WhereFaith(IEnumerable<int> list, Func<int, bool> func)
        {
            List<int> res = new List<int>();
            foreach (var item in list)
            {
                if (func(item))
                {
                    res.Add(item);
                }
            }
            return res;
        }

        public static void FunA()
        {
            Console.WriteLine("Hello Delegate!");
        }
        static void FunC(string a, string b)
        {
            Console.WriteLine(a + b);
        }
        public static int FunB(int a, int b)
        {
            return a + b;
        }
        public static int FOO(int num)
        {
            if (num == 0)
            {
                return 0;
            }
            else if (num == 1 || num == 2)
            {
                return 1;
            }
            else
            {
                return FOO(num - 1) + FOO(num - 2);
            }

        }
        private static Stream GetDirToStream(string url)
        {
            Stream stream = null;
            //获取模板
            using (FileStream fs = File.OpenRead(url))
            {
                byte[] modelArr = new byte[fs.Length];
                fs.Read(modelArr, 0, modelArr.Length);
                stream = new MemoryStream(modelArr);
            }
            return stream;
        }
        /// <summary>
        /// 从excel获取图片
        /// </summary>
        /// <param name="filepath">文件路径</param>
        /// <param name="savepath">图片保存路径</param>
        /// <param name="listPath">返回保存的图表地址list</param>
        /// <returns>保存图片是否成功</returns>
        private static bool ExcelToImage(string filepath, string savepath, ref List<string> listPath)
        {
            try
            {
                using (FileStream fsReader = File.OpenRead(filepath))
                {
                    fsReader.Position = 0;
                    XSSFWorkbook wk = new XSSFWorkbook(fsReader);
                    var pictures = wk.GetAllPictures();
                    int i = 0;
                    foreach (XSSFPictureData pic in pictures)
                    {
                        //if (pic.Data.Length == 19504) //跳过不需要保存的图片，其中pic.data有图片长度
                        //    continue;
                        string ext = pic.SuggestFileExtension();//获取扩展名
                        string path = string.Empty;
                        if (ext.Equals("jpeg"))
                        {
                            Image jpg = Image.FromStream(new MemoryStream(pic.Data));//从pic.Data数据流创建图片
                            path = Path.Combine(savepath, string.Format("pic{0}.jpeg", i++));
                            jpg.Save(path);//保存
                        }
                        if (ext.Equals("jpg"))
                        {
                            Image jpg = Image.FromStream(new MemoryStream(pic.Data));//从pic.Data数据流创建图片
                            path = Path.Combine(savepath, string.Format("pic{0}.jpg", i++));
                            jpg.Save(path);//保存
                        }
                        else if (ext.Equals("png"))
                        {
                            Image png = Image.FromStream(new MemoryStream(pic.Data));
                            path = Path.Combine(savepath, string.Format("pic{0}.png", i++));
                            png.Save(path);
                        }
                        if (!string.IsNullOrEmpty(path))
                            listPath.Add(path);
                    }
                }
            }
            catch (Exception ex)
            {
                return false;

            }
            return true;
        }
        #endregion

    }
    public class Proxy {
        public string Address { get; set; }
        public int Port { get; set; }
    }
}