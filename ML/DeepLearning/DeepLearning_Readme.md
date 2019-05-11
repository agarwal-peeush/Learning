# Deep Learning
## Fundamentals of Deep Learning
### 1. What is a Neural Network (NN)?
Neural Networks (NN), also called as *Artificial Neural Network* is named after its artificial representation of working of a human being’s nervous system. 

*Flashback Recap: Lets start by understanding how our nervous system works. Nervous System comprises of millions of nerve cells or neurons. A neuron has the following structure:*

![Neuron structure](https://www.analyticsvidhya.com/wp-content/uploads/2016/03/1.-neuron.jpg)

The major components are:

+ Dendrites- It takes input from other neurons in form of an electrical impulse
+ Cell Body– It generate inferences from those inputs and decide what action to take
+ Axon terminals– It transmit outputs in form of electrical impulse

In simple terms, each neuron takes input from numerous other neurons through the dendrites. It then performs the required processing on the input and sends another electrical pulse through the axiom into the terminal nodes from where it is transmitted to numerous other neurons.

ANN works in a very similar fashion. The general structure of a neural network looks like:

![ANN structure](https://www.analyticsvidhya.com/wp-content/uploads/2016/03/2.-ann-structure.jpg)

This figure depicts a typical neural network with working of a single neuron explained separately. Let’s understand this.

The input to each neuron are like the dendrites. Just like in human nervous system, a neuron (artificial though!) collates all the inputs and performs an operation on them. Lastly, it transmits the output to all other neurons (of the next layer) to which it is connected. Neural Network is divided into layer of 3 types:

1. Input Layer: The training observations are fed through these neurons
2. Hidden Layers: These are the intermediate layers between input and output which help the Neural Network learn the complicated relationships involved in data.
3. Output Layer: The final output is extracted from previous two layers. For Example: In case of a classification problem with 5 classes, the output later will have 5 neurons.

### 2. How a Single Neuron works?
In this section, we will explore the working of a single neuron with easy examples. The idea is to give you some intuition on how a neuron compute outputs using the inputs. A typical neuron looks like:

![Single Neuron](https://www.analyticsvidhya.com/wp-content/uploads/2016/03/1.jpg)

The different components are:

+ x<sub>1</sub>, x<sub>2</sub>, …, x<sub>N</sub>: Inputs to the neuron. These can either be the actual observations from input layer or an intermediate value from one of the hidden layers.
+ x<sub>0</sub>: Bias unit. This is a constant value added to the input of the activation function. It works similar to an intercept term and typically has +1 value.
+ w<sub>1</sub>, w<sub>2</sub>, …, w<sub>N</sub>: Weights on each input. Note that even bias unit has a weight.
+ a: Output of the neuron which is calculated as:

![Calculation of Single Neuron at output](https://www.analyticsvidhya.com/wp-content/uploads/2016/03/eq1-neuron.png)

Here f is known an activation function. This makes a Neural Network extremely flexible and imparts the capability to estimate complex non-linear relationships in data. It can be a gaussian function, logistic function, hyperbolic function or even a linear function in simple cases.

Lets implement 3 fundamental functions – **OR**, **AND**, **NOT** using Neural Networks. This will help us understand how they work. You can assume these to be like a classification problem where we’ll predict the output (0 or 1) for different combination of inputs.

We will model these like linear classifiers with the following activation function:

![Function output](https://www.analyticsvidhya.com/wp-content/uploads/2016/03/eq2-activation-fn.png)

