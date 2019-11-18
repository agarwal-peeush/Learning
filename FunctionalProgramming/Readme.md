# Functional programming
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