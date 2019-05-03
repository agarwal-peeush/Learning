# Learning-CSharp
It includes projects, codes for all types of learning using c-sharp. 

[![Build Status](https://dev.azure.com/agarwalpeeush/Learning/_apis/build/status/agarwal-peeush.Learning?branchName=master)](https://dev.azure.com/agarwalpeeush/Learning/_build/latest?definitionId=1&branchName=master)

## Learning.Algorithms
This includes learning for different types of algorithms. 

### Prime numbers

#### Methods
+ IsPrime(N)
    * Brute Force algorithm
    
       This iterates through each number(x) from 2 to number(N) itself and check if N is divisible by x. It breaks if N is divisible by x and returns false, otherwise returns true

            for x = 2 to N:
                if N is divisible by x:
                    return false
            return true

    * Sieve of Eratosthenes algorithm
    
        This iterates through number in range x(x), x(x+1), ... upto number(N) itself and mark them false. At the end return all numbers marked as true to get prime numbers. 

            1. Create a list of consecutive integers from 2 to N: (2,3,4,...,N)
            2. Initially, let p equal to 2, the first prime number.
            3. Starting from p*p, count up in increments of p and mark each of these numbers greater than or equal to p*p itself in the list. These numbers will be p(p+1), p(p+2), ... etc.
            4. Find the first number greater than p in the list that is not marked. if there was no such number, stop. Otherwise, let p now equal to this number (which is the next prime), and repeat from step 3.

+ GetPrimeNumbers(N)
    * Brute Force algorithm
    
        This iterates through each number(x) from 2 to number(N) itself and add to prime list if x is prime. After complete iteration, list will have all prime numbers in N

            list = empty list
            for x = 2 to N:
                if IsPrime(x):
                    add x to list
            return list

    * Sieve of Eratosthenes algorithm
        
        Refer in method [_IsPrime(N)'s_ __SieveOfEratosthenes__ algorithm](#methods) above.

+ GetPrimeNumbers(N1, N2)
    * Brute Force algorithm

        This iterates through each number(x) from N1 to number(N2) itself and add to prime list if x is prime. After complete iteration, list will have all prime numbers between N1 and N2

            list = empty list
            for x = N1 to N2:
                if IsPrime(x):
                    add x to list
            return list

    * Sieve of Eratosthenes algorithm
    
        Refer in method [_IsPrime(N)'s_ __SieveOfEratosthenes__ algorithm](#methods) above.



## Learning.DesignPatterns
This includes learning for different design patterns. 

### Builder pattern

#### Overview
This design pattern separates the construction of a complex object from its representation so that the same construction process can create different representations. 

#### Problems that builder pattern solves

+ Too many parameters in constructor
+ Order dependent, sets the process or steps to be followed to achieve final product
+ Different constructions, enables to pass different types of builder to get final product differently.

#### Roles

![The Builder Pattern roles](Readme.Images/TheBuilderPattern.jpg)

+ Director
    * Uses the **Concreate Builder**
    * Knows how to build
    * Client code calls directly
+ Builder
    * Abstract interface or class
    * Defines steps
    * Holds instance of **Product**
+ Concrete Builder
    * Should be more than one of these
    * Provides an implementation for interface defined by the **Builder**
    * A recipe
+ Product
    * What is being built
    * Not a different type, but different data

### Chain of responsibility Pattern

![Traditional Usage](Readme.Images/ChainOfResponsibility_TraditionalUsage.jpg)

#### Traits
+ Sender is aware of only one receiver
+ Each receiver is only aware of the next receiver
+ Receivers process the message or send it down the chain
+ The sender does not know who received the message
+ The first receiver to handle the message terminates the chain
+ The order of the receiver list matters

#### Use the Chain of Responsibility when...
+ More than one message handler for a message
+ The appropriate handler is not explicitly known by the sender
+ The set of handlers can be dynamically defined

#### Benefits of the Chain of Responsibility
+ Reduced coupling
+ Dynamically manage the message handlers
+ End of chain behavior can be defined appropriately

#### Related patterns
+ Composite
+ Tree of responsibility

### Command Pattern

#### Intent

+ Represent an action as an object
+ Decouple clients that execute the command from the details and dependencies of the command logic
+ Enables delayed execution
  + Can queue commands for later execution
  + If command objects are also persistent, can delay across process restarts

#### Also known as
+ Action, Transaction

#### Applicability
+ Logging
+ Validation
+ Undo

#### Structure
![CommandPattern basic structure](Readme.Images/CommandPattern_BasicStructure.jpg)

**Taking it further**
![CommandPattern advanced structure](Readme.Images/CommandPattern_AdvancedStructure.jpg)

#### Consequences
+ Commands must be completely self contained
  + The client doesn't pass in any arguments
+ Easy to add new commands
  + Just add a new class (open/closed principal)