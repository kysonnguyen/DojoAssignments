#Odd/Even
def odd_even():
    for x in range(1, 2001):
        if x%2 != 0:
            print "Number is",x,". This is an odd number."
        else:
            print "Number is",x,". This is an even number."
odd_even()

#Multiply
def multiply(array, num):
    for x in range(0, len(array)):
        array[x] *= num
    return array
a = [2,4,10,16]
print multiply(a, 5)

#Hacker Challenge
def layered_multiples(array):
    new_array = []
    for x in array:
        val = []
        for j in range(0,x):
            val.append(1)
        new_array.append(val)
    return new_array

x = layered_multiples(multiply([2,4,5],3))
print x
