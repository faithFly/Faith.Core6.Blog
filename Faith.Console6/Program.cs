using Faith.Console6.Factory;
using Faith.EntityModel.Entity;

namespace Faith.Console6
{
    public class Program
    {
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
            #region redis
            
            #endregion
        }
     }
}