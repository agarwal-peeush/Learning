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

### Statistics
#### Inferential-Hypotheses Testing
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

#### T-Test (Student's test)
**To be added later**

[Cheatsheet for Statistics](http://web.mit.edu/~csvoss/Public/usabo/stats_handout.pdf)

### Exploratory Data Analysis (EDA)
#### Introduction
There are no shortcuts for data exploration. If you are in a state of mind, that ML can sail you away from every data storm, trust me, it won't. After some point of time, you'll realize that you are struggling at improving model's accuracy. In such situation, data exploration techniques will come to your rescue.
#### Steps of Data Exploration and Preparation
Remember the quality of your inputs decide the quality of your output. So, once you have got your business hypothesis ready, it makes sense to spend lot of time and efforts here. In general, data exploration, cleaning and preparation can take up to 70% of your total project time.    
Below are the steps involved to understand, clean and prepare your data for building your predictive model:

+ Variable Identification
+ Univariate Analysis
+ Bi-variate Analysis
+ Missing values treatment
+ Outlier treatment
+ Variable transformation
+ Variable creation

We need to re-iterate over steps 4-7 multiple times before we come up with our refined model. Let's now study each stage in detail:
##### 1. Variable Indentification
First, identify **Predictor**(*Input*) and **Target**(*Output*) variables. Next, identify the data type and category of the variables. 

Example: 
Suppose, we want to predict, whether the students will  play cricket or not(refer below data set). Here you need to identify predictor variables, target variable, data type of variables and category of variables. 

| Student\_ID | Gender | Prev\_Exam\_Marks | Height(cm) | Weight Category(kgs) | Play cricket |
| :---: | :---: | :---: | :---: | :---: | :---: |
| S001 | M | 65 | 178 | 61 | 1 |
| S002 | F | 75 | 174 | 56 | 0 |
| S003 | M | 45 | 163 | 62 | 1 |
| S004 | M | 57 | 175 | 70 | 0 |
| S005 | F | 59 | 162 | 67 | 0 |

Below, the variables have been defined in different category:

![Variable identification](Readme.Images/EDA_Variable_Identification.jpg)

##### 2. Univariate Analysis
At this stage, we explore variables one by one. Method to perform uni-variate analysis will depend on whether the variable type is categorical or continuous. Let's look at these methods and statistical measures for categorical and continuous variables individually:   
**Continuous Variables**:- In case of continuous variables, we need to understand the central tendency and spread of the variable. These are measured using various statistical metrics visualization methods as shown below:
![Continuous variables analysis](Readme.Images/EDA_ContinuousVariable_Analysis.jpg)

*Note: Univariate Analysis is also used to highlight missing and outlier values.*

**Categorical Variables**:- For categorical variables, we'll use frequency table to understand distribution of each category. We can also read as percentage of values under each category. It can be be measured using two metrics, **Count** and **Count%** against each category. **Bar chart** can be used as visualization.

