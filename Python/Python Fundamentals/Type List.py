x = []
type_str = 0
type_num = 0
sum = 0
newStr = ""
for i in range(0, len(x)):
    if isinstance(x[i], str):
        type_str += 1
        newStr += x[i] + " "
    elif isinstance(x[i], int):
        type_num += 1
        sum += x[i]
if type_str >= 1 and type_num == 0:
    print "The array you entered is of string type"
elif type_str == 0 and type_num >= 1:
    print "The array you entered is of integer type"
elif type_str >= 1 and type_num >= 1:
    print "The array you entered is of mixed type"
print "String:",newStr
print "Sum:", sum
