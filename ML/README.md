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

#### Example
The probability distribution of a discrete random variable X:

| x | 0 | 1 | 2 |
| :---: | :---: | :---: | :---: |
| p(x) | 0.16 | 0.48 | 0.36 |

The **expected value** of a random variable is the theoretical mean of the random variable. 

To calculate the expected value for a discrete random variable X:

<pre><code>
    E(X) = &sum;x*p(x) , for all x
</code></pre>

Expectation of a function g(X):

<pre><code>
    E[g(X)] = &sum;g(x)*p(x) , for all x
</code></pre>

Variance(&sigma;) of X:

<pre><code>
    E[(X - &mu;)<sup>2</sup>] = &sum;(x-&mu;)<sup>2</sup>p(x) , for all x
    E[(X - &mu;)<sup>2</sup>] = E(X<sup>2</sup>) - [E(X)]<sup>2</sup>
    &sigma;<sup>2</sup> = E(X<sup>2</sup>) - &mu;<sup>2</sup>
</code></pre>

