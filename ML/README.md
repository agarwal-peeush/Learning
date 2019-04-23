# ML (Machine Learning)
It includes Python notebooks related to MachineLearning. 

## Data-Visualization-Python
This includes Python notebooks related to Data visualization using Python libraries. 

## Mathematics for ML
We should already know concepts of:

+  Permutation
+  Combination
+  Conditional Probability

### Random variable
These are assigned as outcomes in terms of numbers of a Random process. 

### Discrete Probability Distributions
#### The Bernoulli Distribution
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

Variance(&sigma;) of X:

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
     = 0\*0.016 + 1\*0.48 + 2\*0.36
     = 1.2</code>
</pre>
E(X) is the theoretical mean(<code>&mu;</code>) of X.  

*2. Expectation value of <code>X<sup>2</sup></code>*     
<pre>
<code>E(X<sup>2</sup>) = &sum;x<sup>2</sup>\*p(x), for all values of x
      = 0<sup>2</sup>\*0.16 + 1<sup>2</sup>\*0.48 + 2<sup>2</sup>\*0.36
      = 1.92</code>
</pre>

*3. Variance of X, <code>&sigma;<sup>2</sup></code>*     
<pre>
<code>E[(X - &mu;)<sup>2</sup>] = &sum;(x-&mu;)<sup>2</sup>\*p(x), for all values of x
            = (0 - 1.2)<sup>2</sup>\*0.16 + (1 - 1.2)<sup>2</sup>\*0.48 + (2 - 1.2)<sup>2</sup>\*0.36
            = 0.48</code>
</pre>

We could also use following relationship to calculate *Variance of X*:      
<pre><code>E[(X - &mu;)<sup>2</sup>] = E(X<sup>2</sup>) - [E(X)]<sup>2</sup>
            = 1.92  - 1.2<sup>2</sup>
            = 0.48
</code></pre>

This [Cheatsheet on Probability](https://www.sas.upenn.edu/~astocker/lab/teaching-files/PSYC739-2016/probability_cheatsheet.pdf) provides a comprehensive reference material for probability & statistics. Developed by the University of Pennsylvania. 