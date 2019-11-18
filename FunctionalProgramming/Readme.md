# Functional programming
[Source](https://medium.com/@naveenrtr/introduction-to-functional-programming-with-c-b167f15221e1)

It is a programming paradigm originated from ideas when two mathematicians introduced a theory called lambda calculus. It provided a theoretical framework that treated computation as an evaluation of mathematical functions by evaluating expressions rather than execution of commands and avoiding changing-state and mutating data.

## Fundamental priniciples
The idea is, whenever the same arguments are supplied, the mathematical function returns the same results and the function's signature must convey all information about possible input it accepts and the output it produces. 

1. **Referential Transparency**:
Referential transparency, referred to a function, indicates that you can determine the result of applying that function only by looking at the values of its arguments. It means that the function should operate only on the values that we pass and it shouldn’t refer to the global state.
``` csharp
public int CalculateElapsedDays(DateTime from)
{
    DateTime now = DateTime.Now;
    return (now - from).Days;
}
```
This function is not referentially transparent. Why? Today it returns different output and tomorrow it will return another.  
We can make the function referentially transparent by making the function to operate only on the parameters that we passed in.
``` csharp
public static int CalculateElapsedDays(DateTime from, DateTime now)
    => (now - from).Days;
```
In the above function, we eliminated the dependency on global state thus making the function referentially transparent.

2. **Function honesty**:
Function honesty states that a mathematical function should convey all information about the possible input that it takes and the possible output that it produces. 
``` csharp
public int Divide(int numerator, int denominator)
    => numerator / denominator;
```
The input arguments states that it takes two integers and return an integer as an output. But it throws "DivideByZero" exception in case of:
``` csharp
var result = Divide(1, 0);
```
Hence, the function's signature doesn't convey enough information about the output of the operation. 
To convert this function into a mathematical function, change the type of denominator parameter like below
``` csharp
public static int Divide(int numerator, NonZeroInt denominator)
    => numerator / denominator.Value;
```

## Functions as first-class citizens:
When functions are first-class citizens or first-class values, they can be used as input or output for any other functions. They can be assigned to variables, stored to collections, just like values of other type. 
```csharp
Func<int, bool> isMod2 = x => x % 2 == 0;
var list = Enumberable.Range(1, 10);
var evenNumbers = list.Where(isMod2);
```
The above code illustrates that functions are indeed first-class values because you can assign the function ( x => x % 2 == 0) to a variable isMod2 which in-turn passed as an argument to Where (an extension on IEnumberable).  
Treating functions as values is necessary in functional programming style as it gives the power to define Higher-order functions.

## Higher-order functions (HOF):
HOFs are functions that take one or more functions as arguments or returns a function as a result or both. All other functions are First-order functions.  
Let’s consider the same modulo 2 example in which “list.Where” does filtering to determine which number to be included in the final list based on a predicate provided by the caller. The predicate provided here is isMod2 function and the `Where` extension method of IEnumberable is the Higher-order Function. Implementation of `Where` looks like below
```csharp
public static IEnumerable<T> Where<T>(this IEnumerable<T> ts, Func<T, bool> predicate){
    foreach(T t in ts)
        if(predicate(t))
            yield return t;
}
```

## Pure functions:
Pure functions are mathematical functions that follows the two basic principles that we discussed before — [Referential transparency]() and [Function honesty]().  
In addition to that, Pure functions doesn’t cause any side effects. Which means, it doesn’t mutate neither global state nor input arguments. Pure functions are easy to test and reason about. Since the output is dependent only on input, the order of evaluation isn’t important. These characteristics are very vital for a program to be optimized for parallelization, Lazy evaluation and Memorization (Caching).  
Consider the below example console application that multiplies a list of numbers by 2 and nicely formats that into multiplication table.
```csharp
// Extensions.cs
public static class Extensions
{
    public static int MultiplyBy2(this int value) => value * 2;
}
// MultiplicationFormatter.cs
public static class MultpilicationFormatter
{
    static int counter;
 
    static string Counter(int val) => $"{++counter} x 2 = {val}";
 
    public static List<string> Format(List<int> list)
        => list
         .Select(Extensions.MultiplyBy2)
         .Select(Counter)
         .ToList();
}
// Program.cs
using static System.Console;
static void Main(string[] args)
{
     var list = MultpilicationFormatter.Format(Enumerable.Range(1, 10).ToList());
     foreach (var item in list)
     {
        WriteLine(item);
     }
     ReadLine();
}
// Output
1 x 2 = 2
2 x 2 = 4
3 x 2 = 6
4 x 2 = 8
5 x 2 = 10
6 x 2 = 12
7 x 2 = 14
8 x 2 = 16
9 x 2 = 18
10 x 2 = 20

```

`MultiplyBy2` is a pure function, but `Counter` is an impure function as it mutates the global state.  
If we try to do the above operation for large set of data, we can do multiplications in paraller. That means the sequence of data can be processed independently.
```csharp
public static List<string> Format(List<int> list)
    => list.AsParallel()
         .Select(Extensions.MultiplyBy2)
         .Select(Counter)
         .ToList();
```

As you know that Counter function is an impure function. If you have some experience in multi-threading, this will be familiar to you. The parallel version will have multiple threads reading and updating the counter and there’s no locking in place. The program will end up losing some updates which will lead to incorrect counter results.

**Avoiding state mutation:** One possible way to fix this is to avoid state mutation and running counter. Can we think of a solution to generate a list of counters that we need and map them from the given list of items? Let’s see how:
```csharp
using static System.Linq.ParallelEnumerable;
public static class MultpilicationFormatter
{
   public static List<string> Format(List<int> list)
    => list.AsParallel()
      .Select(Extensions.MultiplyBy2)
      .Zip(Range(1,list.Count), (val, counter) => $"{counter} x 2 = {val}")
      .ToList();
}
```

Using `Zip` and `Range`, we have re-written the MultiplicationFormatter. `Zip` can be used as an extension method, so you can write the `Format` method using a more fluent syntax. After this change, Format method is now pure. Making it parallel is just a cherry on top of the cake. This is almost identical to the sequential version.  
Of course, it is not always as easy as this simple scenario. But the ideas that you have seen till now will deploy you into a better position to tackle such issues related to parallelism and concurrency.
