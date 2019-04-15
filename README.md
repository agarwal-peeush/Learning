# Learning
It includes projects, codes for all types of learning. 

## Algorithms
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

+ GetPrimeNumbers(N)
    * Brute Force algorithm
    
        This iterates through each number(x) from 2 to number(N) itself and add to prime list if x is prime. After complete iteration, list will have all prime numbers in N

            list = empty list
            for x = 2 to N:
                if IsPrime(x):
                    add x to list
            return list

+ GetPrimeNumbers(N1, N2)
    * Brute Force algorithm

        This iterates through each number(x) from N1 to number(N2) itself and add to prime list if x is prime. After complete iteration, list will have all prime numbers between N1 and N2

            list = empty list
            for x = N1 to N2:
                if IsPrime(x):
                    add x to list
            return list
