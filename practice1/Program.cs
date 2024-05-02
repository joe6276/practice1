////Limit 256//8-Bit ==1 Byte

//Byte by = 100;// only positive ---Unsigned 0 -255
//SByte by2 = 127;// positive and negative -128-127

//char ch = 'a'; // ''- character
////"hjk"//string

//Console.WriteLine(Byte.MaxValue);
////short ,int , long both negative and positive 
//// ushort uint , ulong-- positive \


//Console.WriteLine($"The minimum is {short.MinValue}the maximum is {short.MaxValue}"  );
//Console.WriteLine($"The minimum is {ushort.MinValue} the maximum is {ushort.MaxValue}");

//Console.WriteLine($"The minimum is {Int32.MinValue}the maximum is {int.MaxValue}");
//Console.WriteLine($"The minimum is {uint.MinValue} the maximum is {uint.MaxValue}");

//Console.WriteLine($"The minimum is {long.MinValue}the maximum is {long.MaxValue}");
//Console.WriteLine($"The minimum is {ulong.MinValue} the maximum is {ulong.MaxValue}");

//var y = 123345;
//var x= 1.2345m;

//// Disadvantage with performance 
//object a = 23;
//a = "dbn";
//a = true;

using practice1.Model;
using System.Collections;
using System.Diagnostics;
using System.Text;

//int a = 12;// new memory --assign 12
//int b = a;



//string c = "Hello";/// new memory -- assign Hello 
//immutable
//new memory -- assign world
//previous is available for garbage collection-- clean up 
//c = "World"; // new memory


// memory address  // immutable


//Stopwatch sw = Stopwatch.StartNew();
//sw.Start();
//StringBuilder stringBuilder = new StringBuilder();

//for (var i=0; i<100000000; i++)
//{
//    stringBuilder.Append(i.ToString());
//}

//sw.Stop();
////Console.WriteLine($"The time used was {sw.ElapsedMilliseconds}");


//double v = 1200.67;// 1200-255 =945 - 255 690- 255
//int r = (int) v;
//Console.WriteLine(r);


//string d = "123";
//var isconvertable = bool.TryParse(d, out bool result);

//if (isconvertable)
//{
//    Console.WriteLine(a);
//}
//else
//{
//    Console.WriteLine("Not possible ");
//}
//Console.WriteLine(a);

////Non -generic type
//ArrayList arrayList = new ArrayList();

//arrayList.Add('b');
//arrayList.Add(12);
//arrayList.Add(true);

//////Console.WriteLine(arrayList[2]);

//List<string> cars = new List<string>()
//{
//    "POlo GTI",
//    "Jeep",
//    "Nissan"
//};

//List<string> list = new List<string>();
//list.Add("Audi");
//list.Add("BMW");
//list.Add("Mercedes");

////list.AddRange(cars);
////list.Insert(1, "Sienta");
//list.InsertRange(1, cars);

//list.Remove("Jeep");
//list.RemoveAt(0);
//list.RemoveAll(list => list == "Mercedes");
//list.RemoveRange(1, 2);
//foreach (string car in list)
//{
//    Console.WriteLine(car);
//}


//contains
//Console.WriteLine(list.Contains("Jeep"));
//Console.WriteLine(list.Contains("wingroad"));
var newCar = new Car() { Id = 5, Owner = "Kevin", Name = "GLE" };
List<Car> cars= [
    new() { Id = 1, Owner = "Daniel", Name = "Audi" },
    new() { Id = 2, Owner = "Justus", Name = "Jeep" },
    new() { Id = 3, Owner = "Jonathan", Name = "Mercedes" },
    new() { Id = 4, Owner = "Juma", Name = "VW" }
    ]

  
;
SortByCarName sortByCarName = new SortByCarName();
cars.Sort(sortByCarName);
foreach (var car in cars)
{
    Console.WriteLine(car.Owner);
}

//cars.Add(newCar);

//Car found = cars.FindLast(x => x.Owner.StartsWith("J"));

//var x = cars.FindIndex(x => x.Owner == "Juma");
//Console.WriteLine(cars.Exists(c=>c.Owner=="Kevin"));


//List<Car> founduusers = cars.FindAll(x => x.Owner.StartsWith("J"));

//foreach (var car in founduusers)
//{
//    Console.WriteLine(car.Owner);
//}



