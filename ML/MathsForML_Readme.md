# Mathematics for ML
We should already know concepts of:

+  Permutation
+  Combination
+  Conditional Probability

## Random variable
These are assigned as outcomes in terms of numbers of a Random process.

## Discrete Probability Distributions
### The Bernoulli Distribution
These conditions should hold true for applying Bernoulli's Distribution:

+ A single trial
+ The trial can result in one of two possible outcomes, labelled success and failure
+ P(Success) = p
+ P(Failure) = 1 - p

Let `X = 1` if a success occurs, and `X = 0` if a failure occurs.
Then X(Random Variable) has a Bernoulli distribution:

<pre>
<code>P(X = x) = (p<sup>x</sup>)(1-p)<sup>1-x</sup></code>
</pre>

The **expected value** of a random variable is the theoretical mean of the random variable.

To calculate the expected value for a discrete random variable X:

<pre>
<code>E(X) = &sum;x*p(x) , for all x</code>
</pre>

Expectation of a function g(X):

<pre>
<code>E[g(X)] = &sum;g(x)*p(x) , for all x</code>
</pre>

Variance(&sigma;<sup>2</sup>) of X:

<pre>
<code>E[(X - &mu;)<sup>2</sup>] = &sum;(x-&mu;)<sup>2</sup>p(x) , for all x
E[(X - &mu;)<sup>2</sup>] = E(X<sup>2</sup>) - [E(X)]<sup>2</sup>
&sigma;<sup>2</sup> = E(X<sup>2</sup>) - &mu;<sup>2</sup></code>
</pre>

#### Example
Suppose 60% of American adults approve of the way the president is handling his job.  
Randomly sample 2 American adults.   
Let X represent the number that approve.
So X can take values of 0, 1 or 2.

The probability distribution of a discrete random variable X:

| x | 0 | 1 | 2 |
| :---: | :---: | :---: | :---: |
| p(x) | 0.16 | 0.48 | 0.36 |

*1. Expectation value of X or Mean of X*  
<pre>
<code>E(X) = &sum;x*p(x), for all values of x
     = 0*0.016 + 1*0.48 + 2*0.36
     = 1.2</code>
</pre>
E(X) is the theoretical mean(<code>&mu;</code>) of X.  

*2. Expectation value of <code>X<sup>2</sup></code>*     
<pre>
<code>E(X<sup>2</sup>) = &sum;x<sup>2</sup>*p(x), for all values of x
      = 0<sup>2</sup>*0.16 + 1<sup>2</sup>*0.48 + 2<sup>2</sup>*0.36
      = 1.92</code>
</pre>

*3. Variance of X, <code>&sigma;<sup>2</sup></code>*     
<pre>
<code>E[(X - &mu;)<sup>2</sup>] = &sum;(x-&mu;)<sup>2</sup>*p(x), for all values of x
            = (0 - 1.2)<sup>2</sup>*0.16 + (1 - 1.2)<sup>2</sup>*0.48 + (2 - 1.2)<sup>2</sup>*0.36
            = 0.48</code>
</pre>

We could also use following relationship to calculate *Variance of X*:      
<pre><code>E[(X - &mu;)<sup>2</sup>] = E(X<sup>2</sup>) - [E(X)]<sup>2</sup>
            = 1.92  - 1.2<sup>2</sup>
            = 0.48
</code></pre>

This [Cheatsheet on Probability](https://www.sas.upenn.edu/~astocker/lab/teaching-files/PSYC739-2016/probability_cheatsheet.pdf) provides a comprehensive reference material for probability & statistics. Developed by the University of Pennsylvania.

## Statistics
### Inferential-Hypotheses Testing
*What is the Probability?*

+ It is the probability of an outcome given a state of nature.
+ It is not the probability of a state of nature.
+ Possible states of nature are called **Hypotheses** in statistics.

*Null Hypothesis*

<code>&mu;<sub>obese</sub> = &mu;<sub>average</sub></code>

*Alternate Hypothesis*

+ Null hypothesis:
    * <code>&mu;<sub>obese</sub> = &mu;<sub>average</sub></code>
+ Alternatives:
    * <code>&mu;<sub>obese</sub> < &mu;<sub>average</sub></code>
    * <code>&mu;<sub>obese</sub> \> &mu;<sub>average</sub></code>

Researchers Hope to Reject the Null Hypothesis

+ The null hypothesis is the opposite of the researcher's hypothesis
+ Researcher hopes to reject the null hypothesis to support his or her hypothesis

### T-Test (Student's test)
**To be added later**

[Cheatsheet for Statistics](http://web.mit.edu/~csvoss/Public/usabo/stats_handout.pdf)

## Linear Algebra
### Matrix
**Matrix** is a way of writing similar things together to handle and manipulate them as per our requirements easily. In Data Science, it is generally used to store information like weights in an Artificial Neural Network while training various algorithms.

Technically, a matrix is a 2-D array of numbers (as far as Data Science is concerned). For example look at the matrix A below:

#### Terms related to matrix
+ **Order of matrix**: If a matrix has 3 rows and 4 columns, order of the matrix is 3*4 i.e. row*column.
+ **Square matrix**: The matrix in which the number of rows is equal to the number of columns.
+ **Diagonal matrix**: A matrix with all the non-diagonal elements equal to 0 is called a diagonal matrix.
+ **Upper triangular matrix**: Square matrix with all the elements below diagonal equal to 0.
+ **Lower triangular matrix**: Square matrix with all the elements above the diagonal equal to 0.
+ **Scalar matrix**: Square matrix with all the diagonal elements equal to some constant k.
+ **Identity matrix**: Square matrix with all the diagonal elements equal to 1 and all the non-diagonal elements equal to 0.
+ **Column matrix**:  The matrix which consists of only 1 column. Sometimes, it is used to represent a vector.
+ **Row matrix**:  A matrix consisting only of row.
+ **Trace**: It is the sum of all the diagonal elements of a square matrix.

#### Basic operations in matrix
+ Addition    
  Suppose we have 2 matrices ‘A’ and ‘B’ and the resultant matrix after the addition is ‘C’. Then:
  <code>C<sub>ij</sub> = A<sub>ij</sub> + B<sub>ij</sub></code>
+ Scalar multiplication   
  Multiplication of a matrix with a scalar constant is called *scalar multiplication*. Multiply each element of the matrix with the given constant. Suppose we have a constant scalar ‘c’ and a matrix ‘A’. Then multiplying ‘c’ with ‘A’ gives:
  <code>c[A<sub>ij</sub>] =  [c*A<sub>ij</sub>]</code>
+ Transposition   
  Transposition simply means interchanging the row and column index. For example:
  <code>A<sub>ij</sub><sup>T</sup>= A<sub>ji</sub></code>
  Transpose is used in vectorized implementation of linear and logistic regression.

``` python
import numpy as np 
import pandas as pd
# Create a 3*3 matrix 
A= np.arange(21,30).reshape(3,3)
#print the matrix A
array([[21, 22, 23], [24, 25, 26], [27, 28, 29]])
# Take the transpose
A.transpose()
array([[21, 24, 27], [22, 25, 28], [23, 26, 29]])
```

+ Matrix multiplication     
  Matrix multiplication is one of the most frequently used operations in linear algebra. We will learn to multiply two matrices as well as go through its important properties.

  Before landing to algorithms, there are a few points to be kept in mind:
  * The multiplication of two matrices of orders i*j and j*k results into a matrix of order i*k.  Just keep the outer indices in order to get the indices of the final matrix.
  * Two matrices will be compatible for multiplication only if the number of columns of the first matrix and the number of rows of the second one are same.
  * The third point is that order of multiplication matters.

``` python
import numpy as np
A=np.arange(21,30).reshape(3,3) 
B=np.arange(31,40).reshape(3,3)
A.dot(B)
AB= array([[2250, 2316, 2382], [2556, 2631, 2706], [2862, 2946, 3030]]) 
B.dot(A)
BA= array([[2310, 2406, 2502], [2526, 2631, 2736], [2742, 2856, 2970]])
```

  Properties of matrix multiplication:
  * Matrix multiplication is associative provided the given matrices are compatible for multiplication i.e.
    ABC = (AB)C = A(BC)
``` python
import numpy as np 
A=np.arange(21,30).reshape(3,3) 
B=np.arange(31,40).reshape(3,3) 
C=np.arange(41,50).reshape(3,3)
temp1=(A.dot(B)).dot(C)
array([[306108, 313056, 320004], [347742, 355635, 363528], [389376, 398214, 407052]])
temp2=A.dot((B.dot(C)))
array([[306108, 313056, 320004], [347742, 355635, 363528], [389376, 398214, 407052]])
```
  
  * Matrix multiplication is not commutative i.e. AB and  BA are not equal. 
  
  Matrix multiplication is used in linear and logistic regression when we calculate the value of output variable by parameterized vector method.

[Linear Algebra course on Khan Academy](https://www.khanacademy.org/math/linear-algebra)
