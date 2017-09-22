# Find and Replace
str  = "It's thanksgiving day. It's my birthday,too!"
print str.find("day")
str = str.replace("day", "month")
print str

#Min and Max
x = [2,54,-2,7,12,98]
print min(x)
print max(x)

#First and Last
x = ["hello",2,54,-2,7,12,98,"world"]
print x[0], x[len(x)-1]
newlist = [x[0],x[len(x)-1]]

#New List
x = [19,2,54,-2,7,12,98,32,10,-3,6]
x.sort();
first_half = x[0:len(x)/2]
last_list = x[len(x)/2:len(x)]
last_list.insert(0,first_half)
print last_list
